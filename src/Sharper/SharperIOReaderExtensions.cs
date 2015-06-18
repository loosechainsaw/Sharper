using System;

namespace Sharper
{

    public static class SharperIOReaderExtensions
    {
        public static IOReader<A,B> ReaderT<A,B>(this IO<Reader<A,B>> n)
        {
            return new IOReader<A, B>(n);
        }
    }
}
