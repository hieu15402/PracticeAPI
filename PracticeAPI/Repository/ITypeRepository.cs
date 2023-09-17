using PracticeAPI.Entity;

namespace PracticeAPI.Repository
{
    public interface ITypeRepository
    {
        public Task<List<TypeEntity>> GetAllTypeAsync();
        public Task<TypeEntity> GetTypeById(int id);
        public Task<int> AddType(TypeEntity type);
        public Task UpdateType(int id, TypeEntity type);
        public Task DeleteType(int id);
    }
}
