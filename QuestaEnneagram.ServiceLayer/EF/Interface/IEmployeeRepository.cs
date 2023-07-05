using QuestaEnneagram.DbLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestaEnneagram.ServiceLayer.EF.Interface
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
    }
}
