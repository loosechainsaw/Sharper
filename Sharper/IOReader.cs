using System;

namespace Sharper
{

    public class IOReader<A,B>
    {
        public IOReader(IO<Reader<A,B>> n)
        {
            this._n = n;
        }

        public IOReader<A,C> Map<C>(Func<B,C> f)
        {
            return _n.Map(z => z.Map(f)).ReaderT();
        }

        public IOReader<A,D> Map<C,D>(Func<B, IOReader<A,D>> f)
        {
            return null;
        }

        private readonly IO<Reader<A,B>> _n;
    }

}
