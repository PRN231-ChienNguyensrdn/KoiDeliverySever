using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiDeliv.Service.Interface
{
    public interface IGPSService
    {
        Task ImportFile(IFormFile file);
    }
}
