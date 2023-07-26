//using Bank_Simulator.Database;
//using Bank_Simulator.Models;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;

//namespace Bank_Simulator.Controllers
//{
//    [ApiController]
//    public class DatabaseController : ControllerBase
//    {
//        private readonly DataContext _context;

//        public DatabaseController(DataContext context)
//        {
//            _context = context;
//        }

//        [HttpPost("api/AddUser")]
//        public async Task<ActionResult<List<DatabaseModels>>> AddUser(DatabaseModels user)
//        {
//            _context.DatabaseModels.Add(user);
//            await _context.SaveChangesAsync();

//            return Ok(await _context.DatabaseModels.ToListAsync());
//        }
//        [HttpGet("api/GetAllUsers")]
//        public async Task<ActionResult<List<DatabaseModels>>> GetAllUsers()
//        {
//            return Ok(await _context.DatabaseModels.ToListAsync());
//        }

//        [HttpGet("api/GetUser/{IDNumber}")]
//        public async Task<ActionResult<List<DatabaseModels>>> GetUser(string IDNumber)
//        {
//            var user = await _context.DatabaseModels.FindAsync(IDNumber);
//            if (user != null)
//            {
//                return Ok(user);
//            }
//            return BadRequest("User not found");
//        }
//    }
//}
