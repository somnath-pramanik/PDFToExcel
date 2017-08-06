using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Collections;
namespace PDFTOXLS.Models
{
    public class Ex_user
    {
        [Key]
        public int USR_ID { get; set; } 
       
        public string EXUSER { get; set; }
        public string USERGROUP { get; set; }
        public bool AUD_LOCK { get; set; }
        public bool AUD_UNLOCK { get; set; }
        public bool PDATED { get; set; }
        public int MDAYS { get; set; }
        public string PASS { get; set; }
        public int PDAYS { get; set; }
        public string PASSDATE { get; set; }
        public string PASSGROUP { get; set; }
        public string ACT_STAT { get; set; }
        public string OPEN_DATE { get; set; }
        public string WPASS_ENT { get; set; }
        public string PASS_DATE { get; set; }
        public string LAVEL { get; set; }
        public bool RATEEDIT { get; set; }
        public bool CHAL_DATED { get; set; }
        public string DEL_DATE { get; set; }
        public string UOPEN_DATE { get; set; }
        public string ADDRESS { get; set; }
        public byte[] EX_UPIC { get; set; }
        //public decimal USR_ID { get; set; }
        public string USR_TITLE { get; set; }
        public string USER_NAME { get; set; }
        //[Required(ErrorMessage="Can Not Be Blanked")]
        //[StringLength(40)]
        public string EUSER_NAME { get; set; }
        public string J_TITLE { get; set; }
        public string USER_FNAME { get; set; }
        public string USER_LNAME { get; set; }
        public string USER_EFNAME { get; set; }
        public string USER_ELNAME { get; set; }
        public string REPO_TO { get; set; }
        public string ACCGROUP { get; set; }
        public string DIST_CITY { get; set; }
        public string POSTAL_CODE { get; set; }
        public string COUNTRY { get; set; }
        public decimal OF_PH_EXT { get; set; }
        public string OFF_PHONE { get; set; }
        public string HM_PHONE { get; set; }
        public decimal HM_PH_EXT { get; set; }
        
        public string MOBILE { get; set; }
        public string E_MAIL { get; set; }
        public System.DateTime B_DATE { get; set; }
        public string SP_NAME { get; set; }
        public string STATE { get; set; }
        public System.DateTime PSWD_REQDATE { get; set; }
        public bool MAXPERCENT { get; set; }
        public string SUPER_USER { get; set; }
        public string UMOD_CODE { get; set; }
        public string EXUSER1 { get; set; }
        public string DBNAME { get; set; }
        public string SY_OBJ_NAME { get; set; }
        public decimal SY_DOCNO { get; set; }
        public bool ALL_CUST { get; set; }
        public bool IS_PRODGRP { get; set; }
        public bool IS_EXP_BATCH { get; set; }
        public string Group { get; set; }
        public string Item { get; set; }
        //public virtual ICollection<EMPLOYEE_HEAD> EMPLOYEE_HEAD { get; set; }
      
        public string REPASSWORD { get; set; }
        public string WELCOM_MSG { get; set; }
        public bool IsAdministration { get; set; }
        public bool IsManager { get; set; }
        public bool IsMember { get; set; }
        public bool IsClient { get; set; }
        public Ex_user()
        {
            AUD_LOCK = false;
            AUD_UNLOCK =false;
            PDATED = false;
            MDAYS = 0;
            PDAYS =0;
            PASSDATE = "";
            ACT_STAT = "";
            OPEN_DATE = "";
            WPASS_ENT = "";
            PASS_DATE = "";
            LAVEL = "";
            RATEEDIT =false;
            CHAL_DATED = false;
            DEL_DATE = "";
            UOPEN_DATE = "";
            ADDRESS = "";
            PASSGROUP = "";
            USR_TITLE = "";
            USER_NAME = "";
            EUSER_NAME = "";
            J_TITLE = "";
            USER_FNAME = "";
            USER_LNAME = "";
             USER_EFNAME = "";
             USER_ELNAME = "";
             REPO_TO = "";
             ACCGROUP = "";
             DIST_CITY = "";
             POSTAL_CODE = "";
             COUNTRY = "";
             OF_PH_EXT =0;
             OFF_PHONE = "";
             HM_PHONE = "";
             HM_PH_EXT = 0;
             MOBILE = "";
             E_MAIL = "";
             B_DATE = DateTime.Now;
             SP_NAME = "";
             STATE = "";
             MAXPERCENT = false;
             SUPER_USER = "";
             UMOD_CODE = "";
             EXUSER1 = "";
             DBNAME = "";
             SY_OBJ_NAME = "";
             SY_DOCNO = 0;
             ALL_CUST =false;
             IS_PRODGRP = false;
             IS_EXP_BATCH = false;
             Group = "";
              Item = "";
              WELCOM_MSG = "";
              REPASSWORD = "";
             
        }

    }

  
       
    
}