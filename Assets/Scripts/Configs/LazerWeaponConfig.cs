using UnityEngine;
using Asteroids.Game.Bullets;

namespace Asteroids.Configs
{
    [CreateAssetMenu(fileName = "LazerWeaponConfig", menuName = "GameConfigurations/LazerWeaponConfig")]
    public class LazerWeaponConfig : ScriptableObject
    {
        public LazerView lazerPrefab;
        public int ammoMaxCount;
        public float ammoReloadTime;
        public float lazerExistTime;
    }
}