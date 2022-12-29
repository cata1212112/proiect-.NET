﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.BaseEntity
{
    public interface IBaseEntity
    {
        Guid Id { get; set; }
        DateTime DateCreated { get; set; }
        DateTime? DateModified { get; set; }
    }
}
