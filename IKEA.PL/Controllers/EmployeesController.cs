using IKEA.BLL.DTO;
using IKEA.BLL.DTO.EmployeeDTO_s;
using IKEA.BLL.Services.Department;
using IKEA.BLL.Services.EmployeeServices;
using IKEA.DAL.Models.Shared.enums;
using IKEA.PL.Views.DepartmentViewModel;
using Microsoft.AspNetCore.Mvc;

namespace IKEA.PL.Controllers
{
    public class EmployeesController(IEmployeeService _employeeService, IWebHostEnvironment _environment,ILogger<EmployeesController>_logger) : Controller
    {
        
        public IActionResult Index(string? EmployeeSearchName)
        {
            var Employees = _employeeService.GetAll(EmployeeSearchName);
            return View(Employees);
        }


        #region Create
        [HttpGet]
        public IActionResult Create([FromServices]IDepartmentService _departmentService)
        {
            ViewData["Departments"] = _departmentService.GetAllDepartents();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EmployeeViewModel employeeView)
        {
            if (ModelState.IsValid)//Server Side Validation
            {
                var employeeDto = new CreatedEmployeeDto()
                {
                    Name = employeeView.Name,
                    Age= employeeView.Age,
                    Salary= employeeView.Salary,
                    PhoneNumber= employeeView.PhoneNumber,
                    email  =employeeView.email,
                    gender= employeeView.gender,
                    HiringDate= employeeView.HiringDate,
                    IsActive= employeeView.IsActive,
                    EmployeeType= employeeView.EmployeeType,
                    Address= employeeView.Address,
                    CreatedBy= employeeView.CreatedBy,
                    LastModifiedBy= employeeView.LastModifiedBy,
                    DepartmentId= employeeView.DepartmentId,
                };
                //try and catch for database validaion
                try
                {
                    int Result = _employeeService.Create(employeeDto);
                    string Message;
                    if (Result > 0)
                    {
                        
                        return RedirectToAction("Index");
                    }
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
          
            return View(employeeView);
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

            var empDto = new EmployeeViewModel()
            {
                //Id = employee.Id,
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
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute]int? id,EmployeeViewModel employeeViewModel)
        {
            if (!id.HasValue ) return BadRequest();
            var employeeDto = new UpdatedEmployeeDto()
            {
                Id = id.Value,
                Name = employeeViewModel.Name,
                Address = employeeViewModel.Address,
                Age= employeeViewModel.Age,
                IsActive = employeeViewModel.IsActive,  
                PhoneNumber = employeeViewModel.PhoneNumber,
                CreatedBy = employeeViewModel.CreatedBy,
                LastModifiedBy = employeeViewModel.LastModifiedBy,
                EmployeeType= employeeViewModel.EmployeeType,
                gender=employeeViewModel.gender,
                email=employeeViewModel.email,
                HiringDate= employeeViewModel.HiringDate,
                Salary= employeeViewModel.Salary,
                DepartmentId= employeeViewModel.DepartmentId,
                
            };
            if (!ModelState.IsValid) return View(employeeViewModel);
            try
            {
                int Result = _employeeService.Update(employeeDto);
                if (Result > 0) return RedirectToAction(nameof(Index));
                else
                {
                    ModelState.AddModelError(string.Empty, "Employee Canot be Updated");
                    return View(employeeViewModel);
                }
            }
            catch(Exception ex)
            {
                if(_environment.IsDevelopment())
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                    return View(employeeViewModel);
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
        [ValidateAntiForgeryToken]
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
