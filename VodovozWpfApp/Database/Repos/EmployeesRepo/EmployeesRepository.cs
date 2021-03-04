using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vodovoz.Models.ClientSide.Database;

namespace VodovozWpfApp
{
    public class EmployeesRepository : IEmployeesRepo
    {
        private VodovozClientDbContext _context;

        public EmployeesRepository(VodovozClientDbContext ctx)
        {
            _context = ctx;            
        }

        public IEnumerable<Employee> Employees => _context.Employees
            .Include(e => e.Subdivision).ToArray();

        public async Task DeleteEmployeeAsync(Employee employee)
        {
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
        }

        public async Task<Employee> GetEmployeeAsync(long id)
        {
            Employee employee = await _context.Employees.Include(e => e.Subdivision).FirstOrDefaultAsync(s => s.Id == id);
            return employee;
        }

        public async Task<Employee> UpdateOrAddEmployeeAsync(Employee Employee)
        {
            Employee employee = await _context.Employees.FindAsync(Employee.Id);
            bool isItAdd = false;
            if (employee != null)
            {
                employee.Name = Employee.Name;
                employee.Surname = Employee.Surname;
                employee.FatherName = Employee.FatherName;
                employee.Birthday = Employee.Birthday;
                employee.Sex = Employee.Sex;
                employee.Subdivision = Employee.Subdivision;
            }
            else
            {
                isItAdd = true;
                //employee = Employee;
                await _context.Employees.AddAsync(Employee);
            }
            await _context.SaveChangesAsync();

            return isItAdd ? Employee : null;

        }

        
    }
}
