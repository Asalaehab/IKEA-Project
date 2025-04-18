using IKEA.BLL.Profiles;
using IKEA.BLL.Services.Department;
using IKEA.BLL.Services.EmployeeServices;
using IKEA.DAL.Persintance.Data.Contexts;
using IKEA.DAL.Persintance.Reposatories.classes;
//using IKEA.DAL.Persintance.Reposatories.Interfaces;
using IKEA.DAL.Persintance.Reposatories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IKEA.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region To Configure services
            // Add services to the container.
            builder.Services.AddControllersWithViews();
            //builder.Services.AddScoped<ApplicationDbcontext>();//2.Register To Services in DI container
            
            builder.Services.AddControllersWithViews(options=>
            {
                options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
            });
            
            builder.Services.AddDbContext<ApplicationDbcontext>(options=>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
                options.UseLazyLoadingProxies();
            });
            ////2-Register for Serices
            //builder.Services.AddScoped<DepartmentRepository>();

            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            //So If Any Own Need Reference From IDepartmentRepository you will pass Object From DepartmentReposatory
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();
            builder.Services.AddScoped<IDepartmentService, DepartmentService>();
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            //builder.Services.AddScoped<IEmployeeService,>
            builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);
            builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();
            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.


            #region Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            #endregion
            app.Run();
        }
    }
}
