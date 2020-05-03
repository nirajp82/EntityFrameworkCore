using System;

namespace EntityFrameworkCore.APIModel
{
    public class StudentSubjectEntity
    {
        public Guid StudentId { get; set; }

        public Guid SubjectId { get; set; }
    }
}
