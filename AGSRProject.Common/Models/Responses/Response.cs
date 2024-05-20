using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AGSRProject.Common.Models.Responses
{
    public class Response
    {
        public string Description { get; set; }
        public bool IsError { get; set; }

        public Response(string description, bool isError)
        {
            Description = description;
            IsError = isError;
        }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
        }
    }
}
