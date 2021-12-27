using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AccountingTestWPF.Models
{
    public class Recipient
    {
        public Recipient()
        {
            Operations = new List<Operation>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string RecipientName { get; set; }

        public ICollection<Operation> Operations { get; set; }

    }
}
