using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace DD.CBU.Compute.Powershell
{
    public static class Extensions
    {

        internal static string ToPlainString(this SecureString value)
        {
            var valuePtr = IntPtr.Zero;
            string unsecurestring;
            try
            {
                valuePtr = Marshal.SecureStringToGlobalAllocUnicode(value);
                unsecurestring =  Marshal.PtrToStringUni(valuePtr);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(valuePtr);
            }

            return unsecurestring;
        }

    }
}
