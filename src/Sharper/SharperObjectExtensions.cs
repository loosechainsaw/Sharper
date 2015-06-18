using System.Collections.Generic;

namespace Sharper
{

    public static class SharperObjectExtensions
    {
        public static IEnumerable<A> Repeat<A>(this A value)
        {
            for(;;) {
                yield return value;
            }
        }

        public static IEnumerable<A> Replicate<A>(this A value, int n)
        {
            for(int i = 1; i <= n; ++i) {
                yield return value;
            }
        }
    }
    
}
