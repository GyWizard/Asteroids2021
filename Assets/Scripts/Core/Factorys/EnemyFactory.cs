using Asteroids.Services;
using Asteroids.Systems;
using Asteroids.Configs;
using Asteroids.Abstraction;
using Asteroids.Game.Movements;
using Asteroids.Game;
using UnityEngine;
using Asteroids.Utils;
using System.Collections;
using System.Collections.Generic;
using System;


namespace Asteroids.Factorys
{
    public sealed class EnemyFactory
    {
        private UpdateService _updateService;
        private RelocateSystem _relocateSystem;

        private AsteroidConfig _asteroidConfig;
        private AsteroidConfig _asteroidSmallConfig;
        private UfoConfig _ufoConfig;
        private ScoreSystem _scoreSystem;

        private readonly float _noDragSpeed = 0f;
        private readonly float _asteroidCrushAngle = 30f;

        private GameObject _root;

        private Transform _playerTransform;

        private Randomizer _screenRandomizer;

        private List<EnemyController> _listOfEnemyControllers;
        public int EnemyCount => _listOfEnemyControllers.Count;

        public EnemyFactory(UpdateService updateService, RelocateSystem relocateSystem, ScoreSystem scoreSystem, Transform playerTransform, Vector2 screenSize)
        {
            _root = new GameObject();
            _root.name = "Enemys";

            _updateService = updateService;
            _relocateSystem = relocateSystem;
            _playerTransform = playerTransform;

            _scoreSystem = scoreSystem;

            _screenRandomizer = new Randomizer(screenSize);

            _listOfEnemyControllers = new List<EnemyController>();

            _asteroidConfig = Resources.Load<AsteroidConfig>("Configs/AsteroidConfig");
            _asteroidSmallConfig = Resources.Load<AsteroidConfig>("Configs/AsteroidSmallConfig");
            _ufoConfig = Resources.Load<UfoConfig>("Configs/UFOConfig");
        }
        public void ClearAllEnemys()
        {
            while (_listOfEnemyControllers.Count > 0)
            {
                _listOfEnemyControllers[0].DestroyObject();
            }
            GameObject.Destroy(_root);
        }
        private void SubscribeController(EnemyController enemyController)
        {
            _updateService.AddUpdater(enemyController);
            _relocateSystem.AddRelocator(enemyController);

            enemyController.OnDestroyed += _updateService.RemoveUpdater;
            enemyController.OnDestroyed += _relocateSystem.RemoveRelocator;
            enemyController.OnDestroyed += enemyController => _listOfEnemyControllers.Remove(enemyController);
        }

        public EnemyController CreateAsteroid(Action<EnemyController> OnDied)
        {
            EnemyView asteroidView = UnityEngine.Object.Instantiate(_asteroidConfig.asteroidPrefab, _screenRandomizer.CreateRandomPosition(), Quaternion.identity, _root.transform);
            Vector3 direction = _screenRandomizer.CreateRandomDirection();
            StraightMovement movement = new StraightMovement(asteroidView.transform, _asteroidConfig.speed, _asteroidConfig.speed, _noDragSpeed, direction);

            EnemyController asteroidController = new EnemyController(asteroidView, movement);

            SubscribeController(asteroidController);

            asteroidController.Died += OnDied;
            asteroidController.Died += (asteroidController) => _scoreSystem.AddPoints(_asteroidConfig.points);

            asteroidController.Died += (asteroidController) =>
            {
                CreateSmallAsteroid(asteroidView.transform.position, Quaternion.AngleAxis(_asteroidCrushAngle, Vector3.forward) * direction, OnDied);
                CreateSmallAsteroid(asteroidView.transform.position, Quaternion.AngleAxis(-_asteroidCrushAngle, Vector3.forward) * direction, OnDied);
            };

            _listOfEnemyControllers.Add(asteroidController);

            return asteroidController;
        }

        public EnemyController CreateSmallAsteroid(Vector3 position, Vector3 direction, Action<EnemyController> OnDied)
        {
            EnemyView asteroidView = UnityEngine.Object.Instantiate(_asteroidSmallConfig.asteroidPrefab, position, Quaternion.identity, _root.transform);

            StraightMovement movement = new StraightMovement(asteroidView.transform, _asteroidSmallConfig.speed, _asteroidSmallConfig.speed, _noDragSpeed, direction);

            EnemyController asteroidController = new EnemyController(asteroidView, movement);

            SubscribeController(asteroidController);

            asteroidController.Died += OnDied;
            asteroidController.Died += (asteroidController) => _scoreSystem.AddPoints(_asteroidSmallConfig.points);

            _listOfEnemyControllers.Add(asteroidController);

            return asteroidController;
        }

        public EnemyController CreateUFO()
        {
            EnemyView ufoView = UnityEngine.Object.Instantiate(_ufoConfig.ufoPrefab, _screenRandomizer.CreateRandomPosition(), Quaternion.identity, _root.transform);

            FollowObjectMovement followObjectMovement = new FollowObjectMovement(ufoView.transform, _playerTransform, _ufoConfig.speed);

            EnemyController ufoController = new EnemyController(ufoView, followObjectMovement);

            SubscribeController(ufoController);

            ufoController.Died += (ufoController) => _scoreSystem.AddPoints(_ufoConfig.points);

            _listOfEnemyControllers.Add(ufoController);

            return ufoController;
        }
    }
}