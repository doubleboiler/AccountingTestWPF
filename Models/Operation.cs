using AccountingTestWPF.Data;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AccountingTestWPF.Models
{
    public class Operation
    {
        public int Id { get; set; }

        [Required]
        public DateTime OperationDate { get; set; }

        [Required]
        [MaxLength(100)]
        public string Note { get; set; }

        [Required]
        public decimal Sum { get; set; }

        [Required]
        public bool IsIncome { get; set; }

        [Required]
        public int UserId { get; set; }

        public virtual User User { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public int? RecipientId { get; set; }

        public virtual Recipient Recipient { get; set; }

        [NotMapped]
        public User UserById
        {
            get
            {
                return DataAccess.GetUserById(UserId);
            }
        }
    }
}
