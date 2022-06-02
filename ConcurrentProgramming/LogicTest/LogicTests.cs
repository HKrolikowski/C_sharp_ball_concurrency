using NUnit.Framework;
using Logic;
using Data;
using System.Numerics;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace LogicTest
{
    public class LogicTests
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void TestLogicApi()
        {
            DataAbstractApi data = new DataApi();
            LogicAbstractApi logic = new LogicApi(data); 
            Assert.True(logic.Height == 400);
            Assert.True(logic.Width == 800);
            logic.CreateBalls(2);
            ObservableCollection<Ball> balls = logic.Balls;
            Assert.True(balls.Count == 2);
            Assert.True(balls[0].X < logic.Width);
            Assert.True(balls[0].Y < logic.Height);
            Assert.True(balls[0].X > 0);
            Assert.True(balls[0].Y > 0);
            List<BallLogic> ballsLogic = logic.GetBalls();
            Assert.True(ballsLogic[0].Ball == balls[0]);
            logic.StopBalls();
            Assert.True(balls.Count == 0);
        }

        [Test]
        public void TestLogic()
        {
            DataAbstractApi data = new DataApi();
            LogicApi logic = new LogicApi(data);
            logic.CreateBalls(1); Vector2 velocity = new Vector2(1, 1);
            Ball ball1 = new Ball(-5, -20, 10, 2, velocity);
            Assert.True(ball1.VX == 1);
            logic.Collisions(800, 400, ball1.Radius, ball1);
            Assert.True(ball1.VX == -1);
            Vector2 velocity2 = new Vector2(2, 1.5f);
            Vector2 velocity3 = new Vector2(-1, -0.3f);
            Ball ball2 = new Ball(30, 20, 10, 2, velocity);
            Ball ball3 = new Ball(40, 25, 10, 2, velocity);
            logic.BallCrash(ball2, ball3);
            Assert.True(ball2.VX != velocity2.X);
            Assert.True(ball2.VY != velocity2.Y);
            Assert.True(ball3.VX != velocity3.X);
            Assert.True(ball3.VY != velocity3.Y);
        }
    }
}