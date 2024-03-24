using System.Globalization;
using CsvHelper;
using Mapping;
using Model;
using Seed;

class Program
{
    static void Main(string[] args)
    {
        try 
        {
            using (var streamWriter = new StreamWriter("workerFile.csv"))
            using (var csvWriter = new CsvWriter(streamWriter, new CultureInfo("pt-BR", true)))
            {
                FillColumnName(csvWriter, GetKeys());

                csvWriter.Configuration.HasHeaderRecord = false;
                csvWriter.Configuration.RegisterClassMap(new WorkerModelMap(GetKeys()));

                var records = new WorkerModel(StatusMock.GetStatusFound());
                csvWriter.WriteRecords(records.MountWorkerModel());
            }
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred whilst performing the export: " + ex.Message);
        }
    }

    public static void FillColumnName(CsvWriter csvWriter, List<string> keys)
    {
        try 
        {
            var headers = new []{ "Month/Year"}.Concat(keys).ToList();

            headers.ForEach(header => csvWriter.WriteField(header));
            csvWriter.NextRecord();
        }
        catch 
        {
            throw;
        }
    }

    public static List<string> GetKeys()
    {
        var list = new List<string>();
        
        foreach(var status in StatusMock.GetAllStatus())
        {
            list.Add(status.Description);
            list.Add(String.Concat(status.Description, "(%)"));
        }

        return list;
    }
}