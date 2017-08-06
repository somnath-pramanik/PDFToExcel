using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections;
namespace PDFTOXLS.Models
{
    public class tbTimeZoneInfo
    {
        [Key]
        public int TimeZoneID { get; set; }

        public string Display { get; set; }
        public string ZoneId { get; set; }
        public string timeoffset { get; set; }
        

    }
}