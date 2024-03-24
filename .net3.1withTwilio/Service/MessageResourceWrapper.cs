using System;
using System.Collections.Generic;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Comunicacao.Messagem
{
    public class MessageResourceWrapper : IMessageResourceWrapper
    {
        public MessageResource Create(string body, PhoneNumber from, List<Uri> mediaUrl, PhoneNumber to)
        {
            return MessageResource.Create(body, from.ToString(), mediaUrl?.ToString(), to.ToString());
        }
    }
}