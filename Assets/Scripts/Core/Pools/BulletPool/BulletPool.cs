using System;
using System.Collections.Generic;
using UnityEngine;
using Asteroids.Factorys;
using Asteroids.Services;
using Asteroids.Systems;
using Asteroids.Game;

namespace Asteroids.Pools
{
    public sealed class BulletPool
    {
        private Queue<BulletController> _bullets = new Queue<BulletController>();
        private GameObject _root;
        private BulletFactory _factory;

        private UpdateService _updateService;
        private RelocateSystem _relocateSystem;
        public BulletPool(UpdateService updateService, RelocateSystem relocateSystem)
        {
            _root = new GameObject();
            _root.name = "BulletRoot";

            _factory = new BulletFactory();
            _updateService = updateService;
            _relocateSystem = relocateSystem;
        }
        public BulletController GetBullet()
        {
            if (_bullets.Count == 0)
            {
                _bullets.Enqueue(_factory.CreateBullet(_root.transform));
            }
            var bullet = _bullets.Dequeue();
            SubscribeBullet(bullet);
            return bullet;
        }
        public void ReturnBullet(BulletController bullet)
        {
            _bullets.Enqueue(bullet);
            UnSubscribeBullet(bullet);
        }
        void SubscribeBullet(BulletController bullet)
        {
            bullet.BulletDied += ReturnBullet;
            _updateService.AddUpdater(bullet);
            _relocateSystem.AddRelocator(bullet);
        }
        void UnSubscribeBullet(BulletController bullet)
        {
            bullet.BulletDied -= ReturnBullet;
            _updateService.RemoveUpdater(bullet);
            _relocateSystem.RemoveRelocator(bullet);
        }
        public void ClearPool()
        {
            foreach (BulletController bullet in _factory._listOfBullets)
            {
                UnSubscribeBullet(bullet);
            }
            _bullets.Clear();
            _factory.ClearAllBullets();

            UnityEngine.Object.Destroy(_root);
        }
    }
}