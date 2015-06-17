using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sharper.Tests
{


    [TestFixture]
    public class OptionTests
    {

        public class Person
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

    }

}

