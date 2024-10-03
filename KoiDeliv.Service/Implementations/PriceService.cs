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
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KoiDeliv.Service.Implementations
{
    public class PriceService : IPriceService
    {
        private readonly IUnitOfWork _unitOfWork;


		public PriceService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork  ;
		}

		public bool Delete(object id)
        {
            throw new NotImplementedException();
        }

        public void Delete(PriceList entityToDelete)
        {
            throw new NotImplementedException();
        }

		public async Task<IBusinessResult> DeleteById(int id)
		{
            try
            {
                var price = await _unitOfWork.PriceListRepo.GetByIdAsync(id);
                if (price != null)
                {
                    bool result = await _unitOfWork.PriceListRepo.RemoveAsync(price);
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

		public IEnumerable<PriceList> Get(Expression<Func<PriceList, bool>>? filter = null, Func<IQueryable<PriceList>, IOrderedQueryable<PriceList>>? orderBy = null, string includeProperties = "", int? pageIndex = null, int? pageSize = null)
        {
            throw new NotImplementedException();
        }

		public async Task<IBusinessResult> GetAll()
		{
			try
			{
				var price = await _unitOfWork.PriceListRepo.GetAllAsync();

				if (price == null || !price.Any())
				{
					return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG);
				}

				return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, price);
			}
			catch (Exception ex)
			{
				return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
			}
		}

		public PriceList GetByID(object id)
        {
            throw new NotImplementedException();
        }

		public async Task<IBusinessResult> GetById(int id)
		{
			try
			{
				#region Business rule
				#endregion

				//var currency = await _currencyRepository.GetByIdAsync(code);
				var currency = await _unitOfWork.PriceListRepo.GetByIdAsync(id);

				if (currency == null)
				{
					return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG);
				}
				else
				{
					return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, currency);
				}
			}
			catch (Exception ex)
			{
				return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
			}
		}

		public void Insert(PriceList entity)
        {
            throw new NotImplementedException();
        }

		public async Task<IBusinessResult> Save(CreatePriceListDTO priceDTO)
		{
			try
			{
				var price = new PriceList
				{
					 WeightRange = priceDTO.WeightRange,
					BasePrice = priceDTO.BasePrice,
					AdditionalServicePrice = priceDTO.AdditionalServicePrice,
					//CreatedAt = DateTime.UtcNow
					 
				};
				int result = await _unitOfWork.PriceListRepo.CreateAsync(price);
				if (result > 0)
				{
					return new BusinessResult(Const.SUCCESS_CREATE_CODE, Const.SUCCESS_CREATE_MSG);
				}
				else
				{
					return new BusinessResult(Const.FAIL_CREATE_CODE, Const.FAIL_CREATE_MSG);
				}
			}
			catch (Exception ex)
			{
				return new BusinessResult(Const.ERROR_EXCEPTION, ex.ToString());
			}
		}

		public bool Update(object id, PriceList entityToUpdate)
        {
            throw new NotImplementedException();
        }

        public void Update(PriceList entityToUpdate)
        {
            throw new NotImplementedException();
        }

		public async Task<IBusinessResult> Update(UpdatePriceListDTO priceDTO)
		{
			try
			{
			  
				// Retrieve the post to be updated
				var existPrice = await _unitOfWork.PriceListRepo.GetByIdAsync(priceDTO.PriceListId);
				if (existPrice == null)
				{
					return new BusinessResult(Const.FAIL_UPDATE_CODE, "Post not found");
				}

				// Update the post properties
				existPrice.PriceId = priceDTO.PriceListId;
				existPrice.WeightRange = priceDTO.WeightRange ?? existPrice.WeightRange;
				existPrice.BasePrice = priceDTO.BasePrice ?? existPrice.BasePrice;
				existPrice.AdditionalServicePrice = priceDTO.AdditionalServicePrice;

				// Save the changes
				int result = await _unitOfWork.PriceListRepo.UpdateAsync(existPrice);
				if (result > 0)
				{
					return new BusinessResult(Const.SUCCESS_UPDATE_CODE, Const.SUCCESS_UPDATE_MSG);
				}
				else
				{
					return new BusinessResult(Const.FAIL_UPDATE_CODE, Const.FAIL_UPDATE_MSG);
				}
			}
			catch (Exception ex)
			{
				return new BusinessResult(Const.ERROR_EXCEPTION, ex.ToString());
			}
		}
	}
}
