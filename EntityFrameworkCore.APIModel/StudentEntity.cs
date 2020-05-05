using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkCore.APIModel
{
    public class StudentEntity
    {
        public long Id { get; set; }

        [Required(ErrorMessage = APIModelConst.RequiredErrorMsg)]
        [MaxLength(50, ErrorMessage = APIModelConst.MaxLenErrorMsg)]
        public string FirstName { get; set; }

        [MaxLength(1, ErrorMessage = APIModelConst.MaxLenErrorMsg)]
        public string MiddleInitial { get; set; }

        [Required(ErrorMessage = APIModelConst.RequiredErrorMsg)]
        [MaxLength(50, ErrorMessage = APIModelConst.MaxLenErrorMsg)]
        public string LastName { get; set; }

        public int Age { get; set; }

        public string Address { get; set; }


        public ICollection<EvaluationEntity> Evaluations { get; set; }

        public ICollection<StudentSubjectEntity> StudentSubjects { get; set; }

        public string FullName => $"{LastName}, {FirstName} {MiddleInitial}";

    }
}
