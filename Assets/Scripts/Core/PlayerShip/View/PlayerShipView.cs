using Asteroids.Systems;
using Asteroids.Abstraction;
using UnityEngine;

namespace Asteroids.Game
{
    public sealed class PlayerShipView : RelocateView
    {
        [SerializeField] public Transform barrel;
        public override void Awake()
        {
            base.Awake();
        }
    }
}