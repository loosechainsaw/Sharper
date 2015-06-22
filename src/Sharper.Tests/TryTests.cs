using System;
using NUnit.Framework;

namespace Sharper.Tests
{

    [TestFixture]
    public class TryTests
    {

        private Option<Decimal> Divide(int a, int b)
        {
            return Try.RunO(() => (Decimal)a / b);
        }

        [Test]
        public void TestingOptionallyTryWithException()
        {
            var opt = Divide(3, 0);
            Assert.IsTrue(opt.IsNone);
        }

        [Test]
        public void TestingOptionallyTryWithoutException()
        {
            var opt = Divide(30, 5);
            Assert.AreEqual(6, opt.GetValueOrDefault(0));

        }
    }
}