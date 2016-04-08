namespace DD.CBU.Compute.Api.Contracts.Requests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Server20;

    /// <summary>
    /// The interface need to be implemented by requests which support filtering options.
    /// </summary>
	public class FilterableRequest : IFilterableRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FilterableRequest"/> class.
        /// </summary>
        public FilterableRequest()
        {
            Filters = new List<Filter>();
        }

        /// <summary>
        /// Gets the filters.
        /// </summary>
        public IList<Filter> Filters { get; set; }

        /// <summary>
        /// Gets the filter value.
        /// </summary>
        /// <typeparam name="T">The value type</typeparam>
        /// <param name="field">The field name.</param>
        protected T GetFilter<T>(string field)
        {
            var filter = Filters.FirstOrDefault(f => f.Field == field);

            if (filter != null)
            {
                return (T)Convert.ChangeType(filter.Value, typeof(T));
            }

            return default(T);
        }

        /// <summary>
        /// Gets the filter value.
        /// </summary>
        /// <typeparam name="T">The value type</typeparam>
        /// <param name="field">The field name.</param>
        /// <param name="operator">The filter operator.</param>
        protected T GetFilter<T>(string field, FilterOperator @operator)
        {
            var filter = Filters.FirstOrDefault(f => f.Field == field && f.Operator == @operator);

            if (filter != null)
            {
                return (T)Convert.ChangeType(filter.Value, typeof(T));
            }

            return default(T);
        }

        /// <summary>
        /// Sets the filter value.
        /// </summary>
        /// <param name="field">The field name.</param>
        /// <param name="value">The value.</param>
        protected void SetFilter(string field, object value)
        {
            if (value is NullFilterOptions)
            {
                var op = ((NullFilterOptions)value == NullFilterOptions.NULL) ? FilterOperator.Null : FilterOperator.NotNull;
                SetFilter(field, op, string.Empty);
            }
            else
            {
                var op = (value is string && value.ToString().Contains("*")) ? FilterOperator.Like : FilterOperator.Equals;
                SetFilter(field, op, value);
            }
        }

        /// <summary>
        /// Sets the filter value.
        /// </summary>
        /// <param name="field">The field name.</param>
        /// <param name="operator">The filter operator.</param>
        /// <param name="value">The value.</param>
        protected void SetFilter(string field, FilterOperator @operator, object value)
        {
            var filter = Filters.FirstOrDefault(f => f.Field == field);

            if (value == null)
            {
                if (filter != null)
                {
                    Filters.Remove(filter);
                }
            }
            else
            {
                if (filter == null)
                {
                    filter = new Filter
                    {
                        Field = field
                    };

                    Filters.Add(filter);
                }

                filter.Operator = @operator;
                filter.Value = value;
            }
        }
    }
}