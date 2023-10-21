using FutureGeneration.Data;


namespace FutureGeneration.ViewMolel
{
    public class CourceVM
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public IFormFile CourseSyllabus { get; set; }
        public string? ConvertCourseSyllabusURL { get; set; }
        public Enums.CourceStatus? Status { get; set; }
        public int? Capacity { get; set; }
        public decimal? Cost { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
