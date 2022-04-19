using System;
using System.Collections.Generic;

namespace Logic
{
    public class Storage
    {
        public static int width = 600;
        public static int height = 400;
        private List<Ball> _balls = new List<Ball>();
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

        public void CreateBall()
        {
            Ball ball = new Ball();
        }


    }
}
