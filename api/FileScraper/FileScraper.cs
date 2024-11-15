﻿using Microsoft.AspNetCore.Mvc;
using UglyToad.PdfPig.DocumentLayoutAnalysis.PageSegmenter;
using UglyToad.PdfPig.DocumentLayoutAnalysis.ReadingOrderDetector;
using UglyToad.PdfPig.DocumentLayoutAnalysis.WordExtractor;
using UglyToad.PdfPig.DocumentLayoutAnalysis;
using UglyToad.PdfPig.Fonts.Standard14Fonts;
using UglyToad.PdfPig.Writer;
using UglyToad.PdfPig;

namespace api.FileScraper
{
    public static class FileScraper
    {
        // Structs for dataController and DataProcessors
        // Should prbably not be defined here, but for now yes
        #region
        public class SubProcessor
        {
            public string? name { get; set; }
            public string? CVR { get; set; }
            public string? Adress { get; set; }
            public string? Treatment { get; set; }
            public bool? directSubProcessor { get; set; }
            public string? transferReason { get; set; }

            public override string ToString()
            {
                return String.Format("name={0}\n\n\nCVR={1}\n\n\nAdress={2}\n\n\nTreatment={3}\n\n\nDirectSubProcessor={4}\n\n\nTransferReson={5}", this.name, this.CVR, this.Adress, this.Treatment, this.directSubProcessor, this.transferReason);
            }
        }

        public class DataController
        {
            public string? Name { get; set; }
            public string? Role { get; set; }
            public string? Phone { get; set; }
            public string? Email { get; set; }

            // Constructor for initialization
            public DataController(string? name = null, string? role = null, string? phone = null, string? email = null)
            {
                Name = name;
                Role = role;
                Phone = phone;
                Email = email;
            }
            public override string ToString()
            {
                return String.Format("name={0}\nrole={1}\nnumber={2}\nemail={3}\n", this.Name, this.Role, this.Phone, this.Email);
            }
        }

        public class DataProcessor
        {
            public string? Name { get; set; }
            public string? Role { get; set; }
            public string? Phone { get; set; }
            public string? Email { get; set; }

            // Constructor for initialization
            public DataProcessor(string? name = null, string? role = null, string? phone = null, string? email = null)
            {
                Name = name;
                Role = role;
                Phone = phone;
                Email = email;
            }
            public override string ToString()
            {
                return String.Format("name={0}\nrole={1}\nnumber={2}\nemail={3}\n", this.Name, this.Role, this.Phone, this.Email);
            }
        }
        #endregion

        public static PdfDocument OpenPDF( Stream fileData)
        {
            return PdfDocument.Open(fileData);
        }
        public static (String, List<int>) GetSection([FromBody] PdfDocument document, [FromQuery] string start, [FromQuery] string end)
        {
                bool foundSection = false;
                var builder = new PdfDocumentBuilder { };
                int pages = document.GetPages().Count();
                string result = "";
                List<int> pageIndexes = new List<int>();
                for (int i = 1; i <= pages; i++)
                {
                    PdfDocumentBuilder.AddedFont font = builder.AddStandard14Font(Standard14Font.Helvetica);
                    var pageBuilder = builder.AddPage(document, i);
                    pageBuilder.SetStrokeColor(0, 255, 0);
                    var page = document.GetPage(i);

                    var letters = page.Letters; // no preprocessing

                    // 1. Extract words
                    var wordExtractor = NearestNeighbourWordExtractor.Instance;

                    var words = wordExtractor.GetWords(letters);

                    // 2. Segment page
                    var pageSegmenter = DocstrumBoundingBoxes.Instance;

                    var textBlocks = pageSegmenter.GetBlocks(words);

                    // 3. Postprocessing
                    var readingOrder = UnsupervisedReadingOrderDetector.Instance;
                    var orderedTextBlocks = readingOrder.Get(textBlocks);

                    // 4. Add debug info - Bounding boxes and reading order
                    foreach (var block in orderedTextBlocks)
                    {


                        if (block.Text == start && !foundSection)
                        {

                            foundSection = true;
                        }
                        if (foundSection && block.Text == end)
                        {
                            foundSection = false;
                            if (!pageIndexes.Contains(i))
                                pageIndexes.Add(i);
                            break;
                        }
                        if (foundSection)
                        {
                            result += block.Text + "\n";
                        }

                    }
                    if (foundSection)
                    {
                        if (!pageIndexes.Contains(i))
                            pageIndexes.Add(i);

                    }


                }

                return (result, pageIndexes);
            

        }

        static bool NewValidateRowAlignment(List<TextBlock> list, ref int index, Dictionary<double, int> columnMap)
        {
                var columnXPositions = columnMap.Keys.ToList();
                int keyIndex = 0;
                int listIndex = index;

                while (keyIndex < 4)
                {
                    if (IsWithinColumn(list[listIndex], columnXPositions[keyIndex]))
                    {
                        listIndex++;
                    }
                    else if (IsWithinColumn(list[listIndex], columnXPositions[keyIndex + 1]))
                    {
                        keyIndex++;
                    }
                    else
                    {
                        return false;
                    }
                }

                return true;

        }

        //Is row major
       
        public static (Dictionary<(double, int), int>, Dictionary<double, int>) CreateTableIndices(PdfDocument document, List<int> pages)
        {
                Dictionary<double, int> columnMap = new Dictionary<double, int>();
                Dictionary<(double, int), int> RowMap = new Dictionary<(double, int), int>();

                foreach (var pageIndex in pages)
                {
                    // Get the page and extract letters
                    var page = document.GetPage(pageIndex);
                    var letters = page.Letters;

                    // 1. Extract words
                    var wordExtractor = NearestNeighbourWordExtractor.Instance;
                    var words = wordExtractor.GetWords(letters);

                    // 2. Segment page into text blocks
                    var pageSegmenter = DocstrumBoundingBoxes.Instance;
                    var textBlocks = pageSegmenter.GetBlocks(words);

                    // 3. Determine reading order of text blocks
                    var readingOrderDetector = UnsupervisedReadingOrderDetector.Instance;
                    var orderedTextBlocks = readingOrderDetector.Get(textBlocks).ToList();

                    // 4. Initialize table parsing
                    bool foundTable = false;

                    for (int i = 0; i < orderedTextBlocks.Count;)
                    {
                        var currentBlock = orderedTextBlocks[i];
                        double currentYPos = orderedTextBlocks[i].BoundingBox.TopLeft.Y;
                        bool[] checkedColumns = new bool[6];


                        // Check if table header is found (i.e., "NAVN" column)
                        if (currentBlock.Text.Contains("NAVN") && columnMap.Count == 0)
                        {
                            double[] positions = new double[6];
                            for (int j = 0; j < 6; j++)
                            {
                                positions[j] = orderedTextBlocks[i + j].BoundingBox.TopLeft.X;
                            }
                            Array.Sort(positions);
                            columnMap[positions[0]] = 0;
                            columnMap[positions[1]] = 1;
                            columnMap[positions[2]] = 2;
                            columnMap[positions[3]] = 3;
                            columnMap[positions[4]] = 4;
                            columnMap[positions[5]] = 5;
                            i += 6;
                            // Handle case where company name takes a full row
                            if (orderedTextBlocks[i].BoundingBox.TopLeft.Y > orderedTextBlocks[i + 1].BoundingBox.TopLeft.Y + 5)
                            {
                                i++;
                            }

                            foundTable = true;
                            continue;
                        }
                        else if (currentBlock.Text.Contains("NAVN") && columnMap.Count != 0)
                        {
                            i += 6;
                            // Handle case where company name takes a full row
                            if (orderedTextBlocks[i].BoundingBox.TopLeft.Y > orderedTextBlocks[i + 1].BoundingBox.TopLeft.Y + 5)
                            {
                                i++;
                            }
                            foundTable = true;
                            continue;
                        }
                        if (foundTable)
                        {
                            if (i + 1 < orderedTextBlocks.Count)
                            {
                                if (orderedTextBlocks[i].BoundingBox.TopLeft.Y > orderedTextBlocks[i + 1].BoundingBox.TopLeft.Y + 5)
                                {
                                    i++;
                                    continue;
                                }
                            }
                            else if (i == orderedTextBlocks.Count - 1)
                                break;
                            // If the y position is new and is whitin first column that is a new Y position to insert
                            if (!RowMap.ContainsKey((orderedTextBlocks[i].BoundingBox.TopLeft.Y, pageIndex)) && IsWithinColumn(orderedTextBlocks[i], columnMap.First().Key))
                            {
                                if (NewValidateRowAlignment(orderedTextBlocks, ref i, columnMap))
                                {
                                    RowMap[(orderedTextBlocks[i].BoundingBox.TopLeft.Y, pageIndex)] = RowMap.Count;
                                }
                                else
                                {
                                    RowMap[(orderedTextBlocks[i].BoundingBox.TopLeft.Y, pageIndex)] = RowMap.Count - 1;
                                }

                            }

                        }


                        i++;
                    }
                }
                return (RowMap, columnMap);
            
        }


        static public(DataController, DataProcessor) ExtractDataProcessors( PdfDocument document, List<int> pages)
        {
            
                DataController dataAnsvarlig = new DataController();
                DataProcessor dataBehandler = new DataProcessor();

                for (int i = 0; i < pages.Count; i++)
                {
                    var page = document.GetPage(pages[i]);
                    var letters = page.Letters;
                    var keywords = new HashSet<string> { "Navn", "Stilling", "Telefonnummer", "E-mail", "Underskrift" };
                    const double yTolerance = 0.5;

                    // Extract words
                    var wordExtractor = NearestNeighbourWordExtractor.Instance;
                    var words = wordExtractor.GetWords(letters);
                    bool isDataAnsvarlig = true;
                    bool isDataBehandlerComplete = false;

                    foreach (var word in words)
                    {

                        if (isDataBehandlerComplete) continue;

                        if (keywords.Contains(word.Text))
                        {
                            var wordsAtSameY = words
                                .Where(w => w != word && Math.Abs(w.BoundingBox.BottomLeft.Y - word.BoundingBox.BottomLeft.Y) <= yTolerance)
                                .Select(w => w.Text)
                                .ToList();

                            switch (word.Text)
                            {
                                case "Navn":
                                    if (isDataAnsvarlig)
                                    {
                                        dataAnsvarlig.Name = String.Join("", wordsAtSameY);
                                    }
                                    else
                                    {
                                        dataBehandler.Name = String.Join("", wordsAtSameY);
                                    }
                                    break;

                                case "Stilling":
                                    if (isDataAnsvarlig)
                                    {
                                        dataAnsvarlig.Role = String.Join("", wordsAtSameY);

                                    }
                                    else
                                    {
                                        dataBehandler.Role = String.Join("", wordsAtSameY);
                                    }
                                    break;

                                case "Telefonnummer":
                                    if (isDataAnsvarlig)
                                    {
                                        dataAnsvarlig.Phone = String.Join("", wordsAtSameY);
                                    }
                                    else
                                    {
                                        dataBehandler.Phone = String.Join("", wordsAtSameY);
                                    }
                                    break;

                                case "E-mail":
                                    if (isDataAnsvarlig)
                                    {
                                        dataAnsvarlig.Email = String.Join("", wordsAtSameY);
                                        isDataAnsvarlig = false;
                                    }
                                    else
                                    {
                                        dataBehandler.Email = String.Join("", wordsAtSameY);
                                        isDataBehandlerComplete = true;
                                    }
                                    break;
                            }
                        }
                    }
                }

                return (dataAnsvarlig, dataBehandler);
            

        }

        static bool IsWithinColumn(TextBlock block, double columnXPos) =>
            block.BoundingBox.TopLeft.X < columnXPos + 5 && block.BoundingBox.TopLeft.X > columnXPos - 5;

        static  (int?, int?) GetIndicesFromTextBlock(TextBlock block, (Dictionary<(double, int), int>, Dictionary<double, int>) tableindices, ref int y)
        {
            try
            {
                for (var i = y; i < tableindices.Item1.Keys.Count; i++)
                {
                    for (var k = 0; k < tableindices.Item2.Keys.Count; k++)
                    {
                        var rowKeys = tableindices.Item1.Keys.ToArray();
                        var columnKeys = tableindices.Item2.Keys.ToArray();
                        var rowValues = tableindices.Item1.Values.ToArray();
                        var columnValues = tableindices.Item2.Values.ToArray();
                        if (i == 0)
                        {
                            if (IsWithinColumn(block, columnKeys[k]) && block.BoundingBox.TopLeft.Y <= rowKeys[i].Item1 + 5 && block.BoundingBox.TopLeft.Y > rowKeys[i + 1].Item1)
                            {
                                y = i;
                                return (rowValues[i], columnValues[k]);
                            }

                        }
                        else if (i > 0 && i < tableindices.Item1.Keys.Count)
                        {
                            if (i == rowKeys.Length - 1)
                            {
                                if (IsWithinColumn(block, columnKeys[k]) && block.BoundingBox.TopLeft.Y <= rowKeys[i].Item1 + 5)
                                {
                                    y = i;
                                    return (rowValues[i], columnValues[k]);
                                }
                            }
                            else if (rowKeys[i].Item2 == rowKeys[i + 1].Item2)
                            {
                                if (IsWithinColumn(block, columnKeys[k]) && block.BoundingBox.TopLeft.Y <= rowKeys[i].Item1 + 5 && block.BoundingBox.TopLeft.Y > rowKeys[i + 1].Item1)
                                {
                                    y = i;
                                    return (rowValues[i], columnValues[k]);
                                }
                            }
                            else
                            {
                                if (IsWithinColumn(block, columnKeys[k]) && block.BoundingBox.TopLeft.Y <= rowKeys[i].Item1 + 5)
                                {
                                    y = i;
                                    return (rowValues[i], columnValues[k]);
                                }
                            }


                        }
                        else
                        {
                            if (IsWithinColumn(block, columnKeys[k]) && block.BoundingBox.TopLeft.Y < rowKeys[i].Item1)
                            {
                                y = i;
                                return (rowValues[i], columnValues[k]);
                            }
                        }
                    }
                }
                return (null, null);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get indices from textbox", ex);
            }

        }
        static public string[,] ExtractSubProcessors(
             PdfDocument document,
             List<int> pages,
             ValueTuple<Dictionary<ValueTuple<double, int>, int>, Dictionary<double, int>> tableIndices)
        {
            try
            {
                string[,] subProcessors = new string[tableIndices.Item1.Count, tableIndices.Item2.Count];
                int yPos = 0;
                foreach (var pageIndex in pages)
                {
                    // Get the page and extract letters
                    var page = document.GetPage(pageIndex);
                    var letters = page.Letters;

                    // 1. Extract words
                    var wordExtractor = NearestNeighbourWordExtractor.Instance;
                    var words = wordExtractor.GetWords(letters);

                    // 2. Segment page into text blocks
                    var pageSegmenter = DocstrumBoundingBoxes.Instance;
                    var textBlocks = pageSegmenter.GetBlocks(words);

                    // 3. Determine reading order of text blocks
                    var readingOrderDetector = UnsupervisedReadingOrderDetector.Instance;
                    var orderedTextBlocks = readingOrderDetector.Get(textBlocks).ToList();

                    // 4. Initialize table parsing
                    bool foundTable = false;

                    for (int i = 0; i < orderedTextBlocks.Count;)
                    {
                        var currentBlock = orderedTextBlocks[i];

                        // Check if table header is found (i.e., "NAVN" column)
                        if (currentBlock.Text.Contains("NAVN"))
                        {
                            i += 6;

                            // Handle case where company name takes a full row
                            if (orderedTextBlocks[i].BoundingBox.TopLeft.Y > orderedTextBlocks[i + 1].BoundingBox.TopLeft.Y + 5)
                            {
                                i++;
                            }
                            while (!IsWithinColumn(orderedTextBlocks[i], tableIndices.Item2.First().Key))
                            {
                                foreach (var (xpos, xIndex) in tableIndices.Item2)
                                {
                                    if (IsWithinColumn(orderedTextBlocks[i], xpos))
                                    {
                                        subProcessors[yPos, xIndex] += "\n" + orderedTextBlocks[i].Text;
                                    }
                                }

                                i++;
                            }

                            foundTable = true;
                            continue;
                        }

                        if (foundTable)
                        {
                            if (i + 1 < orderedTextBlocks.Count)
                            {
                                if (IsWithinColumn(orderedTextBlocks[i], tableIndices.Item2.Keys.First()) && orderedTextBlocks[i].BoundingBox.TopLeft.Y > orderedTextBlocks[i + 1].BoundingBox.TopLeft.Y + 5)
                                {
                                    i++;
                                    continue;
                                }
                            }
                            // If the y position is new and is whitin first column that is a new Y position to insert

                            (int?, int?) indices = GetIndicesFromTextBlock(orderedTextBlocks[i], tableIndices, ref yPos);
                            if (indices.Item1 != null && indices.Item2 != null)
                                subProcessors[(int)indices.Item1, (int)indices.Item2] += orderedTextBlocks[i].Text;
                        }


                        i++;
                    }
                }

                return subProcessors;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to extract subprocessors", ex);
            }

        }
        static public IEnumerable<SubProcessor>? CreateSubProcessorList(List<List<String>> data)
        {
            List<SubProcessor>? result = new List<SubProcessor>();

            foreach (List<string> row in data)
            {
                // This value should never be null so row is empty
                if (row[0] == null)
                    continue;


                SubProcessor subProcessor = new SubProcessor();
                subProcessor.name = row[0];
                subProcessor.CVR = row[1];
                subProcessor.Adress = row[2];
                subProcessor.Treatment = row[3];
                subProcessor.directSubProcessor = row[4] == "Ja" ? true : false;
                subProcessor.transferReason = row[5] == null ? "N/A" : row[5];
                result.Add(subProcessor);
            }

            return result;
        }
    }
}
