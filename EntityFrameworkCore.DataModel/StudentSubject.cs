using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkCore.DataModel
{
    public class StudentSubject : BaseModel
    {
        [Key]
        [Column("StudentSubjectId")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override long Id { get; set; }

        public long StudentId { get; set; }
        public Student Student { get; set; }

        public long SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}
