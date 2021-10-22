using UnityEngine;
using Asteroids.Abstraction;

namespace Asteroids.Game.Movements
{
    public sealed class FollowObjectMovement : BaseMovement
    {
        private Transform _objectTransform;
        private Transform _transformToFollow;
        public override float Speed => speed;
        public FollowObjectMovement(Transform objectTransform, Transform transformToFollow, float speed) : base(speed)
        {
            _objectTransform = objectTransform;
            _transformToFollow = transformToFollow;
        }
        public override void Movement()
        {
            _objectTransform.Translate((_transformToFollow.position - _objectTransform.position).normalized * speed * Time.deltaTime);
        }
    }
}