using System;
using System.Collections.Generic;

namespace KoiDeliv.DataAccess.Models
{
    public partial class Order
    {
        public Order()
        {
            RatingsFeedbacks = new HashSet<RatingsFeedback>();
            Shipments = new HashSet<Shipment>();
        }

        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public string Origin { get; set; } = null!;
        public string Destination { get; set; } = null!;
        public decimal TotalWeight { get; set; }
        public int TotalQuantity { get; set; }
        public string? ShippingMethod { get; set; }
        public string? AdditionalServices { get; set; }
        public string? Status { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual User Customer { get; set; } = null!;
        public virtual ICollection<RatingsFeedback> RatingsFeedbacks { get; set; }
        public virtual ICollection<Shipment> Shipments { get; set; }
    }
}
