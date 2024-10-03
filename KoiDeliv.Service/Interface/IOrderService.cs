using Business.Base;
using KoiDeliv.DataAccess.Models;
using KoiDeliv.Service.DTO.Create;
using KoiDeliv.Service.DTO.Update;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiDeliv.Service.Interface
{
    public interface IOrderService : IGenericRepository<Order>
    {
		Task<IBusinessResult> GetAll();
		Task<IBusinessResult> GetById(int id);
		Task<IBusinessResult> Save(CreateOrderDTO order);
		Task<IBusinessResult> Update(UpdateOrderDTO order);
		Task<IBusinessResult> DeleteById(int id);
	}
}
