using System.ComponentModel.DataAnnotations;

namespace PracticeAPI.Entity
{
    public class TypeEntity
    {
        [Key]
        public int TypeId { get; set; }

        [Required]
        [StringLength(50, ErrorMessage ="Not over 50 characters")]
        public string Name { get; set; }
    }
}
