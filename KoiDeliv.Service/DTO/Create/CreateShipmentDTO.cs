using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiDeliv.Service.DTO.Create
{
	public class CreateShipmentDTO
	{
		public int OrderID { get; set; }
		public int? SalesStaffId { get; set; }
		public int? DeliveringStaffId { get; set; }
		public string HealthCheckStatus { get; set; }
		public string PackingStatus { get; set; }
		public string ShippingStatus { get; set; }
		public string ForeignImportStatus { get; set; }
		public string CertificateIssued { get; set; }
		public DateTime DeliveryDate { get; set; }
	}

}
