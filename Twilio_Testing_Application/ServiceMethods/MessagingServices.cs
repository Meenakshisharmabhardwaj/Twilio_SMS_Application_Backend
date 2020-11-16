using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio_Testing_Application.Constants;
using Twilio_Testing_Application.Models;

namespace Twilio_Testing_Application.ServiceMethods
{
    public class MessagingServices
    {
        IConfiguration configuration;

        public MessagingServices(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
       

        public ResponseModel SendMessage(GetDataForMessaging request)
        {
            ResponseModel response = new ResponseModel();

                // Find your Account Sid and Token at twilio.com/console
                // DANGER! This is insecure. See http://twil.io/secure
                var accountSid = configuration.GetValue<string>("TwilioCredentails:accountSid");
                var authToken = configuration.GetValue<string>("TwilioCredentails:authToken");
            var fromnum= configuration.GetValue<string>("TwilioCredentails:fromnum");
            TwilioClient.Init(accountSid, authToken);
            try
            {
                MessageResource obj = MessageResource.Create(
                       from: new Twilio.Types.PhoneNumber(fromnum),
                    to: new Twilio.Types.PhoneNumber(request.TophoneNo.internationalNumber),
                    body: request.Message

                );
                response.StatusCode = StatusCode.Success;
                response.Data = obj;
                response.Message = "Success";
                return response;
            }
            catch (Exception e)
            {
              
                response.Data = null;
                response.Message =e.Message;
                return response;
               
            }
           
               // return obj;
           
           
           
        }
    }
}
