using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PDFTOXLS.Models
{

    public class notifications
    {

        [Key]
        public Int32 Id { get; set; }
        public DateTime DateCreated { get; set; }
        public string NotificationMsg { get; set; }
        public string NotificationTitle { get; set; }
        public Int32 ForProject { get; set; }
        public Int32 parent_id { get; set; }
        public Int32 sender_id { get; set; }
        public string sender_name { get; set; }
        public string sender_email { get; set; }
        public DateTime? created_on { get; set; }
        public string raw_additional_properties { get; set; }
        public Int32 OwnerID { get; set; }
        public Int32 UserID { get; set; }
       
        public Int32 UserToID { get; set; }
        public string ch_status { get; set; }
        public string ch_priority { get; set; }
        public string ch_category { get; set; }
        [NotMapped]
        public string CreateUserImg { get; set; }
        public string msgsuffix { get; set; }
        public string msgsuffforexternal { get; set; }
        public string ticket_no { get; set; }
        
        
    }
    public enum NotificationTypeA
    {
        NewTicket,
        UpdateTicket,
        NewChanges,
        UpdateChanges,
        ChangeCategory,
        ChangeStatus,
        ChangePriority
    }

    public enum NotificationParentTypeA
    {
        Ticket,
        Changes
    }
}
