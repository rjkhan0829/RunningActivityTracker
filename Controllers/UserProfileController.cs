using Microsoft.AspNetCore.Mvc;
using RunningActivityTracker.Data;
using RunningActivityTracker.Models;
using System.Linq;
using System.Threading.Tasks;

namespace RunningActivityTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserProfileController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _context.UserProfiles.ToList();
            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserProfile userProfile)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.UserProfiles.Add(userProfile);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAll), new { id = userProfile.Id }, userProfile);
        }
    }
}
