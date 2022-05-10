using System;
using System.Numerics;

namespace Logic
{
    public class Generator
    {
        private Random _generator = new Random();
        private int _x;
        private int _y;
        private int _radius = 15;

        public Generator() { }

        public void GenerateXY()
        {
             }
        
        public void GenerateVelocity()
        {

        }
        public Ball GenerateBall()
        {
            float X = _generator.Next(2 + _radius, Storage.width - _radius - 2);
            float Y = _generator.Next(2 + _radius, Storage.height - _radius - 2);
            float mass = (float) _generator.NextDouble() * 2;
            float velocityX = (float) _generator.NextDouble() * (3 + 3) - 3;
            float velocityY = (float) _generator.NextDouble() * (3 + 3) - 3;
            Vector2 velocity = new Vector2(velocityX, velocityY);
            return new Ball(X, Y, Radius, mass, velocity);
        }

        public int X
        {
            get => _x;
            set => _x = value;
        }

        public int Y
        {
            get => _y;
            set => _y = value;
        }

        public int Radius
        {
            get => _radius;
            set => _radius = value;
        }


    }
}