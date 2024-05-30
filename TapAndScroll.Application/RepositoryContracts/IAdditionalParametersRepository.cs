using TapAndScroll.Core.Models;

namespace TapAndScroll.Infrastructure.Repositories
{
    public interface IAdditionalParametersRepository
    {
        public Task CreateAsync(AdditionalParameters[] additionalParameters);
        public Task UpdateAsync(AdditionalParameters[] additionalParameters);
        public Task DeleteAsync(int id);
        public Task<ICollection<AdditionalParameters>> GetAll(int categoryId);
    }
}
