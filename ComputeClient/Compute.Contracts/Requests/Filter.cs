using System;
using System.Web;

namespace DD.CBU.Compute.Api.Contracts.Requests
{
    /// <summary>
    /// A single request filter.
    /// </summary>
    public class Filter
    {
        /// <summary>
        /// Gets or sets the field name.
        /// </summary>
        public string Field { get; set; }

        /// <summary>
        /// Gets or sets the filter operator.
        /// </summary>
        public FilterOperator Operator { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        public object Value { get; set; }

        /// <summary>
        /// Returns a <see cref="String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            if (string.IsNullOrWhiteSpace(Field))
            {
                return string.Empty;
            }

            string operatorString;

            switch (Operator)
            {
                case FilterOperator.Equals:
                    operatorString = "=";
                    break;
                case FilterOperator.Like:
                    operatorString = ".LIKE=";
                    break;
                case FilterOperator.GreaterThan:
                    operatorString = ".GT=";
                    break;
                case FilterOperator.GreaterOrEqual:
                    operatorString = ".GE=";
                    break;
                case FilterOperator.LessThan:
                    operatorString = ".LT=";
                    break;
                case FilterOperator.LessOrEqual:
                    operatorString = ".LE=";
                    break;
                case FilterOperator.Null:
                    operatorString = ".NULL";
                    break;
                case FilterOperator.NotNull:
                    operatorString = ".NOT_NULL";
                    break;
                default:
                    throw new NotSupportedException("Unknown filter operator type.");
            }

            var valueString = (Value != null) ? Value.ToString() : string.Empty;

            if (Value is DateTime)
                valueString = ((DateTime)Value).ToUniversalTime().ToString("yyyy-MM-ddTHH\\:mm\\:ssZ");

            if (Value is DateTimeOffset)
                valueString = ((DateTimeOffset)Value).ToUniversalTime().ToString("yyyy-MM-ddThh\\:mm\\:ssZ");

            if (Value is bool)
                valueString = valueString.ToLower();
            
            return Field + operatorString + HttpUtility.UrlEncode(valueString);
        }
    }
}
