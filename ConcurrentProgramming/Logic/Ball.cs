using System;
using System.Numerics;


namespace Logic
{
    public class Ball
    {
        private Vector2 _vectorCurrent;
        private float _speed;
        private Vector2 _vectorDestination;
        private int _radius;

        public Ball()
        {
        }

        public Ball(Vector2 vector)
        {
            _vectorCurrent = vector;
            _radius = 15;
        }

        public Ball(int x, int y, int radius, float speed)
        {
            _vectorCurrent.X = x;
            _vectorCurrent.Y = y;
            _radius = radius;
            _speed = speed;
            System.Random random = new System.Random();
            int edge = random.Next(1, 5);// 4 - down, 1 - right, 3 - up, 2 - left
            if (edge == 1 )
            {
                _vectorDestination.X = Storage.width - _radius;
                _vectorDestination.Y = random.Next(_radius, Storage.height - _radius);
            } else if (edge == 2)
            {
                _vectorDestination.X = _radius;
                _vectorDestination.Y = random.Next(_radius, Storage.height - _radius);
            } else if (edge == 3)
            {
                _vectorDestination.Y = Storage.height - _radius;
                _vectorDestination.X = random.Next(_radius, Storage.width - _radius);
            } else
            {
                _vectorDestination.Y = _radius;
                _vectorDestination.X = random.Next(_radius, Storage.width - _radius);
            }
        }

        public void generateNewVectorDestination()
        {
            System.Random random = new System.Random();
            int edge; // 4 - down, 1 - right, 3 - up, 2 - left
            if (_vectorCurrent.X == _radius)
            {
                edge = 2;   
            }
            else if (_vectorCurrent.X == Storage.width - _radius)
            {
                edge = 1;
            }
            else if (_vectorCurrent.Y == _radius)
            {
                edge = 4;
            }
            else
            {
                edge = 3;
            }
            int finalowa;
            int wylosowana = random.Next(1, 4);
            if (edge > wylosowana)
            {
                finalowa = wylosowana;
            } else if (wylosowana == 3)
            {
                finalowa = 4;
            } else
                finalowa = edge + wylosowana ;
            float XCoordinate;
            float YCoordinate;
            if (finalowa < 3)
            { 
                YCoordinate = random.Next(_radius, Storage.height - _radius);
                XCoordinate = (finalowa % 2) * (Storage.width - 2 * _radius) + _radius;

            } else
            {
                XCoordinate = random.Next(_radius, Storage.width - _radius);
                YCoordinate = ((finalowa - 2) % 2) * (Storage.height - 2 * _radius) + _radius;
            }
            _vectorDestination.X = XCoordinate;
            _vectorDestination.Y = YCoordinate;
            double howManyChanges = Math.Sqrt((Math.Pow(_vectorCurrent.X - _vectorDestination.X, 2) + Math.Pow(_vectorCurrent.Y - _vectorDestination.Y, 2))) / _speed;

        }

        public void UpdatePosition()
        {
            if (_vectorCurrent == _vectorDestination)
            {
                generateNewVectorDestination();
            }
            double howManyChanges = Math.Sqrt((Math.Pow(_vectorCurrent.X - _vectorDestination.X, 2) + Math.Pow(_vectorCurrent.Y - _vectorDestination.Y, 2))) / _speed;
            if (howManyChanges == 0)
            {
                _vectorCurrent = _vectorDestination;
            } else
            {
                _vectorCurrent.X += (float)(Math.Abs(_vectorCurrent.X - _vectorDestination.X) / howManyChanges);
                _vectorCurrent.Y += (float)(Math.Abs(_vectorCurrent.Y - _vectorDestination.Y) / howManyChanges);
            }
            
        }
    }
}