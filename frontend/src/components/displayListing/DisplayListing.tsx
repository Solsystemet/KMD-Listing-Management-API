// FILE: DisplayListing.tsx
import DataProcessor30ListingData from "../../types/DataProcessor30ListingData";
import "./DisplayListing.module.css";

export function displayListing(listing: DataProcessor30ListingData) {
   return (
      <div className="listing-container">
         <h2>Data Controller</h2>
         <p>Name: {listing.dataController.name}</p>
         <p>CVR: {listing.dataController.cvr}</p>
         <p>Address: {listing.dataController.address}</p>
         <p>Phone: {listing.dataController.phoneNo}</p>
         <p>Email: {listing.dataController.mail}</p>

         <h2>Data Processor</h2>
         <p>Name: {listing.dataProcessor.name}</p>
         <p>CVR: {listing.dataProcessor.cvr}</p>
         <p>Address: {listing.dataProcessor.address}</p>
         <p>Phone: {listing.dataProcessor.phoneNo}</p>
         <p>Email: {listing.dataProcessor.mail}</p>

         <h2>Data Controller Representative</h2>
         <p>Name: {listing.dataControllerRepresentative.name}</p>
         <p>Role: {listing.dataControllerRepresentative.role}</p>
         <p>Address: {listing.dataControllerRepresentative.address}</p>
         <p>Phone: {listing.dataControllerRepresentative.phoneNo}</p>
         <p>Email: {listing.dataControllerRepresentative.mail}</p>

         <h2>Data Processor Representative</h2>
         <p>Name: {listing.dataProcessorRepresentative.name}</p>
         <p>Role: {listing.dataProcessorRepresentative.role}</p>
         <p>Address: {listing.dataProcessorRepresentative.address}</p>
         <p>Phone: {listing.dataProcessorRepresentative.phoneNo}</p>
         <p>Email: {listing.dataProcessorRepresentative.mail}</p>

         <h2>Data Sub-Processors</h2>
         {listing.dataSubProcessors.map((subProcessor, index) => (
            <div key={index}>
               <p>Name: {subProcessor.name}</p>
               <p>CVR: {subProcessor.cvr}</p>
               <p>Address: {subProcessor.address}</p>
               <p>Treatment: {subProcessor.treatment}</p>
               <p>
                  Direct Sub-Processor:{" "}
                  {subProcessor.directSubProcessor ? "Yes" : "No"}
               </p>
               <p>Transfer Reason: {subProcessor.transferReason}</p>
            </div>
         ))}

         <h2>Information Description</h2>
         <p>{listing.dataCategories.toString()}</p>

         <h2>Security Measures</h2>
         <p>{listing.dataSecurity.toString()}</p>
      </div>
   );
}
