using System;
using System.Collections.Generic;

namespace KoiDeliv.DataAccess.Models
{
    public partial class CustomerProfile
    {
        public int ProfileId { get; set; }
        public int CustomerId { get; set; }
        public int? TotalOrders { get; set; }
        public decimal? TotalSpent { get; set; }
        public DateTime? LastOrderDate { get; set; }

        public virtual User Customer { get; set; } = null!;
    }
}
