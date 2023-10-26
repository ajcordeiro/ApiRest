namespace Entities.DataTransferObjects
{
    public class ClientDto
    {
        public Guid ClientId { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public int? Age { get; set; }
        public string? DocumentNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public IEnumerable<AccountDto>? Accounts { get; set; }
    }
}
