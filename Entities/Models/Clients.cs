using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    [Table("clients")]
    public class Client
    {
        [Column("ClientId")]
        public Guid ClientId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(60, ErrorMessage = "Name can't be longer than 60 characters")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [StringLength(100, ErrorMessage = "Address cannot be longer than 100 characters")]
        public string? Address { get; set; }

        [Required(ErrorMessage = "Age is required")]
        //[StringLength(3, ErrorMessage = "Age cannot be longer than 03 characters")]
        public int? Age { get; set; }

        [Required(ErrorMessage = "Document Number is required")]
        [StringLength(12, ErrorMessage = "DocumentNumber cannot be longer than 12 characters")]
        public string? DocumentNumber { get; set; }

        [Required(ErrorMessage = "Date of birth is required")]
        public DateTime DateOfBirth { get; set; }
       
        public ICollection<Account>? Accounts { get; set; }
    }
}
