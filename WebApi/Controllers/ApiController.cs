using Microsoft.AspNetCore.Mvc;
using WebApi.Core.Services;
using PhoneNumbers;
using WebApi.Core.Models;
using Newtonsoft.Json;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("controller")]

    public class ApiController : ControllerBase
    {
        protected readonly ICoreService service;

        public ApiController(ICoreService service)
        {
            this.service=service;
        }

        [HttpGet("GetReports")]
        public async Task<IActionResult> GetReports(string searchText, string phoneNumber, string countryCode)
        {
            try
            {
                var response = await service.GetFBIReports(searchText);
                if (response == null)
                {
                    return NotFound("There are no reports for that search text");
                }

                PhoneNumberUtil phoneUtil = PhoneNumberUtil.GetInstance();
                PhoneNumber swissNumberProto = phoneUtil.Parse(phoneNumber, countryCode);
                bool valid = phoneUtil.IsValidNumber(swissNumberProto);
                var result = new ReportResponse()
                {
                    ValidPhoneNumber = valid,
                    PhoneNumber = phoneNumber,
                    Reports = response
                };

                //string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
                //string fileName = @$"{searchText}_{phoneNumber}_{DateTime.Now.ToString("dd-MM-yyyy")}";
                //string file = Path.Combine(path, fileName);
                System.IO.File.WriteAllText(@$"../WebApi/Reports/{searchText}_{phoneNumber}_{DateTime.Now.ToString("dd-MM-yyyy")}", JsonConvert.SerializeObject(result));
                return Ok(result);

            }
            catch (Exception ex)

            { return BadRequest(ex.Message); }

        }
    }
}
