using System;
using System.Collections.Generic;
using System.Management.Automation;

namespace DD.CBU.Compute.Powershell
{
	/// <summary>
	///		Extension methods for working with PowerShell <see cref="SessionState"/>.
	/// </summary>
	/// <remarks>
	///		TODO: Add getter / setter for default connection.
	/// </remarks>
	public static class SessionStateExtensions
	{
		#region Constants

		/// <summary>
		///		Statically-cached empty list of compute service connections.
		/// </summary>
		/// <remarks>
		///		Returned when there are no active compute service connections.
		/// </remarks>
		static readonly IReadOnlyList<ComputeServiceConnection> EmptyConnectionList = new ComputeServiceConnection[0];

		/// <summary>
		///		Variable name constants.
		/// </summary>
		public static class VariableNames
		{
			/// <summary>
			///		The name of the PowerShell variable in which active cloud-compute sessions are stored.
			/// </summary>
			public static readonly string ComputeSessions = "_CloudComputeSessions";
		}

		#endregion // Constants

		/// <summary>
		///		Get all active CaaS connections in the current session.
		/// </summary>
		/// <param name="sessionState">
		///		The current PowerShell session state.
		/// </param>
		/// <returns>
		///		A read-only list of active <see cref="ComputeServiceConnection">connection</see>s.
		/// </returns>
		public static IReadOnlyList<ComputeServiceConnection> GetComputeServiceConnections(this SessionState sessionState)
		{
			if (sessionState == null)
				throw new ArgumentNullException("sessionState");

			PSVariable connectionsVariable = sessionState.PSVariable.Get(VariableNames.ComputeSessions);
			if (connectionsVariable == null)
				return EmptyConnectionList;

			List<ComputeServiceConnection> connections = (List<ComputeServiceConnection>)connectionsVariable.Value;
			if (connections == null || connections.Count == 0)
				return EmptyConnectionList;

			return connections.ToArray();
		}

		/// <summary>
		///		Add the specified CaaS connection to the current session.
		/// </summary>
		/// <param name="sessionState">
		///		The current PowerShell session state.
		/// </param>
		/// <param name="connection">
		///		A <see cref="ComputeServiceConnection"/> representing the CaaS connection.
		/// </param>
		/// <returns>
		///		The <paramref name="connection"/> (enables inline use / method-chaining).
		/// </returns>
		/// <exception cref="ArgumentNullException">
		///		<paramref name="connection"/> is <c>null</c>.
		/// </exception>
		public static ComputeServiceConnection AddComputeServiceConnection(this SessionState sessionState, ComputeServiceConnection connection)
		{
			if (sessionState == null)
				throw new ArgumentNullException("sessionState");

			if (connection == null)
				throw new ArgumentNullException("connection");

			List<ComputeServiceConnection> connections;
			PSVariable connectionsVariable = sessionState.PSVariable.Get(VariableNames.ComputeSessions);
			if (connectionsVariable == null)
			{
				connectionsVariable = new PSVariable(
					VariableNames.ComputeSessions,
					value:
						connections = new List<ComputeServiceConnection>(),
					options:
						ScopedItemOptions.AllScope
					);
				sessionState.PSVariable.Set(connectionsVariable); // AF: If this is getting serialised (can't remember), then you need to call Set() AFTER updating the collection.
			}
			else
			{
				connections = (List<ComputeServiceConnection>)connectionsVariable.Value;
				if (connections == null)
				{
					connectionsVariable.Value = connections = new List<ComputeServiceConnection>();
					sessionState.PSVariable.Set(connectionsVariable); // AF: If this is getting serialised (can't remember), then you need to call Set() AFTER updating the collection.
				}
			}

			if (!connections.Contains(connection))
				connections.Add(connection);

			return connection;
		}

		/// <summary>
		///		Remove the specified CaaS connection from the current session.
		/// </summary>
		/// <param name="sessionState">
		///		The current PowerShell session state.
		/// </param>
		/// <param name="connection">
		///		A <see cref="ComputeServiceConnection"/> representing the CaaS connection.
		/// </param>
		/// <returns>
		///		<c>true</c>, if the connection was removed from the session; <c>false</c>, if the connection wasn't present in the session.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		///		<paramref name="connection"/> is <c>null</c>.
		/// </exception>
		public static bool RemoveComputeServiceConnection(this SessionState sessionState, ComputeServiceConnection connection)
		{
			if (sessionState == null)
				throw new ArgumentNullException("sessionState");

			if (connection == null)
				throw new ArgumentNullException("connection");

			PSVariable connectionsVariable = sessionState.PSVariable.Get(VariableNames.ComputeSessions);
			if (connectionsVariable == null)
				return false;

			List<ComputeServiceConnection> connections = (List<ComputeServiceConnection>)connectionsVariable.Value;
			if (connections == null)
				return false;

			return connections.Remove(connection);
		}
	}
}
