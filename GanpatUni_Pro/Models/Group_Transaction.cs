using GanpatUni_Pro.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GanpatUni_Pro.Models
{
    [Table("Group_Transactions")]
    public class Group_Transaction
    {
        [Display(Name = "GroupTransaction_Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GroupTransaction_Id { get; set; }

        [Required]
        [ForeignKey(nameof(Group_Transaction.Group_Masters))]
        public int Group_Id { get; set; }
        public Group_Master Group_Masters { get; set; }

        [Required]
        [ForeignKey(nameof(Group_Transaction.Students))]
        public int Student_Id { get; set; }
        public Student Students{ get; set; }

      

    }
}
