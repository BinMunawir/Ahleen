
using Payment.DTOs;
namespace Payment.Repositories
{
    public class WalletInMemoryRepository : WalletRepository
    {


        private List<WalletDTO> Wallets = new List<WalletDTO>{
            new WalletDTO() with {Guid="6a3f922e-304f-4215-9816-08a1f2947e69", Amount=100},
            new WalletDTO() with {Guid="6a3f922e-304f-4215-9816-08a1f2947e68", Amount=20}
        };
        public WalletDTO Create(WalletDTO wallet) {
            this.Wallets.Add(wallet);
            System.Console.WriteLine(wallet);
            System.Console.WriteLine("wallets: " + this.Wallets.Count);
            return wallet;
        }

        public WalletDTO Update(string guid, WalletDTO wallet) {
            WalletDTO oldWallet = this.Get(guid);
            if (oldWallet is null) throw new Exception("a wallet not exist");
            this.Wallets.Remove(oldWallet);

            oldWallet.Amount = wallet.Amount;
            this.Wallets.Add(oldWallet);
            return oldWallet;
        }
        public WalletDTO Get(string guid) {
            return this.Wallets.Where(u => u.Guid == guid).SingleOrDefault();
        }
        public List<WalletDTO> GetAll() {
            return this.Wallets;
        }
    }
}

