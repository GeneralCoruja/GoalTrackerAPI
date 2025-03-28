namespace GoalTrackingAPI.Domain.Models.Objective
{
    using Database = Database.Models;

    public static class ObjectiveExtensions
    {
        public static Objective ToDomain(this Database.Objective objective) {
            return new Objective { 
                Id = objective.Id,
                Description = objective.Description,
                Title = objective.Title,
                UserId = objective.UserId,
                Occurence = objective.Occurence,
                StartDate = objective.StartDate,
                EndDate = objective.EndDate,
                CreatedDate = objective.CreatedDate,
            };
        }

        public static Database.Objective ToEntity(this Objective objective)
        {
            return new Database.Objective
            {
                Id = objective.Id,
                Description = objective.Description,
                Title = objective.Title,
                UserId = objective.UserId,
                Occurence = objective.Occurence,
                StartDate = objective.StartDate,
                EndDate = objective.EndDate,
                CreatedDate = objective.CreatedDate,
            };
        }
    }
}
