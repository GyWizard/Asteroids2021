using UnityEngine;
using Asteroids.Game;
using Asteroids.Engine;
using Asteroids.Configs;
using System.Collections.Generic;


namespace Asteroids.Factorys
{
    public sealed class BulletFactory
    {
        private BulletConfig _bulletConfig;
        private List<BulletController> _listOfBulletControllers;
        public List<BulletController> _listOfBullets => _listOfBulletControllers;

        private float _noDragSpeed = 0f;
        public BulletFactory()
        {
            _bulletConfig = Object.Instantiate(Resources.Load<BulletConfig>("Configs/BulletConfig"));
            _listOfBulletControllers = new List<BulletController>();
        }
        public BulletController CreateBullet(Transform _root)
        {
            BulletView bulletView = Object.Instantiate(_bulletConfig.bulletPrefab, _root.transform);
            PhysicMovement physic = new PhysicMovement(bulletView.transform, _bulletConfig.speed, _bulletConfig.speed, _noDragSpeed);
            BulletController bulletController = new BulletController(bulletView, physic, _bulletConfig.lifeTime);

            _listOfBulletControllers.Add(bulletController);

            return bulletController;
        }
        public void ClearAllBullets()
        {
            foreach (BulletController bulletController in _listOfBulletControllers)
            {
                bulletController.Destroy();
            }
            _listOfBulletControllers.Clear();
        }
    }
}