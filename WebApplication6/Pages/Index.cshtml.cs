using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication6.Models;
using WebApplication6.Services;

namespace WebApplication6.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public List<Employee> employees;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            EmployeeService employeeService = new EmployeeService();
            employees = employeeService.GetEmployees();
        }
    }
}