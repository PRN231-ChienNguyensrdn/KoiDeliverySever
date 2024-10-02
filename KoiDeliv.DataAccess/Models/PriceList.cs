using System;
using System.Collections.Generic;

namespace KoiDeliv.DataAccess.Models
{
    public partial class PriceList
    {
        public PriceList()
        {
            Blogs = new HashSet<Blog>();
        }

        public int PriceId { get; set; }
        public string WeightRange { get; set; } = null!;
        public decimal BasePrice { get; set; }
        public decimal? AdditionalServicePrice { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual ICollection<Blog> Blogs { get; set; }
    }
}
