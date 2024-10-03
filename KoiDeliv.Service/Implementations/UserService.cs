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
	public class UserService : IUserService
	{
		private readonly IUnitOfWork _unitOfWork;

		public UserService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
		}

		public async Task<IBusinessResult> DeleteById(int id)
		{
			try
			{
				var user = await _unitOfWork.UserRepo.GetByIdAsync(id); // Assuming UserRepo is properly set up
				if (user != null)
				{
					bool result = await _unitOfWork.UserRepo.RemoveAsync(user);
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
				var users = await _unitOfWork.UserRepo.GetAllAsync();

				if (users == null || !users.Any())
				{
					return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG);
				}

				return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, users);
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
				var user = await _unitOfWork.UserRepo.GetByIdAsync(id);

				if (user == null)
				{
					return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG);
				}
				return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, user);
			}
			catch (Exception ex)
			{
				return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
			}
		}

		public async Task<IBusinessResult> Save(CreateUserDTO userDto)
		{
			try
			{
				var user = new User
				{
					FullName = userDto.FullName,
					Email = userDto.Email,
					PasswordHash = userDto.PasswordHash,
					Role = userDto.Role,
					PhoneNumber = userDto.PhoneNumber,
					Address = userDto.Address
				};

				int result = await _unitOfWork.UserRepo.CreateAsync(user);
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

		public async Task<IBusinessResult> Update(UpdateUserDTO userDto)
		{
			try
			{
				var existingUser = await _unitOfWork.UserRepo.GetByIdAsync(userDto.UserId);
				if (existingUser == null)
				{
					return new BusinessResult(Const.FAIL_UPDATE_CODE, "User not found");
				}

				existingUser.FullName = userDto.FullName ?? existingUser.FullName;
				existingUser.Email = userDto.Email ?? existingUser.Email;
				existingUser.PasswordHash = userDto.PasswordHash ?? existingUser.PasswordHash;
				existingUser.Role = userDto.Role ?? existingUser.Role;
				existingUser.PhoneNumber = userDto.PhoneNumber ?? existingUser.PhoneNumber;
				existingUser.Address = userDto.Address ?? existingUser.Address;

				int result = await _unitOfWork.UserRepo.UpdateAsync(existingUser);
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
