﻿ 
namespace Business.Base
{
    public class BusinessResult : IBusinessResult
    {
        public int Status { get; set; }
        public string? Message { get; set; }
        public object? Data { get; set; }

		public bool Success => Status == Common.Const.SUCCESS_READ_CODE;

		public BusinessResult()
        {
            Status = -1;
            Message = "Action failed";
        }

        public BusinessResult(int status, string message)
        {
            Status = status;
            Message = message;
        }

        public BusinessResult(int status, string message, object data)
        {
            Status = status;
            Message = message;
            Data = data;
        }
    }
}
