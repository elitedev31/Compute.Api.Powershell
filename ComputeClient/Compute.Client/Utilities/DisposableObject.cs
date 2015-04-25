// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DisposableObject.cs" company="">
//   
// </copyright>
// <summary>
//   Base class for disposable objects.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System;

namespace DD.CBU.Compute.Api.Client.Utilities
{
	/// <summary>
	/// Base class for disposable objects.
	/// </summary>
	public abstract class DisposableObject
		: IDisposable
	{
		/// <summary>
		/// Has the object been disposed?
		/// </summary>
		private bool _isDisposed;

		/// <summary>
		/// Has the object been disposed?
		/// </summary>
		protected bool IsDisposed
		{
			get { return _isDisposed; }
		}

		/// <summary>
		/// Dispose of resources being used by the disposable object.
		/// </summary>
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);

			_isDisposed = true;
		}

		/// <summary>
		/// Finalises an instance of the <see cref="DisposableObject"/> class. 
		/// Finaliser for <see cref="DisposableObject"/>.
		/// </summary>
		~DisposableObject()
		{
			Dispose(false);
		}

		/// <summary>
		/// Dispose of resources being used by the disposable object.
		/// </summary>
		/// <param name="disposing">
		/// Explicit disposal?
		/// </param>
		protected abstract void Dispose(bool disposing);

		/// <summary>
		/// Check if the object has been disposed.
		/// </summary>
		/// <exception cref="ObjectDisposedException">
		/// The object has been disposed.
		/// </exception>
		protected void CheckDisposed()
		{
			if (!_isDisposed)
				return;

			throw new ObjectDisposedException(
				GetType().Name
				);
		}
	}
}