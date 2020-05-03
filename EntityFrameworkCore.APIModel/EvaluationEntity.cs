using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkCore.APIModel
{
    public class EvaluationEntity
    {
        public Guid Id { get; set; }

        [Required]
        public int Grade { get; set; }

        [MaxLength(250, ErrorMessage = APIModelConst.MaxLenErrorMsg)]
        public string AdditionalExplanation { get; set; }

        public Guid StudentId { get; set; }
    }
}
