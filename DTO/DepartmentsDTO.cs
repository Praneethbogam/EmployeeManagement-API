using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;



namespace TestEmployeeManagement.DTO
{
    public class DepartmentsDTO
    {
        [Key]
        public int DepartmentId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [StringLength(250)]
        public string? Description { get; set; }

        [StringLength(150)]
        public string? Location { get; set; }

        public bool IsActive { get; set; }
        //public object DepartmentName { get; internal set; }
    }

}
