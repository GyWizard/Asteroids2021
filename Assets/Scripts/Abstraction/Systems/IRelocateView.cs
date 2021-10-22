using UnityEngine;

namespace Asteroids.Systems
{
    public interface IRelocateView
    {
        public Renderer Renderer { get; }
        public Transform Transform { get; }
        public bool IsVisible { get; set; }
    }
}


