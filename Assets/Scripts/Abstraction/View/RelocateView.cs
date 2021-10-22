using UnityEngine;
using Asteroids.Systems;

namespace Asteroids.Abstraction
{
    public class RelocateView : InteractView, IRelocateView
    {
        [SerializeField] private Renderer _renderer;
        public Renderer Renderer => _renderer;
        public Transform Transform => transform;
        public bool IsVisible { get; set; }
        public override void Awake()
        {
            base.Awake();
            IsVisible = true;
        }
    }
}



