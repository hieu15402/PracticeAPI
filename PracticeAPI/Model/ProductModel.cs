using System.ComponentModel.DataAnnotations;

namespace PracticeAPI.Model
{
    public class ProductModel
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int TypeId { get; set; }
    }
}
