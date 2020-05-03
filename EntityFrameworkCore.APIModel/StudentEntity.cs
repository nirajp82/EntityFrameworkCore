using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkCore.APIModel
{
    public class StudentEntity
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = APIModelConst.RequiredErrorMsg)]
        [MaxLength(50, ErrorMessage = APIModelConst.MaxLenErrorMsg)]
        public string FirstName { get; set; }

        [MaxLength(1, ErrorMessage = APIModelConst.MaxLenErrorMsg)]
        public string MiddleInitial { get; set; }

        [Required(ErrorMessage = APIModelConst.RequiredErrorMsg)]
        [MaxLength(50, ErrorMessage = APIModelConst.MaxLenErrorMsg)]
        public string LastName { get; set; }

        public int Age { get; set; }

        public string FullName { get; set; }

        public string ShortName { get; set; }

        //public StudentDetailEntity StudentDetail { get; set; }

        //public ICollection<EvaluationEntity> Evaluations { get; set; }

        //public ICollection<StudentSubjectEntity> StudentSubjects { get; set; }
    }
}
