using Microsoft.EntityFrameworkCore;
using PracticeAPI.Entity;

namespace PracticeAPI.Repository
{
    public class TypeRepository : ITypeRepository
    {
        private readonly MyDBContext _myDBContext;

        public TypeRepository(MyDBContext myDBContext)
        {
            _myDBContext = myDBContext;
        }

        public async Task<int> AddType(TypeEntity type)
        {
            _myDBContext.Add(type);
            await _myDBContext.SaveChangesAsync();
            return type.TypeId;
        }

        public async Task DeleteType(int id)
        {
            var type = _myDBContext.Types!.SingleOrDefault(t => t.TypeId == id);
            if(type != null)
            {
                _myDBContext.Types.Remove(type);
                await _myDBContext.SaveChangesAsync();
            }
        }

        public async Task<List<TypeEntity>> GetAllTypeAsync()
        {
            return await _myDBContext.Types!.ToListAsync();
        }

        public async Task<TypeEntity> GetTypeById(int id)
        {
            TypeEntity? typeEntity = await _myDBContext.Types!.FindAsync(id);
            return typeEntity;
        }

        public async Task UpdateType(int id, TypeEntity type)
        {
            if(id == type.TypeId)
            {
                _myDBContext.Types.Update(type);
                await _myDBContext.SaveChangesAsync();
            }
        }
    }
}
