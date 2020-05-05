using System;

namespace EntityFrameworkCore.DataModel
{
    public class StudentSubject : BaseModel
    {
        public long StudentId { get; set; }
        public Student Student { get; set; }

        public long SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}
