using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Core.Models;
using WebApi.Core.Services;
using WebApi.Providers.Services;

namespace WEbApi.Infrastructure.Services
{
    public class InfrastructureService : ICoreService
    {
        protected readonly IFBIService fbiService;

        public InfrastructureService(IFBIService fbiService)
        {
            this.fbiService = fbiService;
        }
        public async Task<List<Report>> GetFBIReports(string searchText)
        {
            var response= await fbiService.GetFBIReports(searchText);
            return response.Reports;
        }
    }

  
}
