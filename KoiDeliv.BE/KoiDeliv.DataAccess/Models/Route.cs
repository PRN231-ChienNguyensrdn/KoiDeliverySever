using System;
using System.Collections.Generic;

namespace KoiDeliv.DataAccess.Models
{
    public partial class Route
    {
        public int RoutedId { get; set; }
        public int? ShipmentId { get; set; }
        public bool? Status { get; set; }
        public string? Notice { get; set; }
        public DateTime DateSetting { get; set; }
        public DateTime? DateUpdate { get; set; }
        public string? Adress { get; set; }

        public virtual Shipment? Shipment { get; set; }
    }
}
