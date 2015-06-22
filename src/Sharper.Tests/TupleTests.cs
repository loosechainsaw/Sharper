using System;
using NUnit.Framework;

namespace Sharper.Tests
{
    [TestFixture]
    public class TupleTests
    {

        [Test]
        public void TestingFst()
        {
            Assert.AreEqual(5, Tuple.Create(5, 6).Fst());
        }

        [Test]
        public void TestingSnd()
        {
            Assert.AreEqual(6, Tuple.Create(5, 6).Snd());
        }
    }

}