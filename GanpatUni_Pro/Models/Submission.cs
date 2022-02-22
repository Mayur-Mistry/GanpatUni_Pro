using GanpatUni_Pro.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GanpatUni_Pro.Models
{
    [Table("Submissions")]
    public class Submission
    {
        [Display(Name = "Submission Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Submission_Id{ get; set; }


        [Display(Name = "Submission Time")]
        [Required]
        public DateTime Submission_Time{ get; set; }

        [Display(Name = "Submission Document")]
        [StringLength(50)]
        [Required]
        public string Submission_Document{ get; set; }

        [Display(Name = "Comment")]
        [StringLength(200)]
        public string Comment{ get; set; }

        [Display(Name = "Status")]
        public int Status { get; set; }
        //------------F1

        [Required]
        [ForeignKey(nameof(Submission.Student))]
        public int Student_Id { get; set; }
        public Student Student { get; set; }

        [Required]
        [ForeignKey(nameof(Submission.Assignment))]
        public int Assignment_Id { get; set; }
        public Assignment Assignment{ get; set; }



    }
}
