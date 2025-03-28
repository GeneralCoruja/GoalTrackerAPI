namespace GoalTrackingAPI.Dtos.Objectives
{
    using Domain = Domain.Models.Objective;
    public static class ObjectivesExtensions
    {
        public static Domain.Objective ToDomain(this ObjectiveDto dto)
        {
            return new Domain.Objective
            {
                Title = dto.Title,
                Description = dto.Description,
                Occurence = "daily",
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
            };
        }

        public static ObjectiveDto ToDto(this Domain.Objective objective)
        {
            return new ObjectiveDto
            {
                Id = objective.Id,
                Title = objective.Title,
                Description = objective.Description,
                CreatedDate = objective.CreatedDate,
                UpdatedDate = objective.CreatedDate,
                StartDate = objective.StartDate,
                EndDate = objective.EndDate,
            };
        }
    }
}
