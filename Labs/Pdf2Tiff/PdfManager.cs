using PDFiumCore;
using System.Drawing;
using System.Drawing.Imaging;

namespace Pdf2Tiff
{
    //Should probobly rewrite this, anyway we make use of PDFIumCore that includes everything we need to render a pdf and then save it as a image.
    //PFiumCore is built around PDFIum and that is Googles project to render pdf in google chrome, so this code should be good enought only problem with this implementation is that its not thread safe!
    //Need to take that into consideration if we should use this somehow, This is just a poc. probobly should check the license also for PDFiumCore and PDFium.
    public static class PdfManager
    {
        public static async Task ConvertPdfAsync(string fileLocation, int counter)
        {
            try
            {
                var pageIndex = 0;
                var scale = 2;

                PDFiumCore.fpdfview.FPDF_InitLibrary();
                FpdfDocumentT pdfDocument = PDFiumCore.fpdfview.FPDF_LoadDocument("C:\\Users\\neisep\\source\\repos\\Labs\\Labs\\Pdf2Tiff\\bin\\Debug\\net8.0\\TestPdf.pdf", "");
                var pdfPage = PDFiumCore.fpdfview.FPDF_LoadPage(pdfDocument, 0);

                var size = new FS_SIZEF_();
                fpdfview.FPDF_GetPageSizeByIndexF(pdfDocument, 0, size);

                var width = (int)Math.Round(size.Width * scale);
                var height = (int)Math.Round(size.Height * scale);

                var bitmap = fpdfview.FPDFBitmapCreateEx(width, height, 4, IntPtr.Zero, 0);

                fpdfview.FPDFBitmapFillRect(bitmap, 0, 0, width, height, (uint)Color.White.ToArgb());

                using var matrix = new FS_MATRIX_();
                using var clipping = new FS_RECTF_();

                matrix.A = scale;
                matrix.B = 0;
                matrix.C = 0;
                matrix.D = scale;
                matrix.E = 0;
                matrix.F = 0;

                clipping.Left = 0;
                clipping.Right = width;
                clipping.Bottom = 0;
                clipping.Top = height;

                fpdfview.FPDF_RenderPageBitmapWithMatrix(bitmap, pdfPage, matrix, clipping, (int)RenderFlags.RenderAnnotations);

                using (var bitmapImage = new Bitmap(width, height, fpdfview.FPDFBitmapGetStride(bitmap), PixelFormat.Format32bppArgb, fpdfview.FPDFBitmapGetBuffer(bitmap)))
                {
                    bitmapImage.Save($"test{counter}.jpg", ImageFormat.Jpeg);
                    //bitmapImage.Save()
                }

                //CleanUp
                fpdfview.FPDFBitmapDestroy(bitmap);
                fpdfview.FPDF_ClosePage(pdfPage);
                fpdfview.FPDF_CloseDocument(pdfDocument);
                fpdfview.FPDF_DestroyLibrary();

                //var test = System.Drawing.Bitmap();
                //var dummy = PDFiumCore.fpdfview.FPDFBitmapCreate(100, 100, 0);
                //PDFiumCore.fpdfview.FPDF_RenderPageBitmap(dummy, pdfPage, 0 ,0, 600, 500, 0, 0);
                ////var dummy2 = PDFiumCore.fpdf_edit.

                ////byte[] bytes = new byte[600 * 500 * 4];
                ////Marshal.Copy(dummy.__Instance, bytes, 0, bytes.Length);
                ////WriteToFileHandle();
                ////MemoryStream memoryStream = new MemoryStream(dummy.__Instance);
                //SafeFileHandle safeHandle = new SafeFileHandle(dummy.__Instance, true);
                //FileStream fileStream = new FileStream(safeHandle, FileAccess.ReadWrite);
                //Bitmap bitmap = Bitmap.FromHbitmap(dummy.__Instance);

                //bitmap.Save("C:\\Users\\neisep\\source\\repos\\Pdf2Tiff\\Pdf2Tiff\\bin\\Debug\\net8.0\\test.jpg");

                //fileStream.read

                //using (MemoryStream strm = new MemoryStream(Convert.FromBase64String(base64EncodedString)))
                //{
                //    strm.Position = 0;

                //    Image MyImage = new Image();
                //    MyImage.
                //    {
                //        using (PdfSharp.Pdf.PdfDocument doc = new PdfSharp.Pdf.PdfDocument())
                //        {
                //            for (int PageIndex = 0; PageIndex < MyImage.GetFrameCount(FrameDimension.Page); PageIndex++)
                //            {
                //                MyImage.SelectActiveFrame(FrameDimension.Page, PageIndex);

                //                PdfSharp.Drawing.XImage img = PdfSharp.Drawing.XImage.FromGdiPlusImage(MyImage);

                //                var page = new PdfSharp.Pdf.PdfPage();

                //                if (img.PixelWidth > img.PixelHeight)
                //                {
                //                    page.Orientation = PdfSharp.PageOrientation.Landscape;
                //                }
                //                else
                //                {
                //                    page.Orientation = PdfSharp.PageOrientation.Portrait;
                //                }
                //                doc.Pages.Add(page);

                //                PdfSharp.Drawing.XGraphics xgr = PdfSharp.Drawing.XGraphics.FromPdfPage(doc.Pages[PageIndex]);

                //                xgr.DrawImage(img, 0, 0);
                //            }

                //            doc.Save(outputFilePath);
                //            doc.Close();
                //        }
                //    }

                //    strm.Close();
                //}
            }
            catch (Exception ex)
            {
                Console.WriteLine($"error: {ex.Message} : {ex.StackTrace}");
                throw;
            }
        }

        //public static async Task ConvertPdfAsync(string fileLocation, int counter)
        //{
        //    try
        //    {
        //        using (var drawing = PdfDocument.Load(fileLocation, ""))
        //        {
        //            using (var page = drawing.GetPage(0))
        //            {
        //                var largestSideSize = page.Width > page.Height ? page.Width : page.Height;
        //                var maxWidth = 8192;
        //                var scale = maxWidth / largestSideSize;

        //                var pdfPageRenderConfig = new PdfPageRenderConfig()
        //                {
        //                    Scale = scale,
        //                    BackgroundColor = Color.White.ToPixel<Argb32>().Argb,
        //                    Viewport = new BoundaryF(0, 0, page.Width * scale, page.Height * scale)
        //                };
        //                using (var result = page.Render(pdfPageRenderConfig))
        //                {
        //                    using (var memoryStream = new MemoryStream())
        //                    {
        //                        //var dummyImage = result.Pointer.ToPointer();
        //                        var tiffEncoder = new TiffEncoder();
        //                        switch (counter)
        //                        {
        //                            case 1:
        //                                //tiffEncoder.Compression = SixLabors.ImageSharp.Formats.Tiff.Constants.TiffCompression.Ccitt1D;
        //                                tiffEncoder.Compression = SixLabors.ImageSharp.Formats.Tiff.Constants.TiffCompression.None;
        //                                break;
        //                            case 2:
        //                                //tiffEncoder.Compression = SixLabors.ImageSharp.Formats.Tiff.Constants.TiffCompression.CcittGroup3Fax;
        //                                tiffEncoder.Compression = SixLabors.ImageSharp.Formats.Tiff.Constants.TiffCompression.None;
        //                                break;
        //                            case 3:
        //                                tiffEncoder.Compression = SixLabors.ImageSharp.Formats.Tiff.Constants.TiffCompression.CcittGroup4Fax;
        //                                break;
        //                            case 4:
        //                                tiffEncoder.Compression = SixLabors.ImageSharp.Formats.Tiff.Constants.TiffCompression.Deflate; //Best Compression!
        //                                break;
        //                            case 5:
        //                                tiffEncoder.Compression = SixLabors.ImageSharp.Formats.Tiff.Constants.TiffCompression.Lzw;
        //                                break;
        //                            case 6:
        //                                tiffEncoder.Compression = SixLabors.ImageSharp.Formats.Tiff.Constants.TiffCompression.None;
        //                                break;
        //                            case 7:
        //                                tiffEncoder.Compression = SixLabors.ImageSharp.Formats.Tiff.Constants.TiffCompression.PackBits;
        //                                break;
        //                            default:
        //                                break;
        //                        }

        //                        tiffEncoder.CompressionLevel = SixLabors.ImageSharp.Compression.Zlib.DeflateCompressionLevel.BestCompression;
        //                        await result.GetImage().SaveAsTiffAsync(memoryStream, tiffEncoder, CancellationToken.None);
        //                        //var image = result.GetImage();
        //                        //image.

        //                        using (var file = new FileStream($"test{counter}.tiff", FileMode.Create, FileAccess.ReadWrite))
        //                        {
        //                            memoryStream.Position = 0;
        //                            memoryStream.CopyTo(file);
        //                            file.Close();
        //                            file.Dispose();
        //                        }
        //                        memoryStream.Close();
        //                        memoryStream.Dispose();
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"error: {ex.Message} : {ex.StackTrace}");
        //        throw;
        //    }
        //}

        //public static void dummy2()
        //{
        //    using (MagickImageCollection images = new MagickImageCollection())
        //    {
        //        MagickImage firstFrame = new MagickImage(@"c:\dips\img1.jpg");
        //        firstFrame.Format = MagickFormat.Tiff;
        //        firstFrame.SetCompression(CompressionMethod.JPEG);
        //        images.Add(firstFrame);

        //        MagickImage secondFrame = new MagickImage(@"c:\dips\img2.tif");
        //        secondFrame.Format = MagickFormat.Tiff;
        //        secondFrame.SetCompression(CompressionMethod.Group4);
        //        images.Add(secondFrame);

        //        images.Write(@"C:\dips\out.tiff", new TiffWriteDefines
        //        {
        //            PreserveCompression = true,
        //        });
        //    }
        //}

        //public unsafe static void Dummy()
        //{

        //}
    }
}
