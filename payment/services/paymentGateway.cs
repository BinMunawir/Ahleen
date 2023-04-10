


using Payment.DTOs;


namespace Payment.Services {
    public interface PaymentGateway
    {
        public WalletDTO TopUpWallet(WalletDTO wallet, int amount);
    }
}
