using System;
using NUnit.Framework;

namespace Sharper.Tests
{

    [TestFixture]
    public class MatchTests
    {

        [Test]
        public void TestingMatchingAndActions()
        {
            var option = 5.ToOption();

            var result = Match.Object(option)
                .Case(x => x.IsNone, () => 1)
                .Case(x => x.IsSome, () => option.GetValueOrDefault(2))
                .Yield();

            Assert.AreEqual(5, result);
        }

        [Test]
        public void TestingMatchingAndFuncs()
        {
            var option = 5.ToOption();

            var result = Match.Object(option)
                .Case(x => x.IsNone, () => 1)
                .Case(x => x.IsSome, _ => _.GetValueOrDefault(2))
                .Yield();

            Assert.AreEqual(5, result);
        }

        [Test]
        public void TestingTypeMatches1()
        {
            var option = 5.ToOption();

            var result = Match.Object(option)
                              .Returning<int>()
                              .When<None<int>>(() => 1)
                              .When<Some<int>>(_ => _.GetValueOrDefault(2))
                              .Yield();

            Assert.AreEqual(5, result);
        }

        [Test]
        public void TestingTypeMatches2()
        {
            var option = new None<int>();

            var result = Match.Object(option)
                              .Returning<int>()
                              .When<None<int>>(() => 1)
                              .When<Some<int>>(_ => _.GetValueOrDefault(2))
                              .Yield();

            Assert.AreEqual(1, result);
        }
    }
}