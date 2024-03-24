using System;
using Comunicacao.Messagem.Configuration;

namespace Comunicacao.Messagem
{
    class Program
    {
        static void Main(string[] args)
        {
            // Display
            Console.WriteLine("Send an outgoing SMS with Twilio !");
            string phoneNumberExemple = "61976430594";

            Console.WriteLine($"Provide the phone number. Example: ({phoneNumberExemple}): ");
            string phoneNumber = Console.ReadLine();

            Console.WriteLine("Report the message: ");
            string message = Console.ReadLine();

            // Type send
            IMessageResourceWrapper messageResourceWrapper = new MessageResourceWrapper();
            IConfiguracaoAppSettings configuracaoAppSettings = new ConfiguracaoAppSettings();

            INotifierComponent envio = new Notifier(messageResourceWrapper, 
                configuracaoAppSettings);

            INotifierComponent zap = new WhatsappStrategy(envio, configuracaoAppSettings);
            Message msg = new Message(phoneNumber, message);
            zap.Send(msg);

            // INotifierComponent Mms = new MmsStrategy(envio);
            // Message msg = new Message(phoneNumber, message);
            // Mms.Send(msg);

            // INotifierComponent Sms = new SmsStrategy(envio);
            // Message msg = new Message(phoneNumber, message);
            // Sms.Send(msg);
        }
    }
}
