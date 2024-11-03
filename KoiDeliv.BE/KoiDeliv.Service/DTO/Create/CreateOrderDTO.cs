using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiDeliv.Service.DTO.Create
{
	public class CreateOrderDTO
	{

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
        public DateTime? DateShip { get; set; }
        public string? PaymentMethod { get; set; }
        public string? PhoneContact { get; set; }
        public string? FishType { get; set; }
        public string? NameUserGet { get; set; }
    }
}
