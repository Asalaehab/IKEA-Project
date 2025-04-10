using IKEA.DAL.Models.EmployeeModels;
using IKEA.DAL.Models.Shared.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.DAL.Persintance.Data.Configrations
{
    public class EmployeeConfigrations : BaseEntityCongigrations<Employee>, IEntityTypeConfiguration<Employee>
    {
        public new void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(E => E.Name).HasColumnType("Varchar(50)");
            builder.Property(E => E.Address).HasColumnType("varchar(100)");
            builder.Property(E => E.Salary).HasColumnType("decimal(10,2)");
            builder.Property(E => E.gender)
                            .HasConversion((EmpGender) => EmpGender.ToString(),
                            (gender) => (Gender)Enum.Parse(typeof(Gender), gender));
            builder.Property(E => E.EmployeeType)
                            .HasConversion((EmpGender) => EmpGender.ToString(),
                            (employeeType) => (EmployeeType)Enum.Parse(typeof(EmployeeType), employeeType));
            base.Configure(builder);//To Can Do the Configgure on the base
        }
    }
}
