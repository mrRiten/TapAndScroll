using TapAndScroll.Core.Models;

namespace TapAndScroll.Application.HelperContracts
{
    public interface IParametersHelper
    {
        public ICollection<AdditionalParameters> CreateListParameters(string input, int productId);
    }
}
