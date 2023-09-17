using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracticeAPI.Entity
{
    [Table("Products")]
    public class ProductEntity
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [Range(0, Double.MaxValue)]
        public double Price { get; set; }

        public int TypeId { get; set; }
        [ForeignKey("TypeId")]
        public TypeEntity Type { get; set; }

    }
}
