using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Data.Repository.Interfaces
{
    public interface IRepository<T>
    {
        T GetById(Guid id);

        T GetByIdAsync(Guid id);
    }
}
