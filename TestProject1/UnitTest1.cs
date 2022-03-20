using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestIsBit()
        {
            projekt_wsp.Bajt b = new projekt_wsp.Bajt(65);
            Assert.IsTrue(b.isBit(0));
            Assert.IsFalse(b.isBit(1));
            Assert.IsFalse(b.isBit(10));
            Assert.IsFalse(b.isBit(-2));
        }
        [TestMethod]
        public void TestSetBitZero()
        {
            projekt_wsp.Bajt b = new projekt_wsp.Bajt(65);
            Assert.IsTrue(b.isBit(0));
            b.setBitZero(0);
            Assert.IsTrue(!b.isBit(0));
            Assert.IsTrue(b.Wartosc == 64);
            b.setBitZero(10);
            Assert.IsTrue(b.Wartosc == 64);

        }
        [TestMethod]
        public void TestSetBitOne()
        {
            projekt_wsp.Bajt b = new projekt_wsp.Bajt(65);
            Assert.IsTrue(!b.isBit(1));
            b.setBitOne(1);
            Assert.IsTrue(b.isBit(1));
            Assert.IsTrue(b.Wartosc == 67);
            b.setBitZero(-2);
            Assert.IsTrue(b.Wartosc == 67);
        }
        [TestMethod]
        public void TestGetSetWartosc()
        {
            projekt_wsp.Bajt b = new projekt_wsp.Bajt(65);
            Assert.IsTrue(b.Wartosc == 65);
            Assert.IsTrue(b.isBit(0));
            b.Wartosc = 64;
            Assert.IsTrue(b.Wartosc == 64);
            b.Wartosc = 300;
            Assert.IsTrue(b.Wartosc == 64);
        }
    }
}