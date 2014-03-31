using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DD.CBU.Compute.Api.Client
{
    public static class Contracts
    {
        public static void Requires<TException>(Func<bool> predicate, string message)
        where TException : Exception, new()
        {
            if (predicate()) 
                return;
            Debug.WriteLine(message);
            throw new TException();
        }
    }
}
