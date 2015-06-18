using System;

namespace Sharper
{

    public class ExecuteAround : IDisposable
    {

        public ExecuteAround(Action pre, Action post)
        {
            pre();

            _post = post;
        }

        public void Dispose()
        {
            _post();
        }

        private readonly Action _post;
    }

    
}
