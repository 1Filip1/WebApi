using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WebApi.Core.Models;

namespace WebApi.Providers.Services
{
    public class FBIService : IFBIService
    {
        public async Task<FBIResponse> GetFBIReports(string searchText)
        {
            string url = $"https://api.fbi.gov/wanted/v1/list?title={searchText}";
            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode==true)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<FBIResponse>(content);
                        return result;
                    }

                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
