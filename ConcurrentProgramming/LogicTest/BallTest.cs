using NUnit.Framework;
using Logic;
using System.Numerics;

namespace LogicTest
{
    public class BallTests
    {
        [SetUp]
        public void Setup()
        {
        }
        /*
        [Test]
        public void BallConstructor()
        {
            Ball ball = new Ball(2, 3, 5, 2);
            Assert.True(ball.VectorCurrent.X == 2);
            Assert.True(ball.VectorCurrent.Y == 3);
            //Ball ball = new Ball(2, 3, 5, 2);

            float destX = ball.VectorDestination.X;
            float destY = ball.VectorDestination.Y;            //ball.VectorCurrent
       
            Assert.True(destX == 5 || destX == Storage.width - 5 || destY == 5 || destY == Storage.height - 5);
            Assert.False(destX == 3);
            Assert.False(destX == Storage.height - 2);
            Assert.True(ball.Diameter == 10);
            Assert.True(ball.Speed == 2);
        }

        [Test]
        public void GenerateDestinationTest()
        {
            Ball ball = new Ball(5, 33, 5, 2);//punkt na lewej scianie
            ball.generateNewVectorDestination();
            Assert.True(ball.VectorDestination.X > 5 && ball.VectorDestination.Y >= 5 && ball.VectorDestination.Y <= Storage.height - 5
                && ball.VectorDestination.X <= Storage.width - 5);
            Ball ball2 = new Ball(33, 5, 5, 2);//punkt na dolnej scianie
            ball2.generateNewVectorDestination();
            Assert.True(ball2.VectorDestination.X >= 5 && ball2.VectorDestination.Y > 5 && ball2.VectorDestination.Y <= Storage.height - 5
                && ball2.VectorDestination.X <= Storage.width - 5);
            Ball ball3 = new Ball(Storage.width - 5, 33, 5, 2);//punkt na prawej scianie
            ball3.generateNewVectorDestination();
            Assert.True(ball3.VectorDestination.X >= 5 && ball3.VectorDestination.Y >= 5 && ball3.VectorDestination.Y <= Storage.height - 5
                && ball3.VectorDestination.X < Storage.width - 5);
            Ball ball4 = new Ball(33, Storage.height - 5, 5, 2);//punkt na gornej scianie
            ball4.generateNewVectorDestination();
            Assert.True(ball4.VectorDestination.X >= 5 && ball4.VectorDestination.Y >= 5 && ball4.VectorDestination.Y < Storage.height - 5
                && ball4.VectorDestination.X <= Storage.width - 5);

        }

        [Test]
        public void UpdatePositionTest()
        {
            Ball ball = new Ball(10, 10, 5, 2);
            Vector2 first = ball.VectorCurrent;
            Vector2 second = new Vector2(20, 10);
            ball.VectorDestination = second;
            ball.UpdatePosition();
            Assert.AreEqual(Vector2.Distance(ball.VectorCurrent, first), System.Math.Ceiling(2f));
            Assert.AreEqual(12, System.Math.Ceiling(ball.VectorCurrent.X));
            Assert.AreEqual(10, ball.VectorCurrent.Y);
        }*/
    }
}