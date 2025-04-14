using IKEA.BLL.DTO;
using IKEA.BLL.DTO.EmployeeDTO_s;
using IKEA.BLL.Services.EmployeeServices;
using Microsoft.AspNetCore.Mvc;

namespace IKEA.PL.Controllers
{
    public class EmployeesController(IEmployeeService _employeeService, IWebHostEnvironment _environment,ILogger<EmployeesController>_logger) : Controller
    {
        
        public IActionResult Index()
        {
            var Employees = _employeeService.GetAll();
            return View(Employees);
        }


        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(CreatedEmployeeDto employeeDto)
        {
            if(ModelState.IsValid)//Server Side Validation
            {
                //try and catch for database validaion
                try
                {
                    int Result=_employeeService.Create(employeeDto);
                    if (Result > 0) return RedirectToAction("Index");
                    else ModelState.AddModelError(string.Empty,"Employee Canot be created");
                    //will go back to the view
                }
                catch (Exception ex)
                {
                    if (_environment.IsDevelopment())
                        ModelState.AddModelError(string.Empty, ex.Message);
                    else
                        _logger.LogError(ex.Message);
                }
            }
           return View(employeeDto);
        }


        [HttpGet]
        public IActionResult Details(int ? id)
        {

            if (!id.HasValue) return BadRequest();
            var emp=_employeeService.GetById(id.Value);
           return emp == null ? NotFound() : View(emp);
        
        }
    }
}
