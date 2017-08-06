using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections;
namespace TicketSystem.Models
{
    public class Client_Group
    {
        [Key]
        public int ID { get; set; }

        public int Client_Id { get; set; }

        public int GROUP_ID { get; set; }
       
        
    }

  
}