using NUnit.Framework;
using api.FileScraper;
using UglyToad.PdfPig;
namespace KMD_API_Test
{
    public class PDFScraperTests
    {
        // Aalborg data expected
        FileScraper.DataController AalborgDataController = new FileScraper.DataController();
        FileScraper.DataProcessor AalborgDataProcessor = new FileScraper.DataProcessor();
        (FileScraper.DataController, FileScraper.DataProcessor) AalborgRepresentativePair;

        List<List<String>> AalborgSubprocessors = new List<List<string>>();

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

        List<List<String>> StruerSubprocessors = new List<List<string>>();

        [SetUp]
        public void SetUp()
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

            string[] row1 = { "UVdata A/S", "27988954", "Lauritzens\nPlads 1,\n9000 Aal-\nborg, Dan-\nmark", "Vedligehold,\nforbedringer, driftog\ndriftsrelaterede\nydelser", "Ja", "N/A" };
            string[] row2 = { "KMD Polen Sp z o.o.", "KRS 516 792\n(datterskab\nselskab,\nPolsk\nregistreret)", "Gdanski\nBusiness\nCenter\nInflancka\n4A, Building\nA,\n4th floor\n00-189 War-saw\nPoland", "Softwareudvikling\nog\nvedligeholdelse.", "Ja", "N/A" };
            string[] row3 = { "Microsoft\nCorporation\nmed tilhørende\nunderdatabehandlere", "911144442", "One Mi-\ncrosoft way\nRedmond,\nWA 98062-\n6399 USA", "Drifts-relaterede\nydelser", "Nej", "EU-Kommissionens\nstandardkontraktbestemmelser." };
            string[] row4 = { "Microsoft Ireland\nOperations Limited", "IE8256796U", "One Mi-\ncrosoft\nPlace, South\nCounty In-\ndustrial Park,\nLeopard-\nstown, Dub-\nlin 18, D18\nP521", "Drift og\ndriftsrelaterede\nydelser", "Ja", "N/A" };
            string[] row5 = { "ZenDesk Inc.\nmed tilhørende\nunderdatabehandlere,\njf. nedenfor underafsnittet, Anvendte\nunderdatabehandlere\nmed særlige vilkår", "U.S. corpora-\ntion formed\nunder the\nlaws of theState of Del-aware", "1019 Market\nStreet, San\nFrancisco,CA 94103\nUSA", "Service desk\nservices.", "Ja", "EU-U.S. Data Privacy Frame-\nwork" };
            string[] row6 = { "InLogic A/S", "Silkeborgvej\n140\n8700 Hor-sens", "CVR:\nDK33583605", "Drifts-relaterede\nydelser", "Ja", "N/A" };
            AalborgSubprocessors.Add(row1.ToList());
            AalborgSubprocessors.Add(row2.ToList());
            AalborgSubprocessors.Add(row3.ToList());
            AalborgSubprocessors.Add(row4.ToList());
            AalborgSubprocessors.Add(row5.ToList());
            AalborgSubprocessors.Add(row6.ToList());

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

            //Assign Herning
            HerningDataController.Name = "Andersine And";
            HerningDataController.Role = "Kontraktansvarlig";
            HerningDataController.Phone = "67 65 34 45";
            HerningDataController.Email = "indkøb@herningkommune.dk";
            
            HerningDataProcessor.Name = "Ole Olsen";
            HerningDataProcessor.Role = "Kontraktsansvarlig";
            HerningDataProcessor.Phone = "45 56 77 78";
            HerningDataProcessor.Email = "oox@kmd.dk";
            HerningRepresentativePair = (HerningDataController, HerningDataProcessor);

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

            string[] arow1 = { "KMD\nPoland\nSp z o.o.", "KRS 516 792\n(datterselskab, polsk\nregistreret)", "Gdanski\nBusiness\nCenter\nInflancka 4A,\nBuilding A,\nth\n4 floor\n00-189\nWarsaw\nPolen", "Softwareudviklingog\nvedligeholdelse.\nKunde- og\ndriftssupport.", "Ja", "N/A" };
            string[] arow2 = { "Kyndryl Danmark\nAps", "CVR 41988169", "Prøvensvej\n1, 2605\nBrøndby,\nDanmark", "IT-drift herun-der\nDataopbe-varing,\nSystem-\n,Applications-\n/Database- og\nNet-værksdrift\nsamt relaterede\nydelser.", "Ja", "N/A" };
            string[] arow3 = { "IBM Danmark ApS", "CVR 65305216", "Prøvensvej\n1, 2605\nBrøndby,\nDanmark", "IT-drift herun-der\nDataopbe-varing,\nSystem-\n,Applications-\n/Data-base- og\nNet-værks-drift\nsamt relate-rede\nydelser.", "Nej", "N/A" };
            string[] arow4 = { "Kyndryl Bulgaria\nEOOD [“Киндрил\nБългария” ЕООД]", "Unified Identi-fication Code:\n206442397", "36.Dragan\nTzankov Str.\nZip Code\n1040, Sofia,\nBulgarien", "Administrativ\nsupport, Pro-\njektledelse og\nrelaterede\nydelser.", "Nej", "N/A" };
            string[] arow5 = { "Kyndryl Deutschland\nGmbH", "Registered with the com-\nmercial register of the Local\nCourt of Stuttgart under:\nHRB 775131", "IBM-Allee 1\nD-71139 Eh-\nningen\nTyskland", "Dataopbevaring\nog relate-rede\nydelser.", "Nej", "N/A" };
            string[] arow6 = { "Kyndryl France\nS.A.S.", "Registered with the\ncommerical register (Imma-\ntriculation au Registre du\nCommerce et des Sociétés\nNanterre) un-der: 894 880\n194", "17 avenue\nde l'Europe\n92275 Bois-\nColombes\nCedex,\nFrank-rig", "Bruger ID sup-\nport og relate-\nrede ydelser.", "Nej", "N/A" };
            string[] row7 = { "Kyndryl Hungary Kft.\n[Kyndryl Hungary\nKorlátolt Felelős-\nségű Társaság]", "Registration number: Cg.\n07-09-031714", "Gabor\nDenes Utca\n2, Info-park\nD, Buda-\npest, 1117\nUngarn", "IT-drift af bl.a.\nKMD Main-frame\nog Mi-drange\nservices,\nitværktøjssupport\nog relaterede\nydelser.", "Nej", "N/A" };
            string[] row8 = { "Kyndryl Global\nServices Delivery\nCentre Polska Sp.\nZ.o.o.", "Register of entrepreneurs\nof the National Court Regis-\nter (KRS) registra-tion num-\nber: 0000333717", "ul. Krako-\nwiaków 32,\n02-255 War-\nszawa, Po-\nlen", "Service mana-\ngement samt IT-\ndrift og relaterede\nydelser.", "Nej", "N/A" };
            string[] row9 = { "Kyndryl Services\nSlovensko, spol. s\nr.o.", "Identification Number: 53\n613 244", "Krasovského\n14\nBratislava,\n85101,\nSlova-kiet", "Asset\nmanagement og\nrelaterede\nydelser", "Nej", "N/A" };
            string[] row10 = { "Kyndryl Ireland Limi-\nted", "Company Number: 668675", "IBM Techno-\nlogy Cam-\npus, Building\n5, Damas-\ntown Indus-\ntrial Park,\nMulhuddart,\nDublin 15, Ir-\nland", "Service Desk\nservices og\nrelaterede\nydelser.", "Nej", "N/A" };
            string[] row11 = { "Kyndryl Nederland\nB.V.", "KVK (CCI) number:\n81589689", "Johan\nHuizin-\ngalaan 765,\nAmsterdam\n1066VH,\nHol-land", "SIAM,leveran-\ndørstyring og\nrelaterede\nydelser.", "Nej", "N/A" };
            string[] row12 = { "IBM România S.R.L", "RO378660 RC\nJ/40/5106/1991", "Şos. Orhi-\ndee-lor 15D\nBuilding A -\nThe Bridge,\n5th floor\n060071,\nSec-tor 6,\nBu-cureşti,\nRu-mænien", "It-, Applikations\nog Data-\nbasedrift,\nAdgangsstyring\nsamt relaterede\nydelser.", "Nej", "N/A" };
            string[] row13 = { "IBM, SoftLayer Tech-\nnologies Netherlands\nBV", "52461041", "Amsterdam,\nThe Nether-\nlands -\nAMS03\nKPN Tele-\ncommunica-\ntions\nKPN Cyber-\nCenter Ron-\ndebeltweg\n62, Almere,\n1329BG", "Dataopbevaring\nog relaterede\nydelser.", "Nej", "N/A" };
            string[] row14 = { "IBM, SoftLayer Tech-\nnologies Deutsch-\nland GmbH", "HRB 99938", "Leonhard -\nHeisswolf\nStr 4.,\nFrankfurt am\nMain, 65936\nTyskland", "Dataopbevaring\nog relaterede\nydelser.", "Nej", "N/A" };
            string[] row15 = { "Kyndryl Client Cen-\nter, s.r.o.", "Registration Number: 262\n44 535", "The Park, V\nParku\n2294/4,\nBuilding 2/4,\n14800\nPraha, Tjek-\nkiet", "Asset\nManagement,\ndataopbevaring,\nog relaterede\nydelser.", "Nej", "N/A" };
            string[] row16 = { "IBM Lietuva, UAB", "Company Code -\n111620231 VAT Number -\nLT116202314", "Šeimyniškių\n3 LT-09312\nVil-nius\nLitauen", "Sikkerheds-\nincident-\nservices/ydelser\nog relaterede\nydelser.", "Nej", "N/A" };
            string[] row17 = { "IBM Slovensko, spol.\ns r.o. / IBM Slo-vakia\nLtd.Microsoft", "31337147", "Krasovského\n14, 851 01\nBratislava,\nSlovakiet", "Applikations-\nudvikling og\nprojektarbejde", "Nej", "N/A" };
            string[] row18 = { "Microsoft\nCorporation\nmed tilhørende\nunderdatabehandlere", "911144442", "One Mi-\ncrosoft way\nRedmond,\nWA 98062-\n6399 USA", "Driftsrelaterede\nydelser", "Nej", "EU-Kommissionens\nstandardkontraktbestemmelser." };
            string[] row19 = { "Microsoft Ireland\nOperations Limited", "IE8256796U", "One Mi-\ncrosoft\nPlace, South\nCounty In-\ndustrial\nPark,\nLeopard-\nstown, Dub-\nlin 18, D18\nP521", "Drift og\ndriftsrelaterede\nydelser", "Ja", "N/A" };
            string[] row20 = { "UVdata A/S", "27988954", "Lauritzens\nPlads 1,\n9000\nAalborg,\nDanmark", "Vedligehold,\nforbedringer, drift\nog drift relaterede\nydelser", "Ja", "N/A" };
            string[] row21 = { "Future Processing\nsp. Z o.o", "0000217147", "NIP (tax ID):\n634-25-32-\n128,\nBojkowska\n37A, 44 -\n100 Gliwice,\nPolen", "Drift og drift\nrelaterede\nydelser", "Ja", "N/A" };
            string[] row22 = { "ServiceNow\nNederland B.V.", "53045998", "Hoekenrode\n3\nAmsterdam\n1102 BR,\nNetherlands", "Dataopbevaring\nSystem-,\napplikation- og\ndatabasedrift\nAdministrativ\nsupport og\nydelser", "Ja", "N/A" };
            string[] row23 = { "ServiceNow, Inc.", "202056195", "2225 Law-\nson Lane\nSanta Clara,\nCA 95054,\nUnited\nStates", "Dataopbevaring\nSystem-,\napplikation- og\ndatabasedrift\nAdministrativ\nsupport og\nydelser", "Nej", "EU Kommissionens\nstandardkontraktbestemmelser\naf 4. juni 2021 (modul 3,\ndatabehandler til\ndatabehandler)\nServiceNow er ligeledes\ncertificeret under EU-U.S. Data\nPrivacy Framework og kan\nfindes på den officielle \"Data\nPrivacy Framework List\"." };
            string[] row24 = { "ServiceNow Australia\nPty Ltd", "149683312", "L 48 680\nGeorge St\nSydney,\nNEW\nSOUTH\nWALES,\n2000 Aus-\ntralia", "Dataopbevaring\nSystem-,\napplikation- og\ndatabasedrift\nAdministrativ\nsupport og\nydelser", "Nej", "EU Kommissionens\nstandardkontraktbestemmelser\naf 4. juni 2021 (modul 3,\ndatabehandler til\ndatabehandler)" };
            string[] row25 = { "ServiceNow Soft-\nware Development\nIndia Private Limited", "U72900TG2014FTC092163", "Knowledge\nCity, 7th\nFloor, Plot\nNo 2, Phase\n1, Survey\nNo.83/1,\nRaidurg Vil-\nlage, Serilin-\ngampally\nHyderabad\nRangareddi\nTG 500081,\nIndia", "Dataopbevaring\nSystem-,\napplikation- og\ndatabasedrift\nAdministrativ\nsupport og\nydelser", "Nej", "EU Kommissionens\nstandardkontraktbestemmelser\naf 4. juni 2021 (modul 3,\ndatabehandler til\ndatabehandler)" };
            string[] row26 = { "ServiceNow UK Ltd.", "06299383", "Strata Build-\ning, 1 Bridge\nStreet,\nStaines,\nUnited King-\ndom, TW18\n4TW, United\nKingdom", "Dataopbevaring\nSystem-,\napplikation- og\ndatabasedrift\nAdministrativ\nsupport og\nydelser", "Nej", "EU-Kommissionen har 28. juni\n2021 godkendt Storbritannien\nsom et sikkert tredjeland,\nhvorfor overførelsesgrundlag\nikke er påkrævet." };
            string[] row27 = { "ServiceNow Ireland\nLimited", "549967", "1st Floor the\nSharp Build-\ning, 10-12\nHogan Place\nDublin 2,\nDublin 2,\nDublin, Ire-\nland", "Dataopbevaring\nSystem-,\napplikation- og\ndatabasedrift\nAdministrativ\nsupport og\nydelser", "Nej", "N/A" };
            string[] row28 = { "ServiceNow Japan\nG.K.", "5493004JMEIL23HMP379", "Ark Mori\nBuilding,\n35th/32nd\nFloor, 107-\n0052, Minato\nku, P-13, Ja-pan", "Dataopbevaring\nSystem-,\napplikation- og\ndatabasedrift\nAdministrativ\nsupport og\nydelser", "Nej", "ServiceNow Japan G.K falder\nunder den Japanske Act on the\nprotection of personal data\n(APPI)ServiceNow Japan G.K er\nligeledes en del af\nServiceNows Intra-Group Data\nprocessing and transfer\nagreement, som inkorporerer\nEU Kommissionens\nstandardkontraktbestemmelser\naf 4. juni 2021 (modul 3,\ndatabehandler til\ndatabehandler)" };

            StruerSubprocessors.Add(arow1.ToList());
            StruerSubprocessors.Add(arow2.ToList());
            StruerSubprocessors.Add(arow3.ToList());
            StruerSubprocessors.Add(arow4.ToList());
            StruerSubprocessors.Add(arow5.ToList());
            StruerSubprocessors.Add(arow6.ToList());
            StruerSubprocessors.Add(row7.ToList());
            StruerSubprocessors.Add(row8.ToList());
            StruerSubprocessors.Add(row9.ToList());
            StruerSubprocessors.Add(row10.ToList());
            StruerSubprocessors.Add(row11.ToList());
            StruerSubprocessors.Add(row12.ToList());
            StruerSubprocessors.Add(row13.ToList());
            StruerSubprocessors.Add(row14.ToList());
            StruerSubprocessors.Add(row15.ToList());
            StruerSubprocessors.Add(row16.ToList());
            StruerSubprocessors.Add(row17.ToList());
            StruerSubprocessors.Add(row18.ToList());
            StruerSubprocessors.Add(row19.ToList());
            StruerSubprocessors.Add(row20.ToList());
            StruerSubprocessors.Add(row21.ToList());
            StruerSubprocessors.Add(row22.ToList());
            StruerSubprocessors.Add(row23.ToList());
            StruerSubprocessors.Add(row24.ToList());
            StruerSubprocessors.Add(row25.ToList());
            StruerSubprocessors.Add(row26.ToList());
            StruerSubprocessors.Add(row27.ToList());
            StruerSubprocessors.Add(row28.ToList());
        }

        [Test]
        public void RepresentativesFromAalborg()
        {
            string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string sFile = System.IO.Path.Combine(sCurrentDirectory, @"..\..\..\PDFFiles\Aalborg Kommune.pdf");
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
            string sFile = System.IO.Path.Combine(sCurrentDirectory, @"..\..\..\PDFFiles\Faaborg-Midtfyn Kommune.pdf");
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
            string sFile = System.IO.Path.Combine(sCurrentDirectory, @"..\..\..\PDFFiles\Herning Kommune.pdf");
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
            string sFile = System.IO.Path.Combine(sCurrentDirectory, @"..\..\..\PDFFiles\Holbæk Kommune.pdf");
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
            string sFile = System.IO.Path.Combine(sCurrentDirectory, @"..\..\..\PDFFiles\Struer Kommune.pdf");
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

        [Test]
        public void SubproccessorsFromAalborg()
        {
            string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string sFile = System.IO.Path.Combine(sCurrentDirectory, @"..\..\..\PDFFiles\Aalborg Kommune.pdf");
            string sFilePath = Path.GetFullPath(sFile);
            PdfDocument doc = PdfDocument.Open(sFilePath);
            (string, List<int>) SubProcessorSection = FileScraper.GetSection(doc, "B.1. Godkendte underdatabehandlere", "B.2.");

            (Dictionary<(double, int), int>, Dictionary<double, int>) tableIndices = FileScraper.CreateTableIndices(doc, SubProcessorSection.Item2);
            string[,] SubProcessorData = FileScraper.ExtractSubProcessors(doc, SubProcessorSection.Item2, tableIndices);
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
            IEnumerable<FileScraper.SubProcessor>? verifiedSubProcessors = FileScraper.CreateSubProcessorList(list);
            IEnumerable<FileScraper.SubProcessor>? verifiedSubProcessorsFromExpected = FileScraper.CreateSubProcessorList(AalborgSubprocessors);

            for (int i = 0; i < verifiedSubProcessorsFromExpected.Count(); i++)
            {
                Assert.That(verifiedSubProcessors.ElementAt(i).name, Is.EqualTo(verifiedSubProcessorsFromExpected.ElementAt(i).name));
                Assert.That(verifiedSubProcessors.ElementAt(i).CVR, Is.EqualTo(verifiedSubProcessorsFromExpected.ElementAt(i).CVR));
                Assert.That(verifiedSubProcessors.ElementAt(i).Adress, Is.EqualTo(verifiedSubProcessorsFromExpected.ElementAt(i).Adress));
                Assert.That(verifiedSubProcessors.ElementAt(i).Treatment, Is.EqualTo(verifiedSubProcessorsFromExpected.ElementAt(i).Treatment));
                Assert.That(verifiedSubProcessors.ElementAt(i).directSubProcessor, Is.EqualTo(verifiedSubProcessorsFromExpected.ElementAt(i).directSubProcessor));
                Assert.That(verifiedSubProcessors.ElementAt(i).transferReason, Is.EqualTo(verifiedSubProcessorsFromExpected.ElementAt(i).transferReason));
            }
        }

        [Test]
        public void SubproccessorsFromStruer()
        {
            string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string sFile = System.IO.Path.Combine(sCurrentDirectory, @"..\..\..\PDFFiles\Struer Kommune.pdf");
            string sFilePath = Path.GetFullPath(sFile);
            PdfDocument doc = PdfDocument.Open(sFilePath);
            (string, List<int>) SubProcessorSection = FileScraper.GetSection(doc, "B.1. Godkendte underdatabehandlere", "B.2.");

            (Dictionary<(double, int), int>, Dictionary<double, int>) tableIndices = FileScraper.CreateTableIndices(doc, SubProcessorSection.Item2);
            string[,] SubProcessorData = FileScraper.ExtractSubProcessors(doc, SubProcessorSection.Item2, tableIndices);
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
            IEnumerable<FileScraper.SubProcessor>? verifiedSubProcessors = FileScraper.CreateSubProcessorList(list);
            IEnumerable<FileScraper.SubProcessor>? verifiedSubProcessorsFromExpected = FileScraper.CreateSubProcessorList(StruerSubprocessors);

            for (int i = 0; i < verifiedSubProcessorsFromExpected.Count(); i++)
            {
                Assert.That(verifiedSubProcessors.ElementAt(i).name, Is.EqualTo(verifiedSubProcessorsFromExpected.ElementAt(i).name));
                Assert.That(verifiedSubProcessors.ElementAt(i).CVR, Is.EqualTo(verifiedSubProcessorsFromExpected.ElementAt(i).CVR));
                Assert.That(verifiedSubProcessors.ElementAt(i).Adress, Is.EqualTo(verifiedSubProcessorsFromExpected.ElementAt(i).Adress));
                Assert.That(verifiedSubProcessors.ElementAt(i).Treatment, Is.EqualTo(verifiedSubProcessorsFromExpected.ElementAt(i).Treatment));
                Assert.That(verifiedSubProcessors.ElementAt(i).directSubProcessor, Is.EqualTo(verifiedSubProcessorsFromExpected.ElementAt(i).directSubProcessor));
                Assert.That(verifiedSubProcessors.ElementAt(i).transferReason, Is.EqualTo(verifiedSubProcessorsFromExpected.ElementAt(i).transferReason));
            }
        }
    }
}
