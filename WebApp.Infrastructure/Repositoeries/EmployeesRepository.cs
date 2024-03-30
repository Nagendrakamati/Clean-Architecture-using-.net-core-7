using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using WebApp.Domain.Entities;
using WebApp.Domain.Repositories;
using WebApp.Infrastructure.Data;

namespace WebApp.Infrastructure.Repositoeries
{
    public class EmployeesRepository : IEmployeesRepository
    {
        private readonly WebDbContext _webDbContext;

        public EmployeesRepository(WebDbContext webDbContext)
        {
            _webDbContext = webDbContext;
        }
        public async Task<Employees> CreateAsync(Employees employees)
        {
            await _webDbContext.Employees.AddAsync(employees);
            await _webDbContext.SaveChangesAsync();
            return employees;
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _webDbContext.Employees
                  .Where(model => model.ID == id)
                  .ExecuteDeleteAsync();
        }

        public async Task<List<Employees>> GetAllAsync()
        {
            return await _webDbContext.Employees.ToListAsync();
        }

        public async Task<Employees> GetByIdAsync(int id)
        {
            return await _webDbContext.Employees.AsNoTracking()
               .FirstOrDefaultAsync(b => b.ID == id);
        }

        public async Task<int> UpdateAsync(int id, Employees employees)
        {
            return await _webDbContext.Employees
                  .Where(model => model.ID == id)
                  .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.FirstName, employees.FirstName)
                    .SetProperty(m => m.Gender, employees.Gender)
                    .SetProperty(m => m.LastName, employees.LastName)
                    .SetProperty(m => m.DepartmentID, employees.DepartmentID)
                  );
        }
    }
}
