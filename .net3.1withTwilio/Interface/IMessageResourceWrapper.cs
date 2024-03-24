using System;
using System.Collections.Generic;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Comunicacao.Messagem
{
    public interface IMessageResourceWrapper
    {
        MessageResource Create(string body, PhoneNumber from, List<Uri> mediaUrl, PhoneNumber to);
    }
}