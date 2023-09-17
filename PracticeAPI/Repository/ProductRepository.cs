using Microsoft.EntityFrameworkCore;
using PracticeAPI.Entity;

namespace PracticeAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly MyDBContext _context;

        public ProductRepository(MyDBContext context)
        {
            _context = context;
        }
        public async Task<int> AddProduct(ProductEntity entity)
        {
            _context.Products.Add(entity);
            await _context.SaveChangesAsync();
            return entity.ProductId;
        }

        public async Task DeleteProduct(int id)
        {
            var product = _context.Products.SingleOrDefault(x => x.ProductId == id);
            if(product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<ProductEntity>> GetAll()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<ProductEntity> GetById(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task UpdateProduct(int id, ProductEntity entity)
        {
            if(id == entity.ProductId)
            {
                _context.Products.Update(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
