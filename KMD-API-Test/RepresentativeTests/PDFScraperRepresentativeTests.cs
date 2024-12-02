using NUnit.Framework;
using api.FileScraper;
using api.Dtos;
using UglyToad.PdfPig;
using api.Dtos.DataProcessor30ListingData.NullableDataProcessor30ListingData;
namespace KMD_API_Test.RepresentativeTests
{
    public class PDFScraperRepresentativeTests
    {
        // Aalborg data expected
        NullableDataControllerRepresentative AalborgDataController = new NullableDataControllerRepresentative();
        NullableDataProcessorRepresentative AalborgDataProcessor = new NullableDataProcessorRepresentative();
        (NullableDataControllerRepresentative, NullableDataProcessorRepresentative) AalborgRepresentativePair;

        // Faaborg data expected
        NullableDataControllerRepresentative FaaborgDataController = new NullableDataControllerRepresentative();
        NullableDataProcessorRepresentative FaaborgDataProcessor = new NullableDataProcessorRepresentative();
        (NullableDataControllerRepresentative, NullableDataProcessorRepresentative) FaaborgRepresentativePair;
        // Herning data expected
        NullableDataControllerRepresentative HerningDataController = new NullableDataControllerRepresentative();
        NullableDataProcessorRepresentative HerningDataProcessor = new NullableDataProcessorRepresentative();
        (NullableDataControllerRepresentative, NullableDataProcessorRepresentative) HerningRepresentativePair;
        // Holbæk data expected
        NullableDataControllerRepresentative HolbækDataController = new NullableDataControllerRepresentative();
        NullableDataProcessorRepresentative HolbækDataProcessor = new NullableDataProcessorRepresentative();
        (NullableDataControllerRepresentative, NullableDataProcessorRepresentative) HolbækRepresentativePair;
        // Struer data expected
        NullableDataControllerRepresentative StruerDataController = new NullableDataControllerRepresentative();
        NullableDataProcessorRepresentative StruerDataProcessor = new NullableDataProcessorRepresentative();
        (NullableDataControllerRepresentative, NullableDataProcessorRepresentative) StruerRepresentativePair;



        [SetUp]
        public void SetUpAalborgRepresentatives()
        {
            //Assign Aalborg
            AalborgDataController.Name = "Anders And";
            AalborgDataController.Role = "Indkøbschef";
            AalborgDataController.PhoneNo = "12 23 34 45";
            AalborgDataController.Mail = "andersand@aakommune.dk";

            AalborgDataProcessor.Name = "Ole Olsen";
            AalborgDataProcessor.Role = "Kontraktsansvarlig";
            AalborgDataProcessor.PhoneNo = "45 56 77 78";
            AalborgDataProcessor.Mail = "oox@kmd.dk";
            AalborgRepresentativePair = (AalborgDataController, AalborgDataProcessor);
        }

        [SetUp]
        public void SetUpFaaborgRepresentatives()
        {
            //Assign Faaborg
            FaaborgDataController.Name = "Georg Gearløs";
            FaaborgDataController.Role = "Teknisk Konsulent";
            FaaborgDataController.PhoneNo = "65 78 88 90";
            FaaborgDataController.Mail = "georgg@fm-kommune.dk";

            FaaborgDataProcessor.Name = "Ole Olsen";
            FaaborgDataProcessor.Role = "Kontraktsansvarlig";
            FaaborgDataProcessor.PhoneNo = "45 56 77 78";
            FaaborgDataProcessor.Mail = "oox@kmd.dk";
            FaaborgRepresentativePair = (FaaborgDataController, FaaborgDataProcessor);
        }

        [SetUp]
        public void SetUpHerningRepresentatives()
        {
            ///Assign Herning
            HerningDataController.Name = "Andersine And";
            HerningDataController.Role = "Kontraktansvarlig";
            HerningDataController.PhoneNo = "67 65 34 45";
            HerningDataController.Mail = "indkøb@herningkommune.dk";

            HerningDataProcessor.Name = "Ole Olsen";
            HerningDataProcessor.Role = "Kontraktsansvarlig";
            HerningDataProcessor.PhoneNo = "45 56 77 78";
            HerningDataProcessor.Mail = "oox@kmd.dk";
            HerningRepresentativePair = (HerningDataController, HerningDataProcessor);
        }

        [SetUp]
        public void SetUpHolbækRepresentatives()
        {
            //Assign Holbæk
            HolbækDataController.Name = "Fætter Guf";
            HolbækDataController.Role = "Leverandøransvarlig";
            HolbækDataController.PhoneNo = "76 45 34 22";
            HolbækDataController.Mail = "fgx@holbæk-kommune.dk";

            HolbækDataProcessor.Name = "Ole Olsen";
            HolbækDataProcessor.Role = "Kontraktsansvarlig";
            HolbækDataProcessor.PhoneNo = "45 56 77 78";
            HolbækDataProcessor.Mail = "oox@kmd.dk";
            HolbækRepresentativePair = (HolbækDataController, HolbækDataProcessor);
        }

        [SetUp]
        public void SetUpStruerRepresentatives()
        {
            //Assign Struer
            StruerDataController.Name = "Joakim Von And";
            StruerDataController.Role = "Økonomichef";
            StruerDataController.PhoneNo = "77 90 20 45";
            StruerDataController.Mail = "jva@komune-struer.dk";

            StruerDataProcessor.Name = "Ole Olsen";
            StruerDataProcessor.Role = "Kontraktsansvarlig";
            StruerDataProcessor.PhoneNo = "45 56 77 78";
            StruerDataProcessor.Mail = "oox@kmd.dk";
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
            (NullableDataControllerRepresentative, NullableDataProcessorRepresentative) representativePair = FileScraper.ExtractDataProcessors(doc, representatives.Item2);

            Assert.That(representativePair.Item1.Name, Is.EqualTo(AalborgRepresentativePair.Item1.Name));
            Assert.That(representativePair.Item1.Role, Is.EqualTo(AalborgRepresentativePair.Item1.Role));
            Assert.That(representativePair.Item1.PhoneNo, Is.EqualTo(AalborgRepresentativePair.Item1.PhoneNo));
            Assert.That(representativePair.Item1.Mail, Is.EqualTo(AalborgRepresentativePair.Item1.Mail));

            Assert.That(representativePair.Item2.Name, Is.EqualTo(AalborgRepresentativePair.Item2.Name));
            Assert.That(representativePair.Item2.Role, Is.EqualTo(AalborgRepresentativePair.Item2.Role));
            Assert.That(representativePair.Item2.PhoneNo, Is.EqualTo(AalborgRepresentativePair.Item2.PhoneNo));
            Assert.That(representativePair.Item2.Mail, Is.EqualTo(AalborgRepresentativePair.Item2.Mail));

        }

        [Test]
        public void RepresentativesFromFaaborg()
        {
            string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string sFile = Path.Combine(sCurrentDirectory, @"..\..\..\PDFFiles\Faaborg-Midtfyn Kommune.pdf");
            string sFilePath = Path.GetFullPath(sFile);
            PdfDocument doc = PdfDocument.Open(sFilePath);
            (string, List<int>) representatives = FileScraper.GetSection(doc, "14. Ikrafttræden og ophør", "15. Kontaktpersoner hos den dataansvarlige og databehandleren");
            (NullableDataControllerRepresentative, NullableDataProcessorRepresentative) representativePair = FileScraper.ExtractDataProcessors(doc, representatives.Item2);

            Assert.That(representativePair.Item1.Name, Is.EqualTo(FaaborgRepresentativePair.Item1.Name));
            Assert.That(representativePair.Item1.Role, Is.EqualTo(FaaborgRepresentativePair.Item1.Role));
            Assert.That(representativePair.Item1.PhoneNo, Is.EqualTo(FaaborgRepresentativePair.Item1.PhoneNo));
            Assert.That(representativePair.Item1.Mail, Is.EqualTo(FaaborgRepresentativePair.Item1.Mail));

            Assert.That(representativePair.Item2.Name, Is.EqualTo(FaaborgRepresentativePair.Item2.Name));
            Assert.That(representativePair.Item2.Role, Is.EqualTo(FaaborgRepresentativePair.Item2.Role));
            Assert.That(representativePair.Item2.PhoneNo, Is.EqualTo(FaaborgRepresentativePair.Item2.PhoneNo));
            Assert.That(representativePair.Item2.Mail, Is.EqualTo(FaaborgRepresentativePair.Item2.Mail));

        }

        [Test]
        public void RepresentativesFromHerning()
        {
            string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string sFile = Path.Combine(sCurrentDirectory, @"..\..\..\PDFFiles\Herning Kommune.pdf");
            string sFilePath = Path.GetFullPath(sFile);
            PdfDocument doc = PdfDocument.Open(sFilePath);
            (string, List<int>) representatives = FileScraper.GetSection(doc, "14. Ikrafttræden og ophør", "15. Kontaktpersoner hos den dataansvarlige og databehandleren");
            (NullableDataControllerRepresentative, NullableDataProcessorRepresentative) representativePair = FileScraper.ExtractDataProcessors(doc, representatives.Item2);

            Assert.That(representativePair.Item1.Name, Is.EqualTo(HerningRepresentativePair.Item1.Name));
            Assert.That(representativePair.Item1.Role, Is.EqualTo(HerningRepresentativePair.Item1.Role));
            Assert.That(representativePair.Item1.PhoneNo, Is.EqualTo(HerningRepresentativePair.Item1.PhoneNo));
            Assert.That(representativePair.Item1.Mail, Is.EqualTo(HerningRepresentativePair.Item1.Mail));

            Assert.That(representativePair.Item2.Name, Is.EqualTo(HerningRepresentativePair.Item2.Name));
            Assert.That(representativePair.Item2.Role, Is.EqualTo(HerningRepresentativePair.Item2.Role));
            Assert.That(representativePair.Item2.PhoneNo, Is.EqualTo(HerningRepresentativePair.Item2.PhoneNo));
            Assert.That(representativePair.Item2.Mail, Is.EqualTo(HerningRepresentativePair.Item2.Mail));

        }

        [Test]
        public void RepresentativesFromHolbæk()
        {
            string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string sFile = Path.Combine(sCurrentDirectory, @"..\..\..\PDFFiles\Holbæk Kommune.pdf");
            string sFilePath = Path.GetFullPath(sFile);
            PdfDocument doc = PdfDocument.Open(sFilePath);
            (string, List<int>) representatives = FileScraper.GetSection(doc, "14. Ikrafttræden og ophør", "15. Kontaktpersoner hos den dataansvarlige og databehandleren");
            (NullableDataControllerRepresentative, NullableDataProcessorRepresentative) representativePair = FileScraper.ExtractDataProcessors(doc, representatives.Item2);

            Assert.That(representativePair.Item1.Name, Is.EqualTo(HolbækRepresentativePair.Item1.Name));
            Assert.That(representativePair.Item1.Role, Is.EqualTo(HolbækRepresentativePair.Item1.Role));
            Assert.That(representativePair.Item1.PhoneNo, Is.EqualTo(HolbækRepresentativePair.Item1.PhoneNo));
            Assert.That(representativePair.Item1.Mail, Is.EqualTo(HolbækRepresentativePair.Item1.Mail));

            Assert.That(representativePair.Item2.Name, Is.EqualTo(HolbækRepresentativePair.Item2.Name));
            Assert.That(representativePair.Item2.Role, Is.EqualTo(HolbækRepresentativePair.Item2.Role));
            Assert.That(representativePair.Item2.PhoneNo, Is.EqualTo(HolbækRepresentativePair.Item2.PhoneNo));
            Assert.That(representativePair.Item2.Mail, Is.EqualTo(HolbækRepresentativePair.Item2.Mail));

        }

        [Test]
        public void RepresentativesFromStruer()
        {
            string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string sFile = Path.Combine(sCurrentDirectory, @"..\..\..\PDFFiles\Struer Kommune.pdf");
            string sFilePath = Path.GetFullPath(sFile);
            PdfDocument doc = PdfDocument.Open(sFilePath);
            (string, List<int>) representatives = FileScraper.GetSection(doc, "14. Ikrafttræden og ophør", "15. Kontaktpersoner hos den dataansvarlige og databehandleren");
            (NullableDataControllerRepresentative, NullableDataProcessorRepresentative) representativePair = FileScraper.ExtractDataProcessors(doc, representatives.Item2);

            Assert.That(representativePair.Item1.Name, Is.EqualTo(StruerRepresentativePair.Item1.Name));
            Assert.That(representativePair.Item1.Role, Is.EqualTo(StruerRepresentativePair.Item1.Role));
            Assert.That(representativePair.Item1.PhoneNo, Is.EqualTo(StruerRepresentativePair.Item1.PhoneNo));
            Assert.That(representativePair.Item1.Mail, Is.EqualTo(StruerRepresentativePair.Item1.Mail));

            Assert.That(representativePair.Item2.Name, Is.EqualTo(StruerRepresentativePair.Item2.Name));
            Assert.That(representativePair.Item2.Role, Is.EqualTo(StruerRepresentativePair.Item2.Role));
            Assert.That(representativePair.Item2.PhoneNo, Is.EqualTo(StruerRepresentativePair.Item2.PhoneNo));
            Assert.That(representativePair.Item2.Mail, Is.EqualTo(StruerRepresentativePair.Item2.Mail));

        }




    }
}
