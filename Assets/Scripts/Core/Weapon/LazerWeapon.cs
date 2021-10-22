using UnityEngine;
using Asteroids.Abstraction.Weapons;
using System;
using Asteroids.Configs;
using Asteroids.Game;
using Asteroids.Abstraction;
using Asteroids.Game.Bullets;

namespace Asteroids.Game.Weapons
{
    public sealed class LazerWeapon : BaseWeapon, IUpdate
    {
        private LazerView _lazerView;
        private LazerWeaponConfig _lazerConfig;

        private int _ammoCurrentCount;
        private float _ammoTimer;

        private float _lazerTimer;
        private float _lazerDistance;

        private RaycastHit2D[] _hits;

        private bool _lazerOn;

        public event Action<int> AmmoValueChanged;
        public float AmmoReloadTimer => _ammoTimer;
        public int AmmoAmount => _ammoCurrentCount;
        public LazerWeapon(Transform barrel, Vector2 screenSize) : base(barrel)
        {
            _lazerDistance = screenSize.x > screenSize.y ? screenSize.x * 2 : screenSize.y * 2;

            _lazerConfig = Resources.Load<LazerWeaponConfig>("Configs/LazerWeaponConfig");

            _lazerView = UnityEngine.Object.Instantiate(_lazerConfig.lazerPrefab, barrel);
            _lazerView.lineRenderer.SetPosition(0, _lazerView.transform.position);
            _lazerView.lineRenderer.SetPosition(0, _lazerView.transform.up * _lazerDistance);

            _ammoCurrentCount = _lazerConfig.ammoMaxCount;
            _ammoTimer = 0;

            LazerOff();
        }
        public override void Shoot()
        {
            if (!Locked && _ammoCurrentCount > 0)
            {
                LazerOn();
            }
        }
        public void Update()
        {
            if (_lazerOn)
            {
                _hits = Physics2D.RaycastAll(_lazerView.transform.position, _lazerView.transform.up, _lazerDistance);
                foreach (RaycastHit2D hit in _hits)
                {
                    var enemy = hit.collider.gameObject.GetComponent<EnemyView>();
                    if (enemy != null)
                    {
                        enemy.Interact(_lazerView);
                    }
                }

                _lazerTimer -= Time.deltaTime;

                if (_lazerTimer <= 0)
                {
                    LazerOff();
                }
            }

            ReloadLazer();
        }
        private void ReloadLazer()
        {
            if (_ammoCurrentCount != _lazerConfig.ammoMaxCount)
            {
                if (_ammoTimer == 0)
                {
                    _ammoTimer = _lazerConfig.ammoReloadTime;
                }
                _ammoTimer -= Time.deltaTime;
                if (_ammoTimer <= 0)
                {
                    _ammoCurrentCount++;
                    AmmoValueChanged?.Invoke(_ammoCurrentCount);
                    _ammoTimer = 0f;
                }
            }
        }
        private void LazerOn()
        {
            if (_lazerOn)
                return;

            _lazerOn = true;
            _lazerView.gameObject.SetActive(true);
            _lazerTimer = _lazerConfig.lazerExistTime;
            _ammoCurrentCount--;
            AmmoValueChanged?.Invoke(_ammoCurrentCount);
        }
        private void LazerOff()
        {
            _lazerOn = false;
            _lazerView.gameObject.SetActive(false);
            _lazerTimer = _lazerConfig.lazerExistTime;
        }
        public override void DestroyWeapon()
        {
            AmmoValueChanged = null;
            _lazerView.Destroy();
        }
    }

}