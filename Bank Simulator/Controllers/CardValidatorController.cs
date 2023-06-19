using Bank_Simulator.Orchestration.Interfaces;
using Bank_Simulator.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace Bank_Simulator.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CardValidatorController : ControllerBase
    {
        private readonly ICardValidatorOrchestration _cardValidatorOrchestration;

        public CardValidatorController(ICardValidatorOrchestration cardValidatorOrchestration)
        {
            _cardValidatorOrchestration = cardValidatorOrchestration;
        }

        [HttpGet]
        public IActionResult Get([StringLength(maximumLength: 16, MinimumLength = 16)] string cardNumber)
        {
            if (ModelState.IsValid)
            {
                var orchestrator = _cardValidatorOrchestration.CardNumberIsValid(cardNumber);
                return Ok(orchestrator);
            }
            else
            {
                return UnprocessableEntity(ModelState);
            }
            
        }
    }
}
