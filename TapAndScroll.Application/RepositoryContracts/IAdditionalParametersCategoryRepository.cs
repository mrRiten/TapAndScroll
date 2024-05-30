using TapAndScroll.Core.Models;

namespace TapAndScroll.Application.RepositoryContracts
{
    public interface IAdditionalParametersCategoryRepository
    {
        public Task CreateAsync(AdditionalParametersCategory[] additionalParameters);
        public Task UpdateAsync(AdditionalParametersCategory additionalParameters);
        public Task DeleteAsync(int categoryId);
        public Task<ICollection<AdditionalParametersCategory>> GetByCategoryIdAsync(int categoryId);
    }
}
