using System;
using System.Collections.Generic;

namespace Sharper
{

    public class MatchContext<A,B>
    {

        public MatchContext(A subject)
        {
            this.subject = subject;
        }

        public MatchContext(A subject, Tuple<Func<A, bool>, Func<B>> t)
        {
            this.subject = subject;
            var u = Tuple.Create<Func<A, bool>,Func<A, B>>(t.Fst(), (x) => t.Snd()());
            l.Add(u);
        }

        public MatchContext(A subject, Tuple<Func<A, bool>, Func<A, B>> t)
        {
            this.subject = subject;
            l.Add(t);
        }

        public MatchContext<A,B> When<C>(Func<B> f)
        {
            Func<A, bool> predicate = arg => arg.GetType().IsAssignableFrom(typeof(C));
            var u = Tuple.Create<Func<A, bool>,Func<A, B>>(predicate, (x) => f());
            l.Add(u);
            return this;
        }

        public MatchContext<A,B> When<C>(Func<A,B> f)
        {
            Func<A, bool> predicate = arg => arg.GetType().IsAssignableFrom(typeof(C));
            l.Add(Tuple.Create(predicate, f));
            return this;
        }

        public MatchContext<A,B> Case(Func<A, bool> predicate, Func<B> f)
        {
            var u = Tuple.Create<Func<A, bool>,Func<A, B>>(predicate, (x) => f());
            l.Add(u);
            return this;
        }

        public MatchContext<A,B> Case(Func<A, bool> predicate, Func<A,B> f)
        {
            l.Add(Tuple.Create(predicate, f));
            return this;
        }

        public B Yield()
        {
            foreach(var a in l) {
                if(a.Item1(subject))
                    return a.Item2(subject);
            }

            throw new MatchException();
        }

        private readonly List<Tuple<Func<A, bool>, Func<A,B>>> l = new List<Tuple<Func<A, bool>, Func<A,B>>>();
        private readonly A subject;
    }
    
}
