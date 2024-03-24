using System;
using System.Collections.Generic;
using System.IO;

namespace Comunicacao.Messagem
{
    public class MemoryStreamDecorator : ILogComponentDecorator
    {
        public void WriteData(Message message)
        {
            Console.WriteLine("Writing the data memoryStream");

            if (message == null) 
                return;

            MemoryStream memoryStream = new MemoryStream();
            BinaryWriter binaryWriter = new BinaryWriter(memoryStream);           

            binaryWriter.Write(message.PhoneNumberDestiny);
            binaryWriter.Write(message.PhoneOrigin);

            // Confirm recording MemoryStream
            Console.WriteLine("Confirm recording MemoryStream");

            BinaryReader binaryReader = new BinaryReader(memoryStream);
            memoryStream.Position = 0;

            Console.WriteLine(binaryReader.ReadChars(
                (int)(memoryStream.Length - memoryStream.Position)));
        }
    }
}