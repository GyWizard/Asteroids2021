using UnityEngine;
using Asteroids.Services;
using Asteroids.Systems;
using Asteroids.Engine;
using Asteroids.Configs;
using Asteroids.Game.Weapons;
using Asteroids.Game.Movements;
using Asteroids.Factorys;
using Asteroids.UI;
using System;

namespace Asteroids.Game
{
    public class GameLoader
    {
        private UpdateService _updateService;
        private Inputs _inputs;
        private LevelSystem _levelSystem;
        private EnemyFactory _enemyFactory;
        private RelocateSystem _relocateSystem;
        private ScoreSystem _scoreSystem;
        ScorePanelView _scorePanelView;

        private PlayerShipView _shipView;
        private PlayerController _playerController;

        private GameUIController _gameUIController;

        private Action<int> GameEnd;
        private Vector2 _screenSize;
        public GameLoader(UpdateService updateService, Inputs inputs, Action<int> OnGameEnd, Camera camera)
        {
            _updateService = updateService;
            _inputs = inputs;
            GameEnd = OnGameEnd;

            _screenSize = camera.ScreenToWorldPoint(new Vector3(0f, 0f, Mathf.Abs(camera.transform.position.y)));
            _screenSize = new Vector2(Mathf.Abs(_screenSize.x), Mathf.Abs(_screenSize.y));
        }
        public void LoadGame()
        {
            LoadSystems();
            LoadPlayer();
            LoadLevel();
        }

        private void LoadSystems()
        {
            _scorePanelView = UnityEngine.Object.Instantiate(Resources.Load<ScorePanelView>("UI/CanvasScorePanel"));
            _scoreSystem = new ScoreSystem();
            _scoreSystem.scoreUpdated += _scorePanelView.UpdateValue;

            _relocateSystem = new RelocateSystem(_screenSize, 0.1f);

            _updateService.AddUpdater(_relocateSystem);
            _updateService.AddUpdater(_gameUIController);
        }

        private void LoadPlayer()
        {
            var playerConfig = Resources.Load<PlayerConfig>("Configs/PlayerConfig");

            _shipView = UnityEngine.Object.Instantiate(playerConfig.shipView);

            var shipMovement = new ShipMovement(
                _inputs,
                _shipView.transform,
                playerConfig.shipSpeed,
                playerConfig.maxShipSpeed,
                playerConfig.shipSpeedDrag,
                playerConfig.shipRotateSpeed
                );

            var turrelWeapon = new TurrelWeapon(_shipView.barrel, _updateService, _relocateSystem);
            var lazerWeapon = new LazerWeapon(_shipView.barrel, _screenSize);

            _playerController = new PlayerController(_shipView, _inputs, shipMovement, turrelWeapon, lazerWeapon);

            GameUIView gameUIView = UnityEngine.Object.Instantiate(Resources.Load<GameUIView>("UI/CanvasInfoPanel"));
            _gameUIController = new GameUIController(gameUIView, _playerController, lazerWeapon);

            _updateService.AddUpdater(_playerController);
            _updateService.AddUpdater(lazerWeapon);
            _updateService.AddUpdater(_gameUIController);

            _relocateSystem.AddRelocator(_playerController);

            _playerController.OnDestroyed += _updateService.RemoveUpdater;
            _playerController.OnDestroyed += _relocateSystem.RemoveRelocator;
            _playerController.OnDestroyed += playerController => _updateService.RemoveUpdater(lazerWeapon);
            _playerController.OnDestroyed += playerController => _updateService.RemoveUpdater(_gameUIController);
            _playerController.OnDestroyed += playerController => _updateService.RemoveUpdater(_relocateSystem);
            _playerController.OnDestroyed += playerController => GameEnd(_scoreSystem.Score);
            _playerController.OnDestroyed += playerController => ClearGameLevel();
        }
        private void LoadLevel()
        {
            _enemyFactory = new EnemyFactory(_updateService, _relocateSystem, _scoreSystem, _shipView.transform, _screenSize);

            _levelSystem = new LevelSystem(_enemyFactory);
            _levelSystem.LoadLevel();
        }
        public void ClearGameLevel()
        {
            _updateService.ClearUpdateService();
            _gameUIController.DestroyObject();
            _enemyFactory.ClearAllEnemys();
            _relocateSystem.ClearSystem();
            _scoreSystem.ClearScoreSystem();
            GameObject.Destroy(_scorePanelView.gameObject);
        }
    }
}