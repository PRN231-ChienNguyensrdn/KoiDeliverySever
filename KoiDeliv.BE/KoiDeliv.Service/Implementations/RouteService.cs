using AutoMapper;
using Business.Base;
using Common;
using KoiDeliv.DataAccess.Models;
using KoiDeliv.Service.DTO.Create;
using KoiDeliv.Service.DTO.Update;
using KoiDeliv.Service.Interface;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiDeliv.Service.Implementations
{
    public class RouteService : IRouteService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RouteService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IBusinessResult> DeleteById(int id)
        {
            try
            {
                var route = await _unitOfWork.RouteRepo.GetByIdAsync(id);
                if (route != null)
                {
                    bool result = await _unitOfWork.RouteRepo.RemoveAsync(route);
                    if (result)
                    {
                        return new BusinessResult(Const.SUCCESS_DELETE_CODE, Const.SUCCESS_DELETE_MSG);
                    }
                    return new BusinessResult(Const.FAIL_DELETE_CODE, Const.FAIL_DELETE_MSG);
                }

                return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG);
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.ToString());
            }
        }

        public async Task<IBusinessResult> GetAll()
        {
            try
            {
                var Routes = await _unitOfWork.RouteRepo.GetAllAsync();

                if (Routes == null || !Routes.Any())
                {
                    return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG);
                }

                return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, Routes);
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }

        public async Task<IBusinessResult> GetById(int id)
        {
            try
            {
                var Route = await _unitOfWork.RouteRepo.GetByIdAsync(id);

                if (Route == null)
                {
                    return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG);
                }
                return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, Route);
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }

        public async Task<IBusinessResult> Save(CreateRouteDTO routeDTO)
        {
            try
            {
                Route route = _mapper.Map<Route>(routeDTO);

                int result = await _unitOfWork.RouteRepo.CreateAsync(route);
                if (result > 0)
                {
                    return new BusinessResult(Const.SUCCESS_CREATE_CODE, Const.SUCCESS_CREATE_MSG);
                }
                return new BusinessResult(Const.FAIL_CREATE_CODE, Const.FAIL_CREATE_MSG);
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.ToString());
            }
        }

        public async Task<IBusinessResult> Update(UpdateRouteDTO RouteDto)
        {
            try
            {
                var existingRoute = await _unitOfWork.RouteRepo.GetByIdAsync(RouteDto.RoutedId);
                if (existingRoute == null)
                {
                    return new BusinessResult(Const.FAIL_UPDATE_CODE, "Route not found");
                }

                existingRoute.Adress = RouteDto.Adress ?? existingRoute.Adress;
                existingRoute.ShipmentId = RouteDto.ShipmentId ?? existingRoute.ShipmentId;
                existingRoute.Status = RouteDto.Status ?? existingRoute.Status;
                existingRoute.DateUpdate = RouteDto.DateUpdate ?? existingRoute.DateUpdate;
                existingRoute.DateSetting = RouteDto.DateSetting;
                existingRoute.Notice = RouteDto.Notice ?? existingRoute.Notice;

                int result = await _unitOfWork.RouteRepo.UpdateAsync(existingRoute);
                if (result > 0)
                {
                    return new BusinessResult(Const.SUCCESS_UPDATE_CODE, Const.SUCCESS_UPDATE_MSG,result);
                }
                return new BusinessResult(Const.FAIL_UPDATE_CODE, Const.FAIL_UPDATE_MSG);
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.ToString());
            }
        }
    }
}
