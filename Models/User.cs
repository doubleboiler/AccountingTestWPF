using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AccountingTestWPF.Models
{
    public class User
    {
        public User()
        {
            Operations = new List<Operation>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FullName { get; set; }

        [Required]
        public decimal Balance { get; set; }

        [Required]
        public bool IsAdmin { get; set; }

        public ICollection<Operation> Operations { get; set; }
    }
}
