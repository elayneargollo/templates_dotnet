using System;
using System.Collections.Generic;

public class Message
{
    public string PhoneNumberDestiny { set; get; }
    public string MessageSend { set; get; }
    public string PhoneOrigin { set; get; }
    public List<Uri> MediaUrl { set; get; }

    public Message() { }

    public Message(string phoneNumber, string messageSend, List<Uri> mediaUrl = null)
    {
        PhoneNumberDestiny = phoneNumber;
        MessageSend = messageSend;
        MediaUrl = mediaUrl;
    }
}
