using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectData.Models;
using Repository;
using SkDemo.Models;

namespace ProjectData.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        
        private ProjectDataContext _context;
        
        public ProjectController(ProjectDataContext context)
        {
            _context = context;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllProjects()
        {
            var results = await _context.Projects.ToListAsync();
            return Ok(results);
        }

        [HttpPost("new")]
        public async Task<IActionResult> Create([FromBody]Project model )
        {
            _context.Projects.Add(model);
            await _context.SaveChangesAsync();

            return Created("all", model);
        }
    }
}