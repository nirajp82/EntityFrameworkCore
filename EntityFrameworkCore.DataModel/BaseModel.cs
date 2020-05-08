using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkCore.DataModel
{
    public abstract class BaseModel
    {
        public virtual long Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
