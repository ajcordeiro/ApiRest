using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects
{
    public class ClientForUpdateDto
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(60, ErrorMessage = "Name can't be longer than 60 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [StringLength(100, ErrorMessage = "Address cannot be loner then 100 characters")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Age is required")]
        public int? Age { get; set; }

        [Required(ErrorMessage = "Document Number is required")]
        [StringLength(12, ErrorMessage = "DocumentNumber cannot be longer than 12 characters")]
        public string? DocumentNumber { get; set; }

        [Required(ErrorMessage = "Date of birth is required")]
        public DateTime DateOfBirth { get; set; }

    }
}
