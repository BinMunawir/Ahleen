
using System.ComponentModel.DataAnnotations;

namespace Payment.DTOs
{
    public record WalletDTO
    {

        public string Guid { get; set; }
        public string UserID { get; set; }
        public bool IsActive { get; set; }
        public int Amount { get; set; }
        public string Currency { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

