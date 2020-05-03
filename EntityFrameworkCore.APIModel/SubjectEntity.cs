using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkCore.APIModel
{
    public class Subject
    {
        public Guid Id { get; set; }

        [MaxLength(50, ErrorMessage = APIModelConst.MaxLenErrorMsg)]
        public string SubjectName { get; set; }

        public ICollection<StudentSubjectEntity> StudentSubjects { get; set; }
    }
}
