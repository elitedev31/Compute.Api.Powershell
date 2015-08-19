// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CloudComputePsException.cs" company="">
//   
// </copyright>
// <summary>
//   The cloud compute ps exception.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace DD.CBU.Compute.Powershell
{
	/// <summary>
	///     The cloud compute ps exception.
	/// </summary>
	public class CloudComputePsException : Exception
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="CloudComputePsException"/> class. 
		/// Initialises a new instance of the <see cref="CloudComputePsException"/> class.
		/// </summary>
		/// <param name="message">
		/// The message.
		/// </param>
		public CloudComputePsException(string message) : base(message)
		{
		}
	}
}