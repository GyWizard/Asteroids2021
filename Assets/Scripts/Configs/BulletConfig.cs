using UnityEngine;
using Asteroids.Game;

namespace Asteroids.Configs
{
    [CreateAssetMenu(fileName = "BulletConfig", menuName = "GameConfigurations/BulletConfig")]
    public class BulletConfig : ScriptableObject
    {
        public float lifeTime;
        public float speed;
        public BulletView bulletPrefab;
    }
}



