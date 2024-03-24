using System.Globalization;
using CsvHelper;
using Mapping;
using Seed;

class Program
{
    static void Main(string[] args)
    {
        using (var streamWriter = new StreamWriter("AtendimentosExport.csv"))
        using (var csvWriter = new CsvWriter(streamWriter, new CultureInfo("pt-BR", true)))
        {
            csvWriter.Configuration.RegisterClassMap<AtendimentoMap>();

            csvWriter.WriteRecords(AtendimentoMock.ObterAtendimentos());
            streamWriter.Flush();
        }
    }
}