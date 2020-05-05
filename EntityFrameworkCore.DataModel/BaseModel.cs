using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkCore.DataModel
{
    public abstract class BaseModel
    {
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
