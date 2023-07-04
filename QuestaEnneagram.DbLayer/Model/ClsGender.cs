using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestaEnneagram.DbLayer.Model
{


    [Table("mstDepartment")]
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DepartmentId { get; set; }

        [Required]
        [StringLength(50)]
        public string DepartmentName { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }

    [Table("mstEmployee")]
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; }

        [Required]
        [StringLength(50)]
        public string EmployeeName { get; set; }

        // Foreign key   
        [Display(Name = "Department")]
        public virtual int DepartmentId { get; set; }

        [ForeignKey("mstEmployee_mstDepartment_DepartmentId")]
        public virtual Department Departments { get; set; }
    }



}
