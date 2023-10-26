using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    [Table("account")]
    public class Account
    {
        [Column("AccountId")]
        public Guid AccountId { get; set; }

        [Required(ErrorMessage = "Date created is required")]
        public DateTime DateCreated { get; set; }

        [Required(ErrorMessage = "Account type is required")]
        public string? AccountType { get; set; }
        
        [ForeignKey(nameof(Clients))]
        public Guid ClientId { get; set; }

        public Client? Clients { get; set; }
    }
}