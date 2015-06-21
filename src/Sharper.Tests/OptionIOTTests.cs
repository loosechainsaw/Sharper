using NUnit.Framework;
using System;

namespace Sharper.Tests
{

    [TestFixture]
    public class OptionIOTTests
    {

        [Test]
        public void Mapping_over_it_should_return_a_new_value_if_it_contains_a_some()
        {
            var s = 5.ToOption().ToOptionIO();
            var t = s.Map(f => f + 1).PerformUnsafeIO();
            var z = t.GetValueOrDefault(0);

            Assert.AreEqual(6, z);
        }

        [Test]
        public void Mapping_over_it_with_comphrension_syntax_should_return_a_new_value_if_it_contains_a_some()
        {
           
            var t = (from a in 5.ToOption().ToOptionIO()
                              select a + 1)
                .PerformUnsafeIO()
                .GetValueOrDefault(0);
            Assert.AreEqual(6, t);
        }

        public IO<Option<int>> GetValue()
        {
            return 5.ToOption().ToIO();
        }

        [Test]
        public void Mapping_over_it_with_comprehension_syntax_after_lifting_it_into_a_transformer()
        {
            var t = (from z in GetValue().OptionT()
                              select z + 1);
            var u = t.PerformUnsafeIO();
            var v = u.GetValueOrDefault(0);
            Assert.AreEqual(6, v);
        }
    }

}
