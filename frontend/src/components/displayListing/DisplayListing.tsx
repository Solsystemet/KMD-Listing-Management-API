import DataProcessor30ListingData from "../../types/DataProcessor30ListingData";
import styles from "./DisplayListing.module.css";

export function DisplayListing({
   listing,
}: {
   listing: DataProcessor30ListingData;
}) {
   const {
      dataController,
      dataProcessor,
      dataControllerRepresentative,
      dataProcessorRepresentative,
      dataSubProcessors,
      dataCategories,
      dataSecurity,
   } = listing;

   return (
      <div className={styles.listingBackground}>
         <div className={styles.listingContainer}>
            <section className={styles.infoContainer}>
               <h1>{listing.name}</h1>
               <div>
                  <span>Created at: </span>
                  <span> {listing.creationTime.toUTCString()}</span>
               </div>
               <div>
                  <span>Updated at: </span>
                  <span>{listing.updateTime.toUTCString()}</span>
               </div>
            </section>
            <section>
               <h2>Data Controller</h2>
               <p>
                  <b>Name:</b> {dataController.name}
               </p>
               <p>
                  <b>CVR:</b> {dataController.cvr}
               </p>
               <p>
                  <b>Address:</b> {dataController.address}
               </p>
               <p>
                  <b>Phone:</b> {dataController.phoneNo}
               </p>
               <p>
                  <b>Email:</b> {dataController.mail}
               </p>
            </section>

            <section>
               <h2>Data Processor</h2>
               <p>
                  <b>Name:</b> {dataProcessor.name}
               </p>
               <p>
                  <b>CVR:</b> {dataProcessor.cvr}
               </p>
               <p>
                  <b>Address:</b> {dataProcessor.address}
               </p>
               <p>
                  <b>Phone:</b> {dataProcessor.phoneNo}
               </p>
               <p>
                  <b>Email:</b> {dataProcessor.mail}
               </p>
            </section>

            <section>
               <h2>Data Controller Representative</h2>
               <p>
                  <b>Name:</b> {dataControllerRepresentative.name}
               </p>
               <p>
                  <b>Role:</b>
                  {dataControllerRepresentative.role}
               </p>
               <p>
                  <b>
                     <b>Address:</b>
                  </b>
                  {dataControllerRepresentative.address}
               </p>
               <p>
                  <b>Phone:</b> {dataControllerRepresentative.phoneNo}
               </p>
               <p>
                  <b>Email:</b> {dataControllerRepresentative.mail}
               </p>
            </section>

            <section>
               <h2>Data Processor Representative</h2>
               <p>
                  <b>Name:</b> {dataProcessorRepresentative.name}
               </p>
               <p>
                  <b>Role:</b> {dataProcessorRepresentative.role}
               </p>
               <p>
                  <b>Address:</b> {dataProcessorRepresentative.address}
               </p>
               <p>
                  <b>Phone:</b> {dataProcessorRepresentative.phoneNo}
               </p>
               <p>
                  <b>Email:</b> {dataProcessorRepresentative.mail}
               </p>
            </section>

            <section className={styles.SubProcessorContainer}>
               <h2>Data Sub-Processors</h2>
               {dataSubProcessors.map((subProcessor, index) => (
                  <div key={index} className={styles.subProcessor}>
                     <p>{subProcessor.name}</p>
                     <p>
                        <b>CVR:</b> {subProcessor.cvr}
                     </p>
                     <p>
                        <b>Address:</b> {subProcessor.address}
                     </p>
                     <p>
                        <b>Treatment:</b> {subProcessor.treatment}
                     </p>
                     <p>
                        <b>Direct Sub-Processor:</b>{" "}
                        {subProcessor.directSubProcessor ? "Yes" : "No"}
                     </p>
                     <p>
                        <b>Transfer Reason:</b> {subProcessor.transferReason}
                     </p>
                  </div>
               ))}
            </section>
         </div>
      </div>
   );
}
