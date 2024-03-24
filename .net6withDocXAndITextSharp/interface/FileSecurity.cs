using GroupDocs.Merger;
using GroupDocs.Merger.Domain.Options;

public abstract class FileSecurity
{
    public void ProtectFile(string path, string password)
    {
        if(String.IsNullOrEmpty(password)) 
            throw new ArgumentException("Value cannot be null or empty");

        this.FileExist(path);
        AddPasswordOptions addOptions = new AddPasswordOptions(password);

        using (Merger merger = new Merger(path))
        {
            merger.AddPassword(addOptions);
            merger.Save(path);
        }
    }

    public void FileExist(string path)
    {
        if(String.IsNullOrEmpty(path)) throw new ArgumentException("Value cannot be null or empty");

        FileInfo file = new FileInfo(path);

        if(!file.Exists) 
            throw new ArgumentException("File not found");
    }
}