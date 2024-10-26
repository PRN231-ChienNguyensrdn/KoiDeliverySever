using System;
using System.Collections.Generic;

namespace KoiDeliv.DataAccess.Models
{
    public partial class Shipment
    {
        public int ShipmentId { get; set; }
        public int OrderId { get; set; }
        public int? SalesStaffId { get; set; }
        public int? DeliveringStaffId { get; set; }
        public string? HealthCheckStatus { get; set; }
        public string? PackingStatus { get; set; }
        public string? ShippingStatus { get; set; }
        public string? ForeignImportStatus { get; set; }  
        public string? CertificateIssued { get; set; }
        public DateTime? DeliveryDate { get; set; }

        public virtual User? DeliveringStaff { get; set; }
        public virtual Order Order { get; set; } = null!;
        public virtual User? SalesStaff { get; set; }
    }
}
