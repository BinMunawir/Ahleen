
using Microsoft.AspNetCore.Mvc;
using Payment.DTOs;
using Payment.Repositories;
using Payment.Usecases;
using Payment.Services;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;

namespace Payment.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class Wallets : ControllerBase
    {

        private WalletRepository repo;
        private PaymentGateway paymentGateway;
        public Wallets(WalletRepository repo, PaymentGateway paymentGateway) {
            this.repo = repo;
            this.paymentGateway = paymentGateway;
        }

        [HttpPost]
        public ActionResult<WalletDTO> OpenWallet(WalletDTO walletDTO) {
            return new PaymentUsecases(this.repo, this.paymentGateway).OpenWallet(walletDTO);
        }

        [HttpPost, Route("topup")]
        public async Task<ActionResult<WalletDTO>> TopUpWallet(WalletDTO walletDTO) {
            var wallet = new PaymentUsecases(this.repo, this.paymentGateway).TopUpWallet(walletDTO.Guid, walletDTO.Amount);

            await createTransaction(wallet, "topup", wallet.UserID, null, walletDTO.Amount);

            return wallet;
        }

        [HttpPost, Route("transfer/{id}")]
        public async Task<ActionResult<WalletDTO>> Transfer(string id, WalletDTO walletDTO) {
            var wallet = new PaymentUsecases(this.repo, this.paymentGateway).TransferFunds(walletDTO.Guid, id, walletDTO.Amount);

            await createTransaction(wallet, "transfer", wallet.UserID, id, walletDTO.Amount);
            return wallet;
        }

        [HttpGet("{guid}")]
        public ActionResult<WalletDTO> GetWallet(string guid) {
            WalletDTO wallet = new PaymentUsecases(this.repo, this.paymentGateway).GetWallet(guid);
            if (wallet is null) return NotFound();
            return wallet;
        }
        [HttpGet]
        public ActionResult<List<WalletDTO>> GetWallets() {
            List<WalletDTO> wallets = new PaymentUsecases(this.repo, this.paymentGateway).GetWallets();
            return wallets;
        }

        private static async Task createTransaction(WalletDTO walletDTO, string type, string userID, string receiverID, int amount)
            {
                var client = new HttpClient();
                var body = new Dictionary<string, Object>();
                body.Add("amount", amount);
                body.Add("currency", walletDTO.Currency);
                body.Add("snapshot", "");
                body.Add("date", DateTime.Now);
                body.Add("type", type);
                body.Add("userID", userID);
                body.Add("receiverID", receiverID);
                body.Add("walletID", walletDTO.Guid);
                var request = await client.PostAsync(
                    new Uri("http://statement:18083/api/statements"),
                    new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json")
                );
                string resultContent = await request.Content.ReadAsStringAsync();
                if ((int)request.StatusCode > 299) throw new Exception("couldn't make the transaction>>>\n " + resultContent);
            }
    }
}