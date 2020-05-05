using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkCore.APIModel
{
    public class StudentAddressEntity
    {
        public long Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = APIModelConst.MaxLenErrorMsg)]
        public string Address { get; set; }

        public long StudentId { get; set; }
    }
}
