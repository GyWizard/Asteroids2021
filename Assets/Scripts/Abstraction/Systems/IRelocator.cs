using UnityEngine;

namespace Asteroids.Systems
{
    public interface IRelocator
    {
        public IRelocateView RelocateView { get; }
    }
}


