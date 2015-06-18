using System;

namespace Sharper
{

    public class EitherOption<A,B>
    {
        public EitherOption(Either<A, Option<B>> inner)
        {
            _inner = inner;
        }

        private readonly Either<A, Option<B>> _inner;
    }
        
}
