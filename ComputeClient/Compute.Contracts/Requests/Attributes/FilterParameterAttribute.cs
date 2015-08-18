namespace DD.CBU.Compute.Api.Contracts.Requests.Attributes
{
    using System;

    /// <summary>
    /// The attribute must be applied to filter properties to defined the API parameter name.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class FilterParameterAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FilterParameterAttribute"/> class.
        /// </summary>
        /// <param name="parameterName">
        /// The name of the parameter.
        /// </param>
        public FilterParameterAttribute(string parameterName)
        {
            if (String.IsNullOrEmpty(parameterName))
                throw new ArgumentNullException("parameterName");

            ParameterName = parameterName;
            Operator = null;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FilterParameterAttribute"/> class.
        /// </summary>
        /// <param name="parameterName">
        /// The name of the parameter.
        /// </param>
        /// <param name="operator">
        /// The operator of the parameter.
        /// </param>
        public FilterParameterAttribute(string parameterName, string @operator)
        {
            if (String.IsNullOrEmpty(parameterName))
                throw new ArgumentNullException("parameterName");
            if (String.IsNullOrEmpty(@operator))
                throw new ArgumentNullException("operator");

            ParameterName = parameterName;
            Operator = @operator;
        }

        /// <summary>
        /// Gets the name of the parameter;
        /// </summary>
        public string ParameterName { get; private set; }

        /// <summary>
        /// Gets the operator of the parameter;
        /// </summary>
        public string Operator { get; private set; }
    }
}
