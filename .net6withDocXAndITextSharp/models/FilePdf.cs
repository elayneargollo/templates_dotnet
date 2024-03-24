using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

public class FilePdf : File
{
    public override void WriteFile(string path, string filename)
    {
        if(String.IsNullOrEmpty(path) || String.IsNullOrEmpty(filename))
            throw new ArgumentException("Value cannot be null or empty");

        Document doc = new Document(PageSize.A4);
        doc.SetMargins(40, 40, 40, 80);
        doc.AddCreationDate();

        string pathFile = String.Concat(path, filename);
        PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(pathFile, FileMode.Create));

        doc.Open();

        string dados = String.Empty;

        Paragraph paragrafo = new Paragraph(dados, new Font(Font.NORMAL, 14));
        paragrafo.Alignment = Element.ALIGN_JUSTIFIED;

        paragrafo.Add("Lorem ipsum nunc hac, mauris.");
        doc.Add(paragrafo);

        doc.Close();
    }

    public override void OpenFile(string path, string filename)
    {
        StringBuilder text = new StringBuilder();
        PdfReader pdfReader = new PdfReader(String.Concat(path, filename));

        FileExist(String.Concat(path, filename));
        for (int page = 1; page <= pdfReader.NumberOfPages; page++)
        {
            ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
            string currentText = PdfTextExtractor.GetTextFromPage(pdfReader, page, strategy);

            currentText = Encoding.UTF8.GetString(ASCIIEncoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(currentText)));
            text.Append(currentText);
        }

        pdfReader.Close();
        Console.Write(text.ToString());
    }
}