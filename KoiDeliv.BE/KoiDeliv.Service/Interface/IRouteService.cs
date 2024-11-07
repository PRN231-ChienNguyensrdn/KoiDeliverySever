using Business.Base;
using KoiDeliv.Service.DTO.Create;
using KoiDeliv.Service.DTO.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiDeliv.Service.Interface
{
    public interface IRouteService
    {
        Task<IBusinessResult> GetAll();
        Task<IBusinessResult> GetById(int id);
        Task<IBusinessResult> Save(CreateRouteDTO blog);
        Task<IBusinessResult> Update(UpdateRouteDTO blog);
        Task<IBusinessResult> DeleteById(int id);
        Task<IBusinessResult> GetRouteByShipmentId(int sid);
        Task<IBusinessResult> GetRouteByOrderId(int oid);
        Task<IBusinessResult> CreateRoute(CreateRouteDTO route);
    }
}
