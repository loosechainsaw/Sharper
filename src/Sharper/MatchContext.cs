using System;
using System.Collections.Generic;

namespace Sharper
{

    public class MatchContext<A,B>
    {
        public MatchContext(A subject, Tuple<Func<A, bool>, Func<B>> t)
        {
            this.subject = subject;
            l.Add(t);
        }

        public MatchContext<A,B> Case(Func<A, bool> predicate, Func<B> f)
        {
            l.Add(Tuple.Create(predicate, f));
            return this;
        }

        public B Yield()
        {
            foreach(var a in l) {
                if(a.Item1(subject))
                    return a.Item2();
            }

            throw new MatchException();
        }

        private List<Tuple<Func<A, bool>, Func<B>>> l = new List<Tuple<Func<A, bool>, Func<B>>>();
        private readonly A subject;
    }
    
}
