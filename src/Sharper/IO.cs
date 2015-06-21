using System;

namespace Sharper
{

    public class IO<A>
    {
        public IO(Func<A> run)
        {
            this.run = run;
        }

        public A PerformUnsafeIO()
        {
            return run();
        }

        public virtual IO<B> Map<B>(Func<A, B> m)
        {
            return new IO<B>(() => m(run()));
        }

        public virtual IO<B> FlatMap<B>(Func<A, IO<B>> m)
        {
            return new IO<B>(() => m(run()).run());
        }

        protected internal Func<A> run;
    }


}

