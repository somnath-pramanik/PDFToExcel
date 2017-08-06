using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections;
namespace PDFTOXLS.Models
{
    public class USERLOG
    {
        [Key]
        public int ID { get; set; }

        public int user_id { get; set; }
        public DateTime EENT_DATE { get; set; }
        public DateTime EOUT_DATE { get; set; }
        public bool FAILURE { get; set; }
	
    }

  
}