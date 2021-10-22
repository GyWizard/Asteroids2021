
namespace Asteroids.Abstraction
{
    public abstract class BaseMovement
    {
        protected float speed;
        public abstract float Speed { get; }
        public abstract void Movement();
        public BaseMovement(float speed)
        {
            this.speed = speed;
        }
    }
}


