using System;
using System.Collections.Generic;
using System.Linq;

namespace Sharper
{

    public static class SharperEnumerableExtensions
    {
        public static Tuple<IEnumerable<A>, IEnumerable<A>> PartitionWhen<A>(this IEnumerable<A> source, Func<A,Boolean> f)
        {
            var counter = 0;

            foreach(var item in source) {
                if(!f(item))
                    break;
                ++counter;
            }

            return PartitionAt(source, counter);

        }

        public static Tuple<IEnumerable<A>, IEnumerable<A>> PartitionAt<A>(this IEnumerable<A> source, int position) =>
        Tuple.Create(source.Take(position), source.Skip(position));

        public static Int32 Product(this IEnumerable<Int32> source) => source.Aggregate(1, (a, b) => a * b);

        public static IEnumerable<A> Flatten<A>(this IEnumerable<IEnumerable<A>> source) =>
        source.SelectMany(x => x);

        public static IEnumerable<A> Cycle<A>(this IEnumerable<A> source)
        {
            for(;;) {
                foreach(var item in source)
                    yield return item;
            }
        }
    }
    
}
