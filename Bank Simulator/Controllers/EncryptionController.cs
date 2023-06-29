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
        public EncryptionController(IEncrptionService rsaHelper)
        {
            _rsaHelper = rsaHelper;
        }

        [HttpPost]
        public bool Post([FromBody] CardInformationModel user)
        {
            try
            {
                string encryptedCvv = _rsaHelper.Encrypt(user.Cvv);         // TODO: Remove this line after demo

                Console.WriteLine(encryptedCvv);                            // TODO: Remove this line after demo

                string clearTextCvv = _rsaHelper.Decrypt(encryptedCvv);

                Console.WriteLine(clearTextCvv);                            // TODO: Remove this line after demo

                return clearTextCvv.Equals("988", StringComparison.Ordinal);// TODO: Get CVV from database and compare with user.Cvv
            }
            catch (Exception)
            {
                
               return false;
            }
        }
    }
}
