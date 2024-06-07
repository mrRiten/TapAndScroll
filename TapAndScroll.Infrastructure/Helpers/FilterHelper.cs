using TapAndScroll.Application.HelperContracts;
using TapAndScroll.Core.Models;

namespace TapAndScroll.Infrastructure.Helpers
{
    public class FilterHelper : IFilterHelper
    {
        public bool DoAloneQuery(Product product, string targetKey, string targetValue)
        {
            var pr = from p in product.Parameters
                     where p.Key == targetKey && p.Value == targetValue
                     select p;

            if (pr.Any()) { return true; }
            return false;
        }

        public bool DoRangeQuery(Product product, string targetKey, decimal beginValue, decimal endValue)
        {
            var pr = from p in product.Parameters
                     where p.Key.Contains(targetKey) && decimal.Parse(p.Value) >= beginValue && decimal.Parse(p.Value) <= endValue
                     select p;

            if (pr.Any()) { return true; }
            return false;
        }

        public bool GetCorrectValue(AdditionalParameters parameters, out decimal beginValue, out decimal endValue)
        {
            beginValue = decimal.Parse(parameters.Value.Split("~")[0]);
            endValue = decimal.Parse(parameters.Value.Split("~")[1]);

            if (beginValue == endValue) { return false; }

            if (beginValue == decimal.Zero)
            {
                beginValue = decimal.MinValue;
            }
            if (endValue == decimal.Zero)
            {
                endValue = decimal.MaxValue;
            }

            if (beginValue > endValue) { return false; }
            return true;
        }
    }
}
