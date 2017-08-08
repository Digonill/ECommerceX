using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Results;

namespace EcX.Server.WebApi
{

    public class ExceptionHandler : System.Web.Http.ExceptionHandling.ExceptionHandler
    {
        public override void Handle(ExceptionHandlerContext context)
        {
            Exception exception = context.Exception;
            if (exception != null)
            {
                string messagemErro = GetExceptionMessages(exception);
                context.Result = new ResponseMessageResult(context.Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, messagemErro));
            }
            else
            {
                context.Result = new ResponseMessageResult(context.Request.CreateResponse(System.Net.HttpStatusCode.InternalServerError, " :( "));
            }
        }

        public static string GetExceptionMessages(Exception e, string msgs = "")
        {
            if (e == null) return string.Empty;
            if (msgs == "") msgs = e.Message;
            if (e.InnerException != null)
                msgs += "\r\nInnerException: " + GetExceptionMessages(e.InnerException);
            return msgs;
        }

    }
}
