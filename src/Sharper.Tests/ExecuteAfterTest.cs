using NUnit.Framework;

namespace Sharper.Tests
{
    [TestFixture]
    public class ExecuteAfterTest
    {

        [Test]
        public void MethodIsCalled()
        {
            var v = 0;

            using (var t = new ExecuteAfter(() =>
            {
                v = 5;
            }))
            {
                v = 1;
            }

            Assert.AreEqual(5,v );
        }
    }
}