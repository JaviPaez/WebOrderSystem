using System.ComponentModel.DataAnnotations;

namespace WebOrderSystem.Models
{
    public class Member
    {
        public long Id { get; set; }
        [MaxLength(500)]
        public string Name { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

    }
}
