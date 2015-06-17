using System;
using System.Collections.Generic;

namespace Sharper
{

    public static class Partially
    {
        public static Func<B,C> Apply<A,B,C>(Func<A,B,C> f, A first)
        {
            return b => f(first, b);
        }

        public static Func<C> Apply<A,B,C>(Func<A,B,C> f, A first, B second)
        {
            return () => f(first, second);
        }

        public static Func<B,C,D> Apply<A,B,C,D>(Func<A,B,C,D> f, A first)
        {
            return (b, c) => f(first, b, c);
        }

        public static Func<C,D> Apply<A,B,C,D>(Func<A,B,C,D> f, A first, B second)
        {
            return c => f(first, second, c);
        }

        public static Func<D> Apply<A,B,C,D>(Func<A,B,C,D> f, A first, B second, C third)
        {
            return () => f(first, second, third);
        }
    }
    
}
