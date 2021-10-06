using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using NLog;
using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;

namespace EducationalProject.WebApi.Utilities
{
    [AttributeUsage(AttributeTargets.Method)]
    public class LogAttribute : ActionFilterAttribute
    {
        DateTime startDateTime;
        public string name;

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            startDateTime = DateTime.Now;
            IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());
            string ipAddress = Convert.ToString(ipHost.AddressList.FirstOrDefault(address => address.AddressFamily == AddressFamily.InterNetwork ));
            var controllerName =context.ActionDescriptor.RouteValues["controller"];
            var methodName = context.ActionDescriptor.RouteValues["action"];
            var logger = NLog.LogManager.GetCurrentClassLogger();
            if(context.ActionArguments.Keys.Count != 0)
            {
                foreach (var parameterKey in context.ActionArguments.Keys)
                {
                    context.ActionArguments.TryGetValue(parameterKey, out object parameter);
                    logger.Log(LogLevel.Info, $"Request-Parameter : {JsonConvert.SerializeObject(parameter)} Method:{methodName} ip:{ipAddress}");
                }
            }
            else
            {
                logger.Log(LogLevel.Info,$"Request: Method:{methodName} ip:{ipAddress}");
            }
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var logger = NLog.LogManager.GetCurrentClassLogger();
            var result = context.Result as ObjectResult;
            var timeSpan = DateTime.Now.Subtract(startDateTime).TotalSeconds;
            logger.Log(LogLevel.Info, $"Response :{JsonConvert.SerializeObject(result.Value)}");
        }

    }
}
