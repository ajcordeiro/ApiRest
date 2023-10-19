using System.ComponentModel.DataAnnotations;

namespace WebTest.Models
{
    public class ClientViewModel
    {
        public Guid ClientID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public string DocumentNumber { get; set; }
        public bool IsActive { get; set; }
    }
}
