using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ProjectApiCompanyCTECH.Common;
using ProjectApiCompanyCTECH.Entities;
using ProjectApiCompanyCTECH.Extensions;
using ProjectApiCompanyCTECH.Model.Request;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ProjectApiCompanyCTECH.Services
{
    public interface IEmployeeService
    {
        Task<int> CreateEmployee(EmployeeCreateRequest request);
        Task<PagedResult<Employee>> GetAllEmployee(string fullname, int pageIndex, int pageSize);
        Task<Employee> GetById(int id);
        Task<int> DeleteEmployee(int id);
    }
    public class EmployeeService : IEmployeeService
    {
        private readonly ContextDbWrite _context;
        public EmployeeService(ContextDbWrite context)
        {
            _context = context;
        }
        public async Task<int> CreateEmployee(EmployeeCreateRequest request)
        {
            try
            {
                var employ = new Employee
                {
                    Fullname= request.Fullname,
                    Birthday= request.Birthday,
                    Gender= request.Gender,
                    Email = request.Email,
                    PhoneNumber = request.PhoneNumber,
                    Salary= request.Salary,
                    Department= request.Department,
                    Image = request.Image,
                    Biography = request.Biography,
                    CreateDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    
                };
                
                _context.Employees.Add(employ);
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Log.Fatal($"Create employee error {ex.Message}, {ex.StackTrace}");
                throw ex;
            }
        }

        public async Task<int> DeleteEmployee(int id)
        {
            try
            {
                var cus = await _context.Employees.FindAsync(id);
                if (cus == null)
                    throw new EmpExtensions($"Cannot find a employee: {id}");

                _context.Employees.Remove(cus);
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Log.Fatal($"Deleted Employee error {ex.Message}, {ex.StackTrace}");
                throw ex;
            }
        }

        public async Task<PagedResult<Employee>> GetAllEmployee(string fullname, int pageIndex, int pageSize)
        {
            var query = from p in _context.Employees
                        where p.Fullname== fullname
                        orderby p.ModifiedDate descending
                        select p;
                        
                       
            //3 pading
            int totalRow = await query.CountAsync();
            var data = await query.Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .Select(x => new Employee()
                {
                    Id = x.Id,
                    Fullname= x.Fullname,
                    Birthday= x.Birthday,
                    Gender= x.Gender,  
                    Email= x.Email,
                    PhoneNumber    = x.PhoneNumber,
                    Salary = x.Salary,
                    Department= x.Department,
                    Biography= x.Biography,
                    Image= x.Image,
                    CreateDate = x.CreateDate,
                    ModifiedDate = x.ModifiedDate,
                    
                }).ToListAsync();

            //4 select and project
            var pagedResult = new PagedResult<Employee>()
            {
                TotalRecords = totalRow,
                PageIndex = pageIndex,
                PageSize = pageSize,
                Items = data
            };
            return pagedResult;
        }

        public async Task<Employee> GetById(int id)
        {
            try
            {
                return await _context.Employees.FindAsync(id);
            }
            catch (Exception ex)
            {
                Log.Fatal($"GetById error {ex.Message}, {ex.StackTrace}");
                throw ex;
            }
        }
    }
}
