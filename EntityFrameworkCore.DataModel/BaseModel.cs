using System;

namespace EntityFrameworkCore.DataModel
{
    public abstract class BaseModel
    {
        public virtual long Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
