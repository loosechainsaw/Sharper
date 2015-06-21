using NUnit.Framework;
using System;

namespace Sharper.Tests
{


    [TestFixture]
    public class OptionTests
    {
        private class Person
        {

            public Person(string surname, string middlename, string firstname)
            {
                Firstname = firstname.ToOption();
                MiddleName = middlename.ToOption();
                Surname = surname ?? String.Empty;
            }

            public Option<String> Firstname{ get; private set; }

            public Option<String> MiddleName{ get; private set; }

            public String Surname{ get; private set; }
        }

        [Test]
        public void Mapping_an_option_with_a_value_should_produce_a_new_option_with_an_updated_value()
        {
            var initial = 5.ToOption();
            var inc = initial.Map(x => x + 1);

            Assert.AreEqual(inc, 6.ToOption());
        }

        [Test]
        public void Mapping_an_option_with_a_value_should_produce_a_new_option_with_an_updated_value_with_linq_syntax()
        {
            var initial = 5.ToOption();
            var inc = from i in initial
                               select i + 1;

            Assert.AreEqual(inc, 6.ToOption());
        }

        [Test]
        public void FlatMapping_should_return_the_correct_value()
        {
            var human = new Person("Smith", "Douglas", "Patrick");
            var result = human.Firstname
                              .FlatMap(fn => human.MiddleName
                                                  .Map(mm => String.Format("{0} {1} {2}", fn, mm, human.Surname)))
                              .GetValueOrDefault(human.Surname);
            Assert.AreEqual("Patrick Douglas Smith", result);
        }

        [Test]
        public void FlatMapping_should_return_the_correct_value_with_linq_syntax()
        {

            var human = new Person("Smith", "Douglas", "Patrick");
            var result = (from fn in human.Firstname
                                   from mm in human.MiddleName
                                   select String.Format("{0} {1} {2}", fn, mm, human.Surname))
                            .GetValueOrDefault(human.Surname);

            Assert.AreEqual("Patrick Douglas Smith", result);
        }

        [Test]
        public void TestingSomeIsSome()
        {
            Assert.IsTrue(new Some<Int32>(5).IsSome);
        }

        [Test]
        public void TestingSomeIsNone()
        {
            Assert.IsFalse(new Some<Int32>(5).IsNone);
        }

        [Test]
        public void OptionFilteringStartingWithSomeSuccess()
        {
            var a = new Some<int>(5);

            Assert.AreEqual(5, a.Filter(x => x <= 5).GetValueOrDefault(0));

        }

        [Test]
        public void OptionFilteringStartingWithSomeFail()
        {
            var a = new Some<int>(5);

            Assert.AreEqual(0, a.Filter(x => x > 5).GetValueOrDefault(0));

        }

        [Test]
        public void TestingNoneIsSome()
        {
            Assert.IsFalse(new None<Int32>().IsSome);
        }

        [Test]
        public void TestingNoneIsNone()
        {
            Assert.IsTrue(new None<Int32>().IsNone);
        }

        [Test]
        public void NoneOrElseReturnsOther()
        {
            Assert.AreEqual(5, new None<int>().OrElse(new Some<int>(5)).GetValueOrDefault(5));
        }

        [Test]
        public void Mapping_over_none_does_nothing()
        {
            Assert.AreEqual(5, new None<int>().Map(x => x.Succ()).GetValueOrDefault(5));
            Assert.AreNotEqual(1, new None<int>().Map(x => x.Succ()).GetValueOrDefault(5));
        }

    }
}

