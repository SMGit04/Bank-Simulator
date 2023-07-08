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
    }
}
