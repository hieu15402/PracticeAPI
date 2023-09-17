using System.ComponentModel.DataAnnotations;

namespace PracticeAPI.Entity
{
    public class Entity
    {
        [Key]
        public string Id { get; set; }
        public DateTime CreateTimes { get; set; }
        public DateTime LastUpdateTimes { get; set; }

        public Entity()
        {
            Id = Guid.NewGuid().ToString("N");
            CreateTimes = DateTime.Now;
            LastUpdateTimes = DateTime.Now;
        }
    }
}
