public abstract class File : FileSecurity, IFileTool
{
    public abstract void OpenFile(string path, string filename);
    public abstract void WriteFile(string path, string filename);
}