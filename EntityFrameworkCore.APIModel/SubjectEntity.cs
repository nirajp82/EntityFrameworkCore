using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkCore.APIModel
{
    public class SubjectEntity : BaseEntity
    {
        [MaxLength(50, ErrorMessage = APIModelConst.MaxLenErrorMsg)]
        public string SubjectName { get; set; }

        public ICollection<StudentSubjectEntity> StudentSubjects { get; set; }
    }
}
