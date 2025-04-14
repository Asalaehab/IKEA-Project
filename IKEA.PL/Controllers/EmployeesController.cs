using IKEA.BLL.DTO;
using IKEA.BLL.DTO.EmployeeDTO_s;
using IKEA.BLL.Services.EmployeeServices;
using IKEA.DAL.Models.Shared.enums;
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


        #region Create
        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(CreatedEmployeeDto employeeDto)
        {
            if (ModelState.IsValid)//Server Side Validation
            {
                //try and catch for database validaion
                try
                {
                    int Result = _employeeService.Create(employeeDto);
                    if (Result > 0) return RedirectToAction("Index");
                    else ModelState.AddModelError(string.Empty, "Employee Canot be created");
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
        #endregion


        #region Details
        [HttpGet]
        public IActionResult Details(int? id)
        {

            if (!id.HasValue) return BadRequest();
            var emp = _employeeService.GetById(id.Value);
            return emp == null ? NotFound() : View(emp);

        }
        #endregion

        #region Edit

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue) return BadRequest();

            var employee = _employeeService.GetById(id.Value);

            if (employee == null) return NotFound();

            var empDto = new UpdatedEmployeeDto()
            {
                Id = employee.Id,
                Name = employee.Name,
                Address = employee.Address,
                Age = employee.Age,
                IsActive = employee.IsActive,
                PhoneNumber = employee.PhoneNumber,
                email = employee.email,
                HiringDate = employee.HiringDate,
                Salary = employee.Salary,
                EmployeeType = employee.EmployeeType,
                gender = employee.gender

            };
            return View(empDto);
        }

        [HttpPost]
        public IActionResult Edit([FromRoute]int? id,UpdatedEmployeeDto employeeDto)
        {
            if (!id.HasValue || employeeDto.Id != id) return BadRequest();
            if (!ModelState.IsValid) return View(employeeDto);
            try
            {
                int Result = _employeeService.Update(employeeDto);
                if (Result > 0) return RedirectToAction(nameof(Index));
                else
                {
                    ModelState.AddModelError(string.Empty, "Employee Canot be Updated");
                    return View(employeeDto);
                }
            }
            catch(Exception ex)
            {
                if(_environment.IsDevelopment())
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                    return View(employeeDto);
                }
                else
                {
                    _logger.LogError(ex.Message);
                    return View("Error View", ex.Message);
                }
            }
        }
        #endregion


        #region Delete Employee
        public IActionResult Delete(int id)
        {
            if(id == 0) return BadRequest();
            if (id == 0) { return BadRequest(); }
            try
            {
                bool Deleted = _employeeService.Delete(id);
                if (Deleted) return RedirectToAction(nameof(Index));
                else
                {
                    ModelState.AddModelError(string.Empty, "Employee is not Deleted");
                    return RedirectToAction(nameof(Delete), new { id });
                }

            }
            catch (Exception ex)
            {
                if (_environment.IsDevelopment())
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                    return RedirectToAction(nameof(Delete), new { id });
                }
                else//Deploymnet
                {
                    _logger.LogError(ex.Message);
                    return View("Error View", ex);
                }
            }
        }
        #endregion
    }
}
