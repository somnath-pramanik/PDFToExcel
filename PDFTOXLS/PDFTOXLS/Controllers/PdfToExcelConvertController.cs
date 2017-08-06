using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Threading.Tasks;
using System.IO;
using PDFTOXLS.Models;
//using Aspose.Pdf;
using PDFTOXLS.Controllers;
using SautinSoft;
namespace PDFTOXLS.ApiController
{
   
    public class PdfToExcelConvertController : System.Web.Http.ApiController
    {
        
        [HttpPost]
        [ActionName("UploadZIP")]
        public void UploadZIP(int k=0)
        {
           // int userid = int.Parse(HttpContext.Current.Request.Form["UserId"]);

            string[] _ret = null;
            _ret = new string[2];
            string _UploadFileName = "";
            var httpRequest = HttpContext.Current.Request;
            string Message, fileName, actualFileName, filePath, uploadedFilePath, folderName;
            Message = fileName = actualFileName = string.Empty;
            if (httpRequest.Files != null)
            {

                var file = httpRequest.Files[0];
                actualFileName = file.FileName;
                _UploadFileName = file.FileName;
                folderName = "UploadedPdfFile\\";
                int size = file.ContentLength;
                try
                {
                    actualFileName = Guid.NewGuid().ToString().Trim() + DateTime.Now.Ticks.ToString().Trim() + Path.GetExtension(file.FileName);
                    file.SaveAs(AppDomain.CurrentDomain.BaseDirectory + folderName + actualFileName);
                    filePath = AppDomain.CurrentDomain.BaseDirectory + folderName + actualFileName;
                    uploadedFilePath = folderName;

                    //WebForm1 obj = new WebForm1();
                    //obj.ExportPDFToExcel(filePath);
                    MainContext _mc = new MainContext();
                    PdfConvertRecord newpdf = new PdfConvertRecord();
                    newpdf.UserId =k;
                    newpdf.pdffilename = actualFileName;
                    newpdf.xlsfilename = actualFileName;
                    newpdf.isactive = true;
                    newpdf.datecreated = DateTime.Now;
                    _mc.PdfConvertRecord.Add(newpdf);
                    _mc.SaveChanges();


                    string pathToPdf = @filePath; //"E:\AngularJS_Demo\AngularJS_Demo\AngularJS_Demo\UploadedPdfFile\f5cc3aee-ee70-4acc-b7c5-7b55ee3ca8e5636329642903503241.pdf";
                    string pathToExcel = Path.ChangeExtension(pathToPdf, ".xls");

                    // Convert PDF file to Excel file
                    SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();

                    // This property is necessary only for registered version
                    //f.Serial = "XXXXXXXXXXX";

                    // 'true' = Convert all data to spreadsheet (tabular and even textual).
                    // 'false' = Skip textual data and convert only tabular (tables) data.
                    f.ExcelOptions.ConvertNonTabularDataToSpreadsheet = true;

                    // 'true'  = Preserve original page layout.
                    // 'false' = Place tables before text.
                    f.ExcelOptions.PreservePageLayout = true;

                    f.OpenPdf(pathToPdf);

                    if (f.PageCount > 0)
                    {
                        int result = f.ToExcel(pathToExcel);

                        //Open a produced Excel workbook
                        if (result == 0)
                        {
                            System.Diagnostics.Process.Start(pathToExcel);
                        }
                    }

                
                }
                catch (Exception ex)
                {
                    Message = "File upload failed! Please try again";
                    fileName = null;
                }

            }
           // _ret[0] = actualFileName;
           // _ret[1] = _UploadFileName;
            //return _ret;

        } 


        //private static readonly string ServerUploadFolder = ConfigurationManager.AppSettings["PdfFileUploadedPath"].ToString(); //Path.GetTempPath();

        ////[Route("files")]
        ////[HttpGet]
        ////[ValidateMimeMultipartContentFilter]
        //public async Task<FileResult> ConvertPdfToExcel()
        //{
        //    var streamProvider = new MultipartFormDataStreamProvider(ServerUploadFolder);
        //    await Request.Content.ReadAsMultipartAsync(streamProvider);

        //    string pdfSavedFileName = string.Empty;
        //    //To save every file with different name
        //    string randomName = DateTime.Now.ToFileTime().ToString();

        //    //string relativePath = ConfigFilePath; // + "/_Temp/";
        //    pdfSavedFileName = randomName + "_" + streamProvider.FileData.Select(entry => entry.LocalFileName);

        //    //Complete path of the file.
        //    string filePath = ServerUploadFolder + pdfSavedFileName;

        //    // Load PDF document
        //    Document pdfDocument = new Document(filePath);

        //    // Instantiate ExcelSave Option object
        //    Aspose.Pdf.ExcelSaveOptions excelsave = new ExcelSaveOptions();

        //    // Save the output in XLS format
        //    pdfDocument.Save("PDFToXLS_out.xls", excelsave);

        //    return new FileResult
        //    {
        //        FileNames = streamProvider.FileData.Select(entry => entry.LocalFileName),
        //        Names = streamProvider.FileData.Select(entry => entry.Headers.ContentDisposition.FileName),
        //        ContentTypes = streamProvider.FileData.Select(entry => entry.Headers.ContentType.MediaType),
        //        Description = streamProvider.FormData["description"],
        //        CreatedTimestamp = DateTime.UtcNow,
        //        UpdatedTimestamp = DateTime.UtcNow,
        //        DownloadLink = "TODO, will implement when file is persisited"
        //    };
        //}
      
    }
}
