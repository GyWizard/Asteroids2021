using UnityEngine;
using Asteroids.Factorys;
using Asteroids.Configs;

namespace Asteroids.Game
{
    public sealed class LevelSystem
    {
        private EnemyFactory _enemyFactory;
        private LevelSystemConfig _levelSystemConfig;
        private int _currentLevelAsteroidsAmount;

        private EnemyController _enemyController;
        private int _enemysCount;

        private int _halfAsteroidAmount;
        public LevelSystem(EnemyFactory enemyFactory)
        {
            _levelSystemConfig = Resources.Load<LevelSystemConfig>("Configs/LevelSystemConfig");
            _enemyFactory = enemyFactory;

            _currentLevelAsteroidsAmount = _levelSystemConfig.startAsteroidsAmount;
            _halfAsteroidAmount = HalfAsteroidAmount();
        }
        public void LoadLevel()
        {
            for (int i = 0; i < _currentLevelAsteroidsAmount; i++)
            {
                _enemyController = _enemyFactory.CreateAsteroid(EnemyDestroyed);
            }
            _enemysCount = _currentLevelAsteroidsAmount * 3;
        }
        private void EnemyDestroyed(EnemyController enemyController)
        {
            _enemysCount--;

            if (_enemysCount == _halfAsteroidAmount)
            {
                _enemyController = _enemyFactory.CreateUFO();
            }
            if (_enemysCount == 0)
            {
                NextLevel();
            }
        }
        private void NextLevel()
        {
            _currentLevelAsteroidsAmount += _levelSystemConfig.asteroidsIncremental;
            _halfAsteroidAmount = HalfAsteroidAmount();
            LoadLevel();
        }

        private int HalfAsteroidAmount()
        {
            return ((_currentLevelAsteroidsAmount * 3) / 2);
        }
    }
}