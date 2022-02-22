using GanpatUni_Pro.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GanpatUni_Pro.Models
{
    [Table("Announcements")]
    public class Announcement
    {
        [Display(Name = "Announcement ID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Announcement_Id { get; set; }

     

        [Display(Name = "Description")]
        [Required]
        [StringLength(100)]
        public string Desc{ get; set; }
        
        
        [Display(Name = "Document")]
        public string Document{ get; set; }
       
        [Display(Name = "Date")]
        public DateTime Announcement_Date { get; set; }

        [Required]
        [ForeignKey(nameof(Announcement.Mentors))]
        public int Mentor_Id { get; set; }
        public Mentor Mentors { get; set; }

        [Required]
        [ForeignKey(nameof(Announcement.Group_Masters))]
        public int Group_Id { get; set; }
        public Group_Master Group_Masters { get; set; }
  



    }
}
