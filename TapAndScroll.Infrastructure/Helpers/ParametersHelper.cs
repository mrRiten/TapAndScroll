using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TapAndScroll.Application.HelperContracts;
using TapAndScroll.Core.Models;

namespace TapAndScroll.Infrastructure.Helpers
{
    public class ParametersHelper : IParametersHelper
    {

        public List<AdditionalParameters> CreateListParameters(string input, int productId)
        {
            var parameters = new List<AdditionalParameters>();

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

                    var parameter = new AdditionalParameters
                    {
                        ProductId = productId,
                        Key = key,
                        Value = value
                    };

                    parameters.Add(parameter);
                }
            }

            return parameters;
        }
    }
}
