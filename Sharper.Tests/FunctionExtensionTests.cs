using System;
using NUnit.Framework;

namespace Sharper.Tests
{
    [TestFixture]
    public class FunctionExtensionTests
    {

        [Test]
        public void TestingCompose()
        {
            Func<int, int> f = arg => arg * arg;
            Func<int, int> g = arg => arg + 1;

            var h = f.Compose(g);

            Assert.AreEqual(9, h(2));
        }
    }
}