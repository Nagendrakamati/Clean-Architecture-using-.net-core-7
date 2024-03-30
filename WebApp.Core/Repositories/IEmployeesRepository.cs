using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Domain.Entities;

namespace WebApp.Domain.Repositories
{
    public interface IEmployeesRepository
    {
        Task<List<Employees>> GetAllAsync();
        Task<Employees> GetByIdAsync(int id);
        Task<Employees> CreateAsync(Employees employees);
        Task<int> UpdateAsync(int id, Employees employees);
        Task<int> DeleteAsync(int id);
    }
}
