﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public interface IBaseEntity
    {
        int Id { get; }
        bool IsDeleted { get; }
        bool IsActive { get; }
    }
    public class BaseEntity:IBaseEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; } 
        public bool IsActive { get; set; }
    }
}
