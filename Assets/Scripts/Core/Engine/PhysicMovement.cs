using UnityEngine;

namespace Asteroids.Engine
{
    public sealed class PhysicMovement
    {
        private Transform _transform;

        private float _maxSpeed;
        private float _speed;
        private float _speedDrag;

        private readonly float _speedStopTreshhold = 0.001f;

        private Vector3 _dir = Vector3.zero;
        public float CurrentSpeed => _dir.magnitude;
        public PhysicMovement(Transform transform, float maxSpeed, float speed, float speedDrag)
        {
            _transform = transform;

            _maxSpeed = maxSpeed;
            _speed = speed;
            _speedDrag = speedDrag;
        }
        public void AddForce(Vector3 forceDir)
        {
            _dir += forceDir * _speed * Time.deltaTime;

            if (_dir.sqrMagnitude > _maxSpeed * _maxSpeed)
            {
                _dir = _dir.normalized * _maxSpeed;
            }
        }
        public void AddConstantForce(Vector3 forceDir)
        {
            _dir = forceDir * _speed;
        }
        public void PhysicsExecute()
        {
            if (_dir.sqrMagnitude > _speedStopTreshhold * _speedStopTreshhold)
            {
                _dir += -_dir * _speedDrag * Time.deltaTime;
            }
            else
            {
                _dir = Vector3.zero;
            }
            _transform.Translate(_dir * _speed * Time.deltaTime, Space.World);
        }
        public void ClearPhysics()
        {
            _dir = Vector3.zero;
        }
    }
}