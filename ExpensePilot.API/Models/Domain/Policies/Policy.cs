using System.ComponentModel.DataAnnotations;

namespace ExpensePilot.API.Models.Domain.Policies
{
    public class Policy
    {
        [Key]
        public int PolicyID {  get; set; }
        public string PolicyName { get; set; }
        public string PolicyPurpose { get; set; }
        public string PolicyDescription { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
