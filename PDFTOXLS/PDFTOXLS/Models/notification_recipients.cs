using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PDFTOXLS.Models
{
    public class notification_recipients
    {
        [Key]
        public Int32 Id { get; set; }
        public DateTime DateCreated { get; set; }

        //[BelongsTo("UserID", NotNull = false, Lazy = FetchWhen.OnInvoke)]
        //public PMS_User user { get; set; }
        //[BelongsTo("notificatio_Id", NotNull = false, Lazy = FetchWhen.OnInvoke)]
        //public PMS_notifications notificationId { get; set; }
        //[BelongsTo("recipient_id", NotNull = false, Lazy = FetchWhen.OnInvoke)]

        public Int32 recipient_id { get; set; }
        public string recipient_name { get; set; }
        public string recipient_email { get; set; }
        public DateTime? seen_on { get; set; }
        public DateTime? read_on { get; set; }
        public Int32 ForProject { get; set; }
        public Int32 ForCompany { get; set; }
        public Int32 ForTask { get; set; }
        //public string sender_name { get; set; }
        //public string sender_email { get; set; }
        public Int32 OwnerID { get; set; }
        public Int32 UserID { get; set; }
        public Int32 notificatio_Id { get; set; }
        public bool isRead { get; set; }

        
    }
}
