using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Twilio_Testing_Application.Models
{
    public class GetDataForMessaging
    {
        [Required]
        public PhoneData TophoneNo { get; set; }
        [Required]
        public string Message { get; set; }
    }
    public class PhoneData
    {
        public string number { get; set; }
        public string internationalNumber { get; set; }
        public string nationalNumber { get; set; }
        public string countryCode { get; set; }
        public string dialCode { get; set; }
    }
}
