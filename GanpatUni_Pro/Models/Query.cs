
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GanpatUni_Pro.Models
{
    [Table("Querys")]
    public class Query
    {
        [Display(Name = "Query Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Query_Id { get; set; }

      
        [Display(Name = "User Type")]
        [Required]
        public int User_Type { get; set; }



        [Display(Name = "Query Description")]
        [Required]
        [StringLength(300)]

        public string Query_Desc { get; set; }

        [Display(Name = "Query Date")]
        [Required]
        public int Query_Date { get; set; }


        [Display(Name = "Response")]        
        public string Response { get; set; }

        [Required]
        [ForeignKey(nameof(Query.Users))]
        public int User_Id { get; set; }
        public Userm Users { get; set; }

        [Required]
        [ForeignKey(nameof(Query.Mentors))]
        public int Mentor_id { get; set; }
        public Mentor Mentors { get; set; }

        



    }
}
