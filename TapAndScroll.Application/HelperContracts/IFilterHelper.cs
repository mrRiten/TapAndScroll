using TapAndScroll.Core.Models;

namespace TapAndScroll.Application.HelperContracts
{
    public interface IFilterHelper
    {
        /// <summary>
        /// Checks if the product matches the given range query parameters.
        /// </summary>
        /// <param name="product">The product to check.</param>
        /// <param name="key">The key of the parameter to check.</param>
        /// <param name="beginValue">The beginning value of the range.</param>
        /// <param name="endValue">The end value of the range.</param>
        /// <returns>True if the product matches the range query; otherwise, false.</returns>
        public bool DoRangeQuery(Product product, string targetKey, decimal beginValue, decimal endValue);

        /// <summary>
        /// Checks if the product matches the given single query parameter.
        /// </summary>
        /// <param name="product">The product to check.</param>
        /// <param name="key">The key of the parameter to check.</param>
        /// <param name="value">The value of the parameter to check.</param>
        /// <returns>True if the product matches the single query; otherwise, false.</returns>
        public bool DoAloneQuery(Product product, string targetKey, string targetValue);
        
        /// <summary>
        /// Parses the parameter value to extract the beginning and end values for range queries.
        /// </summary>
        /// <param name="parameter">The parameter containing the range value.</param>
        /// <param name="beginValue">The extracted beginning value of the range.</param>
        /// <param name="endValue">The extracted end value of the range.</param>
        /// <returns>True if parsing was successful; otherwise, false.</returns>
        public bool GetCorrectValues(AdditionalParameters parameters, out decimal beginValue, out decimal endValue);

        public string GetCorrectValue(AdditionalParameters parameters);
    }
}
