using TapAndScroll.Application.HelperContracts;
using TapAndScroll.Core.Models;

namespace TapAndScroll.Infrastructure.Helpers
{
    public class SerializeParametersHelper : ISerializeParametersHelper
    {
        public ICollection<Product> GetByParameter(ICollection<Product> products, string parameterName, string parameter)
        {
            var sortedList = new List<Product>();

            foreach (var product in products)
            {
                if (product.Parameters.TryGetValue(parameterName, out string value))
                {
                    if (value == parameter)
                    {
                        sortedList.Add(product);
                    }
                }
            }

            return sortedList;
        }

        public Dictionary<string, string> Serialize(string input)
        {
            var parameters = new Dictionary<string, string>();

            if (input.EndsWith(","))
            {
                input.TrimEnd(',');
            }

            var pairs = input.Split(',');

            foreach ( var pair in pairs )
            {
                var keyValue = pair.Split(':');
                if ( keyValue.Length == 2 )
                {
                    var key = keyValue[0].Trim();
                    var value = keyValue[1].Trim();
                    parameters[key] = value;
                }
            }

            return parameters;
        }
    }
}
