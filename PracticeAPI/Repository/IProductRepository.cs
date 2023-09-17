using PracticeAPI.Entity;

namespace PracticeAPI.Repository
{
    public interface IProductRepository
    {
        public Task<List<ProductEntity>> GetAll();
        public Task<ProductEntity> GetById(int id);
        public Task<int> AddProduct(ProductEntity entity);
        public Task UpdateProduct(int id, ProductEntity entity);
        public Task DeleteProduct(int id);
    }
}
