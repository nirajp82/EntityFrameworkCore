using System;

namespace EntityFrameworkCore.APIModel
{
    public class StudentSubjectEntity
    {
        public Guid StudentId { get; set; }

        public StudentEntity Student { get; set; }


        public Guid SubjectId { get; set; }

        public SubjectEntity Subject { get; set; }
    }
}
