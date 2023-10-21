using FutureGeneration.Data;
using System.Text.Json.Serialization;

namespace FutureGeneration.Models
{
    public class Cource
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string CourseSyllabus { get; set; }
        public Enums.CourceStatus Status { get; set; }
        public int? Capacity { get; set; }
        public decimal? Cost { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [JsonIgnore]
        public virtual ICollection<StudentCource> StudentCource { get; set; }
    }
}
