using System;

namespace Sharper
{

    public static class SharperReaderExtensions
    {
        public static Reader<A,C> ToReader<A,C>(C value)
        {
            return new Reader<A, C>(_ => value);
        }

        public static Reader<A,C> Select<A,B,C>(this Reader<A,B> o, Func<B,C> f)
        {
            return o.Map(f);
        }

        public static Reader<A,D> SelectMany<A,B,C,D>(this Reader<A,B> o, Func<B, Reader<A,C>> f, Func<B,C,D> m)
        {
            return o.FlatMap(z => f(z).Map(y => m(z, y)));
        }
    }
}
