using System;

namespace EntityFrameworkCore.APIModel
{
    public class StudentEntity
    {
        public Guid StudentId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
