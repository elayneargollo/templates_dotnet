using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.IO;
using CsvHelper;

namespace Comunicacao.Messagem
{
    public class FileDecorator : ILogComponentDecorator
    {
        protected List<dynamic> records = new List<dynamic>();

        public void WriteData(Message message)
        {
            Console.WriteLine("Writing the data file type csv");

            if (message == null) 
                return;

            using (var streamWriter = new StreamWriter("MessageExport.csv"))
            using (var csvWriter = new CsvWriter(streamWriter, new CultureInfo("pt-BR", true)))
            {
                FillData(message);

                csvWriter.WriteRecords(records);
                streamWriter.Flush();
            }
        }

        protected void FillData(Message message)
        {
            dynamic record = new ExpandoObject();

            record.Date = DateTime.Now;
            record.PhoneNumberDestiny = message.PhoneNumberDestiny;
            record.PhoneNumberOrigin = message.PhoneOrigin;
            record.MediaUrl = message.MediaUrl;

            records.Add(record);
        }
    }
}