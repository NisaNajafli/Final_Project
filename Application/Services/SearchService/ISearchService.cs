using Application.DTOs.ClientDto;
using Application.DTOs.EmployeeDto;
using DataAccess.DataContext;
using DataAccess.Entities;
using DataAccess.Migrations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.SearchService
{
    public interface ISearchService
    {
        Task<List<GetEmployeeForSearch>> SearchEmployee( string username);
        Task<List<GetClientForSearch>> SearchClient( string username);
    }
    public class SearchService : ISearchService
    {
        private readonly ManagementDb _context;

        public SearchService(ManagementDb context)
        {
            _context = context;
        }

        public async Task<List<GetClientForSearch>> SearchClient( string username)
        {
            var query = _context.Clients ;
            if (username != null)
            {
                query.Where(h => username.Contains(h.UserName));
            }

            List<Client> clients = await query.ToListAsync();
            List<GetClientForSearch> clientdtos = new List<GetClientForSearch>();
            foreach (var client in clients)
            {
                clientdtos.Add(new GetClientForSearch()
                {
                    Id = client.Id,
                    Phone=client.PhoneNumber,
                    Email = client.Email,
                    Username = client.UserName,
                });
            }

            return clientdtos.OrderBy(c => c.Username).ToList();

        }

        public async Task<List<GetEmployeeForSearch>> SearchEmployee( string username)
        {
            var query = _context.Employees;
            if (username != null)
            {
                query.Where(h => username.Contains(h.UserName));
            }
           
            List<Employee> employees = await query.ToListAsync();
            List<GetEmployeeForSearch> employeedtos = new List<GetEmployeeForSearch>();
            foreach (var employee in employees)
            {
                employeedtos.Add(new GetEmployeeForSearch()
                {
                    Id = employee.Id,
                    Payments = employee.Payments.Sum(c => c.NetPay),
                    Email = employee.Email,
                    Username = employee.UserName,
                });
            }
           
            return employeedtos.OrderBy(c=>c.Username).ToList();
        }
    }
}
