using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections;
namespace PDFTOXLS.Models
{
    public class User_Client
    {
        [Key]
        public int ID { get; set; }

        public int USER_ID { get; set; }
        public int Client_Id { get; set; }

        public bool Is_PC { get; set; }
        
       
        
    }

  
}