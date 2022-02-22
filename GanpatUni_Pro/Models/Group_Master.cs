using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace GanpatUni_Pro.Models
{
    [Table("Group_Masters")]
    public class Group_Master
    {
        [Display(Name = "Group Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Group_Id { get; set; }

        [Display(Name = "Group Name")]
        [Required]
        [StringLength(20)]
        [Column(TypeName = "varchar")]
        public string Group_Name { get; set; }

        [Display(Name = "Group Image")]
        [Column(TypeName = "varchar")]
        public string Group_Image { get; set; }

        [Display(Name = "Group Description")]
        [StringLength(50)]
        [Column(TypeName = "varchar")]
        public string Group_desc{ get; set; }


        [Required]
        [ForeignKey(nameof(Group_Master.Mentors))]
        public int Mentor_Id { get; set; }
        public Mentor Mentors { get; set; }


        public ICollection<Assignment> Assignments { get; set; }
        public ICollection<Announcement> Announcements { get; set; }

        public ICollection<Group_Transaction> Group_Transactions { get; set; }



    }
}
