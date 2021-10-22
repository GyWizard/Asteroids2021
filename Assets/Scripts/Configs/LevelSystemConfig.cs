using UnityEngine;

namespace Asteroids.Configs
{
    [CreateAssetMenu(fileName = "LevelSystemConfig", menuName = "GameConfigurations/LevelSystemConfig")]
    public class LevelSystemConfig : ScriptableObject
    {
        public int startAsteroidsAmount;
        public int asteroidsIncremental;
    }
}
