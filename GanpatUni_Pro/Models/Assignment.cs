using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GanpatUni_Pro.Models
{
    [Table("Assignments")]
    public class Assignment
    {
        [Display(Name = "Assignment Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Assignment_Id { get; set; }

        [Display(Name = "Assignment Title")]
        [Required]
        [StringLength(20)]
        [Column(TypeName = "varchar")]
        public string Assignment_Title { get; set; }

        [Display(Name = "Assignment StartingDate")]
        [Required]
        public DateTime Assignment_StartingDate { get; set; }

        [Display(Name = "Assignment EndingDate")]
        [Required]
        public DateTime Assignment_EndingDate { get; set; }

      

        [Display(Name = "Semester")]
        [Required]       
        public int Semester { get; set; }

        [Display(Name = "Document")]
        public string Document { get; set; }

        [Required]
        [ForeignKey(nameof(Assignment.Mentors))]
        public int Mentor_Id { get; set; }
        public Mentor Mentors { get; set; }


        [Required]
        [ForeignKey(nameof(Assignment.Departments))]
        public int Dept_Id { get; set; }
        public Department Departments { get; set; }


        [Required]
        [ForeignKey(nameof(Assignment.Group_Masters))]
        public int Group_Id { get; set; }
        public Group_Master Group_Masters { get; set; }


        //___________F1
        public ICollection<Submission> Submisions{ get; set; }

    }
}
