using System;

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
            if (string.IsNullOrWhiteSpace(Field) || Value == null)
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
                default:
                    throw new NotSupportedException("Unknown filter operator type.");
            }

            var valueString = Value.ToString();

            if (Value.GetType() == typeof(DateTime))
                valueString = ((DateTime)Value).ToString("o");

            if (Value.GetType() == typeof(DateTimeOffset))
                valueString = ((DateTimeOffset)Value).ToString("o");

            if (Value.GetType() == typeof(bool))
                valueString = valueString.ToLower();

            return Field + operatorString + valueString;
        }
    }
}
