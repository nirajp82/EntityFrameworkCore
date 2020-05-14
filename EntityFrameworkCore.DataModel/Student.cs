using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkCore.DataModel
{
    public class Student : BaseModel
    {
        [Key]
        [Column("StudentId")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override long Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = DataModelConst.MaxLenErrorMsg)]
        public string FirstName { get; set; }

        [MaxLength(1, ErrorMessage = DataModelConst.MaxLenErrorMsg)]
        public string MiddleInitial { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = DataModelConst.MaxLenErrorMsg)]
        public string LastName { get; set; }

        public int Age { get; set; }

        public StudentAddress StudentAddress { get; set; }

        public ICollection<StudentEnrollment> StudentEnrollments { get; set; }

        public ICollection<StudentSubject> StudentSubjects { get; set; }
    }
}