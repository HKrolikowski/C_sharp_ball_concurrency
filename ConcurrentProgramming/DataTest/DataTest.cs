using NUnit.Framework;
using Data;
using System.Numerics;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Diagnostics;

namespace DataTest
{

    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void dataApiTest()
        {
            DataAbstractApi data = new DataApi();
            Assert.True(data.Height == 400);
            Assert.True(data.Width == 800);
            data.CreateBalls(2);
            ObservableCollection<Ball> balls = data.GetStorage().Balls;
            Assert.True(balls.Count == 2);
            Assert.True(balls[0].X < data.Width);
            Assert.True(balls[0].Y < data.Height);
            Assert.True(balls[0].X > 0);
            Assert.True(balls[0].Y > 0);
            data.StopBalls();
            Assert.True(balls.Count == 0);
        }

        [Test]
        public void generateBallTest()
        {
            Generator generator = new Generator();
            Ball ball = generator.GenerateBall();
            Assert.True(ball.VectorCurrent.X >= 2 + generator.Radius && ball.VectorCurrent.X <= Storage._width - generator.Radius - 1);
            Assert.True(ball.VectorCurrent.Y >= 2 + generator.Radius && ball.VectorCurrent.Y <= Storage._height - generator.Radius - 1);
            Assert.True(ball.Mass <= 2 && ball.Mass > 0);
        }

        [Test]
        public void BallConstructor()
        {
            Vector2 velocity = new Vector2(1, 4);
            Ball ball = new Ball(2, 3, 5, 2, velocity);
            Assert.True(ball.VectorCurrent.X == 2);
            Assert.True(ball.VectorCurrent.Y == 3);
            Assert.True(ball.Radius == 5);
            Assert.True(ball.Mass == 2);
            Assert.True(ball.VX == 1);
            Assert.True(ball.VY == 4);
        }

        [Test]
        public void StorageCreateBallsTest()
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
        public void StorageStopBallsTest()
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
        public void fileExistTest()
        {
            Storage storage = new Storage();
            storage.CreateBalls(3);
            Thread.Sleep(1000);
            var fil1 = new FileInfo(storage.FileName);
            int length1 =  (int) fil1.Length;
            Assert.AreNotEqual(length1, 0);
            Thread.Sleep(3000);
            fil1 = new FileInfo(storage.FileName);
            int length2 = (int)fil1.Length;
            Assert.False(length1 == length2);
            storage.StopBalls();
            storage.CreateBalls(1);
            Thread.Sleep(100);
            fil1 = new FileInfo(storage.FileName);
            int length3 = (int)fil1.Length;
            Assert.True(length3 < length2);
        }
    }
}