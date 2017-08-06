using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PDFTOXLS.Models
{

    public class NotificationNews
    {

        [Key]
        public Int32 Id { get; set; }
        public DateTime DateCreated { get; set; }
        public string NotificationMsg { get; set; }
        public string NotificationTitle { get; set; }
        public Int32 recepiant_id { get; set; }
        public Int32 sender_id { get; set; }
      
        
    }
    
}
