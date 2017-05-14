using ShatteredTemple.StructureMap;
using ShatteredTemple.VortexElucidator.ExternalServices.Sms;
using ShatteredTemple.VortexElucidator.Services;
using StructureMap;
using VortexElucidator.ExternalServices.Email;

namespace ShatteredTemple.VortexElucidator.ExternalServices
{
    public class ExternalServicesRegistry : Registry
    {
        public ExternalServicesRegistry()
        {
            For<IEmailSender>().Use<AuthEmailSender>().Transient();
            For<ISmsSender>().Use<AuthSmsSender>().Transient();

            this.RegisterOptions<SmsOptions>();
        }
    }
}
