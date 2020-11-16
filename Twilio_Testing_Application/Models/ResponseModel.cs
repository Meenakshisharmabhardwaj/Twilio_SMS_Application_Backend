using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Twilio_Testing_Application.Models
{
    public class ResponseModel
    {
        public object Data { get; set; }
        public int? StatusCode { get; set; }
        public string Message { get; set; }
    }
}
