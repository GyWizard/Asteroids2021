using UnityEngine;
using Asteroids.Engine;
using Asteroids.Abstraction;

namespace Asteroids.Game.Movements
{
    public sealed class StraightMovement : BaseMovement
    {
        private PhysicMovement _physics;
        public override float Speed => _physics.CurrentSpeed;
        public StraightMovement(Transform viewTransform, float maxSpeed, float speed, float speedDrag, Vector3 direction) : base(speed)
        {
            _physics = new PhysicMovement(viewTransform, maxSpeed, speed, speedDrag);
            _physics.AddConstantForce(direction);
        }
        public override void Movement()
        {
            _physics.PhysicsExecute();
        }
    }
}