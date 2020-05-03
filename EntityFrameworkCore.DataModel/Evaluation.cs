using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkCore.DataModel
{
    public class Evaluation
    {
        [Column("EvaluationId")]
        public Guid Id { get; set; }

        [Required]
        public int Grade { get; set; }

        [MaxLength(250, ErrorMessage = DataModelConst.MaxLenErrorMsg)]
        public string AdditionalExplanation { get; set; }

        public Guid StudentId { get; set; }
        public Student Student { get; set; }
    }
}
