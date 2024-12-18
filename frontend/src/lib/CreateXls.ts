import {
    downloadTableAsExcel,
    tableToFile,
  } from 'https://cdn.jsdelivr.net/npm/html-table-to-excel.ts@1/esm.js' //for some reason doesnt work when downloaded so doin this, idk y,,,
  import { getAllListings, getListingById } from "./api";
import { useQuery } from "@tanstack/react-query";
import QueryObject from "../types/QueryObject";


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
        },
    ],[
        {
            text: '(Name of the soution',
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

export function createXlsFile() {
    //create doc
    const doc = document.implementation.createHTMLDocument('temporary Document');

    const HTMLBody = doc.body;
    const HTMLTable = doc.createElement('table');

    //Use helper function to format static information
    staticInformation.forEach(rowData => {      // kmd info, taken from the staticInformation arr
        const newRow = document.createElement('tr');
        
        newRow.appendChild(createHeaderCell(rowData[0], '2'));
        newRow.appendChild(createNormalCell(rowData[1], '2'));

        HTMLTable.appendChild(newRow);
    });
    listingHeaders.forEach(headerRow => {       // headers for listing data, taken from listingHeaders
        HTMLTable.appendChild(createHeaderRow(headerRow));
    })

    //Use helper function to append listing rows
        //fetch list of relevant listings
        //iterate through id's:
            //fetch data{}
            //execute function to create info row
            //append row



    HTMLBody.appendChild(HTMLTable);  //Appends table to document (prob not needed?)

    // Convert the table to an Excel file
    tableToFile(HTMLTable, 'Listings.xls');
    // Trigger download of the Excel file
    //const link = document.createElement('a');
    //link.href = URL.createObjectURL(excelFile);
    //link.download = 'Listings.xls';
    //link.click();

    
}

//Helper function to create a row
function createHeaderRow(row) {
    const headerRow = document.createElement('tr');

    row.forEach(rowCell =>{
        headerRow.appendChild(createHeaderCell(rowCell.text, rowCell.colSpan, rowCell.rowSpan));
    })

    return headerRow;
}

/*
//helper function to create data row
function createListingRow(_listingData) {
    const listingRow = document.createElement('tr');

    let Aeven = false;
    let Tsystems = false;
    let Microsoft = false;
    let ServiceNow = false;
    let UVdata = false;
    let ZenDesk = false;
    let KMDPoland = false;
    let Pathfindr = false;
    let InLogic = false;
    let Other = '';

    _listingData.dataSubProcessors.forEach(subProcessor => {
        if subProcessor.name.includes('Aeven'){
            Aeven = true;
        } else if subProcessor.name.includes('T-systems'){
            Tsystems = true;
        } else if subProcessor.name.includes('Microsoft'){
            Microsoft = true;
        } else if subProcessor.name.includes('ServiceNow'){
            ServiceNow = true;
        } else if subProcessor.name.includes('UVdata'){
            UVdata = true;
        } else if subProcessor.name.includes('ZenDesk'){
            ZenDesk = true;
        } else if subProcessor.name.includes('KMD Poland'){
            KMDPoland = true;
        } else if subProcessor.name.includes('Pathfindr'){
            Pathfindr = true;
        } else if subProcessor.name.includes('InLogic'){
            InLogic = true;
        } else {
            Other = Other.concat(subProcessor.name + ', ');
        }
    });


    listingRow.appendChild(createNormalCell(_listingData)); // Solution
    listingRow.appendChild(createNormalCell(_listingData)); // Data Controller
    listingRow.appendChild(createNormalCell(_listingData)); // Data Controller Contact info
    listingRow.appendChild(createNormalCell(_listingData)); // Processing activity list
    if Aeven{ listingRow.appendChild(createNormalCell('X')); 
    } else { listingRow.appendChild(createNormalCell(' ')); 
    }
    if Tsystems{listingRow.appendChild(createNormalCell('X')); // Sub-processor: T-systems
    } else {listingRow.appendChild(createNormalCell(' ')); 
    }
    if Microsoft{listingRow.appendChild(createNormalCell('X')); // Sub-processor: Microsoft
    } else {listingRow.appendChild(createNormalCell(' ')); 
    }
    if ServiceNow{listingRow.appendChild(createNormalCell('X')); // Sub-processor: ServiceNow
    }else{listingRow.appendChild(createNormalCell(' '));
    }
    if UVdata {listingRow.appendChild(createNormalCell('X')); // Sub-processor: UVdata
    } else{listingRow.appendChild(createNormalCell(' '));
    }
    if ZenDesk {listingRow.appendChild(createNormalCell('X')); // Sub-processor: ZenDesk Inc.
    } else {listingRow.appendChild(createNormalCell(' '));
    }
    if KMDPoland {listingRow.appendChild(createNormalCell('X')); // Sub-processor: KMD Poland
    } else {listingRow.appendChild(createNormalCell(' ')); 
    } 
    if Pathfindr {listingRow.appendChild(createNormalCell('X')); // Sub-processor: Pathfindr
    } else {listingRow.appendChild(createNormalCell(' ')); 
    }
    if InLogic {listingRow.appendChild(createNormalCell('X')); // Sub-processor: InLogic
    } else {listingRow.appendChild(createNormalCell(' '));}    
    listingRow.appendChild(createNormalCell(Other)); // Sub-processor: Other (list of names)
    listingRow.appendChild(createNormalCell(_listingData)); // ???Sub-processor: Changes of sub-processors (Indsigelse/Samtykke)
    listingRow.appendChild(createNormalCell(_listingData)); // Third country transfer (y/n)
    listingRow.appendChild(createNormalCell(_listingData)); // Third countries
}
*/

//Helper function to create Header cell
function createHeaderCell(content: string, colSpan: string = '1', rowSpan: string = '1') {
    const headerCell = document.createElement('th');

    headerCell.setAttribute('colspan', colSpan);
    headerCell.setAttribute('rowspan', rowSpan);
    headerCell.textContent = content;

    return headerCell;
}

//Helper function to create normal cell
function createNormalCell(content: string, colSpan: string = '1', rowSpan: string = '1') {
    const normalCell = document.createElement('tr');

    normalCell.setAttribute('colspan', colSpan);
    normalCell.setAttribute('rowspan', rowSpan);
    normalCell.textContent = content;

    return normalCell;
}

export default createXlsFile;