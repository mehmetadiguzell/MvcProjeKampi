using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Heading
    {
        [Key]
        public int HeadingId { get; set; }

        [StringLength(50)]
        public string HeadingName { get; set; }
        public DateTime HeadingDate { get; set; }
        public bool Status { get; set; }
        //her başlığın bir kategorisi olacak
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        //her başlığın bir yazarı olacak
        public int WriterId { get; set; }
        public virtual Writer Writer { get; set; }

        //bir başlıkta birden fazla içerik olabilir
        public ICollection<Content> Contents { get; set; }
    }
}
