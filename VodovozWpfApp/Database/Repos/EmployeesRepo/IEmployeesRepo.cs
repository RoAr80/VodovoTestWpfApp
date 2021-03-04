using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vodovoz.Models.ClientSide.Database;

namespace VodovozWpfApp
{
    public interface IEmployeesRepo
    {
        IEnumerable<Employee> Employees { get; }
        Task DeleteEmployeeAsync(Employee employee);
        Task<Employee> UpdateOrAddEmployeeAsync(Employee employee);
        Task<Employee> GetEmployeeAsync(long id);
    }
}
