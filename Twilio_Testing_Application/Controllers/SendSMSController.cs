using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio_Testing_Application.Models;
using Twilio_Testing_Application.ServiceMethods;
//using Twilio.Rest.Chat.V1.Service.Channel;

namespace Twilio_Testing_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    public class SendSMSController : Controller
    {
        IConfiguration configuration;

        public SendSMSController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // GET api/values
        [HttpPost]
        [Route("/sendSMS")]
        public ResponseModel PostData(GetDataForMessaging request)
        {
            MessagingServices messagingServices = new MessagingServices(configuration);
            ResponseModel obj =messagingServices.SendMessage(request);
            
              ResponseModel response = new ResponseModel();
            if (ModelState.IsValid)
            {
                if (obj.Data != null)
                {
                    response.Data = obj.Data;
                    response.StatusCode = Constants.StatusCode.Success;
                }
                else
                {
                    response.Data = obj.Data;
                    response.StatusCode = Constants.StatusCode.InternalServerError;
                    response.Message = obj.Message;
                }
            }
            else
            {
                List<string> errorlist = new List<string>();

                foreach (var modelState in ViewData.ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        errorlist.Add(error.ErrorMessage);
                    }
                }
                response.Data = errorlist;
                response.StatusCode = StatusCodes.Status500InternalServerError;
                response.Message = Constants.Messages.SOMETHING_WENT_WRONG;
                return response;
            }
           
            return response;
          
        }

        
    }
}
