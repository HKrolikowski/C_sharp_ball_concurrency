using Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Numerics;
using System.Threading;
using System.Threading.Tasks;

namespace Logic
{
    public class Storage : LogicApi
    {
        private DataAbstractApi dataAbstract;
        public static int width = 800;
        public static int height = 400;
        private Generator _generator = new Generator();
        private ObservableCollection<Ball> _balls = new ObservableCollection<Ball>();
        private List<Task> _tasks = new List<Task>();
        CancellationTokenSource tokenSource;
        CancellationToken token;

        public Storage()
        {
        }

        public void AddBall(Ball ball)
        {
            _balls.Add(ball);
        }

        public void RemoveBall(Ball ball)
        {
            _balls.Remove(ball);
        }

        public void CreateBalls(int number)
        {
            if (number > 0)
            {
                tokenSource = new CancellationTokenSource();
                token = tokenSource.Token;
                for (int i = 0; i < number; i++)
                {
                    Ball ball = _generator.GenerateBall();
                    AddBall(ball);
                }
            }
            
        }

        public void StopBalls()
        {   
            if (tokenSource != null && !tokenSource.IsCancellationRequested)
            {
                tokenSource.Cancel();
                _tasks.Clear();
                _balls.Clear();
            }
        }

        public async void Moving()
        {
            //Trace.WriteLine("Zaczynamy ruszac kule");
            foreach (Ball ball in _balls)
            {
                Task task = Task.Run(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(5);
                        ball.UpdatePosition();
                        try { token.ThrowIfCancellationRequested(); }
                        catch (System.OperationCanceledException) { break; } //Rzuca OperationCanceledException jeżeli jest zgłoszone cancel.
                    }
                });
                _tasks.Add(task);
                _tasks.Add(Task.Run(() => Collisions()));
            }
        }

        public async void Collisions()
        { 
            while(true)
            {
                //Jezeli Ball1.Velocity.X jest +AND Ball1.Pos.X > Ball2.Pos.X AND Ball2.Velocity.X jest -
                try {
                for (int i = 0; i < _balls.Count - 1; i++)
                {
                    for (int j = i + 1; j < _balls.Count; j++)
                    {  
                                /*if (!((_balls[i].VX > 0 && _balls[j].VX < 0 && _balls[i].X > _balls[j].X) 
                                || (_balls[i].VX < 0 && _balls[j].VX > 0 && _balls[i].X < _balls[j].X) 
                                || (_balls[i].VY > 0 && _balls[j].VY < 0 && _balls[i].Y > _balls[j].Y)
                                || (_balls[i].VY < 0 && _balls[j].VY > 0 && _balls[i].Y < _balls[j].Y)))
                            {*/
                            float distance = Vector2.Distance(_balls[i].VectorCurrent, _balls[j].VectorCurrent);
                            if (distance <= (_balls[i].Radius + _balls[j].Radius))
                            {
                                if (Vector2.Distance(_balls[i].VectorCurrent, _balls[j].VectorCurrent) // do poprawy laczenie pilek po odbiciu
                                - Vector2.Distance(_balls[i].VectorCurrent + _balls[i].Velocity, _balls[j].VectorCurrent + _balls[i].Velocity) > 0)
                                {
                                    _balls[i].CanMove = false;
                                    _balls[j].CanMove = false;
                                    BallCrash(_balls[i], _balls[j]);
                                    _balls[i].CanMove = true;
                                    _balls[j].CanMove = true;
                                }
                            }
                            
                         
                    }
                }
                }
                catch (System.ArgumentOutOfRangeException) { break; }
            } 
        }
        public void BallCrash(Ball b1, Ball b2)
        {
            //Trace.WriteLine("Doszlo do zderzenia");
            //Vector2 newVelocity1 = b1.Velocity - 2 * b2.Mass / (b1.Mass + b2.Mass) * Vector2.Dot(b1.Velocity - b2.Velocity, b1.VectorCurrent - b2.VectorCurrent) / Vector2.DistanceSquared(b1.VectorCurrent, b2.VectorCurrent) * (b1.VectorCurrent - b2.VectorCurrent);
            //Vector2 newVelocity2 = b2.Velocity - 2 * b1.Mass / (b1.Mass + b2.Mass) * Vector2.Dot(b2.Velocity - b1.Velocity, b2.VectorCurrent - b1.VectorCurrent) / Vector2.DistanceSquared(b2.VectorCurrent, b1.VectorCurrent) * (b2.VectorCurrent - b1.VectorCurrent);


            Vector2 newVelocity1 = (b1.Velocity * (b1.Mass - b2.Mass) + b2.Velocity * 2 * b2.Mass) / (b1.Mass + b2.Mass);
            Vector2 newVelocity2 = (b2.Velocity * (b2.Mass - b1.Mass) + b1.Velocity * 2 * b1.Mass) / (b1.Mass + b2.Mass);
            //Trace.WriteLine(b1.Velocity);
            //Trace.WriteLine(newVelocity1);
            //Trace.WriteLine(b2.Velocity);
            //Trace.WriteLine(newVelocity2);
            //Trace.WriteLine("");

            b1.Velocity = newVelocity1;
            b2.Velocity = newVelocity2;
        }

        public Generator Generator
        {
            get => _generator;
        }

        public ObservableCollection<Ball> Balls
        {
            get => _balls;
        }

        public List<Task> Tasks
        {
            get => _tasks;
        }

    }
}