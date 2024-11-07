using CsvHelper;
using CsvHelper.Configuration;
using KoiDeliv.DataAccess.Models;
using KoiDeliv.DataAccess.Repository;
using KoiDeliv.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LicenseContext = OfficeOpenXml.LicenseContext;

namespace KoiDeliv.Service.Implementations
{
    public class GPSService : IGPSService
    {
        private readonly IUnitOfWork _unitOfWork;

        public GPSService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        private string ReplaceString(string stringReplace)
        {
            if (stringReplace != null)
            {
                stringReplace = stringReplace.Replace("(", "").Replace("'", "").Replace("_", " ").Replace(")", "");
            }
            return stringReplace;
        }
        public async Task ImportFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                throw new ArgumentException("File không hợp lệ. Vui lòng tải lên file CSV.");
            }

            List<Gsp> gspList = new List<Gsp>();

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true, // Bỏ qua dòng tiêu đề
                MissingFieldFound = null,
                IgnoreBlankLines = true,
                BadDataFound = null
            };

            using (var stream = new StreamReader(file.OpenReadStream(), Encoding.UTF8))
            using (var csv = new CsvReader(stream, config))
            {
                await csv.ReadAsync();
                csv.ReadHeader(); // Đọc và bỏ qua dòng tiêu đề

                while (await csv.ReadAsync())
                {
                    var gsp = new Gsp
                    {
                        Id = csv.GetField<long?>(0) ?? 0,
                        Index = csv.GetField<int?>(1) ?? 0,
                        VehicleId = csv.GetField<string>(2),
                        PStart = csv.GetField<string>(3),
                        PTerm = csv.GetField<string>(4),
                        PEnd = csv.GetField<string>(5),
                        PreRouted = ReplaceString(csv.GetField<string>(6)),
                        Freg = csv.GetField<int?>(7) ?? 0,
                        Label = csv.GetField<bool?>(8) ?? false,
                        Regions = ReplaceString(csv.GetField<string>(9))
                    };

                    gspList.Add(gsp);
                }
            }
            await _unitOfWork.GPSRepo.AddGPS(gspList);
        }
    }
}
