using UnityEngine;

namespace Asteroids.Abstraction.Weapons
{
    public abstract class BaseWeapon
    {
        protected Transform _barrel;
        public bool Locked
        {
            get { return _weaponLocked; }
            set { _weaponLocked = value; }
        }
        private bool _weaponLocked = false;
        public BaseWeapon(Transform barrel)
        {
            _barrel = barrel;
        }
        public abstract void Shoot();
        public abstract void DestroyWeapon();
    }
}


