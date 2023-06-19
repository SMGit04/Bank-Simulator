using Bank_Simulator.Models;
using Bank_Simulator.Services.Implementation.Encryption;
using Bank_Simulator.Services.Interfaces.Encryption;
using Microsoft.AspNetCore.Mvc;


namespace Bank_Simulator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EncryptionController : ControllerBase
    {
        private readonly IRsaHelper _rsaHelper;
        public EncryptionController(IRsaHelper rsaHelper)
        {
            _rsaHelper = rsaHelper;
        }

        [HttpPost]
        public bool Post([FromBody] CardInformationModel user)
        {
            try
            {
                string encryptedCvv = _rsaHelper.Encrypt(user.cvv);         // TODO: Remove this line after demo

                Console.WriteLine(encryptedCvv);                            // TODO: Remove this line after demo


                string clearTextCvv = _rsaHelper.Decrypt(encryptedCvv);
                return user.cvv.Equals("988", StringComparison.Ordinal);
            }
            catch (Exception)
            {
                
               return false;
            }
        }
    }
}
