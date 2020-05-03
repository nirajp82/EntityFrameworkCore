using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkCore.APIModel
{
    public class StudentDetailEntity
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = APIModelConst.MaxLenErrorMsg)]
        public string Address { get; set; }

        [MaxLength(150, ErrorMessage = APIModelConst.MaxLenErrorMsg)]
        public string AdditionalInformation { get; set; }

        public Guid StudentId { get; set; }
    }
}
