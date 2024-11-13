using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UglyToad.PdfPig;
using UglyToad.PdfPig.DocumentLayoutAnalysis;
using UglyToad.PdfPig.DocumentLayoutAnalysis.PageSegmenter;
using UglyToad.PdfPig.DocumentLayoutAnalysis.ReadingOrderDetector;
using UglyToad.PdfPig.DocumentLayoutAnalysis.WordExtractor;
using UglyToad.PdfPig.Fonts.Standard14Fonts;
using UglyToad.PdfPig.Writer;
using api.FileScraper;

namespace api.Controllers
{

    [Route("api/file-scraper")]
    [ApiController]
    public class FileScraperController : ControllerBase
    {
       

        [HttpPost]
        public IActionResult ScrapeFile(IFormFile file)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (Path.GetExtension(file.FileName) != ".pdf")
            {
                return BadRequest("File must be a PDF");
            }


            PdfDocument pdfDocument = FileScraper.FileScraper.OpenPDF(file.OpenReadStream());
            //Extract ContactInfo
            (string, List<int>) representatives = FileScraper.FileScraper.GetSection(pdfDocument, "14. Ikrafttræden og ophør", "15. Kontaktpersoner hos den dataansvarlige og databehandleren");
            (FileScraper.FileScraper.DataController, FileScraper.FileScraper.DataProcessor) representativePair = FileScraper.FileScraper.ExtractDataProcessors(pdfDocument, representatives.Item2);

            // Extract Subprocessors
            (string, List<int>) SubProcessorSection = FileScraper.FileScraper.GetSection(pdfDocument, "B.1. Godkendte underdatabehandlere", "B.2.");
            // row major
            (Dictionary<(double, int), int>, Dictionary<double, int>) tableIndices = FileScraper.FileScraper.CreateTableIndices(pdfDocument, SubProcessorSection.Item2);
            string[,] SubProcessorData = FileScraper.FileScraper.ExtractSubProcessors(pdfDocument, SubProcessorSection.Item2, tableIndices);
            var list = new List<List<string>>();
            for (int i = 0; i < SubProcessorData.GetLength(0); i++)
            {
                var innerList = new List<string>();
                for (int j = 0; j < SubProcessorData.GetLength(1); j++)
                {
                    innerList.Add(SubProcessorData[i, j]);
                }
                list.Add(innerList);
            }
            IEnumerable<FileScraper.FileScraper.SubProcessor>? verifiedSubProcessors = FileScraper.FileScraper.CreateSubProcessorList(list);

            List<object?> objList = new List<object?>();
            objList.Add(representativePair.Item1);
            objList.Add(representativePair.Item2);
            objList.Add(verifiedSubProcessors);

            return Ok(objList);
            
        }
    }
}