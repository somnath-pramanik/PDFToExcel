using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections;
namespace PDFTOXLS.Models
{
    public class Group
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "can not be blank")]
        public string GroupTitle { get; set; }

        public string Description { get; set; }

        public int? PrimaryConsultant { get; set; }
        //[ForeignKey("PrimaryConsultant")]
        //public virtual Ex_user_new Ex_user_new { get; set; }

        
        
         
    }

  
       
    
}