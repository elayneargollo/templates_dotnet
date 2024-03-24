namespace Model
{
    public class WorkerModel
    {
        public readonly List<StatusModel> _statusList;
        public string Period { get; set; }
        public Dictionary<string, string> CustomerField { get; set; }
        public const string SymboloPercentage = "%";
        public const string Delimiter = "/";        


        public WorkerModel(List<StatusModel> statusList) {  _statusList = statusList;  }

        public WorkerModel() { }

        public Dictionary<string, string> FormattedData()
        {
            var statusGrouped = _statusList.GroupBy(status => status.Identificador)
                                            .Select(group => new 
                                            {   
                                                Description = group.Key, 
                                                Amount = group.Count() 
                                            });

            var dictionary = new Dictionary<string, string>();
            var totalFound = statusGrouped.Count();

            foreach(var grouped in statusGrouped)
            {
                var percentage = ((grouped.Amount / (double)totalFound) * 100).ToString();

                dictionary.Add(grouped.Description, grouped.Amount.ToString());
                dictionary.Add(String.Concat(grouped.Description, SymboloPercentage), String.Concat(percentage, SymboloPercentage));
            }

            return dictionary;
        }

        public List<WorkerModel> MountWorkerModel()
        {
            return new List<WorkerModel>()
            {
                new WorkerModel()
                {
                    Period = String.Concat(DateTime.Now.Month, Delimiter, DateTime.Now.Year),
                    CustomerField = FormattedData()
                },
                new WorkerModel()
                {
                    Period = String.Concat(DateTime.Now.Month, Delimiter, DateTime.Now.Year),
                    CustomerField = FormattedData()
                }
            };
        }
    }
}

