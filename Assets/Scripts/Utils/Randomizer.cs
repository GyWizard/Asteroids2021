
using System;
using UnityEngine;

namespace Asteroids.Utils
{
    internal enum Sides
    {
        Top = 0,
        Right = 1,
        Bottom = 2,
        Left = 3
    }
    public class Randomizer
    {
        private Vector2 _screenSize;
        public Randomizer(Vector2 screenSize)
        {
            _screenSize = screenSize;
        }
        public Vector2 CreateRandomPosition()
        {
            Vector2 pos = new Vector2();
            Sides side = (Sides)UnityEngine.Random.Range(0, Enum.GetValues(typeof(Sides)).Length);

            switch (side)
            {
                case Sides.Top:
                    pos.x = UnityEngine.Random.Range(_screenSize.x, -_screenSize.x);
                    pos.y = -_screenSize.y;
                    break;

                case Sides.Right:
                    pos.y = UnityEngine.Random.Range(_screenSize.y, -_screenSize.y);
                    pos.x = -_screenSize.x;
                    break;

                case Sides.Bottom:
                    pos.x = UnityEngine.Random.Range(_screenSize.x, -_screenSize.x);
                    pos.y = _screenSize.y;
                    break;

                case Sides.Left:
                    pos.y = UnityEngine.Random.Range(_screenSize.y, -_screenSize.y);
                    pos.x = _screenSize.x;
                    break;
                default:
                    pos.x = UnityEngine.Random.Range(_screenSize.x, -_screenSize.x);
                    pos.y = -_screenSize.y;
                    break;
            }

            return pos;
        }
        public Vector2 CreateRandomDirection()
        {
            return new Vector2(UnityEngine.Random.Range(-0.5f, 0.5f), UnityEngine.Random.Range(-0.5f, 0.5f)).normalized;
        }
    }
}


