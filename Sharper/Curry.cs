using System;

namespace Sharper
{

    public static class Curry
    {
        public static Func<A, Func<B,C>> Function<A,B,C>(Func<A,B,C> f)
        {
            return a => b => f(a, b);
        }

        public static Func<A, Func<B,Func<C,D>>> Function<A,B,C,D>(Func<A,B,C,D> f)
        {
            return a => b => c => f(a, b, c);
        }

        public static Func<A, Func<B, Func<C, Func<D,E>>>> Function<A, B, C, D,E>(Func<A, B, C, D,E> f)
        {
            return a => b => c => d => f(a, b, c, d);
        }

        public static Func<A, Func<B, Func<C, Func<D, Func<E,F>>>>> Function<A, B, C, D, E, F>(Func<A, B, C, D, E, F> f)
        {
            return a => b => c => d => e => f(a, b, c, d, e);
        }

        public static Func<A, Func<B,C>> Function<A,B,C>(Func<Tuple<A,B>,C> f)
        {
            return a => b => f(Tuple.Create(a, b));
        }
    }
    
}
