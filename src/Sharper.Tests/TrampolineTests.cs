using NUnit.Framework;

namespace Sharper.Tests
{

    [TestFixture]
    public class TrampolineTests
    {

        [Test]
        public void TestingSimpleCaseRet()
        {
            var ret = new Return<int>(5);
            var result = Interpreter.Run(ret);
            Assert.AreEqual(5, result);
        }
    }
}