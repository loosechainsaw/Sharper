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
    }
}