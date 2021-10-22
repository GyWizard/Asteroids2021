using UnityEngine;
using Asteroids.Game;

namespace Asteroids.Configs
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "GameConfigurations/PlayerConfig")]
    public class PlayerConfig : ScriptableObject
    {
        public PlayerShipView shipView;

        public float shipSpeed;
        public float maxShipSpeed;
        public float shipSpeedDrag;
        public float shipRotateSpeed;

    }
}
