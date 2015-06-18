using System;
using NUnit.Framework;

namespace Sharper.Tests
{

    [TestFixture]
    public class PartialApTests
    {

        [Test]
        public void Testing2ParamFunc()
        {
            Func<int, int, int> f = (a, b) => a + b;

            var g = Partially.Apply(f, 5);

            Assert.AreEqual(11, g(6));
        }

        [Test]
        public void Testing2ParamFuncSupplyingBoth()
        {
            Func<int, int, int> f = (a, b) => a + b;

            var g = Partially.Apply(f, 5, 6);

            Assert.AreEqual(11, g());
        }

        [Test]
        public void Testing3ParamFunctionSupplying1Arg()
        {
            Func<int, int, int, int> f = (a, b, c) => a + b + c;

            var g = Partially.Apply(f, 5);

            Assert.AreEqual(18, g(6, 7));

        }

        [Test]
        public void Testing3ParamFunctionSupplying2Arg()
        {
            Func<int, int, int, int> f = (a, b, c) => a + b + c;

            var g = Partially.Apply(f, 5, 6);

            Assert.AreEqual(18, g(7));

        }

        [Test]
        public void Testing3ParamFunctionSupplying3Arg()
        {
            Func<int, int, int, int> f = (a, b, c) => a + b + c;

            var g = Partially.Apply(f, 5, 6, 7);

            Assert.AreEqual(18, g());

        }


    }
}