using System;

namespace EntityFrameworkCore.DataModel
{
    public class Student
    {
        public Guid StudentId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
