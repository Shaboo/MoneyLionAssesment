using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MoneyLionAssesment.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Email { get; set; }

        public virtual ICollection<Feature> Features { get; set; }
    }
}
