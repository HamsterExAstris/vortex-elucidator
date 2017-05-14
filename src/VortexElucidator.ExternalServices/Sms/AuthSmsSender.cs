using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using ShatteredTemple.VortexElucidator.Services;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace ShatteredTemple.VortexElucidator.ExternalServices.Sms
{
    // This class is used by the application to send Email and SMS
    // when you turn on two-factor authentication in ASP.NET Identity.
    // For more details see this link https://go.microsoft.com/fwlink/?LinkID=532713
    public class AuthSmsSender : ISmsSender
    {
        public AuthSmsSender(IOptions<SmsOptions> optionsAccessor)
        {
            Options = optionsAccessor.Value;
        }

        public SmsOptions Options { get; }  // set only via Secret Manager

        public Task SendEmailAsync(string email, string subject, string message)
        {
            // Plug in your email service here to send an email.
            return Task.FromResult(0);
        }

        public Task SendSmsAsync(string number, string message)
        {
            throw new InvalidOperationException("SMS not configured " + this.Options.AccountSid);

            // Plug in your SMS service here to send a text message.
            // Your Account SID from twilio.com/console
            var accountSid = Options.AccountSid;
            // Your Auth Token from twilio.com/console
            var authToken = Options.AuthToken;

            TwilioClient.Init(accountSid, authToken);

            var msg = MessageResource.Create(
              to: new PhoneNumber(number),
              from: new PhoneNumber("+1(808) 201-1433"),
              body: message);

            return Task.FromResult(0);
        }
    }
}
