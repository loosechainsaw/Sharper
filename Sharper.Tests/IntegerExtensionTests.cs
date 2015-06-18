using NUnit.Framework;

namespace Sharper.Tests
{
    [TestFixture]
    public class IntegerExtensionTests
    {

        [Test]
        public void TestingSucc()
        {
            var a = 5;
            Assert.AreEqual(6,a.Succ());
        }

        [Test]
        public void TestingPred()
        {
            var a = 5;
            Assert.AreEqual(4, a.Pred());
        }

        [Test]
        public void TestingNegate()
        {
            var a = 5;
            Assert.AreEqual(-5, a.Negate());
        }

        [Test]
        public void TestingEven()
        {
            Assert.IsTrue(4.IsEven());
        }

        [Test]
        public void TestingEven2()
        {
            Assert.False(5.IsEven());
        }

        [Test]
        public void TestingOdd()
        {
            Assert.IsTrue(5.IsOdd());
        }

        [Test]
        public void TestingOdd2()
        {
            Assert.False(4.IsOdd());
        }
    }
}