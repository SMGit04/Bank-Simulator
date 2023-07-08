using Bank_Simulator.Database;
using Bank_Simulator.Models;
using Bank_Simulator.Services.Interfaces.Encryption;
using Microsoft.AspNetCore.Mvc;


namespace Bank_Simulator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EncryptionController : ControllerBase
    {
        private readonly IEncrptionService _rsaHelper;
        private readonly DataContext _context;
        public EncryptionController(IEncrptionService rsaHelper, DataContext dataContext)
        {
            _rsaHelper = rsaHelper;
            _context = dataContext;
        }

        [HttpPost]
        public bool DecryptCvvNumber([FromBody] DatabaseModels user)
        {
            try
            {
                string clearTextCvv = _rsaHelper.Decrypt(user.CVV);     // The user.CVV is encrypted, so we need to decrypt it first
                DatabaseModels? databaseModelId = _context.DatabaseModels.FirstOrDefault(id => id.IDNumber == user.IDNumber);

                return databaseModelId != null && clearTextCvv.Equals(databaseModelId.CVV, StringComparison.Ordinal);
            }
            catch (Exception)
            {
               return false;
            }
        }

        /// <summary>
        /// The "Contract" I sigh with the client, in this case, the POS machine is whether the transaction is approved on not
        /// Based on the information that the POS machine sends me, I will either approve or decline the transaction
        /// I should should check if the user has enough money in his account to make the transaction among other things
        /// We should check the CVV number, the PIN number, the expiry date, the card number, the account number, the account balance against the database
        /// - If all the information is correct, we should approve the transaction
        /// 
        /// We should structure the system such that, only when the user approves the tranaction on their mobile phone, the card information 
        /// is sent to the bank for approval. This is to prevent fraud.
        /// </summary>
    }
}
