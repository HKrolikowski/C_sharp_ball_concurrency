using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class Generator
    {

            private Random generator = new Random();
            private int _x;
            private int _y;
            private int _radius = 15;
            private int _speed = 13;

        public Generator() {}

        public void GenerateXY()
        {
            this.X = generator.Next(2 + _radius, Storage.width - _radius - 2);
            this.Y = generator.Next(2 + _radius, Storage.height - _radius - 2);
        }

        public Ball GenerateBall()
        {
            GenerateXY();
            return new Ball(X, Y, Radius, Speed);
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
        
        private int Radius
        {
            get => _radius;
            set => _radius = value;
        }

        private int Speed
        {
            get => _speed;
            set => _speed = value;
        }
    }
}
