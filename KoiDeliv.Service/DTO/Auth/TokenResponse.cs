using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiDeliv.Service.DTO.Auth
{
    public class TokenResponse
    {
        public string AccessTokenToken { get; set; }
        public string RefreshToken { get; set; }
        public DateTime ExpiredAt { get; set; }
    }
}
