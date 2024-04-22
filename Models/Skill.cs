using System.Text.Json.Serialization;

namespace Simple_API_Assessment.Models
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ApplicantId { get; set; }
        [JsonIgnore]
        public Applicant Applicant { get; set; }

    }
}
