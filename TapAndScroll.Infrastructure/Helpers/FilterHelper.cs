using System.Globalization;
using TapAndScroll.Application.HelperContracts;
using TapAndScroll.Core.Models;

namespace TapAndScroll.Infrastructure.Helpers
{
    public class FilterHelper : IFilterHelper
    {
        public bool DoAloneQuery(Product product, string targetKey, string targetValue)
        {
            var pr = from p in product.Parameters
                     where p.Key.Contains(targetKey) && p.Value == targetValue
                     select p;

            if (pr.Count() > 0) { return true; }
            return false;
        }

        public bool DoRangeQuery(Product product, string targetKey, decimal beginValue, decimal endValue)
        {
            var pr = from p in product.Parameters
                     where p.Key.Contains(targetKey) && decimal.Parse(p.Value, CultureInfo.InvariantCulture) >= beginValue 
                     && decimal.Parse(p.Value, CultureInfo.InvariantCulture) <= endValue
                     select p;

            if (pr.Count() > 0) { return true; }
            return false;
        }

        public string GetCorrectValue(AdditionalParameters parameters)
        {
            var targetValue = parameters.Value;
            if (parameters.Value == "on")
            {
                targetValue = "true";
            }
            else if (parameters.Value == "off")
            {
                targetValue = "false";
            }

            return targetValue;
        }

        public bool GetCorrectValues(AdditionalParameters parameters, out decimal beginValue, out decimal endValue)
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
