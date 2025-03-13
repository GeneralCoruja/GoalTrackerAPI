namespace TestAPI.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using TestAPI.Database.Models;
    using TestAPI.Services;

    [ApiController]
    [Route("api/[controller]")]
    public class ObjectiveController : Controller
    {

        private readonly ObjectiveService _objectiveService;

        public ObjectiveController(ObjectiveService objectiveService)
        {
            _objectiveService = objectiveService;
        }

        [HttpGet]
        public async Task<List<Objective>> Get() =>
            await _objectiveService.GetAsync();


        [HttpPost]
        public async Task<IActionResult> Post(Objective newObjective)
        {
            await _objectiveService.CreateAsync(newObjective);
            return CreatedAtAction(nameof(Get), new { id = newObjective.Id }, newObjective);
        }
    }
}
