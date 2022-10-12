using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebApi.Core.Models
{
    public  class FBIResponse
    {
        [JsonProperty("total")]  
        public int Total { get; set; }

        [JsonProperty("items")]
        public List<Report> Reports { get; set; }
    }
}
