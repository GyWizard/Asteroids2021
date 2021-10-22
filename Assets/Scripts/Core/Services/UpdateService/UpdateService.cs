using System;

namespace Asteroids.Services
{
    public sealed class UpdateService
    {
        private event Action OnUpdate;
        private event Action OnFixedUpdate;
        private event Action OnLateUpdate;
        public void AddUpdater(IUpdater updaterListener)
        {
            if (updaterListener is IUpdate update)
            {
                OnUpdate += update.Update;
            }
            if (updaterListener is IFixedUpdate fixedUpdate)
            {
                OnFixedUpdate += fixedUpdate.FixedUpdate;
            }
            if (updaterListener is ILateUpdate lateUpdate)
            {
                OnLateUpdate += lateUpdate.LateUpdate;
            }
        }
        public void RemoveUpdater(IUpdater updaterListener)
        {
            if (updaterListener is IUpdate update)
            {
                OnUpdate -= update.Update;
            }
            if (updaterListener is IFixedUpdate fixedUpdate)
            {
                OnFixedUpdate -= fixedUpdate.FixedUpdate;
            }
            if (updaterListener is ILateUpdate lateUpdate)
            {
                OnLateUpdate -= lateUpdate.LateUpdate;
            }
        }
        public void Update()
        {
            OnUpdate?.Invoke();
        }
        public void FixedUpdate()
        {
            OnFixedUpdate?.Invoke();
        }
        public void LateUpdate()
        {
            OnLateUpdate?.Invoke();
        }
        public void ClearUpdateService()
        {
            OnUpdate = null;
            OnFixedUpdate = null;
            OnLateUpdate = null;
        }
    }
}
