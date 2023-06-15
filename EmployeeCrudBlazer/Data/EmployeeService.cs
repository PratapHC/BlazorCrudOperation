using EmployeeCrudBlazer.Context;
using Microsoft.EntityFrameworkCore;

namespace EmployeeCrudBlazer.Data
{
    public class EmployeeService
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public EmployeeService(ApplicationDbContext applicationDbContext) 
        {
            _applicationDbContext = applicationDbContext;
        }

        //get all employee
        public async Task<List<Employee>> GetEmployees()
        {
            return await _applicationDbContext.Employees.ToListAsync();
        }
        //add new employee
        public async Task<bool> AddNewEmployee(Employee employee)
        {

             _applicationDbContext.Employees.AddAsync(employee);

            await _applicationDbContext.SaveChangesAsync();
            return true;

        }
        //get employee by ID
        public async Task<Employee> GetEmployeeById(int id)
        {
           Employee employee = await _applicationDbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
            return employee;

        }
        //update Employee by ID
        public async Task<bool> UpdateEmployeeById(Employee employee)
        {
            _applicationDbContext.Employees.Update(employee);
            await _applicationDbContext.SaveChangesAsync();
            return true;

        }
        //delete emoloyee
        public async Task<bool> DeleteEmployeeRecords(Employee employee)
        {
            _applicationDbContext.Employees.Remove(employee);
            await _applicationDbContext.SaveChangesAsync();
            return true;

        }
    }
}
