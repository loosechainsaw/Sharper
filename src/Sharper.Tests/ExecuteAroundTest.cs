using NUnit.Framework;

namespace Sharper.Tests
{
    [TestFixture]
    public class ExecuteAroundTest
    {

        [Test]
        public void MethodIsCalled()
        {
            var v = 0;
            var x = 0;

            using (var t = new ExecuteAround(() =>
            {
                x = 6;
            }, () =>
            {
                v = 5;
            }))
            {
                v = 1;
            }

            Assert.AreEqual(5, v);
            Assert.AreEqual(6, x);
        }
    }
}