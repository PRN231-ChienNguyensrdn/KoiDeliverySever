using AutoMapper;
using KoiDeliv.DataAccess.Models;
using KoiDeliv.Service.DTO.Create;
using KoiDeliv.Service.DTO.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiDeliv.Service.Mapper
{
    public class MappingSetting : Profile
    {
        public MappingSetting() { 
            CreateMap<Order,CreateOrderDTO>();
            CreateMap<CreateOrderDTO, Order>();
            CreateMap<Route, CreateRouteDTO>();
            CreateMap<CreateRouteDTO, Route>();
            CreateMap<PaymentResponse, Transaction>();
            CreateMap<Transaction, PaymentResponse>();
        }
    }
}
