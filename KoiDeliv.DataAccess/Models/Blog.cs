using System;
using System.Collections.Generic;

namespace KoiDeliv.DataAccess.Models
{
    public partial class Blog
    {
        public int BlogId { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public string? ImagePath { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? AuthorId { get; set; }
        public int? PriceListId { get; set; }

        public virtual User? Author { get; set; }
        public virtual PriceList? PriceList { get; set; }
    }
}
