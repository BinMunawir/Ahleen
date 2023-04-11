
using MassTransit;
using Payment.DTOs;


namespace Payment.Usecases {
    public interface PaymentFacad
    {
        public Task<WalletDTO> OpenWallet(WalletDTO walletDTO, IBus bus); 
        public WalletDTO TransferFunds(string senderWalletID, string receiverWalletID, int amount);
        public WalletDTO TopUpWallet(string walletID, int amount);
        public WalletDTO GetWallet(string guid);
        public List<WalletDTO> GetWallets();
    }
}
