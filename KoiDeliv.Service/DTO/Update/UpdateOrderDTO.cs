using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiDeliv.Service.DTO.Update
{
	public class UpdateOrderDTO
	{
		public int OrderId { get; set; }

		public int CustomerId { get; set; }
		[Required]
		public string Origin { get; set; } = null!;
		[Required]
		public string Destination { get; set; } = null!;
		[Required]
		public decimal TotalWeight { get; set; }
		[Required]
		public int TotalQuantity { get; set; }
		[Required]
		public string? ShippingMethod { get; set; }
		public string? Status { get; set; }
		public string? AdditionalServices { get; set; }
	}
}
