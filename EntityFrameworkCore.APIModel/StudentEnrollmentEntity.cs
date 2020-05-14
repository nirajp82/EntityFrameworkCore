using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkCore.APIModel
{
    public class StudentEnrollmentEntity : BaseEntity
    {
        [Required]
        public int Grade { get; set; }

        [MaxLength(250, ErrorMessage = APIModelConst.MaxLenErrorMsg)]
        public string AdditionalExplanation { get; set; }

        public long StudentId { get; set; }
    }
}
