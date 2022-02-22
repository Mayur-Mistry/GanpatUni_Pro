using GanpatUni_Pro.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GanpatUni_Pro.Models
{
    [Table("Departments")]
    public class Department
    {
        [Display(Name = "Dept Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Dept_Id { get; set; }


        [Display(Name = "Department Title")]
        [Required]
        [StringLength(20)]
        [Column(TypeName = "varchar")]
        public string Dept_Name { get; set; }
        public ICollection<Assignment> Assignments{ get; set; }
        public ICollection<Student> Students { get; set; }
        public ICollection<Mentor> Mentors { get; set; }



    }
}
