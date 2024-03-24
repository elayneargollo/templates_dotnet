using CsvHelper.Configuration;
using Model;

namespace Mapping
{
    public class WorkerModelMap : ClassMap<WorkerModel>
    {
        public WorkerModelMap(List<string> keys)
        {
            Map(m => m.Period).Name("Month/Year");

            Map(m => m.CustomerField)
            .ConvertUsing(row => 
                keys.Select(key => new 
                { 
                    key, 
                    value = row.GetField(key)
                }).ToDictionary(dic => dic.key, dic => dic.value)
            );
        }
    }
}