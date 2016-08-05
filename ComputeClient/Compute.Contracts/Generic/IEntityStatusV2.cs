namespace DD.CBU.Compute.Api.Contracts.Generic
{
    /// <summary>
    /// An entity in the MCP2.0 API that has a status.
    /// </summary>
    public interface IEntityStatusV2
    {
        /// <summary>
        /// Entity ID
        /// </summary>
        string id { get; }

        /// <summary>
        /// Provisioned state
        /// </summary>
        string state { get; }
    }
}
