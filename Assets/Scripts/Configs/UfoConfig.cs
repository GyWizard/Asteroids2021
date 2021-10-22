using UnityEngine;

namespace Asteroids.Configs
{
    [CreateAssetMenu(fileName = "UFOConfig", menuName = "GameConfigurations/UFOConfig")]
    public class UfoConfig : ScriptableObject
    {
        public float speed;
        public UFOView ufoPrefab;
        public int points;
    }
}