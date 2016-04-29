namespace DD.CBU.Compute.Powershell.Mcp20.Model
{
    public enum TagKeyNameIdType
    {
        /// <summary>
        /// The tag key id.
        /// </summary>
        TagKeyId,

        /// <summary>
        /// The tag key name.
        /// </summary>
        TagKeyName,
    }

    public class TagKeyNameIdElement
    {
        public TagKeyNameIdType TagKeyNameIdType { get; set; }

        public string Item { get; set; }
    }
}
