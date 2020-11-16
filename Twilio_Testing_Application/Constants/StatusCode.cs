using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Twilio_Testing_Application.Constants
{
    public static class StatusCode
    {
        public static int Success = 200;
        public static int BadRequest = 404;
        public static int InternalServerError = 500;
    }
    public static class Messages
    {
        public static string SOMETHING_WENT_WRONG = "Something went wrong";
    }
}
