using System;

namespace Sharper
{

    public class IOReader<A,B>
    {
        public IOReader(IO<Reader<A,B>> monad)
        {
            this.monad = monad;
        }

        public IOReader<A,C> Map<C>(Func<B,C> f)
        {
            return monad.Map(z => z.Map(f)).ReaderT();
        }

        public IOReader<A,D> FlatMap<C,D>(Func<B, IOReader<A,D>> f)
        {
            return new IO<Reader<A,D>>(() => {
                var reader = monad.PerformUnsafeIO();
                var g = reader.FlatMap(x => f(x).monad.PerformUnsafeIO());
                return g;
            }).ReaderT();
        }

        private readonly IO<Reader<A,B>> monad;
    }

}
