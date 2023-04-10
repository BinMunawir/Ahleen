
using Payment.DTOs;

namespace Payment.Repositories
{
    public interface WalletRepository
    {

       public WalletDTO Create(WalletDTO wallet);
       public WalletDTO Update(string guid, WalletDTO wallet);
       public WalletDTO Get(string guid);
       public List<WalletDTO> GetAll();

    }
}