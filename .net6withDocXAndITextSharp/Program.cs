class Program
{
    static void Main(string[] args)
    {       

        Console.WriteLine("Choose the file extension: ");
        Console.WriteLine("(1)PDF   (2)DOCX");
        var extensao = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Choose an action: ");
        Console.WriteLine("(1)Write   (2)Open    (3)ProtectFile");
        var acao = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter a path: ");
        var path = Console.ReadLine();

        Console.WriteLine("Enter a name: ");
        var filename = Console.ReadLine();

        File file = extensao.Equals(1) ? new FilePdf() : new FileDoc();

        switch(acao)
        {
            case 1: 
                file.WriteFile(path, filename);
                break;
            case 2:
                file.OpenFile(path, filename);
                break;
            case 3:
                Console.WriteLine("Enter a password: ");
                var password = Console.ReadLine();

                file.ProtectFile(String.Concat(path, filename), password);
                break;
        }
    }
}