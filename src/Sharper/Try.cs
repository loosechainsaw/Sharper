using System;

namespace Sharper
{

    public static class Try
    {
        public static Option<A> RunO<A>(Func<A> f)
        {
            try {
                return f().ToOption();
            } catch {
                return new None<A>();
            }
        }

        public static Either<Exception,B> RunE<B>(Func<B> f)
        {
            try {
                return new Right<Exception, B>(f());
            } catch(Exception e) {
                return new Left<Exception, B>(e);
            }
        }
    }

}
