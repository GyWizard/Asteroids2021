using UnityEngine;
using Asteroids.Abstraction.Weapons;
using Asteroids.Services;
using Asteroids.Systems;
using Asteroids.Pools;

namespace Asteroids.Game.Weapons
{
    public sealed class TurrelWeapon : BaseWeapon
    {
        private BulletPool _bulletPool;
        private BulletController _bullet = null;

        public TurrelWeapon(Transform barrel, UpdateService updateService, RelocateSystem relocateSystem) : base(barrel)
        {
            _bulletPool = new BulletPool(updateService, relocateSystem);
        }
        public override void Shoot()
        {
            if (!Locked)
            {
                _bullet = _bulletPool.GetBullet();
                _bullet.ShootBullet(_barrel);
            }
        }
        public override void DestroyWeapon()
        {
            _bulletPool.ClearPool();
            _bulletPool = null;
        }
    }
}