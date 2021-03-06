using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Entities.Concrete
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }

        [StringLength(100)]
        public string Subject { get; set; }

        [StringLength(50)]
        public string SenderMail { get; set; }

        [StringLength(50)]
        public string ReceiverMail { get; set; }

        [AllowHtml]
        public string MessageContent { get; set; }

        public DateTime MessageDate { get; set; }

        public bool IsRead { get; set; }

        public bool IsDraft { get; set; }


    }
}
