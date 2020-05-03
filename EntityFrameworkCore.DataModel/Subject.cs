using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkCore.DataModel
{
    public class Subject
    {
        [Column("SubjectId")]
        public Guid Id { get; set; }

        [MaxLength(50, ErrorMessage = DataModelConst.MaxLenErrorMsg)]
        public string SubjectName { get; set; }

        public ICollection<StudentSubject> StudentSubjects { get; set; }
    }
}
