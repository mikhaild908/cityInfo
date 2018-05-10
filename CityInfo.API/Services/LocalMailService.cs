using System;
using System.Diagnostics;

namespace CityInfo.API.Services
{
	public class LocalMailService : IMailService
    {
		private string _mailTo = @"admin@test.com";
		private string _mailFrom = @"no-reply@test.com";

        public void Send(string subject, string message)
		{
			Debug.WriteLine($"Mail from {_mailFrom} to {_mailTo}, with LocalMailService.");
			Debug.WriteLine($"Subject: {subject}");
			Debug.WriteLine($"Message: {message}");
		}      
    }
}
