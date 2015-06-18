using System;
using NUnit.Framework;

namespace Sharper.Tests
{

    [TestFixture]
    public class CurryTests
    {

        [Test]
        public void Testing2ParamFunction()
        {
            Func<int, int, int> f = (a, b) => a + b;

            var g = Curry.Function(f);

            Assert.AreEqual(11, g(5)(6));

        }

        [Test]
        public void Testing3ParamFunction()
        {
            Func<int, int, int, int> f = (a, b, c) => a + b + c;

            var g = Curry.Function(f);

            Assert.AreEqual(18, g(5)(6)(7));

        }

        [Test]
        public void Testing4ParamFunction()
        {
            Func<int, int, int, int, int> f = (a, b, c, d) => a + b + c + d;

            var g = Curry.Function(f);

            Assert.AreEqual(26, g(5)(6)(7)(8));

        }


    }
}