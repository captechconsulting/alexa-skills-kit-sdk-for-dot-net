using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ask.Sdk.Runtime.Dispatcher
{
    public interface IRequestDispatcher<TInput, TOutput>
    {
        Task<TOutput> Dispatch(TInput input);
    }
}
