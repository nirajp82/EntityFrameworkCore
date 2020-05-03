using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntityFrameworkCore.DataModel
{
    public class StudentDetail
    {
        [Column("StudentDetailId")]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = DataModelConst.MaxLenErrorMsg)]
        public string Address { get; set; }

        [MaxLength(150, ErrorMessage = DataModelConst.MaxLenErrorMsg)]
        public string AdditionalInformation { get; set; }

         public Guid StudentId { get; set; }
         public Student Student { get; set; }
    }
}
