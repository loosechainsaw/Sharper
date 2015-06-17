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
            var s = 5.ToOption().ToOptionIOT();
            var t = s.Map(f => f + 1).PerformUnsafeIO();
            var z = t.GetValueOrDefault(0);

            Assert.AreEqual(6, z);
        }

    }

}
