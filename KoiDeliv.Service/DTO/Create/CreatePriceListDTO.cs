using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiDeliv.Service.DTO.Create
{
	public class CreatePriceListDTO
	{
		[Required]
		public string WeightRange { get; set; }

		[Required]
		[Range(0.01, double.MaxValue, ErrorMessage = "Base price must be greater than 0")]
		public decimal BasePrice { get; set; }

		public decimal? AdditionalServicePrice { get; set; }
	}
}
