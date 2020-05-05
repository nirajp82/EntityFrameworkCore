using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkCore.DataModel
{
    public class StudentAddress : BaseModel
    {
        [Key]
        [Column("StudentAddressId")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = DataModelConst.MaxLenErrorMsg)]
        public string Address { get; set; }

         public long StudentId { get; set; }
         public Student Student { get; set; }
    }
}
