using Microsoft.AspNetCore.Mvc;
using RunningActivityTracker.Data;
using RunningActivityTracker.Models;
using System.Linq;
using System.Threading.Tasks;

namespace RunningActivityTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RunningActivityController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RunningActivityController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var activities = _context.RunningActivities.ToList();
            return Ok(activities);
        }

        [HttpPost]
        public async Task<IActionResult> Create(RunningActivity runningActivity)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.RunningActivities.Add(runningActivity);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAll), new { id = runningActivity.Id }, runningActivity);
        }
    }
}
