using System;

namespace Sharper
{

    public static class Match
    {
        public static Match<A> Object<A>(A o)
        {
            return new Match<A>(o);
        }
    }

    public class Match<A>
    {
        public Match(A subject)
        {
            this.subject = subject;
        }

        public MatchContext<A,B> Case<B>(Func<A, bool> predicate, Func<B> f)
        {
            return new MatchContext<A, B>(subject, Tuple.Create(predicate, f));
        }

        private readonly A subject;
    }
}
