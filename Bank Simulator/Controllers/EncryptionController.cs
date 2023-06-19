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

        [HttpPost]
        public bool Post([FromBody] CardInformationModel user)
        {
            try
            {
                var clearTextCvv = _rsaHelper.Decrypt(user.cvv);
                return user.cvv.Equals("988", StringComparison.Ordinal);
            }
            catch (Exception)
            {
                // Log ex 
                return false;
            }
        }
    }
}
