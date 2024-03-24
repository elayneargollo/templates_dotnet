using Twilio;

namespace Comunicacao.Messagem
{
    public class Notifier : INotifierComponent
    {
        protected string AccountSid;
        protected string AuthToken;
        private readonly IMessageResourceWrapper _messageResourceWrapper;
        private readonly IConfiguracaoAppSettings _configuracaoAppSettings;

        public Notifier(IMessageResourceWrapper messageResourceWrapper,
            IConfiguracaoAppSettings configuracaoAppSettings)
        {
            _messageResourceWrapper = messageResourceWrapper;

            _configuracaoAppSettings = configuracaoAppSettings;
            AccountSid = _configuracaoAppSettings.GetValueKey("accountSid");
            AuthToken = _configuracaoAppSettings.GetValueKey("authToken");
        }
        public void Send(Message message)
        {
            TwilioClient.Init(AccountSid, AuthToken);

            _messageResourceWrapper.Create(
                message.MessageSend,
                new Twilio.Types.PhoneNumber(message.PhoneOrigin),
                message.MediaUrl,
                new Twilio.Types.PhoneNumber(message.PhoneNumberDestiny)
            );
        }
    }
}