using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkCore.APIModel
{
    public abstract class BaseEntity
    {
        public long Id { get; set; }
    }
}
