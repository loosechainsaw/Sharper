using System.Linq;
using NUnit.Framework;
using System.Collections.Generic;

namespace Sharper.Tests
{

    [TestFixture]
    public class ObjectExtensionTests
    {

        [Test]
        public void TestingReplicate()
        {
            var v = 5;
            var r = v.Replicate(3);

            CollectionAssert.AreEqual(new List<int> { 5, 5, 5 }, r);
        }

        [Test]
        public void TestingRepeat()
        {
            var v = 5;
            var r = v.Repeat().Take(3);

            CollectionAssert.AreEqual(new List<int> { 5, 5, 5 }, r);
        }
    }
}