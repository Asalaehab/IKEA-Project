using IKEA.BLL.DTO;
using IKEA.BLL.Services;
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
                        return RedirectToAction(nameof(Index));
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
    }
}
