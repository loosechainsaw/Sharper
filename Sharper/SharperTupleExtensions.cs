using System;

namespace Sharper
{

    public static class SharperTupleExtensions
    {
        public static A Fst<A,_>(this Tuple<A,_> t) => t.Item1;

        public static B Snd<_,B>(this Tuple<_,B> t) => t.Item2;

    }


}
