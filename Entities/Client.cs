using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WebTest.Entities
{
    public class Client
    {
        [Key]
        public Guid ClientID { get; set; }

        [Required(ErrorMessage = "O Nome é Obrigatorio")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "O Campo nome deve ter entre 3 e 200 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O Endereço é obrigatório")]
        [StringLength(200, MinimumLength = 4, ErrorMessage = "O Campo endereço deve ter entre 3 e 200 caracteres")]
        public string Address { get; set; }
        public int Age { get; set; }
        public string DocumentNumber { get; set; }
        public bool IsActive { get; set; }

        public void Update(string name, string address, int age, string documentNumber, bool isActive)
        {
            Name = name;
            Address = address;
            Age = age;
            DocumentNumber = documentNumber;
            IsActive = isActive;
        }

        public void Delete()
        {
            IsActive = false;
        }
    }
}
