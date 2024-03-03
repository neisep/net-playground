
namespace Pdf2Tiff
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Testing Convert");

            for (int i = 1; i <= 7; i++)
            {
                await PdfManager.ConvertPdfAsync("C:\\Users\\neisep\\source\\repos\\Pdf2Tiff\\TestPdf.pdf", i);
                Console.WriteLine("Complete, press any key to continue");
                Console.ReadLine();
            }


            //Console.WriteLine("Press anykey to exit");
            //Console.ReadLine();
            //await PdfManager.ConvertPdfAsync("C:\\Users\\neisep\\source\\repos\\Pdf2Tiff\\TestPdf.pdf", 6);

        }
    }
}
