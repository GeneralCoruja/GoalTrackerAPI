namespace GoalTrackingAPI.Domain.Models.Objective
{
    using System;

    public class Objective
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; }
        public string Occurence { get; set; } // should be enum
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
