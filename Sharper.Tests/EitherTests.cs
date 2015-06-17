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

        [Test]
        public void When_mapping_over_a_structure_using_comprehension_syntax_that_is_right_i_should_get_an_updated_value()
        {
            var t = (from a in new Right<Exception,int>(5)
                              select a + 1).GetValueOrDefault(0);
            Assert.AreEqual(6, t);
        }

        [Test]
        public void When_flat_mapping_over_a_structure_using_comprehension_syntax_that_is_right_i_should_get_an_updated_value()
        {
            var t = (from a in new Right<Exception,int>(5)
                              from b in new Right<Exception,int>(6)
                              select a + b).GetValueOrDefault(0);
            Assert.AreEqual(11, t);
        }
    }
}
