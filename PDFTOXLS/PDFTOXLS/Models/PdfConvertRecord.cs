using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections;

namespace PDFTOXLS.Models
{
    public class PdfConvertRecord
    {
        [Key]
        public int ID { get; set; }
        public int UserId { get; set; }
        public string pdffilename { get; set; }
        public string xlsfilename { get; set; }
        public DateTime? datecreated { get; set; }
        public bool isactive { get; set; }
    }
}
