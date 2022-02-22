
using GanpatUni_Pro.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace GanpatUni_Pro.Models
{
    [Table("Mentors")]
    public class Mentor
    {

        [Display(Name = "Mentor Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Mentor_Id { get; set; }



        [Required]
        [ForeignKey(nameof(Mentor.Departments))]
        public int Dept_Id { get; set; }
        public Department Departments { get; set; }

               
        [Required]
        [ForeignKey(nameof(Mentor.Users))]
        public int User_Id { get; set; }
        public Userm Users { get; set; }

        public ICollection<Query> Query { get; set; }
        public ICollection<Announcement> Announcements { get; set; }




    }
}
