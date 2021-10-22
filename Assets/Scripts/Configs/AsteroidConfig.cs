using UnityEngine;
using Asteroids.Abstraction;

namespace Asteroids.Configs
{
    [CreateAssetMenu(fileName = "AsteroidConfig", menuName = "GameConfigurations/AsteroidConfig")]
    public class AsteroidConfig : ScriptableObject
    {
        public float speed;
        public EnemyView asteroidPrefab;
        public int points;
    }
}