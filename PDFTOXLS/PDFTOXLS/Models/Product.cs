using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections;

namespace PDFTOXLS.Models
{
   public class Product
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
    }

   public class ProductView
   {
       public int ID { get; set; }
       public string Name { get; set; }

   }
}
