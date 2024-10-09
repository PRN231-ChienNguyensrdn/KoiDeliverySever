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
	public class BlogService : IBlogService
	{
		private readonly IUnitOfWork _unitOfWork;

		public BlogService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
		}

		public async Task<IBusinessResult> DeleteById(int id)
		{
			try
			{
				var blog = await _unitOfWork.BlogRepo.GetByIdAsync(id); // Assuming BlogRepo is set up
				if (blog != null)
				{
					bool result = await _unitOfWork.BlogRepo.RemoveAsync(blog);
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
				var blogs = await _unitOfWork.BlogRepo.GetAllAsync();

				if (blogs == null || !blogs.Any())
				{
					return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG);
				}

				return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, blogs);
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
				var blog = await _unitOfWork.BlogRepo.GetByIdAsync(id);

				if (blog == null)
				{
					return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG);
				}
				return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, blog);
			}
			catch (Exception ex)
			{
				return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
			}
		}

		public async Task<IBusinessResult> Save(CreateBlogDTO blogDto)
		{
			try
			{
				var blog = new Blog
				{
					Title = blogDto.Title,
					Content = blogDto.Content,
					ImagePath = blogDto.ImagePath,
					AuthorId = blogDto.AuthorId,
					PriceListId = blogDto.PriceListId,
					// Add any other properties required
				};

				int result = await _unitOfWork.BlogRepo.CreateAsync(blog);
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

		public async Task<IBusinessResult> Update(UpdateBlogDTO blogDto)
		{
			try
			{
				var existingBlog = await _unitOfWork.BlogRepo.GetByIdAsync(blogDto.BlogId);
				if (existingBlog == null)
				{
					return new BusinessResult(Const.FAIL_UPDATE_CODE, "Blog not found");
				}

				existingBlog.Title = blogDto.Title ?? existingBlog.Title;
				existingBlog.Content = blogDto.Content ?? existingBlog.Content;
				existingBlog.ImagePath = blogDto.ImagePath ?? existingBlog.ImagePath;
				 

				int result = await _unitOfWork.BlogRepo.UpdateAsync(existingBlog);
				if (result > 0)
				{
					return new BusinessResult(Const.SUCCESS_UPDATE_CODE, Const.SUCCESS_UPDATE_MSG);
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
