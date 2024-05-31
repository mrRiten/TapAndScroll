using TapAndScroll.Core.Models;

namespace TapAndScroll.Application.HelperContracts
{
    public interface IParametersHelper
    {
        public List<AdditionalParameters> CreateListParameters(string input, int productId);
    }
}
