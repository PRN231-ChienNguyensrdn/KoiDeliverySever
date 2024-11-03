using Business.Base;
using KoiDeliv.Service.DTO.Create;
using KoiDeliv.Service.DTO.Payment;
using KoiDeliv.Service.DTO.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiDeliv.Service.Interface
{
    public interface ITransactionService
    {
        Task<PaymentResponse> CreatePayment(PaymentRequest paymentRequest);
    }
}
