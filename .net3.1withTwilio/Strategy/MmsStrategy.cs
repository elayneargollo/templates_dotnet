using System;
using System.Linq;

namespace Comunicacao.Messagem
{
    public class MmsStrategy  : BaseStrategy  
    {
        public MmsStrategy(INotifierComponent envioComponent, IConfiguracaoAppSettings configuracaoAppSettings) : base(envioComponent, configuracaoAppSettings) { }

        public override void Send(Message msg)
        {
            Console.WriteLine("Report the uri:");
            string uri = Console.ReadLine();

            msg.PhoneNumberDestiny = String.Concat(CodPhone, msg.PhoneNumberDestiny);
            msg.PhoneOrigin = PhoneSmsAndMms;

            msg.MediaUrl = new[] {
                new System.Uri(uri)
            }.ToList();

            base.Send(msg);
        }
    }
}