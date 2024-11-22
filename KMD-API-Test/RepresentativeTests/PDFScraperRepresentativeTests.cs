using NUnit.Framework;
using api.FileScraper;
using UglyToad.PdfPig;
namespace KMD_API_Test.RepresentativeTests
{
    public class PDFScraperRepresentativeTests
    {
        // Aalborg data expected
        FileScraper.DataController AalborgDataController = new FileScraper.DataController();
        FileScraper.DataProcessor AalborgDataProcessor = new FileScraper.DataProcessor();
        (FileScraper.DataController, FileScraper.DataProcessor) AalborgRepresentativePair;

        // Faaborg data expected
        FileScraper.DataController FaaborgDataController = new FileScraper.DataController();
        FileScraper.DataProcessor FaaborgDataProcessor = new FileScraper.DataProcessor();
        (FileScraper.DataController, FileScraper.DataProcessor) FaaborgRepresentativePair;
        // Herning data expected
        FileScraper.DataController HerningDataController = new FileScraper.DataController();
        FileScraper.DataProcessor HerningDataProcessor = new FileScraper.DataProcessor();
        (FileScraper.DataController, FileScraper.DataProcessor) HerningRepresentativePair;
        // Holbæk data expected
        FileScraper.DataController HolbækDataController = new FileScraper.DataController();
        FileScraper.DataProcessor HolbækDataProcessor = new FileScraper.DataProcessor();
        (FileScraper.DataController, FileScraper.DataProcessor) HolbækRepresentativePair;
        // Struer data expected
        FileScraper.DataController StruerDataController = new FileScraper.DataController();
        FileScraper.DataProcessor StruerDataProcessor = new FileScraper.DataProcessor();
        (FileScraper.DataController, FileScraper.DataProcessor) StruerRepresentativePair;



        [SetUp]
        public void SetUpAalborgRepresentatives()
        {
            //Assign Aalborg
            AalborgDataController.Name = "Anders And";
            AalborgDataController.Role = "Indkøbschef";
            AalborgDataController.Phone = "12 23 34 45";
            AalborgDataController.Email = "andersand@aakommune.dk";

            AalborgDataProcessor.Name = "Ole Olsen";
            AalborgDataProcessor.Role = "Kontraktsansvarlig";
            AalborgDataProcessor.Phone = "45 56 77 78";
            AalborgDataProcessor.Email = "oox@kmd.dk";
            AalborgRepresentativePair = (AalborgDataController, AalborgDataProcessor);
        }

        [SetUp]
        public void SetUpFaaborgRepresentatives()
        {
            //Assign Faaborg
            FaaborgDataController.Name = "Georg Gearløs";
            FaaborgDataController.Role = "Teknisk Konsulent";
            FaaborgDataController.Phone = "65 78 88 90";
            FaaborgDataController.Email = "georgg@fm-kommune.dk";

            FaaborgDataProcessor.Name = "Ole Olsen";
            FaaborgDataProcessor.Role = "Kontraktsansvarlig";
            FaaborgDataProcessor.Phone = "45 56 77 78";
            FaaborgDataProcessor.Email = "oox@kmd.dk";
            FaaborgRepresentativePair = (FaaborgDataController, FaaborgDataProcessor);
        }

        [SetUp]
        public void SetUpHerningRepresentatives()
        {
            ///Assign Herning
            HerningDataController.Name = "Andersine And";
            HerningDataController.Role = "Kontraktansvarlig";
            HerningDataController.Phone = "67 65 34 45";
            HerningDataController.Email = "indkøb@herningkommune.dk";

            HerningDataProcessor.Name = "Ole Olsen";
            HerningDataProcessor.Role = "Kontraktsansvarlig";
            HerningDataProcessor.Phone = "45 56 77 78";
            HerningDataProcessor.Email = "oox@kmd.dk";
            HerningRepresentativePair = (HerningDataController, HerningDataProcessor);
        }

        [SetUp]
        public void SetUpHolbækRepresentatives()
        {
            //Assign Holbæk
            HolbækDataController.Name = "Fætter Guf";
            HolbækDataController.Role = "Leverandøransvarlig";
            HolbækDataController.Phone = "76 45 34 22";
            HolbækDataController.Email = "fgx@holbæk-kommune.dk";

            HolbækDataProcessor.Name = "Ole Olsen";
            HolbækDataProcessor.Role = "Kontraktsansvarlig";
            HolbækDataProcessor.Phone = "45 56 77 78";
            HolbækDataProcessor.Email = "oox@kmd.dk";
            HolbækRepresentativePair = (HolbækDataController, HolbækDataProcessor);
        }

        [SetUp]
        public void SetUpStruerRepresentatives()
        {
            //Assign Struer
            StruerDataController.Name = "Joakim Von And";
            StruerDataController.Role = "Økonomichef";
            StruerDataController.Phone = "77 90 20 45";
            StruerDataController.Email = "jva@komune-struer.dk";

            StruerDataProcessor.Name = "Ole Olsen";
            StruerDataProcessor.Role = "Kontraktsansvarlig";
            StruerDataProcessor.Phone = "45 56 77 78";
            StruerDataProcessor.Email = "oox@kmd.dk";
            StruerRepresentativePair = (StruerDataController, StruerDataProcessor);
        }





        [Test]
        public void RepresentativesFromAalborg()
        {
            string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string sFile = Path.Combine(sCurrentDirectory, @"..\..\..\PDFFiles\Aalborg Kommune.pdf");
            string sFilePath = Path.GetFullPath(sFile);
            PdfDocument doc = PdfDocument.Open(sFilePath);
            (string, List<int>) representatives = FileScraper.GetSection(doc, "14. Ikrafttræden og ophør", "15. Kontaktpersoner hos den dataansvarlige og databehandleren");
            (FileScraper.DataController, FileScraper.DataProcessor) representativePair = FileScraper.ExtractDataProcessors(doc, representatives.Item2);

            Assert.That(representativePair.Item1.Name, Is.EqualTo(AalborgRepresentativePair.Item1.Name));
            Assert.That(representativePair.Item1.Role, Is.EqualTo(AalborgRepresentativePair.Item1.Role));
            Assert.That(representativePair.Item1.Phone, Is.EqualTo(AalborgRepresentativePair.Item1.Phone));
            Assert.That(representativePair.Item1.Email, Is.EqualTo(AalborgRepresentativePair.Item1.Email));

            Assert.That(representativePair.Item2.Name, Is.EqualTo(AalborgRepresentativePair.Item2.Name));
            Assert.That(representativePair.Item2.Role, Is.EqualTo(AalborgRepresentativePair.Item2.Role));
            Assert.That(representativePair.Item2.Phone, Is.EqualTo(AalborgRepresentativePair.Item2.Phone));
            Assert.That(representativePair.Item2.Email, Is.EqualTo(AalborgRepresentativePair.Item2.Email));

        }

        [Test]
        public void RepresentativesFromFaaborg()
        {
            string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string sFile = Path.Combine(sCurrentDirectory, @"..\..\..\PDFFiles\Faaborg-Midtfyn Kommune.pdf");
            string sFilePath = Path.GetFullPath(sFile);
            PdfDocument doc = PdfDocument.Open(sFilePath);
            (string, List<int>) representatives = FileScraper.GetSection(doc, "14. Ikrafttræden og ophør", "15. Kontaktpersoner hos den dataansvarlige og databehandleren");
            (FileScraper.DataController, FileScraper.DataProcessor) representativePair = FileScraper.ExtractDataProcessors(doc, representatives.Item2);

            Assert.That(representativePair.Item1.Name, Is.EqualTo(FaaborgRepresentativePair.Item1.Name));
            Assert.That(representativePair.Item1.Role, Is.EqualTo(FaaborgRepresentativePair.Item1.Role));
            Assert.That(representativePair.Item1.Phone, Is.EqualTo(FaaborgRepresentativePair.Item1.Phone));
            Assert.That(representativePair.Item1.Email, Is.EqualTo(FaaborgRepresentativePair.Item1.Email));

            Assert.That(representativePair.Item2.Name, Is.EqualTo(FaaborgRepresentativePair.Item2.Name));
            Assert.That(representativePair.Item2.Role, Is.EqualTo(FaaborgRepresentativePair.Item2.Role));
            Assert.That(representativePair.Item2.Phone, Is.EqualTo(FaaborgRepresentativePair.Item2.Phone));
            Assert.That(representativePair.Item2.Email, Is.EqualTo(FaaborgRepresentativePair.Item2.Email));

        }

        [Test]
        public void RepresentativesFromHerning()
        {
            string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string sFile = Path.Combine(sCurrentDirectory, @"..\..\..\PDFFiles\Herning Kommune.pdf");
            string sFilePath = Path.GetFullPath(sFile);
            PdfDocument doc = PdfDocument.Open(sFilePath);
            (string, List<int>) representatives = FileScraper.GetSection(doc, "14. Ikrafttræden og ophør", "15. Kontaktpersoner hos den dataansvarlige og databehandleren");
            (FileScraper.DataController, FileScraper.DataProcessor) representativePair = FileScraper.ExtractDataProcessors(doc, representatives.Item2);

            Assert.That(representativePair.Item1.Name, Is.EqualTo(HerningRepresentativePair.Item1.Name));
            Assert.That(representativePair.Item1.Role, Is.EqualTo(HerningRepresentativePair.Item1.Role));
            Assert.That(representativePair.Item1.Phone, Is.EqualTo(HerningRepresentativePair.Item1.Phone));
            Assert.That(representativePair.Item1.Email, Is.EqualTo(HerningRepresentativePair.Item1.Email));

            Assert.That(representativePair.Item2.Name, Is.EqualTo(HerningRepresentativePair.Item2.Name));
            Assert.That(representativePair.Item2.Role, Is.EqualTo(HerningRepresentativePair.Item2.Role));
            Assert.That(representativePair.Item2.Phone, Is.EqualTo(HerningRepresentativePair.Item2.Phone));
            Assert.That(representativePair.Item2.Email, Is.EqualTo(HerningRepresentativePair.Item2.Email));

        }

        [Test]
        public void RepresentativesFromHolbæk()
        {
            string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string sFile = Path.Combine(sCurrentDirectory, @"..\..\..\PDFFiles\Holbæk Kommune.pdf");
            string sFilePath = Path.GetFullPath(sFile);
            PdfDocument doc = PdfDocument.Open(sFilePath);
            (string, List<int>) representatives = FileScraper.GetSection(doc, "14. Ikrafttræden og ophør", "15. Kontaktpersoner hos den dataansvarlige og databehandleren");
            (FileScraper.DataController, FileScraper.DataProcessor) representativePair = FileScraper.ExtractDataProcessors(doc, representatives.Item2);

            Assert.That(representativePair.Item1.Name, Is.EqualTo(HolbækRepresentativePair.Item1.Name));
            Assert.That(representativePair.Item1.Role, Is.EqualTo(HolbækRepresentativePair.Item1.Role));
            Assert.That(representativePair.Item1.Phone, Is.EqualTo(HolbækRepresentativePair.Item1.Phone));
            Assert.That(representativePair.Item1.Email, Is.EqualTo(HolbækRepresentativePair.Item1.Email));

            Assert.That(representativePair.Item2.Name, Is.EqualTo(HolbækRepresentativePair.Item2.Name));
            Assert.That(representativePair.Item2.Role, Is.EqualTo(HolbækRepresentativePair.Item2.Role));
            Assert.That(representativePair.Item2.Phone, Is.EqualTo(HolbækRepresentativePair.Item2.Phone));
            Assert.That(representativePair.Item2.Email, Is.EqualTo(HolbækRepresentativePair.Item2.Email));

        }

        [Test]
        public void RepresentativesFromStruer()
        {
            string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string sFile = Path.Combine(sCurrentDirectory, @"..\..\..\PDFFiles\Struer Kommune.pdf");
            string sFilePath = Path.GetFullPath(sFile);
            PdfDocument doc = PdfDocument.Open(sFilePath);
            (string, List<int>) representatives = FileScraper.GetSection(doc, "14. Ikrafttræden og ophør", "15. Kontaktpersoner hos den dataansvarlige og databehandleren");
            (FileScraper.DataController, FileScraper.DataProcessor) representativePair = FileScraper.ExtractDataProcessors(doc, representatives.Item2);

            Assert.That(representativePair.Item1.Name, Is.EqualTo(StruerRepresentativePair.Item1.Name));
            Assert.That(representativePair.Item1.Role, Is.EqualTo(StruerRepresentativePair.Item1.Role));
            Assert.That(representativePair.Item1.Phone, Is.EqualTo(StruerRepresentativePair.Item1.Phone));
            Assert.That(representativePair.Item1.Email, Is.EqualTo(StruerRepresentativePair.Item1.Email));

            Assert.That(representativePair.Item2.Name, Is.EqualTo(StruerRepresentativePair.Item2.Name));
            Assert.That(representativePair.Item2.Role, Is.EqualTo(StruerRepresentativePair.Item2.Role));
            Assert.That(representativePair.Item2.Phone, Is.EqualTo(StruerRepresentativePair.Item2.Phone));
            Assert.That(representativePair.Item2.Email, Is.EqualTo(StruerRepresentativePair.Item2.Email));

        }




    }
}
