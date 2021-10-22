using System;
using UnityEngine;

namespace Asteroids.Abstraction
{
    public class InteractView : MonoBehaviour
    {
        [HideInInspector] public Collider2D _collider;
        [HideInInspector] public Rigidbody2D _rigidbody;

        public event Action<InteractView> OnInteracted;
        public event Action<InteractView> OnDestroyed;

        public virtual void Awake()
        {
            _collider = GetComponent<Collider2D>();
            _rigidbody = GetComponent<Rigidbody2D>();
        }
        public void Interact(InteractView view)
        {
            OnInteracted?.Invoke(view);
        }
        public void Destroy()
        {
            OnDestroyed?.Invoke(this);
            OnInteracted = null;
            OnDestroyed = null;
            Destroy(this.gameObject);
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            var view = collision.gameObject.GetComponent<InteractView>();
            if (view != null)
            {
                Interact(view);
            }
        }
    }

}


