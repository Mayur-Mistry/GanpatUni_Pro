using GanpatUni_Pro.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GanpatUni_Pro.Models
{
    [Table("Userms")]
    public class Userm
    {
        [Display(Name = "User ID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int User_id { get; set; }

        [Display(Name = "User Type")]
        [Required]
        [StringLength(5)]
        [Column(TypeName = "varchar")]
        public User_types User_type { get; set; }

        [Display(Name = "Email")]
        [Required]
        [StringLength(30)]
        [Column(TypeName = "varchar")]
        public string Email_id { get; set; }

        [Display(Name = "Password")]
        [Required]
        [StringLength(20)]
        [Column(TypeName = "varchar")]

        public string Password{ get; set; }

        [Display(Name = "Name")]
        [Required]
        [StringLength(20)]
        [Column(TypeName = "varchar")]
        public string Name{ get; set; }


        [Display(Name = "Address")]
        [Required]
        [StringLength(250)]
        [Column(TypeName = "varchar")]
        public string Address { get; set; }


        [Display(Name = "Mobile Number")]
        [Required]
        [StringLength(30)]    
        public string Mobile_no { get; set; }


        [Display(Name = "Date Of Birth")]
        [Required]

        public DateTime DateOfBirth { get; set; }


      /*  [Display(Name = "Student Id")]
        [Required]
        public int StudentId { get; set; }*/


        [Display(Name = "Pincode")]
        [Required]
        public int Pincode { get; set; }

        //____________________ForeignKey_________________

        /*   [Required]
           [ForeignKey(nameof(User.Student))]
           public int Student_Id{ get; set; }
           public Student Student { get; set; }*/
        public ICollection<Student> Students{ get; set; }
        public ICollection<Mentor> Mentors { get; set; }
        public ICollection<Query> Querys { get; set; }
        public ICollection<Meeting> Meetings { get; set; }



    }
    public enum User_types { 
    ADMIN=1,
    HOD=2,
    FAC=3,
    STUD=4

    }
}
