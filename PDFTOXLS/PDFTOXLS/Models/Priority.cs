using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections;

namespace PDFTOXLS.Models
{
   public class Priority
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
