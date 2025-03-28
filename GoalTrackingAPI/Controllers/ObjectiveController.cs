namespace GoalTrackingAPI.Controllers
{
    using GoalTrackingAPI.Domain.Models.Objective;
    using GoalTrackingAPI.Domain.Services;
    using GoalTrackingAPI.Dtos.Objectives;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
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
        public async Task<IEnumerable<ObjectiveDto>> Get() { 
            return _objectiveService.GetAllAsync().Result.Select(x => x.ToDto());
        }

        [HttpPost]
        public async Task<IActionResult> Post(ObjectiveDto newObjective)
        {
            await _objectiveService.CreateAsync(newObjective.ToDomain());
            return CreatedAtAction(nameof(Get), new { id = newObjective.Id }, newObjective);
        }
    }
}
