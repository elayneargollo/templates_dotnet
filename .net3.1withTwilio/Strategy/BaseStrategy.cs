using System;
using Comunicacao.Messagem.Validations;
using FluentValidation.Results;

namespace Comunicacao.Messagem
{
    public class BaseStrategy : INotifierComponent
    {
        private readonly INotifierComponent _notifierComponent;
        private readonly IConfiguracaoAppSettings _configuracaoAppSettings;
        protected string CodPhone;
        protected string PhoneSmsAndMms;
        protected string PhoneWhatsApp;

        public BaseStrategy (INotifierComponent notifierComponent,  
                            IConfiguracaoAppSettings configuracaoAppSettings)
        {
            _notifierComponent = notifierComponent;

            _configuracaoAppSettings = configuracaoAppSettings;
            CodPhone = _configuracaoAppSettings.GetValueKey("codPhone");
            PhoneSmsAndMms = _configuracaoAppSettings.GetValueKey("phoneNumber_to_sms");
            PhoneWhatsApp = _configuracaoAppSettings.GetValueKey("phoneNumber_to_whats");
        }

        public virtual void Send(Message message)
        {
            try
            {
                CustomerValidator validator = new CustomerValidator();
                ValidationResult result = validator.Validate(message);

                // Write types
                ILogComponentDecorator writeFile = new MemoryStreamDecorator();
                writeFile.WriteData(message);

                // ILogComponentDecorator writeFile = new FileDecorator();
                // writeFile.WriteData(message);

                _notifierComponent.Send(message);

                Console.WriteLine("Message sent successfully !");
            }
            catch(Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw new Exception(exception.Message);
            }
        }
    }
}