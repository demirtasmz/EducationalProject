using Hangfire;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EducationalProject.Hangfire.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangfireController : ControllerBase
    {
        [HttpPost]
        [Route("[action]")]
        //[Log]
        public IActionResult Welcome(string userName)
        {
            var jobId = BackgroundJob.Enqueue(() => SendWelcomeMail(userName));
            return Ok($"Job Id {jobId} Completed. Welcome Mail Sent!");
        }

        public void SendWelcomeMail(string userName)
        {
            //Logic to Mail the user
            Console.WriteLine($"Welcome to our application, {userName}");
        }

        [HttpPost]
        [Route("[action]")]
        //[Log]
        public IActionResult DelayedWelcome(string userName)
        {
            var jobId = BackgroundJob.Schedule(() => SendDelayedWelcomeMail(userName), TimeSpan.FromMinutes(1));
            return Ok($"Job Id {jobId} Completed. Delayed Welcome Mail Sent!");
        }

        public void SendDelayedWelcomeMail(string userName)
        {
            //Logic to Mail the user
            Console.WriteLine($"Welcome to our application, {userName}");
        }
        [HttpPost]
        [Route("[action]")]
        //[Log]
        public IActionResult Daily()
        {
            RecurringJob.AddOrUpdate(() => DailyReminder(), "0 25 9 ? * MON-FRI", TimeZoneInfo.Local);
            return Ok("Recurring Job Scheduled. You have a daily meeting each day at 9.25 !");
        }

        public void DailyReminder()
        {
            //Logic to reminder
            Console.WriteLine("Here is your reminder");
        }
        [HttpPost]
        [Route("[action]")]
        //[Log]
        public IActionResult Unsubscribe(string userName)
        {
            var jobId = BackgroundJob.Enqueue(() => UnsubscribeUser(userName));
            BackgroundJob.ContinueJobWith(jobId, () => Console.WriteLine($"Sent Confirmation Mail to {userName}"));
            return Ok($"Unsubscribed");
        }

        public void UnsubscribeUser(string userName)
        {
            //Logic to Unsubscribe the user
            Console.WriteLine($"Unsubscribed {userName}");
        }
    }
}
