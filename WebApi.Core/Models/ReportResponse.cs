using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Core.Models
{
    public class ReportResponse
    {

        [JsonProperty("validPhoneNumber")]
        public bool ValidPhoneNumber { get; set; }

        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonProperty("reports")]
        public List<Report> Reports { get; set; }
    }
}
