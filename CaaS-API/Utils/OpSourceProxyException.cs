using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CaaSAPI.Utils
{
    public class OpSourceProxyException: Exception
    {
        public OpSourceProxyException(Type proxyType, string message)
            : base(message)
        { }
    }
}
