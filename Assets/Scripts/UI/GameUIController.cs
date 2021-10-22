using UnityEngine;
using Asteroids.Game;
using Asteroids.Game.Weapons;

namespace Asteroids.UI
{
    public sealed class GameUIController : IUpdate
    {
        private GameUIView _gameUIView;
        private PlayerController _playerController;
        private LazerWeapon _lazerWeapon;
        public GameUIController(GameUIView gameUIView, PlayerController playerController, LazerWeapon lazerWeapon)
        {
            _gameUIView = gameUIView;
            _playerController = playerController;
            _lazerWeapon = lazerWeapon;
            _lazerWeapon.AmmoValueChanged += UpdateLazerAmmo;
            UpdateLazerAmmo(_lazerWeapon.AmmoAmount);
            UpdateLazerTimer(_lazerWeapon.AmmoReloadTimer);
        }
        public void Update() //garbage nightmare!!!!!-----
        {
            if (Time.frameCount % 3 == 0)
            {
                UpdatePosition(_playerController.ShipPosition);
                UpdateAngle(_playerController.ShipAngle);
                UpdateSpeed(_playerController.ShipSpeed);
                if (_lazerWeapon.AmmoReloadTimer != 0)
                {
                    UpdateLazerTimer(_lazerWeapon.AmmoReloadTimer);
                }
            }
        }
        private void UpdatePosition(Vector2 position)
        {
            _gameUIView.positionValueText.text = position.ToString();
        }
        private void UpdateAngle(float angle)
        {
            _gameUIView.angleValueText.text = angle.ToString("00");
        }
        private void UpdateSpeed(float speed)
        {
            _gameUIView.speedValueText.text = speed.ToString("0.00");
        }
        private void UpdateLazerAmmo(int ammoAmount)
        {
            _gameUIView.lazerAmmoValueText.text = ammoAmount.ToString();
        }
        private void UpdateLazerTimer(float time)
        {
            _gameUIView.lazerTimerValueText.text = time.ToString("00");
        }
        public void DestroyObject()
        {
            GameObject.Destroy(_gameUIView.gameObject);
        }
    }
}

