// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SecureStringExtensions.cs" company="">
//   
// </copyright>
// <summary>
//   The secure string extensions.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System;
using System.Runtime.InteropServices;
using System.Security;

namespace DD.CBU.Compute.Powershell
{
	/// <summary>
	/// The secure string extensions.
	/// </summary>
	public static class SecureStringExtensions
	{
		/// <summary>
		/// The to plain string.
		/// </summary>
		/// <param name="value">
		/// The value.
		/// </param>
		/// <returns>
		/// The <see cref="string"/>.
		/// </returns>
		internal static string ToPlainString(this SecureString value)
		{
			IntPtr valuePtr = IntPtr.Zero;
			string unsecurestring;
			try
			{
				valuePtr = Marshal.SecureStringToGlobalAllocUnicode(value);
				unsecurestring = Marshal.PtrToStringUni(valuePtr);
			}
			finally
			{
				Marshal.ZeroFreeGlobalAllocUnicode(valuePtr);
			}

			return unsecurestring;
		}
	}
}