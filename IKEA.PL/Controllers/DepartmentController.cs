using IKEA.BLL.DTO;
using IKEA.BLL.Services;
using IKEA.PL.Views.DepartmentViewModel;
using Microsoft.AspNetCore.Mvc;

namespace IKEA.PL.Controllers
{
    public class DepartmentController: Controller
    {
        private readonly IDepartmentService _departmentService;
        private readonly ILogger<DepartmentController> _logger;

        public IWebHostEnvironment Environment { get; }


        // Constructor injection
        public DepartmentController(IDepartmentService departmentService, ILogger<DepartmentController> logger,IWebHostEnvironment environment)
        {
            _departmentService = departmentService;
            _logger = logger;//To can Record the error
        
            Environment = environment;//To Can Check the Env
        }
        //Get BaseUrl/Departments/Index

        [HttpGet]
        public IActionResult Index()
        {
            var departments = _departmentService.GetAllDepartents();
            return View(departments);
        }


        #region Create Department
        [HttpGet]
        public IActionResult Create()=>  View();

        [HttpPost]
        public IActionResult Create(CreatedDepartmentDto dto)
        {
            if (ModelState.IsValid)//Server Side Validation
            {
                // add try catch because if there is any error in database model
                try
                {
                    int Result = _departmentService.AddDepartment(dto);
                    if (Result > 0)
                    {
                        //return RedirectToAction(nameof(Index));
                        return View(nameof(Index));//XXXXX
                    }//if it created go to index view
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Department Can not be created");
                        //return View(dto);//will go to create with get
                    }
                }
                catch(Exception ex)
                {
                    //Log Exception

                    //1.Development:Log Error in console and return the same view with error message  =>
                    //This means you will print the error message in the terminal (output window), which is useful when you're developing your application.

                    //2.Deployment: log error in file or table in database and return view Error


                    if (Environment.IsDevelopment())
                    {
                        ModelState.AddModelError(string.Empty,ex.Message);
                        //return View(dto);
                    }
                    else//Deploymnet
                    {
                        _logger.LogError(ex.Message);
                        //return View(dto);//we can make view for error
                    }
                }
            }
                return View(dto);//return the same view to can check the errors
        }
        #endregion



        #region Department Details

        [HttpGet]
        public IActionResult Details(int? id)
        {
            //if i doesnot have value return bad request
            if (!id.HasValue) return BadRequest();//400
            var department=_departmentService.GetDepartmentById(id.Value);
            if (department is null) return NotFound();//404

            return View(department);
        }
        #endregion


        #region Edit Department

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue) return BadRequest();//400
            var department = _departmentService.GetDepartmentById(id.Value);
            if (department is null) return NotFound();//404
            var departmentView = new DepartmentEditViewModel()
            {
                Code = department.Code,
                Name = department.Name,
                Description = department.Description,
                DateOfCreation=department.CreatedOn

            };
            return View(departmentView);

        }


        [HttpPost]
        public IActionResult Edit([FromRoute]int id,DepartmentEditViewModel viewModel)
        {
            if (!ModelState.IsValid) { return View(viewModel); }
            try
            {
                var updatedDepartment = new UpdatedDepartmentDto()
                {
                    Id = id,
                    Code = viewModel.Code,
                    Name = viewModel.Name,
                    Description = viewModel.Description,
                    DateOfCreation = viewModel.DateOfCreation

                };
                int Result = _departmentService.UpdateDepartment(updatedDepartment);

                if (Result > 0)  return RedirectToAction(nameof(Index));
                else
                {
                    ModelState.AddModelError(string.Empty, "Department is not Updated");
                }
            }
            catch (Exception ex)
            {
                if (Environment.IsDevelopment())
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                   
                }
                else//Deploymnet
                {
                    _logger.LogError(ex.Message);
                }
            }
            return View(viewModel);
        }
        #endregion


        #region Delete Department
        //[HttpGet]
        //public IActionResult Delete(int? id)
        //{
        //    if (!id.HasValue) return BadRequest();
        //    var department=_departmentService.GetDepartmentById(id.Value);

        //    if (department is null) return NotFound();

        //    return View(department);

        //}

        [HttpPost]
        public IActionResult Delete(int id)
        {
            if(id==0) { return BadRequest(); }
            try
            {
                bool Deleted = _departmentService.DeleteDepartment(id);
                if (Deleted) return RedirectToAction(nameof(Index));
                else
                {
                    ModelState.AddModelError(string.Empty, "Department is not Deleted");
                    return RedirectToAction(nameof(Delete), new { id });
                }

            }
            catch (Exception ex)
            {
                if (Environment.IsDevelopment())
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                    return RedirectToAction(nameof(Delete), new { id });
                }
                else//Deploymnet
                {
                    _logger.LogError(ex.Message);
                    return View("Error View",ex);
                }
            }
            
        }
        #endregion
    }
}
