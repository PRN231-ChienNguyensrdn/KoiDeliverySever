using Business.Base;
using KoiDeliv.Service.DTO.Create;
using KoiDeliv.Service.DTO.Update;
using KoiDeliv.Service.Implementations;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiDeliv.Service.Interface
{
    public interface IFeedbackService  
    {
		Task<IBusinessResult> GetAll();
		Task<IBusinessResult> GetById(int id);
		Task<IBusinessResult> Save(CreateRatingsFeedbackDTO post );
		//Task<IBusinessResult> Save(CreateRatingsFeedbackDTO post, int feedbackId);
		Task<IBusinessResult> Update(UpdateRatingsFeedbackDTO post);
		Task<IBusinessResult> DeleteById(int id);

		 


	}
}
