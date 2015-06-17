using NUnit.Framework;
using System;

namespace Sharper.Tests
{

    [TestFixture]
    public class EitherTests
    {

        [Test]
        public void When_mapping_over_a_structure_that_is_right_i_should_get_an_updated_value()
        {
            Either<Exception,int> a = new Right<Exception,int>(5);
            var b = a.Map(x => x + 1);
            var c = b.GetValueOrDefault(0);
            Assert.AreEqual(6, c);
        }
    }
}
