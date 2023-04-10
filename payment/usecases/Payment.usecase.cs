
using Payment.Repositories;
using Payment.DTOs;
using Payment.Services;


namespace Payment.Usecases
{
    public class PaymentUsecases: PaymentFacad
    {

        private WalletRepository repo;
        private PaymentGateway paymentGateway;
        public PaymentUsecases(WalletRepository repo, PaymentGateway paymentGateway) {
            this.repo = repo;
            this.paymentGateway = paymentGateway;
        }

        public WalletDTO OpenWallet(WalletDTO walletDTO) {
            walletDTO.Guid = Guid.NewGuid().ToString();
            walletDTO.Amount = 0;
            walletDTO.IsActive = true;
            walletDTO.CreatedAt = DateTime.Now;
            walletDTO.Currency = "SAR";

            walletDTO = this.repo.Create(walletDTO);
            return walletDTO;
        }

        public WalletDTO TransferFunds(string senderWalletID, string receiverWalletID, int amount) {
            WalletDTO senderWallet = this.GetWallet(senderWalletID);
            if (senderWallet.Amount < amount) throw new Exception("no enough amount");
            WalletDTO receiverWallet = this.GetWallet(receiverWalletID);

            senderWallet.Amount -= amount;
            receiverWallet.Amount += amount;
            
            this.repo.Update(senderWalletID, senderWallet);
            this.repo.Update(receiverWalletID, receiverWallet);

            
            return senderWallet;
        }
        public WalletDTO TopUpWallet(string walletID, int amount) {
            WalletDTO wallet = this.GetWallet(walletID);
            wallet = this.paymentGateway.TopUpWallet(wallet, amount);

            return this.repo.Update(walletID, wallet);

        }
        public WalletDTO GetWallet(string guid) {
            WalletDTO wallet = this.repo.Get(guid);
            return wallet;
        }
        public List<WalletDTO> GetWallets() {
            List<WalletDTO> wallet = this.repo.GetAll();
            return wallet;
        }

    }
}