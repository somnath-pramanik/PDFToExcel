using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Collections;
using System.ComponentModel.DataAnnotations.Schema;
namespace PDFTOXLS.Models
{
    public class Ex_user_new
    {
        [Key]
        public int USR_ID { get; set; } 

       
        //public string EXUSER { get; set; }
        //public string USERGROUP { get; set; }

        public int? group_id { get; set; }
        [ForeignKey("group_id")]
        public virtual Group Group { get; set; }

         [Required(ErrorMessage = "User Access must be enetred,")]
        public int? RoleMasterId { get; set; }
        [ForeignKey("RoleMasterId")]
        public virtual RoleMaster rolemaster { get; set; }

         [Required(ErrorMessage = "Must be enetred,")]
        public string USER_LNAME { get; set; }
         [Required(ErrorMessage = "User Name must be enetred,")]
        public string USER_FNAME { get; set; }
        [Required(ErrorMessage = "E Mail must be enetred,")]
        public string E_MAIL { get; set; }
         [Required(ErrorMessage = "Please eneter Password,")]
        public string PASS { get; set; }
       // public string Group { get; set; }
         [Required(ErrorMessage = "Retype Password for secuirity,")]
        public string REPASSWORD { get; set; }
        public string WELCOM_MSG { get; set; }
        public bool IsAdministration { get; set; }
        public bool IsManager { get; set; }
        public bool IsMember { get; set; }
        public bool IsClient { get; set; }
        public bool IsTaskAssign { get; set; }
        public bool IsTaskCreate { get; set; }
         [MaxLength(20, ErrorMessage = "Cannot be more than 20 characters")]
        public string OF_PH_EXT { get; set; }
         [MaxLength(20, ErrorMessage = "Cannot be more than 20 characters")]
         public string HM_PH_EXT { get; set; }
         public string UserImg { get; set; }
         public UserStatus UserStatus { get; set; }
         public bool IsInternalOrExternal { get; set; }

         public bool IsGlobalAccess { get; set; }
         public bool IsTeamAccess { get; set; }
         public bool IsSelfAccess { get; set; }
         public bool IsChangeAdmin { get; set; }
         public  string TicketAccess { get; set; }
        [NotMapped]
         public string selectedTeam { get; set; }
        public int? TimeZoneId { get; set; }    
         
        public string FullName
         {
             get
             {
                 return USER_FNAME + " " + USER_LNAME;
             }
         }
        public Ex_user_new()
        {
            OF_PH_EXT = "";
            HM_PH_EXT = "";

            //AUD_LOCK = false;
            //EXUSER = "";
           // USERGROUP = "";
            //LAVEL = "";
            //RATEEDIT =false;
            // B_DATE = DateTime.Now;
            // SP_NAME = "";
            // SY_DOCNO = 0;
            //  WELCOM_MSG = "";
            //  REPASSWORD = "";
             
        }

    }

    public enum ActiveStatus
    {
       Open,
        OnHold,
        Closed,
        Approved,
        Reopen,
        Working,
        DeveloperClosed
    }

    public enum UserStatus
    {
        Active,
        Inactive,
        Closed
    }
       
    
}