using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiDeliv.Service.DTO.Update
{
    public class UpdateRouteDTO
    {
        public int RoutedId { get; set; }
        public int? ShipmentId { get; set; }
        public bool? Status { get; set; }
        public string? Notice { get; set; }
        public DateTime DateSetting { get; set; }
        public DateTime? DateUpdate { get; set; }
        public string? Origin { get; set; }
        public string? Adress { get; set; }
    }
}
