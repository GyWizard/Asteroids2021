using UnityEngine;
using Asteroids.Systems;
using Asteroids.Engine;
using Asteroids.Abstraction;
using System;

namespace Asteroids.Game
{
    public sealed class BulletController : IUpdate, IRelocator
    {
        private BulletView _bulletView;
        public IRelocateView RelocateView => _bulletView;
        private PhysicMovement _physics;
        private float _currentLifeTime;
        private float _maxLifeTime;

        public event Action<BulletController> BulletDied;
        public BulletController(BulletView bulletView, PhysicMovement physics, float maxLifeTime)
        {
            _bulletView = bulletView;
            _physics = physics;

            _maxLifeTime = maxLifeTime;
            _bulletView.OnInteracted += Interact;
        }
        public void Update()
        {
            if (_currentLifeTime >= _maxLifeTime)
            {
                BulletHited();
            }
            else
            {
                _currentLifeTime += Time.deltaTime;
            }
            _physics.PhysicsExecute();
        }
        public void BulletHited()
        {
            BulletDied?.Invoke(this);
            BulletSetActive(false);
        }
        public void BulletSetActive(bool value)
        {
            _bulletView.gameObject.SetActive(value);
        }
        public void SetUpBullet()
        {
            _currentLifeTime = 0f;
            _physics.ClearPhysics();
        }
        public void ShootBullet(Transform barrel)
        {
            SetUpBullet();
            BulletSetActive(true);
            _bulletView.transform.position = barrel.transform.position;
            _bulletView.transform.rotation = barrel.transform.rotation;
            _physics.AddConstantForce(barrel.transform.up);
        }
        public void Destroy()
        {
            _bulletView.Destroy();
            BulletDied = null;
        }
        private void Interact(InteractView view)
        {
            if (view is EnemyView)
            {
                BulletHited();
            }
        }
    }
}

