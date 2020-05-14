namespace EntityFrameworkCore.APIModel
{
    public class StudentSubjectEntity : BaseEntity
    {
        public long StudentId { get; set; }

        public StudentEntity Student { get; set; }


        public long SubjectId { get; set; }

        public SubjectEntity Subject { get; set; }
    }
}
