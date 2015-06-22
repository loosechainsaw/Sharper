using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Sharper.Tests
{
    [TestFixture]
    public class PersistentListTests
    {

        [Test]
        public void When_adding_a_set_of_numbers_we_should_be_able_to_manually_aggregate_them()
        {

            var list = 1.Cons(2.Cons(3.Cons(new Nil<int>())));
            var sum = list.FoldLeft(0, (x, y) => x + y);
            Assert.AreEqual(6, sum);
        }

        [Test]
        public void When_adding_a_large_set_of_numbers_we_should_be_able_to_manually_aggregate_them()
        {

            var list = Enumerable.Range(1,10000).Apply();
            var sum = list.FoldLeft(0, (x, y) => x + y);
            Assert.AreEqual(50005000, sum);
        }

        [Test]
        public void When_taking_a_subset_less_than_the_count_of_the_list()
        {
            var list = Enumerable.Range(1, 100).Apply().Reverse();
            var subset = list.Take(3);
            var sum = subset.FoldLeft(0, (x, y) => x + y);
            Assert.AreEqual(6, sum);
        }

        [Test]
        public void When_dropping_a_subset_less_than_the_count_of_the_list()
        {
            var list = Enumerable.Range(1, 100).Apply().Reverse().Drop(98);

            var sum = list.FoldLeft(0, (x, y) => x + y);
            Assert.AreEqual(199, sum);
        }

        [Test]
        public void When_calculating_the_number_of_items_in_a_list()
        {
            var list = Enumerable.Range(1, 100).Apply();
            Assert.AreEqual(100, list.Count());
        }

        [Test]
        public void When_foreaching_the_list()
        {
            var list = Enumerable.Range(1, 3).Apply().Reverse();
            var updated = new List<int>();

            list.Foreach(updated.Add);

            CollectionAssert.AreEqual(new List<int>{ 1,2,3}, updated);
        }
    }
}