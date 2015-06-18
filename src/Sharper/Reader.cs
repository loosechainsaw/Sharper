using System;

namespace Sharper
{

    public class Reader<A,B>
    {
        public Reader(Func<A,B> f)
        {
            _f = f;   
        }

        public Reader<A,C> Map<C>(Func<B,C> m)
        {
            return new Reader<A, C>(e => m(_f(e)));
        }

        public Reader<A,C> FlatMap<C>(Func<B,Reader<A,C>> m)
        {
            return new Reader<A, C>(e => m(_f(e))._f(e));
        }

        private readonly Func<A,B> _f;
    }

}
