
using System.ComponentModel.DataAnnotations;

namespace Statement.DTOs
{
    public record StatementDTO
    {

        public string Guid { get; set; }
        public string Type { get; set; }
        public string UserID { get; set; }
        public string WalletID { get; set; }
        public int Amount { get; set; }
        public string Currency { get; set; }
        public string Note { get; set; }
        public string ReceiverID { get; set; }
        public string Snapshot { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime Date { get; set; }
    }
}