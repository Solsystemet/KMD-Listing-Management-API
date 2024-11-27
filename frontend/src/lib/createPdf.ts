import jsPDF from "jspdf";
import "jspdf-autotable";


export function createPdf(_listing: any /*{ 
        name: string; 
        "Data Controller": { Name: string; Address: string; PhoneNo: string; Mail: string; CVR: string; }; 
        "Data Processor": { Name: string; Address: string; PhoneNo: string; Mail: string; CVR: string; }; 
        "Data Processor Representative": { Name: string; Address: string; PhoneNo: string; Mail: string; }; 
        "Data Security Adviser": { Name: string; Address: string; PhoneNo: string; Mail: string; }; 
        "Data Categories": { CategoryList: string; }; 
        "Data Transfer": { TransferInformation: string; }; 
        "Data Security": { SecurityMeasures: string; }; 
    }*/) {

        const doc = new jsPDF();

    // Data for the table
    const columns = ["Category", "Label", "Data"];


    //Base data (treat contact and data categories as that cus they are always needed)
    const data = [
        ["Contact", "Data Controller", `
            ${_listing["Data Controller"].Name}\n
            ${_listing["Data Controller"].Address}\n
            ${_listing["Data Controller"].PhoneNo}\n
            ${_listing["Data Controller"].Mail}\n
            ${_listing["Data Controller"].CVR}
        `],
        ["", "Data Processor", `
            ${_listing["Data Processor"].Name}\n
            ${_listing["Data Processor"].Address}\n
            ${_listing["Data Processor"].PhoneNo}\n
            ${_listing["Data Processor"].Mail}\n
            ${_listing["Data Processor"].CVR}
        `],
        ["", "Data Processor Representative", `
            ${_listing["Data Processor Representative"].Name}\n
            ${_listing["Data Processor Representative"].Address}\n
            ${_listing["Data Processor Representative"].PhoneNo}\n
            ${_listing["Data Processor Representative"].Mail}
        `],
        ["", "Data Security Adviser", `
            ${_listing["Data Security Adviser"].Name}\n
            ${_listing["Data Security Adviser"].Address}\n
            ${_listing["Data Security Adviser"].PhoneNo}\n
            ${_listing["Data Security Adviser"].Mail}
        `],
        ["Data Categories", "Categories of data", `- ${_listing["Data Categories"].CategoryList.replaceAll(", ", '\n- ')}`],
    ];

    //if transfer/security has data, needs to add a row for it
    if(_listing["Data Transfer"].TransferInformation != ""){
        data.push(["Data Transfer", "Terms for transfer of data internationally and to 3rd countries",
            `${_listing["Data Transfer"].TransferInformation}`]
        );
    }
    if(_listing["Data Security"].SecurityMeasures != ""){
        data.push(["Data Security", "Security measures in place to protect data privacy",
            `${_listing["Data Security"].SecurityMeasures}`
        ])
    }

    doc.autoTable({ //autoTable "doesnt exist" in jspdf but still works, idk
        head: [columns],
        body: data,
        startY: 20,
    });

    // Save the PDF
    doc.save(`${_listing.name} listing.pdf`);

}
