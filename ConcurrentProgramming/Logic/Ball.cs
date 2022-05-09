using System.ComponentModel;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Logic
{
    public class Ball : INotifyPropertyChanged
    {
        private Vector2 _vectorCurrent;
        private int _radius;
        private float _mass;
        private Vector2 _velocity;
        //ped = mass*velocity
        private bool _canMove = true;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Ball()
        {
        }

        public Ball(Vector2 vector)
        {
            _vectorCurrent = vector;
            _radius = 15;
        }

        public Ball(float x, float y, int radius, float mass, Vector2 velocity)
        {
            _vectorCurrent.X = x;
            _vectorCurrent.Y = y;
            _radius = radius;
            _mass = mass;
            _velocity = velocity;
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
            int destinationWall;
            int wall = random.Next(1, 4);
            if (edge > wall)
            {
                destinationWall = wall;
            }
            else if (wall == 3)
            {
                destinationWall = 4;
            }
            else
                destinationWall = edge + wall;
            float XCoordinate;
            float YCoordinate;
            if (destinationWall < 3)
            {
                YCoordinate = random.Next(_radius, Storage.height - _radius);
                XCoordinate = (destinationWall % 2) * (Storage.width - 2 * _radius) + _radius;
            }
            else
            {
                XCoordinate = random.Next(_radius, Storage.width - _radius);
                YCoordinate = ((destinationWall - 2) % 2) * (Storage.height - 2 * _radius) + _radius;
            }
            //_vectorDestination.X = XCoordinate;
            //_vectorDestination.Y = YCoordinate;
        }

        public void UpdatePosition()
        {
            if (_canMove)
            {
                _vectorCurrent += _velocity;


                //Odbicia od scian
                if (VectorCurrent.X + Velocity.X > Storage.width - Radius)
                {
                    X = Storage.width - Radius;
                    VX = Velocity.X * (-1);
                } 
                else if (VectorCurrent.X + Velocity.X < Radius)
                {
                    X = Radius;
                    VX = Velocity.X * (-1);
                }
                else if (VectorCurrent.Y + Velocity.Y > Storage.height - Radius)
                {
                    Y = Storage.height - Radius;
                    VY = Velocity.Y * (-1);
                }
                else if (VectorCurrent.Y + Velocity.Y < Radius)
                {
                    Y = Radius;
                    VY = Velocity.Y * (-1);
                }


                RaisePropertyChanged(nameof(X));
                RaisePropertyChanged(nameof(Y));
            }
            
        }


        public Vector2 VectorCurrent
        {
            get => _vectorCurrent;
            set => _vectorCurrent = value;
        }
        public Vector2 Velocity
        {
            get => _velocity;
            set => _velocity = value;
        }

        public int Diameter
        {
            get => 2 * _radius;
        }

        public float X
        {
            get => _vectorCurrent.X;
            set => _vectorCurrent.X = value;
        }

        public float Y
        {
            get => _vectorCurrent.Y;
            set => _vectorCurrent.Y = value;
        }

        public float VX
        {
            get => _velocity.X;
            set => _velocity.X = value;
        }

        public float VY
        {
            get => _velocity.Y;
            set => _velocity.Y = value;
        }

        public int Radius
        {
            get => _radius;
        }
        public float Mass
        {
            get => _mass;
            set => _mass = value;
        }

        public bool CanMove
        {
            get => _canMove;
            set => _canMove = value;
        }
    }
}