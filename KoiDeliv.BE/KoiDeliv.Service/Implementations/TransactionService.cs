using AutoMapper;
using Business.Base;
using KoiDeliv.DataAccess.Models;
using KoiDeliv.Service.DTO.Payment;
using KoiDeliv.Service.Interface;
using Repository;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiDeliv.Service.Implementations
{
    public class TransactionService : ITransactionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TransactionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<PaymentResponse> CreatePayment(PaymentRequest paymentRequest)
        {
            using (var transaction = await _unitOfWork.BeginTransactionAsync())
            {
                try
                {
                    var existedOrder = _unitOfWork.OrderRepo.GetById(int.Parse(paymentRequest.vnp_TxnRef));
                    if (existedOrder != null)
                    {
                        var payment = new Transaction()
                        {
                            PaymentMethod = "VNPay",
                            BankCode = paymentRequest.vnp_BankCode,
                            BankTranNo = paymentRequest.vnp_BankTranNo,
                            CardType = paymentRequest.vnp_CardType,
                            PaymentInfor = paymentRequest.vnp_OrderInfo,
                            PayDate = DateTime.ParseExact(paymentRequest.vnp_PayDate, "yyyyMMddHHmmss", CultureInfo.InvariantCulture),
                            TransactionNo = paymentRequest.vnp_TransactionNo,
                            TransasctionStatus = int.Parse(paymentRequest.vnp_TransactionStatus),
                            PaymentAccount = int.Parse(paymentRequest.vnp_Amount) / 100,
                            OrderId = int.Parse(paymentRequest.vnp_TxnRef)
                        };
                        _unitOfWork.TransactionRepo.Create(payment);
                        //Update Order's status is Paid
                        existedOrder.Status = "Paid";
                        _unitOfWork.OrderRepo.UpdateAsync(existedOrder);
                        _unitOfWork.Save();
                        await transaction.CommitAsync();
                        return _mapper.Map<PaymentResponse>(payment);
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
