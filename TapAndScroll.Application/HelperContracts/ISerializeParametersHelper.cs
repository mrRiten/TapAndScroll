using TapAndScroll.Core.Models;

namespace TapAndScroll.Application.HelperContracts
{
    public interface ISerializeParametersHelper
    {
        public Dictionary<string, string> Serialize(string input);
        public ICollection<Product> GetByParameter(ICollection<Product> products, string parameterName, string parameter);
    }
}
