using Business.Base;
using Common;
using KoiDeliv.DataAccess.Models;
using KoiDeliv.DataAccess.Repository;
using KoiDeliv.Service.DTO.Create;
using KoiDeliv.Service.DTO.Update;
using KoiDeliv.Service.Interface;
using Microsoft.EntityFrameworkCore;
using Repository;
 

namespace KoiDeliv.Service.Implementations
{
	public class FeedbackService : IFeedbackService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly RatingsFeedbackRepo _feedbackRepository;
		private readonly KoiDeliveryDBContext _dbcontext;

		public FeedbackService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<IBusinessResult> GetAll()
		{
			try
			{
				var feedbacks = await _unitOfWork.RatingsFeedbackRepo.GetAllAsync();

				if (feedbacks == null || !feedbacks.Any())
				{
					return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG);
				}

				// Eager load the order data using the repository
				var feedbacksWithOrders = feedbacks
					.Select(f => new RatingsFeedback
					{
						FeedbackId = f.FeedbackId,
						OrderId = f.OrderId,
						Rating = f.Rating,
						Feedback = f.Feedback,
						CreatedAt = f.CreatedAt,
						Order = f.Order != null ? new Order
						{
							OrderId = f.Order.OrderId,
							CustomerId = f.Order.CustomerId,
							Origin = f.Order.Origin,
							Destination = f.Order.Destination,
							TotalWeight = f.Order.TotalWeight,
							TotalQuantity = f.Order.TotalQuantity,
							ShippingMethod =f.Order.ShippingMethod,
							AdditionalServices = f.Order.AdditionalServices,
							Status = f.Order.Status,
							CreatedAt =f.Order.CreatedAt
						} : null
					}).ToList();

				return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, feedbacksWithOrders);
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
				var feedback = await _unitOfWork.RatingsFeedbackRepo.GetByIdAsync(id);

				if (feedback == null)
				{
					return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG);
				}

				// Map to DTO with order data if available
				var feedbackDto = new RatingsFeedback
				{
					FeedbackId = feedback.FeedbackId,
					OrderId = feedback.OrderId,
					Rating = feedback.Rating,
					Feedback = feedback.Feedback,
					CreatedAt = feedback.CreatedAt,
					Order = feedback.Order != null ? new Order
					{
						OrderId = feedback.Order.OrderId,
						CustomerId = feedback.Order.CustomerId,
						Origin = feedback.Order.Origin,
						Destination = feedback.Order.Destination,
						TotalWeight = feedback.Order.TotalWeight,
						TotalQuantity = feedback.Order.TotalQuantity,
						ShippingMethod = feedback.Order.ShippingMethod,
						AdditionalServices = feedback.Order.AdditionalServices,
						Status = feedback.Order.Status,
						CreatedAt = feedback.Order.CreatedAt
					} : null
				};

				return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, feedbackDto);
			}
			catch (Exception ex)
			{
				return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
			}
		}

		public async Task<IBusinessResult> Save(CreateRatingsFeedbackDTO feedbackDTO)
		{
			try
			{
				var feedback = new RatingsFeedback
				{
					OrderId = feedbackDTO.OrderId,
					Rating = feedbackDTO.Rating,
					Feedback = feedbackDTO.Feedback,
					CreatedAt = feedbackDTO.CreatedAt ?? DateTime.Now
				};

				int result = await _unitOfWork.RatingsFeedbackRepo.CreateAsync(feedback);

				if (result > 0)
				{
					return new BusinessResult(Const.SUCCESS_CREATE_CODE, Const.SUCCESS_CREATE_MSG);
				}

				return new BusinessResult(Const.FAIL_CREATE_CODE, Const.FAIL_CREATE_MSG);
			}
			catch (Exception ex)
			{
				return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
			}
		}

		public async Task<IBusinessResult> Update(UpdateRatingsFeedbackDTO feedbackDTO)
		{
			try
			{
				var existingFeedback = await _unitOfWork.RatingsFeedbackRepo.GetByIdAsync(feedbackDTO.FeedbackId);

				if (existingFeedback == null)
				{
					return new BusinessResult(Const.FAIL_UPDATE_CODE, "Feedback not found");
				}

				existingFeedback.Rating = feedbackDTO.Rating ?? existingFeedback.Rating;
				existingFeedback.Feedback = feedbackDTO.Feedback ?? existingFeedback.Feedback;

				int result = await _unitOfWork.RatingsFeedbackRepo.UpdateAsync(existingFeedback);

				if (result > 0)
				{
					return new BusinessResult(Const.SUCCESS_UPDATE_CODE, Const.SUCCESS_UPDATE_MSG);
				}

				return new BusinessResult(Const.FAIL_UPDATE_CODE, Const.FAIL_UPDATE_MSG);
			}
			catch (Exception ex)
			{
				return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
			}
		}

		public async Task<IBusinessResult> DeleteById(int id)
		{
			try
			{
				var feedback = await _unitOfWork.RatingsFeedbackRepo.GetByIdAsync(id);

				if (feedback != null)
				{
					bool result = await _unitOfWork.RatingsFeedbackRepo.RemoveAsync(feedback);

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
				return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
			}
		}

		 

		 
	}
}
