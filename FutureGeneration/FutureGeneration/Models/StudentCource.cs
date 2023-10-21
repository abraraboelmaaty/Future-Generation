using System.ComponentModel.DataAnnotations.Schema;

namespace FutureGeneration.Models
{
    public class StudentCource
    {
        [ForeignKey("Student")]
        public int? StudentId { get; set; }
        [ForeignKey("Cource")]
        public int? CourceId { get; set; }
        public virtual  Student? Student { get; set; }
        public virtual Cource?  Cource { get; set; }
    }
}
