using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkCore.DataModel
{
    public class Evaluation :BaseModel
    {
        [Key]
        [Column("EvaluationId")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        public int Grade { get; set; }

        [MaxLength(250, ErrorMessage = DataModelConst.MaxLenErrorMsg)]
        public string AdditionalExplanation { get; set; }

        public long StudentId { get; set; }
        public Student Student { get; set; }
    }
}
