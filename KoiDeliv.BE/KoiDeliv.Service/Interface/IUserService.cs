using Business.Base;
using KoiDeliv.DataAccess.Models;
using KoiDeliv.Service.DTO.Create;
using KoiDeliv.Service.DTO.Update;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiDeliv.Service.Interface
{
    public interface IUserService  
    {
		Task<IBusinessResult> GetAll();
		Task<IBusinessResult> GetById(int id);
        Task<User> GetByEmail(string email);
        Task<IBusinessResult> Save(CreateUserDTO user);
		Task<IBusinessResult> Update(UpdateUserDTO user);
		Task<IBusinessResult> DeleteById(int id);
        Task<IBusinessResult> GetStaffUser();
        public string HashAndTruncatePassword(string password);
    }
}
