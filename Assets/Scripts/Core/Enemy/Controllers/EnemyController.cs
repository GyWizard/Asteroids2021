using Asteroids.Systems;
using Asteroids.Abstraction;
using Asteroids.Game.Bullets;
using System;

namespace Asteroids.Game
{
    public class EnemyController : IUpdate, IRelocator
    {
        private EnemyView _enemyView;
        public IRelocateView RelocateView => _enemyView;

        private BaseMovement _movement;

        public event Action<EnemyController> Died;
        public event Action<EnemyController> OnDestroyed;
        public EnemyController(EnemyView enemyView, BaseMovement movement)
        {
            _enemyView = enemyView;
            _movement = movement;

            _enemyView.OnInteracted += Interact;
        }
        public void Update()
        {
            _movement.Movement();
        }
        private void Interact(InteractView view)
        {
            if (view is BulletView || view is LazerView)
            {
                Die();
            }
        }
        public void Die()
        {
            Died?.Invoke(this);
            DestroyObject();
        }
        public void DestroyObject()
        {
            OnDestroyed?.Invoke(this);
            _enemyView.Destroy();
            Died = null;
            OnDestroyed = null;
        }
    }
}