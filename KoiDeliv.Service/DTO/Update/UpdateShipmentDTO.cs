using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiDeliv.Service.DTO.Update
{
	public class UpdateShipmentDTO
	{
		public int ShipmentId { get; set; }
		public string? HealthCheckStatus { get; set; }
		public string? PackingStatus { get; set; }
		public string? ShippingStatus { get; set; }
		public string? ForeignImportStatus { get; set; }
	}
}
