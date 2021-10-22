using System;
using Asteroids.Systems;
using Asteroids.Abstraction.Weapons;
using Asteroids.Abstraction;
using UnityEngine.InputSystem;
using UnityEngine;

namespace Asteroids.Game
{
    public sealed class PlayerController : IUpdate, IRelocator
    {
        private PlayerShipView _view;

        private Inputs _input;

        private BaseMovement _movement;
        private BaseWeapon _primaryWeapon;
        private BaseWeapon _secondWeapon;
        public IRelocateView RelocateView => _view;

        public event Action<PlayerController> OnDestroyed;

        public float ShipAngle => _view.transform.rotation.eulerAngles.z;
        public Vector2 ShipPosition => _view.transform.position;
        public float ShipSpeed => _movement.Speed;
        public PlayerController(PlayerShipView view, Inputs inputs, BaseMovement movement, BaseWeapon primaryWeapon, BaseWeapon secondWeapon)
        {
            _view = view;
            _movement = movement;
            _primaryWeapon = primaryWeapon;
            _secondWeapon = secondWeapon;

            _input = inputs;
            _input.Ship.Enable();

            _input.Ship.FirePrimaryWeapon.performed += ShootPrimaryWeapon;
            _input.Ship.FireSecondWeapon.performed += ShootSecondWeapon;

            _view.OnInteracted += Interact;
        }
        public void Update()
        {
            _movement.Movement();
        }
        private void ShootPrimaryWeapon(InputAction.CallbackContext contex)
        {
            _primaryWeapon.Shoot();
        }
        private void ShootSecondWeapon(InputAction.CallbackContext contex)
        {
            _secondWeapon.Shoot();
        }
        private void Interact(InteractView view)
        {
            if (view is EnemyView)
            {
                Destroy();
            }
        }
        private void Destroy()
        {
            OnDestroyed?.Invoke(this);
            _view.Destroy();

            _input.Ship.FirePrimaryWeapon.performed -= ShootPrimaryWeapon;
            _input.Ship.FireSecondWeapon.performed -= ShootSecondWeapon;
            _input.Ship.Disable();

            _primaryWeapon.DestroyWeapon();
            _secondWeapon.DestroyWeapon();

            OnDestroyed = null;
        }
    }
}
