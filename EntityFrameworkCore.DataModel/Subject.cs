using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkCore.DataModel
{
    public class Subject : BaseModel
    {
        [Key]
        [Column("SubjectId")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [MaxLength(50, ErrorMessage = DataModelConst.MaxLenErrorMsg)]
        public string SubjectName { get; set; }

        public ICollection<StudentSubject> StudentSubjects { get; set; }
    }
}
