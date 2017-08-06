using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections;
namespace PDFTOXLS.Models
{
    public class Client
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Must be enetred,")]
        [MaxLength(10, ErrorMessage = "Serial Number Exceeds Limit")]
        public string Serial_no { get; set; }
        
        [Required(ErrorMessage = " Name Must be enetred,")]
        [MaxLength(50, ErrorMessage = "Name Exceeds Limit")]
        public string Name { get; set; }
        
        public bool HRMS { get; set; }
         [Required(ErrorMessage = " ERP Must be enetred,")]
        public bool ERP { get; set; }
        public bool CRMS { get; set; }
        public bool PMS { get; set; }

        [MaxLength(500, ErrorMessage = "Too Many Characters")]
        public string ADDRESS1 { get; set; }

        [MaxLength(50, ErrorMessage = "Too Many Characters")]
        public string ZIPCODE { get; set; }
        [MaxLength(50, ErrorMessage = "Too Many Characters")]
        public string PHONE1 { get; set; }
        [MaxLength(50, ErrorMessage = "Too Many Characters")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string E_MAIL { get; set; }
        
        //public int group_id { get; set; }

        public int? RoleMasterId { get; set; }
        [ForeignKey("RoleMasterId")]
        public virtual RoleMaster rolemaster { get; set; }

        public string ContactName { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }
        public int ERPNoUser { get; set; }
        public int HRMSNoUser { get; set; }
        public int CRMNoUser { get; set; }
        public int PMSNoUser { get; set; }
        public int city_id { get; set; }
        [NotMapped]
        public string selectedTeam { get; set; }
        [Required(ErrorMessage = "Must be Select,")]
        public int SlaPolicyId { get; set; }
      
        public DateTime AMCUpto { get; set; }

        public decimal PurchaseAmount { get; set; }
        public DateTime PurchaseDate { get; set; }

        [NotMapped]
        public string NameSrlNo { get; set; }
        //[ForeignKey("group_id")]
        //public virtual Group Group { get; set; }

        public Client()
        {
            ERPNoUser = 0;
            HRMSNoUser = 0;
            CRMNoUser = 0;
            PMSNoUser = 0;
        }
    }

  
       
    
}