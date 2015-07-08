namespace DD.CBU.Compute.Api.Contracts.Requests
{
	public interface IPageableRequest
	{
		/// <summary>	The size of the paged results required. </summary>
		int PageSize { get; set; }

		/// <summary>	The page number. </summary>
		int PageNumber { get; set; }

		/// <summary>	Comma separated list of
		/// fieldNames, each with an optional,
		/// directional keyword. By default
		/// each fieldName will be in
		/// ascending order unless otherwise
		/// documented.. </summary>
		string Order { get; set; }
	}
}