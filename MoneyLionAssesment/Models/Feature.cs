using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MoneyLionAssesment.Models
{
    public class Feature
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
