
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tuesday.Entities;

namespace Tuesday.Services
{
    public interface IJalonService : IDependantBaseService<JalonEntity>
    {
        public bool IsJalonExist(int idJalon, int idParent);
    }
}
