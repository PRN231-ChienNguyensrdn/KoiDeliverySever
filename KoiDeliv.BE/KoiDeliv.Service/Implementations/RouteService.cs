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
using System.Security.Cryptography;
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

        public async Task<IBusinessResult> GetRouteByOrderId(int oid)
        {
            try
            {
                List<Shipment> listShipment = new List<Shipment>();
                List<Route> listRoute = new List<Route>();
                listShipment = await _unitOfWork.ShipmentRepo.GetShipmentsByOrderId(oid);
                foreach (var item in listShipment)
                {
                    var Routes = await _unitOfWork.RouteRepo.getRouteByShipmentId(item.ShipmentId);
                    listRoute.AddRange(Routes);
                }
                if (listRoute == null || !listRoute.Any())
                {
                    return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG);
                }

                var createRouteList = _mapper.Map<List<CreateRouteDTO>>(listRoute);

                return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, createRouteList);
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }

        public async Task<IBusinessResult> GetRouteByShipmentId(int sid)
        {
            try
            {
                var Routes = await _unitOfWork.RouteRepo.getRouteByShipmentId(sid);

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


        private double CalculateDistance(double latitudePStart, double longitudePStart, double latitudeEnd, double longitudeEnd)
        {
            // Bán kính trái đất (km)
            const double EarthRadius = 6371.0;

            // Chuyển đổi độ sang radian
            double latPStartRad = ToRadians(latitudePStart);
            double lonPStartRad = ToRadians(longitudePStart);
            double latEndRad = ToRadians(latitudeEnd);
            double lonEndRad = ToRadians(longitudeEnd);

            // Tính sự khác biệt về kinh độ và vĩ độ
            double deltaLat = latEndRad - latPStartRad;
            double deltaLon = lonEndRad - lonPStartRad;

            // Áp dụng công thức Haversine
            double a = Math.Pow(Math.Sin(deltaLat / 2), 2) +
                       Math.Cos(latPStartRad) * Math.Cos(latEndRad) *
                       Math.Pow(Math.Sin(deltaLon / 2), 2);

            double c = 2 * Math.Asin(Math.Sqrt(a));

            // Tính khoảng cách
            return EarthRadius * c; // Khoảng cách tính bằng km
        }

        private double ToRadians(double angle)
        {
            return (Math.PI / 180) * angle;
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
                    return new BusinessResult(Const.SUCCESS_UPDATE_CODE, Const.SUCCESS_UPDATE_MSG, result);
                }
                return new BusinessResult(Const.FAIL_UPDATE_CODE, Const.FAIL_UPDATE_MSG);
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.ToString());
            }
        }


        public async Task<IBusinessResult> CreateRoute(CreateRouteDTO createRouteDTO)
        {
            try
            {
                double longitudePStart = 0, latitudePStart = 0, longitudeEnd = 0, latitudeEnd = 0;
                var gsp = await _unitOfWork.GPSRepo.GetGSP(createRouteDTO.Origin, createRouteDTO.Adress);
                if (gsp == null)
                {
                    throw new Exception("GSP is not exist!!!");
                }
                else
                {
                    string[] partsPStart = gsp.PStart.Trim('(', ')').Split(',');
                    longitudePStart = double.Parse(partsPStart[0].Trim());
                    latitudePStart = double.Parse(partsPStart[1].Trim());

                    string[] partsPEnd = gsp.PEnd.Trim('(', ')').Split(',');
                    longitudeEnd = double.Parse(partsPEnd[0].Trim());
                    latitudeEnd = double.Parse(partsPEnd[1].Trim());
                }
                double distance =  CalculateDistance(latitudePStart, longitudePStart, latitudeEnd, longitudeEnd);
                Route route = _mapper.Map<Route>(createRouteDTO);
                route.DateSetting = DateTime.Now;
                route.ShipmentId = createRouteDTO.ShipmentId;
                route.SourceLatitude = latitudePStart;
                route.SourceLongitude = longitudePStart;
                route.DestinationLatitude = latitudeEnd;
                route.DestinationLongitude = longitudeEnd;
                route.Distance = distance;
                route.Price = Math.Round(10000m + (5000m * (decimal)distance) + (500m * ((decimal)distance / 50m)) + 20000m, 2);
                var result = await _unitOfWork.RouteRepo.CreateAsync(route);
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
    }
}
