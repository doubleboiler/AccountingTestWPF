using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AccountingTestWPF.Models
{
    public class Category
    {
        public Category()
        {
            Operations = new List<Operation>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string CategoryName { get; set; }

        public ICollection<Operation> Operations { get; set; }

    }
}
