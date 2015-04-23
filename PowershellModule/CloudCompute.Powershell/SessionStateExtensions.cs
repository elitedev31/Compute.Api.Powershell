using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Runtime.CompilerServices;

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
	    private static readonly IReadOnlyDictionary<string, ComputeServiceConnection> EmptyConnectionList =
	        new Dictionary<string, ComputeServiceConnection>();

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


	    private static string _defaultComputeServiceConnectionName;

        /// <summary>
        /// Retrieve the dictonary with all connections from session
        /// </summary>
        /// <param name="sessionState"></param>
        /// <returns></returns>
        private static Dictionary<string, ComputeServiceConnection> GetComputeServiceConnectionsFromSession(SessionState sessionState)
	    {

            if (sessionState == null)
                throw new ArgumentNullException("sessionState");

            PSVariable connectionsVariable = sessionState.PSVariable.Get(VariableNames.ComputeSessions);
            if (connectionsVariable == null)
                return null;

            Dictionary<string, ComputeServiceConnection> connections = (Dictionary<string, ComputeServiceConnection>)connectionsVariable.Value;
	        return connections;

	    }
		/// <summary>
		///		Get all active CaaS connections in the current session.
		/// </summary>
		/// <param name="sessionState">
		///		The current PowerShell session state.
		/// </param>
		/// <returns>
		///		A read-only list of active <see cref="ComputeServiceConnection">connection</see>s.
		/// </returns>
		public static IReadOnlyDictionary<string,ComputeServiceConnection> GetComputeServiceConnections(this SessionState sessionState)
		{
		    var connections = GetComputeServiceConnectionsFromSession(sessionState);
			if (connections == null || connections.Count == 0)
				return EmptyConnectionList;

		    return connections;
		}


        public static ComputeServiceConnection GetComputeServiceConnectionByName(this SessionState sessionState, string name)
        {
          
            if(string.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");

            var connections = GetComputeServiceConnectionsFromSession(sessionState);
            if (connections == null || connections.Count == 0)
                return null;
            if (connections.ContainsKey(name))
                return connections[name];

            return null;
        }

        /// <summary>
	    /// Default Caas Connection 
	    /// </summary>
	    public static ComputeServiceConnection GetDefaultComputeServiceConnection(this SessionState sessionState)
        {
            var connections = GetComputeServiceConnectionsFromSession(sessionState);
            if (!connections.ContainsKey(_defaultComputeServiceConnectionName))
                    return null;
            return connections[_defaultComputeServiceConnectionName];


        }

       


        /// <summary>
        /// Default Caas Connection 
        /// </summary>
        public static void SetDefaultComputeServiceConnection(this SessionState sessionState, string connectionName)
        {


            var connections = GetComputeServiceConnectionsFromSession(sessionState);
            if(!connections.ContainsKey(connectionName))
                throw new IndexOutOfRangeException("connectionName does not exisits");
            _defaultComputeServiceConnectionName = connectionName;

        }


	    ///  <summary>
	    /// 		Add the specified CaaS connection to the current session.
	    ///  </summary>
	    ///  <param name="sessionState">
	    /// 		The current PowerShell session state.
	    ///  </param>
	    /// <param name="name">the name for the connection</param>
	    /// <param name="connection">
	    /// 		A <see cref="ComputeServiceConnection"/> representing the CaaS connection.
	    ///  </param>
	    ///  <returns>
	    /// 		The <paramref name="connection"/> (enables inline use / method-chaining).
	    ///  </returns>
	    ///  <exception cref="ArgumentNullException">
	    /// 		<paramref name="connection"/> is <c>null</c>.
	    ///  </exception>
        public static ComputeServiceConnection AddComputeServiceConnection(this SessionState sessionState, string connectionName, ComputeServiceConnection connection)
		{
			if (sessionState == null)
				throw new ArgumentNullException("sessionState");

			if (connection == null)
				throw new ArgumentNullException("connection");


            if (string.IsNullOrEmpty(connectionName))
                throw new ArgumentNullException("connectionName");


			Dictionary<string,ComputeServiceConnection> connections;
			PSVariable connectionsVariable = sessionState.PSVariable.Get(VariableNames.ComputeSessions);
			if (connectionsVariable == null)
			{
				connectionsVariable = new PSVariable(
					VariableNames.ComputeSessions,
					value:
                        connections = new Dictionary<string, ComputeServiceConnection>(),
					options:
						ScopedItemOptions.AllScope
					);
				sessionState.PSVariable.Set(connectionsVariable); // AF: If this is getting serialised (can't remember), then you need to call Set() AFTER updating the collection.
			}
			else
			{
                connections = (Dictionary<string, ComputeServiceConnection>)connectionsVariable.Value;
				if (connections == null)
				{
                    connectionsVariable.Value = connections = new Dictionary<string, ComputeServiceConnection>();
					sessionState.PSVariable.Set(connectionsVariable); // AF: If this is getting serialised (can't remember), then you need to call Set() AFTER updating the collection.
				}
			}

	        if (!connections.ContainsKey(connectionName))
	            connections.Add(connectionName, connection);
	        else
	            connections[connectionName] = connection;

             if (string.IsNullOrEmpty(_defaultComputeServiceConnectionName) || connections.Count().Equals(1))
                 _defaultComputeServiceConnectionName = connectionName;

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
		public static bool RemoveComputeServiceConnection(this SessionState sessionState, string connectionName)
		{
			if (sessionState == null)
				throw new ArgumentNullException("sessionState");

            if (string.IsNullOrEmpty(connectionName))
                throw new ArgumentNullException("connectionName");

			PSVariable connectionsVariable = sessionState.PSVariable.Get(VariableNames.ComputeSessions);
			if (connectionsVariable == null)
				return false;

            Dictionary<string, ComputeServiceConnection> connections = (Dictionary<string, ComputeServiceConnection>)connectionsVariable.Value;
			if (connections == null)
				return false;
            
            return connections.Remove(connectionName);
		}
	}
}
