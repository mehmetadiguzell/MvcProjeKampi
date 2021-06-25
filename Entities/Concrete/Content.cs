using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Content
    {
        [Key]
        public int ContentId { get; set; }

        [StringLength(1000)]
        public string ContentValue { get; set; }
        public DateTime ContentDate { get; set; }

        //her içeriğin bir başlığı olacak
        public int HeadingId { get; set; }
        public virtual Heading Heading { get; set; }

        public bool Status { get; set; }

        public int? WriterId { get; set; }
        public virtual Writer Writer { get; set; }
    }
}
