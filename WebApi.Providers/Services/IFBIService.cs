using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Core.Models;

namespace WebApi.Providers.Services
{
    public interface IFBIService
    {
        Task<FBIResponse> GetFBIReports(string searchText);
    }
}
