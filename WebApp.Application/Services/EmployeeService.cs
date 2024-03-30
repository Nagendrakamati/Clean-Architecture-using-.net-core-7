using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Domain.Entities;
using WebApp.Domain.Repositories;

namespace WebApp.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeesRepository employeesRepository;

        public EmployeeService(IEmployeesRepository employeesRepository)
        {
            this.employeesRepository = employeesRepository;
        }
        public async Task<Employees> CreateAsync(Employees employees)
        {
           return await employeesRepository.CreateAsync(employees);
        }

        public async Task<int> DeleteAsync(int id)
        {
           return await employeesRepository.DeleteAsync(id);
        }

        public async Task<List<Employees>> GetAllAsync()
        {
           return await employeesRepository.GetAllAsync();
        }

        public async Task<Employees> GetByIdAsync(int id)
        {
            return await employeesRepository.GetByIdAsync(id);
        }
        public async Task<int> UpdateAsync(int id, Employees employees)
        {
                return await employeesRepository.UpdateAsync(id, employees);
        }
    }
}
