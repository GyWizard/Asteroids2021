using UnityEngine;
using Asteroids.Abstraction;

namespace Asteroids.Game.Bullets
{
    public sealed class LazerView : InteractView
    {
        public LineRenderer lineRenderer;
        public override void Awake()
        {
            base.Awake();
            lineRenderer = GetComponent<LineRenderer>();
        }
    }
}

