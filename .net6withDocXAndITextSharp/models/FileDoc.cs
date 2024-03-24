using Xceed.Document.NET;
using Xceed.Words.NET;

public class FileDoc : File
{
    public override void WriteFile(string path, string filename)
    {
        if(String.IsNullOrEmpty(path) || String.IsNullOrEmpty(filename))
            throw new ArgumentException("Value cannot be null or empty");

        using (var document = DocX.Create(String.Concat(path, filename)))
        {
            document.InsertParagraph("Adding Custom Properties to a document").FontSize(15d).SpacingAfter(50d).Alignment = Alignment.center;

            document.AddCustomProperty(new CustomProperty("CompanyName", "Xceed Software inc."));
            document.AddCustomProperty(new CustomProperty("Product", "Xceed Words for .NET"));
            document.AddCustomProperty(new CustomProperty("Address", "3141 Taschereau, Greenfield Park"));
            document.AddCustomProperty(new CustomProperty("Date", DateTime.Now));

            var paragraph = document.InsertParagraph("This document contains ").Append(document.CustomProperties.Count.ToString()).Append(" Custom Properties :");
            paragraph.SpacingAfter(30);

            foreach (var prop in document.CustomProperties)
                document.InsertParagraph(prop.Value.Name).Append(" = ").Append(prop.Value.Value.ToString()).AppendLine();
            
            document.Save();
        }
    }

    public override void OpenFile(string path, string filename)
    {
        var lines = File.ReadAllLines(String.Concat(path, filename));

        foreach (var line in lines)
            Console.WriteLine(line);
    }
}