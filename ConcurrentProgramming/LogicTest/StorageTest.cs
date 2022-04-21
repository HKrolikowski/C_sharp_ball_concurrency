using NUnit.Framework;
using Logic;
using System.Numerics;

namespace LogicTest
{
    public class StorageTests
    {

        [Test]
        public void CreateBallsTest()
        {
            Storage storage = new Storage();
            int numberBalls0 = storage.Balls.Count;
            Assert.True(numberBalls0 == 0);
            storage.CreateBalls(0);
            Assert.True(numberBalls0 == storage.Balls.Count);
            storage.CreateBalls(2);
            Assert.False(numberBalls0 == storage.Balls.Count);
            Assert.True(2 == storage.Balls.Count);
            storage.CreateBalls(3);
            Assert.True(5 == storage.Balls.Count);
        }

        [Test]
        public void StopBallsTest()
        {
            Storage storage = new Storage();
            storage.CreateBalls(3);
            Assert.True(3 == storage.Balls.Count);
            storage.StopBalls();
            Assert.True(0 == storage.Balls.Count);
            storage.CreateBalls(2);
            storage.CreateBalls(2);
            Assert.True(4 == storage.Balls.Count);
            storage.StopBalls();
            Assert.True(0 == storage.Balls.Count);
        }

        [Test]
        public void MovingTest()
        {
            Storage storage = new Storage();
            storage.CreateBalls(2);
            float ball0X = storage.Balls[0].VectorCurrent.X;
            float ball0Y = storage.Balls[0].VectorCurrent.Y;
            float ball1X = storage.Balls[1].VectorCurrent.X;
            float ball1Y = storage.Balls[1].VectorCurrent.Y;
            System.Threading.Thread.Sleep(1000);
            Assert.True(ball0X == storage.Balls[0].VectorCurrent.X);
            Assert.True(ball0Y == storage.Balls[0].VectorCurrent.Y);
            Assert.True(ball1X == storage.Balls[1].VectorCurrent.X);
            Assert.True(ball1Y == storage.Balls[1].VectorCurrent.Y);
            storage.Moving();
            System.Threading.Thread.Sleep(1000);
            Assert.True(ball0X != storage.Balls[0].VectorCurrent.X);
            Assert.True(ball0Y != storage.Balls[0].VectorCurrent.Y);
            Assert.True(ball1X != storage.Balls[1].VectorCurrent.X);
            Assert.True(ball1Y != storage.Balls[1].VectorCurrent.Y);

        }
    }
}