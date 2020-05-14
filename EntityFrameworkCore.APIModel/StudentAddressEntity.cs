using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkCore.APIModel
{
    public class StudentAddressEntity : BaseEntity
    {
        [Required]
        [MaxLength(50, ErrorMessage = APIModelConst.MaxLenErrorMsg)]
        public string Address { get; set; }

        public long StudentId { get; set; }
    }
}
