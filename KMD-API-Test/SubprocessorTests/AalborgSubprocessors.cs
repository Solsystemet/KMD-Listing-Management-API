using api.FileScraper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UglyToad.PdfPig;

namespace KMD_API_Test.SubprocessorTests
{
    public class AalborgSubprocessors
    {
        List<List<string>> AalborgSubprocessorsList = new List<List<string>>();

        [SetUp]
        public void SetUpAalborgSubprocessors()
        {
            string[] row1 = { "UVdata A/S", "27988954", "Lauritzens\nPlads 1,\n9000 Aal-\nborg, Dan-\nmark", "Vedligehold,\nforbedringer, driftog\ndriftsrelaterede\nydelser", "Ja", "N/A" };
            string[] row2 = { "KMD Polen Sp z o.o.", "KRS 516 792\n(datterskab\nselskab,\nPolsk\nregistreret)", "Gdanski\nBusiness\nCenter\nInflancka\n4A, Building\nA,\n4th floor\n00-189 War-saw\nPoland", "Softwareudvikling\nog\nvedligeholdelse.", "Ja", "N/A" };
            string[] row3 = { "Microsoft\nCorporation\nmed tilhørende\nunderdatabehandlere", "911144442", "One Mi-\ncrosoft way\nRedmond,\nWA 98062-\n6399 USA", "Drifts-relaterede\nydelser", "Nej", "EU-Kommissionens\nstandardkontraktbestemmelser." };
            string[] row4 = { "Microsoft Ireland\nOperations Limited", "IE8256796U", "One Mi-\ncrosoft\nPlace, South\nCounty In-\ndustrial Park,\nLeopard-\nstown, Dub-\nlin 18, D18\nP521", "Drift og\ndriftsrelaterede\nydelser", "Ja", "N/A" };
            string[] row5 = { "ZenDesk Inc.\nmed tilhørende\nunderdatabehandlere,\njf. nedenfor underafsnittet, Anvendte\nunderdatabehandlere\nmed særlige vilkår", "U.S. corpora-\ntion formed\nunder the\nlaws of theState of Del-aware", "1019 Market\nStreet, San\nFrancisco,CA 94103\nUSA", "Service desk\nservices.", "Ja", "EU-U.S. Data Privacy Frame-\nwork" };
            string[] row6 = { "InLogic A/S", "Silkeborgvej\n140\n8700 Hor-sens", "CVR:\nDK33583605", "Drifts-relaterede\nydelser", "Ja", "N/A" };
            AalborgSubprocessorsList.Add(row1.ToList());
            AalborgSubprocessorsList.Add(row2.ToList());
            AalborgSubprocessorsList.Add(row3.ToList());
            AalborgSubprocessorsList.Add(row4.ToList());
            AalborgSubprocessorsList.Add(row5.ToList());
            AalborgSubprocessorsList.Add(row6.ToList());
        }

        [Test]
        public void SubproccessorsFromAalborg()
        {
            string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string sFile = Path.Combine(sCurrentDirectory, @"..\..\..\PDFFiles\Aalborg Kommune.pdf");
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
            IEnumerable<FileScraper.SubProcessor>? verifiedSubProcessorsFromExpected = FileScraper.CreateSubProcessorList(AalborgSubprocessorsList);

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
