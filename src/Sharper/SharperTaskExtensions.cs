using System;
using System.Threading.Tasks;

namespace Sharper
{

    public static class SharperTaskExtensions
    {
        public static Task<B> Select<A,B>(this Task<A> t, Func<A,B> f)
        {
            return t.ContinueWith(x => {
                return f(x.Result);
            }); 
        }

        public static Task<C> SelectMany<A,B,C>(this Task<A> t, Func<A,Task<B>> f, Func<A,B,C> n)
        {
            var b = t.ContinueWith(z => {
                var result = z.Result;
                var temp = f(result);
                var temp2 = temp.ContinueWith(d => {
                    return n(result, d.Result);
                });
                return temp2;
            });
            return b.Unwrap();
        }
    }

}
