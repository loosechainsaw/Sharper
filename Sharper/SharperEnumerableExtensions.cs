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

        public static IEnumerable<B> Scan<A, B>(this IEnumerable<A> sequence, Func<B, A, B> f, B accum)
        {
            foreach (A value in sequence)
            {
                accum = f(accum, value);
                yield return accum;
            }
        }

        public static Tuple<IEnumerable<A>, IEnumerable<A>> PartitionAt<A>(this IEnumerable<A> source, int position)
        {
            return Tuple.Create(source.Take(position), source.Skip(position));
        }

        public static Int32 Product(this IEnumerable<Int32> source)
        {
            return source.Aggregate(1, (a, b) => a * b);
        }

        public static IEnumerable<A> Flatten<A>(this IEnumerable<IEnumerable<A>> source)
        {
            return source.SelectMany(x => x);
        }

        public static IEnumerable<A> Cycle<A>(this IEnumerable<A> source)
        {
            for(;;) {
                foreach(var item in source)
                    yield return item;
            }
        }

        public static A Aggregate<A>(this IEnumerable<A> source, Monoid<A> monoid)
        {
            A zero = monoid.Zero;

            foreach (A element in source)
            {
                zero = monoid.Sum(zero, element);
            }

            return zero;
        }

        public static B FoldMap<A, B>(this IEnumerable<A> source, Monoid<B> monoid, Func<A, B> f)
        {
            B zero = monoid.Zero;

            foreach (A element in source)
            {
                zero = monoid.Sum(zero, f(element));
            }

            return zero;
        }
    }
}
