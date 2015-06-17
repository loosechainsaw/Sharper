using System;
using System.Collections.Generic;

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

        public static Func<A, Func<B,C>> Function<A,B,C>(Func<Tuple<A,B>,C> f)
        {
            return a => b => f(Tuple.Create(a, b));
        }
    }
    
}
