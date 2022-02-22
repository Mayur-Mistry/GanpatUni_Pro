using GanpatUni_Pro.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace GanpatUni_Pro.Models
{
    [Table("Students")]
    public class Student
    {

        [Display(Name = "Student Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Student_Id { get; set; }

        [Display(Name = "Enrollment Number")]
        [Required]
        [StringLength(20)]
        public string Enroll_No { get; set; }

        

        [Display(Name = "Semester")]
        [Required]
        public int Semester { get; set; }

        [Required]
        [ForeignKey(nameof(Student.Departments))]
        public int Dept_Id { get; set; }
        public Department Departments { get; set; }


        [Required]
        [ForeignKey(nameof(Student.Users))]
        public int User_Id { get; set; }
        public Userm Users { get; set; }


        //____________________ForeignKey_________________

        /*        public ICollection<User> Users { get; set; }*/
        public ICollection<Submission> Submissions { get; set; }
        public ICollection<Group_Transaction> Group_Transactions { get; set; }



    }
}
