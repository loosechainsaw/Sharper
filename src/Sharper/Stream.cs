using System;

namespace Sharper.Streaming
{

    public interface Stream<out A>
    {

    }

    public class Empty<A> : Stream<A>
    {
        
    }

    public class Cons<A> : Stream<A>
    {
        
    }

}
