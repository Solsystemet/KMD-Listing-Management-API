import jsPDF from "jspdf";
import "jspdf-autotable";

export async function createPdf(_listing: any) {
    const doc = new jsPDF();

    doc.setFont('arial');
    doc.setFontSize(24);
    doc.text(`${_listing.name} Data Processor Listing`, 15, 30)

    // Columns for the table
    const columns = ["Category", "Label", "Data"];

    // Use helper function to format data 
    const listingData = formatListingData(_listing);
    

    // Generate the table using autoTable
    doc.autoTable({ //ignore error, it works
        head: [columns],
        body: listingData,
        styles: {   //default style
            font: 'arial',
            fontSize: 10
        },
        headStyles: {   //header styles
            fontSize: 12,
            fontStyle: "bold",
            fillColor: "#1f614e",
            textColor: "#d9d9d9"
        },
        startY: 50, // Start table 50 units down
    });

    // Save the PDF file
    const fileName = `${_listing.name} listing.pdf`;
    doc.save(fileName);
}

// Helper function to format all data
function formatListingData(listing: any){
    if (!listing) return "N/A";
    
    // Base data (contact and data categories)
    const data = [
        ["Contact", "Data Controller", formatContact(listing["dataController"])],
        ["", "Data Processor", formatContact(listing["dataProcessor"])],
        ["", "Data Processor Representative", formatContact(listing["dataProcessorRepresentative"])],
        ["", "Data Security Adviser", formatContact(listing["dataSecurityAdvisor"])],
        ["Data Categories", "Categories of data", formatDataCategories(listing["dataCategories"])]
    ];

    // Conditional rows for data transfer and security
    if (listing["dataTransfer"]?.transferInformation) {
        data.push([
            "Data Transfer",
            "Terms for transfer of data internationally and to 3rd countries",
            listing["dataTransfer"].transferInformation
        ]);
    }

    if (listing["dataSecurity"]?.securityMeasures) {
        data.push([
            "Data Security",
            "Security measures in place to protect data privacy",
            listing["dataSecurity"].securityMeasures
        ]);
    }

    return data;
}

// Helper function to format contact information
function formatContact(contact: any): string {
    if (!contact) return "N/A";
    return [
        contact.name,
        contact.address,
        contact.phoneNo,
        contact.mail,
        contact.cvr
    ]
        .filter(Boolean) // Filter out undefined or null values
        .join("\n");
}

// Helper function to format data categories
function formatDataCategories(dataCategories: any): string {
    if (!dataCategories?.categoryList) return "N/A";
    return dataCategories.categoryList.split(", ").map((category: string) => `- ${category}`).join("\n");
}
