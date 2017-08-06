using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections;
namespace PDFTOXLS.Models
{
    public class ProductModule
    {
        [Key]
        public int ID { get; set; }

        public string ModuleName { get; set; }
        public string ProductName { get; set; }
        public int product_id { get; set; }
       
    }

  
       
    
}