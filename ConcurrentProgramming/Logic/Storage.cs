using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Logic
{
    public class Storage
    {
        public static int width = 800;
        public static int height = 400;
        private Generator _generator = new Generator();
        private ObservableCollection<Ball> _balls = new ObservableCollection<Ball>();
        private List<Task> _tasks;
        public int wide = 30;

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
            _tasks = new List<Task>();
            for (int i = 0; i < number; i++)
            {
                Ball ball = _generator.GenerateBall();
                AddBall(ball);
            }
        }

        public void Moving()
        {
            foreach (Ball ball in _balls)
            {
                Thread.Sleep(1);
                Task task = Task.Run(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(5);
                        ball.UpdatePosition();
                    }

                });
                _tasks.Add(task);
            }
            //Task.WaitAll(_tasks.ToArray());//chyba tak
        }

        public Generator Generator
        {
            get => _generator;
        }

        public ObservableCollection<Ball> Balls
        {
            get => _balls;
            set => _balls = value ?? throw new ArgumentNullException(nameof(value));
        }

    }
}