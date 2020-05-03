using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkCore.DataModel
{
    public class Student
    {
        [Key]
        [Column("StudentId")]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = DataModelConst.MaxLenErrorMsg)]
        public string FirstName { get; set; }

        [MaxLength(1, ErrorMessage = DataModelConst.MaxLenErrorMsg)]
        public string MiddleInitial { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = DataModelConst.MaxLenErrorMsg)]
        public string LastName { get; set; }

        public int Age { get; set; }

        public StudentDetail StudentDetail { get; set; }

        public ICollection<Evaluation> Evaluations { get; set; }

        public ICollection<StudentSubject> StudentSubjects { get; set; }

        [NotMapped]
        public string FullName
        {
            get
            {
                return $"{LastName}, {FirstName} {MiddleInitial}";
            }
        }
    }
}
