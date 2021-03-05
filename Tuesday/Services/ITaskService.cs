﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tuesday.Entities;

namespace Tuesday.Services
{
    public interface ITaskService : IBaseService<TaskEntity>
    {
        public void UpdateJalon(UrlConfig config);
    }
}
