using UnityEngine;
using System.Collections.Generic;

namespace Asteroids.Systems
{
    public sealed class RelocateSystem : IUpdate
    {
        private List<IRelocator> _listOfRelocators = new List<IRelocator>();
        private Vector3 _newPosition;
        private Vector2 _screenSize;
        private float _relocateTreshold;
        public RelocateSystem(Vector2 screenSize, float relocateTreshold)
        {
            _screenSize = screenSize;
            _relocateTreshold = relocateTreshold;
        }
        public void AddRelocator(IRelocator relocator)
        {
            _listOfRelocators.Add(relocator);
        }
        public void RemoveRelocator(IRelocator relocator)
        {
            _listOfRelocators.Remove(relocator);
        }
        public void Update()
        {
            CheckForRelocation();
        }
        public void ClearSystem()
        {
            _listOfRelocators.Clear();
        }
        private void CheckForRelocation()
        {
            foreach (IRelocator relocator in _listOfRelocators)
            {
                if (relocator.RelocateView.Renderer.isVisible)
                {
                    if (!relocator.RelocateView.IsVisible)
                    {
                        relocator.RelocateView.IsVisible = true;
                    }
                }
                else
                {
                    if (relocator.RelocateView.IsVisible)
                    {
                        relocator.RelocateView.IsVisible = false;
                        Relocate(relocator.RelocateView);
                    }
                }
            }
        }
        private void Relocate(IRelocateView relocateView)
        {
            _newPosition = relocateView.Transform.position;

            if (relocateView.Transform.position.x > _screenSize.x || relocateView.Transform.position.x < -_screenSize.x)
            {
                _newPosition.x = -_newPosition.x;
                _newPosition.x += _newPosition.x > 0 ? -_relocateTreshold : _relocateTreshold;
            }

            if (relocateView.Transform.position.y > _screenSize.y || relocateView.Transform.position.y < -_screenSize.y)
            {
                _newPosition.y = -_newPosition.y;
                _newPosition.y += _newPosition.y > 0 ? -_relocateTreshold : _relocateTreshold;
            }
            relocateView.Transform.position = _newPosition;
        }
    }
}


