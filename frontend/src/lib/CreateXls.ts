import {
    downloadTableAsExcel,
    tableToFile,
  } from 'https://cdn.jsdelivr.net/npm/html-table-to-excel.ts@1/esm.js' //for some reason doesnt work when downloaded so doin this, idk y,,,
import { getAllListings, getListingById } from "./api";
import { useQuery } from "@tanstack/react-query";
import QueryObject from "../types/QueryObject";
import {QueryClient} from "../main" 

// This function creates a temporary html document containing a table which will be converted to 
// an xls (excel) file. The function constructs a static setup but appends information dynamically below
// where each row will contain listinf information from a single listing. 
const staticInformation = [
    ["Name & contact details of the data processor:", "UVDATA A/S"],
    ["Contact details of data processor:", "Lauritzens Plads 1, 9000 Aalborg, Denmark, Phone: 45 44 60 66 29"],
    ["Name & contact details of the DPO:", "Julie de Linde, Data Protection Officer, Privacy@KMD.dk"],
    ["Name of the resposible SBU: ", "KMD Essentials"],
    ["Name of the resposible BU: ", "UVDATA"],
    ["Record last updated by (initials, date):", ``]
]

const listingHeaders = [
    [
        {
            text: 'Solution',
        },{
            text: 'Data Controller',
            colSpan: '2',
        },{
            text: 'Processing Activity',
        },{
            text: 'Sub-Processors',
            colSpan: '11',
        },{
            text: 'Third Countries',
            colSpan: '2'
        },
    ],[
        {
            text: '(Name of the soution)',
            rowSpan: '2'
        },{
            text: '(Full name of the customer who is the data controller)',
            rowSpan: '2'
        },{
            text: '(Name, mail, telephone)',
            rowSpan: '2'
        },{
            text: 'Categories of processing activities ',
            rowSpan: '2'
        },{
            text: 'Sub-processors /n(Mark with an X the sub-processors being used and/or fill in full name of the sub-processors not mentioned in the list)',
            colSpan: '11'
        },{
            text: 'Third country transfers /n(Yes/No)',
            rowSpan: '2'
        },{
            text: 'Third countries /n(Insert link to TIA or list the relevant countries to which personal data may be transferred)',            rowSpan: '2'
        }
    ],[
          {text: 'Aeven'
        },{text: 'T-systems'
        },{text: 'Microsoft'
        },{text: 'ServiceNow'
        },{text: 'UVdata'
        },{text: 'ZenDesk Inc.'
        },{text: 'KMD Poland'
        },{text: 'Pathfindr'
        },{text: 'InLogic'
        },{text: 'Other /n(insert fullname of other sub-processors)'
        },{text: 'Changes of sub-processors/n(Indsigelse/Samtykke)'
}]]

export async function createXlsFile() {
    //create doc
    const doc = document.implementation.createHTMLDocument('temporary Document');

    const HTMLBody = doc.body;
    const HTMLTable = doc.createElement('table');
    HTMLTable.appendChild(document.createElement('tr')); //Spacing row
    HTMLTable.style.borderCollapse = 'collapse'; //formatting to merge cell borders

    //Use helper function to format static information
    staticInformation.forEach(rowData => {      // kmd info, taken from the staticInformation arr
        
        let newRow = document.createElement('tr');
        newRow.appendChild(createNormalCell('')); //Spacing cell

        newRow.appendChild(createHeaderCell(rowData[0], '2'));
        newRow.appendChild(createNormalCell(rowData[1], '2'));
        HTMLTable.appendChild(newRow);
    });
    HTMLTable.appendChild(document.createElement('tr')); //Spacing row
    listingHeaders.forEach(headerRow => {       // headers for listing data, taken from listingHeaders
        HTMLTable.appendChild(createHeaderRow(headerRow));
    })

    const allListingQuery: QueryObject = {
        isDescending: true,
        pageNumber: 1,
        pageSize: 10000,    //arbetrary
    };

    const allListings = await getAllListings(allListingQuery);

// Use a for of loop through all listings to append a row for each
for (const listing of allListings) {
    // Await the result of getListingById for each listing
    const currListing = await getListingById(listing.Id);
    
    // Create a new row
    const newRow = document.createElement('tr');
    
    // Use template literals or string concatenation for the cells
    newRow.appendChild(createNormalCell('')); //Spacing cell
    newRow.appendChild(createNormalCell(currListing?.solution ?? 'N/A'));
    newRow.appendChild(createNormalCell(currListing?.dataController?.name ?? 'N/A'));
    newRow.appendChild(createNormalCell(
        `${currListing?.dataController?.address ?? 'N/A'}, ${currListing?.dataController?.mail ?? 'N/A'}, ${currListing?.dataController?.phoneNo ?? 'N/A'}`
    ));
    newRow.appendChild(createNormalCell(currListing?.dataCategories.categoryList ?? 'N/A'));

    const subProcessors = createSubProcessorChecklist(currListing);
    newRow.appendChild(createNormalCell(subProcessors.Aeven));
    newRow.appendChild(createNormalCell(subProcessors.Tsystems));
    newRow.appendChild(createNormalCell(subProcessors.Microsoft));
    newRow.appendChild(createNormalCell(subProcessors.ServiceNow));
    newRow.appendChild(createNormalCell(subProcessors.UVdata));
    newRow.appendChild(createNormalCell(subProcessors.ZenDesk));
    newRow.appendChild(createNormalCell(subProcessors.KMDPoland));
    newRow.appendChild(createNormalCell(subProcessors.Pathfindr));
    newRow.appendChild(createNormalCell(subProcessors.InLogic));
    newRow.appendChild(createNormalCell(subProcessors.Other));
    newRow.appendChild(createNormalCell('')); //ngl not sure what changes in subprocessors means *exactly* and its too late to deep dive rn so blank and possible to type manually if needed
    newRow.appendChild(createNormalCell('')); // y/n if third country transfer, not implemented
    newRow.appendChild(createNormalCell('')); // list of relevant third countries ^^
    
    // Append the new row to the table
    HTMLTable.appendChild(newRow);
}
    // Convert the table to an Excel file
    const excelFile = tableToFile(HTMLTable, 'Listings.xls');
    // Trigger download of the Excel file
    //const link = document.createElement('a');
    //link.href = URL.createObjectURL(excelFile);
    //link.download = 'Listings.xls';
    //link.click();

    return excelFile;
    
}

//Helper function to create a row
function createHeaderRow(row) {
    const headerRow = document.createElement('tr');
    headerRow.appendChild(createNormalCell('')); //Spacing cell

    row.forEach(rowCell =>{
        headerRow.appendChild(createHeaderCell(rowCell.text, rowCell.colSpan, rowCell.rowSpan));
    })

    return headerRow;
}


//helper function to create checklist of sub processors
// Helper function to create checklist of sub-processors
function createSubProcessorChecklist(listingData) {
    // By default, empty, if true, place an 'X'
    let Aeven = '';
    let Tsystems = '';
    let Microsoft = '';
    let ServiceNow = '';
    let UVdata = '';
    let ZenDesk = '';
    let KMDPoland = '';
    let Pathfindr = '';
    let InLogic = '';
    let Other = '';

    // Check if listingData and dataSubProcessors exist
    if (listingData?.dataSubProcessors && Array.isArray(listingData.dataSubProcessors)) {
        listingData.dataSubProcessors.forEach(subProcessor => {
            const subProcessorName = subProcessor.name?.toLowerCase(); // Convert to lowercase for case-insensitive comparison

            if (subProcessorName.includes('aeven')) {
                Aeven = 'X';
            } else if (subProcessorName.includes('t-systems')) {
                Tsystems = 'X';
            } else if (subProcessorName.includes('microsoft')) {
                Microsoft = 'X';
            } else if (subProcessorName.includes('servicenow')) {
                ServiceNow = 'X';
            } else if (subProcessorName.includes('uvdata')) {
                UVdata = 'X';
            } else if (subProcessorName.includes('zendesk')) {
                ZenDesk = 'X';
            } else if (subProcessorName.includes('kmd poland')) {
                KMDPoland = 'X';
            } else if (subProcessorName.includes('pathfindr')) {
                Pathfindr = 'X';
            } else if (subProcessorName.includes('inlogic')) {
                InLogic = 'X';
            } else {
                // gather remaing subprocessors in a list in a string
                Other = Other ? Other + subProcessor.name + ', ' : subProcessor.name + ', ';
            }
        });
    }

    // Clean up the 'Other' cus its gonna end with a ', ' if it has anything
    if (Other.endsWith(', ')) {
        Other = Other.slice(0, -2);
    }

    // Return the checklist as an object
    return {
        Aeven,
        Tsystems,
        Microsoft,
        ServiceNow,
        UVdata,
        ZenDesk,
        KMDPoland,
        Pathfindr,
        InLogic,
        Other
    };
}



//Helper function to create Header cell
function createHeaderCell(content: string, colSpan: string = '1', rowSpan: string = '1') {
    const newHeaderCell = document.createElement('th');

    newHeaderCell.textContent = content;
    newHeaderCell.colSpan = parseInt(colSpan, 10);
    newHeaderCell.rowSpan = parseInt(rowSpan, 10);

    newHeaderCell.style.backgroundColor = '#1f614e';
    newHeaderCell.style.color = 'white';
    newHeaderCell.style.fontWeight = 'bold';
    newHeaderCell.style.padding = '8px';
    newHeaderCell.style.border = '1px solid black';

    return newHeaderCell;
}

//Helper function to create normal cell
function createNormalCell(content: string, colSpan: string = '1', rowSpan: string = '1') {
    const newNormalCell = document.createElement('th');

    newNormalCell.textContent = content;
    newNormalCell.colSpan = parseInt(colSpan, 10);
    newNormalCell.rowSpan = parseInt(rowSpan, 10);

    newNormalCell.style.fontWeight = 'normal';
    newNormalCell.style.border = '1px solid black';

    return newNormalCell;
}

export default createXlsFile;