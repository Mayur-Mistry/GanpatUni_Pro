using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace GanpatUni_Pro.Models
{
    [Table("Meetings")]
    public class Meeting
    {
        [Display(Name = "Meeting Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Meeting_Id { get; set; }

       

        [Display(Name = "Topic")]
        [Required]
        [StringLength(50)]
        public string Topic{ get; set; }

        [Display(Name = "Link")]
        [Required]
        [StringLength(200)]
        public string Meeting_Link { get; set; }

        [Display(Name = "Meeting Date")]
        [Required]
        public DateTime Meeting_Date { get; set; }

        [Display(Name = "Meeting Start-time")]
        [Required]
        public DateTime Meeting_StartTime { get; set; }

        [Display(Name = "Meeting End-time")]
        
        public DateTime Meeting_EndTime { get; set; }

        [Required]
        [ForeignKey(nameof(Meeting.Users))]
        public int User_Id { get; set; }
        public Userm Users{ get; set; }
        


    }
}
