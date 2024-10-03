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
    public interface IPriceService  
    {
        Task<IBusinessResult> GetAll();
		Task<IBusinessResult> GetById(int id);
		Task<IBusinessResult> Save(CreatePriceListDTO post);
		Task<IBusinessResult> Update(UpdatePriceListDTO post);
		Task<IBusinessResult> DeleteById(int id);
	}
}
