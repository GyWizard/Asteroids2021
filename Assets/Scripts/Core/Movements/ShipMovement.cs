using UnityEngine;
using Asteroids.Engine;
using UnityEngine.InputSystem;
using Asteroids.Abstraction;

namespace Asteroids.Game.Movements
{
    public sealed class ShipMovement : BaseMovement
    {
        private PhysicMovement _shipPhysics;
        private Transform _shipTransform;
        private float _rotateSpeed;
        private Inputs _inputs;
        public override float Speed => _shipPhysics.CurrentSpeed;
        public ShipMovement(Inputs inputs, Transform shipTransform, float maxSpeed, float speed, float speedDrag, float rotateSpeed) : base(speed)
        {
            _shipPhysics = new PhysicMovement(shipTransform, maxSpeed, speed, speedDrag);
            _shipTransform = shipTransform;
            _rotateSpeed = rotateSpeed;
            _inputs = inputs;
        }
        public override void Movement()
        {
            MoveForward();
            Rotate();
            _shipPhysics.PhysicsExecute();
        }
        void MoveForward()
        {
            if (_inputs.Ship.Forward.phase == InputActionPhase.Performed)
            {
                _shipPhysics.AddForce(_shipTransform.up);
            }
        }
        void Rotate()
        {
            if (_inputs.Ship.RotateRight.phase == InputActionPhase.Performed)
            {
                _shipTransform.Rotate(_shipTransform.forward * -_rotateSpeed * Time.deltaTime);
            }
            if (_inputs.Ship.RotateLeft.phase == InputActionPhase.Performed)
            {
                _shipTransform.Rotate(_shipTransform.forward * _rotateSpeed * Time.deltaTime);
            }
        }
    }
}