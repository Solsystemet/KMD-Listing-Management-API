import jsPDF from "jspdf";
import "jspdf-autotable";

export function createPdf(_listing: any) {
    const doc = new jsPDF();

    // Columns for the table
    const columns = ["Category", "Label", "Data"];

    // Base data (contact and data categories)
    const data = [
        ["Contact", "Data Controller", formatContact(_listing["dataController"])],
        ["", "Data Processor", formatContact(_listing["dataProcessor"])],
        ["", "Data Processor Representative", formatContact(_listing["dataProcessorRepresentative"])],
        ["", "Data Security Adviser", formatContact(_listing["dataSecurityAdvisor"])],
        ["Data Categories", "Categories of data", formatDataCategories(_listing["dataCategories"])]
    ];

    // Conditional rows for data transfer and security
    if (_listing["dataTransfer"]?.transferInformation) {
        data.push([
            "Data Transfer",
            "Terms for transfer of data internationally and to 3rd countries",
            _listing["dataTransfer"].transferInformation
        ]);
    }

    if (_listing["dataSecurity"]?.securityMeasures) {
        data.push([
            "Data Security",
            "Security measures in place to protect data privacy",
            _listing["dataSecurity"].securityMeasures
        ]);
    }

    // Generate the table using autoTable
    doc.autoTable({
        head: [columns],
        body: data,
        startY: 20, // Start table 20 units down
    });

    // Save the PDF file
    const fileName = `${_listing.name || "Listing"}.pdf`;
    doc.save(fileName);
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
