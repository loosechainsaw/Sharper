using System;
using System.Collections.Generic;

namespace Sharper
{

    public class ExecuteAround : IDisposable
    {

        public ExecuteAround(Action pre, Action post)
        {
            pre();

            this.post = post;
        }

        public void Dispose()
        {
            post();
        }

        private readonly Action post;
    }

    
}
