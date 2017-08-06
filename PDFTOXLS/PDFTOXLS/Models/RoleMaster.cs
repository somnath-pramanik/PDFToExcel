using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections;
namespace PDFTOXLS.Models
{
    public class RoleMaster
    {
        [Key]
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }

        [Required(ErrorMessage = "Must be enetred,")]
        [MaxLength(150, ErrorMessage = "RoleName Exceeds Limit")]
        public string RoleName { get; set; }
        public string Description { get; set; }

        public bool IsCategory { get; set; }
        public bool IsNewTicket { get; set; }
        public bool IsGrouopClientMapping { get; set; }
        public bool IsFieldAccess { get; set; }
        public bool IsUserAccess { get; set; }
        public bool IsChangeStatus { get; set; }
        public bool IsViewInternalDiscussion { get; set; }
        public bool IsAssignTo { get; set; }
        public bool IsApproval { get; set; }
        public bool IsPriority { get; set; }
        public bool IsCreateUser { get; set; }
        public bool IsCreateUserGroup { get; set; }
        public bool IsCreateCustomer { get; set; }
        public bool IsViewGroupTicket { get; set; }
       
        public bool IsShowLayOut { get; set; }
        public bool IsUserClientMapping { get; set; }
        public bool IsClientUserMapping { get; set; }
        public bool IsTeam { get; set; }
        public bool IsSlaPolicy { get; set; }
        public bool IsBusinessCalendar { get; set; }
        public bool IsTeamUserModule { get; set; }

        public bool IsAddRelease { get; set; }
        public bool IsAddNews { get; set; }
        //public bool IsReportVisible { get; set; }
        public bool IsExport { get; set; }

        public string reportlist { get; set; }
    }
}