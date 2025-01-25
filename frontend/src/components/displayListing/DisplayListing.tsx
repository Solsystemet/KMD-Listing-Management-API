import DataProcessor30ListingData from "../../types/DataProcessor30ListingData";
import styles from "./DisplayListing.module.css";
import exportListingSvg from "../../assets/listingIcons/exportListing.svg";
import archiveListingSvg from "../../assets/listingIcons/archiveListing.svg";
import editListingSvg from "../../assets/listingIcons/editListing.svg";
import { Link } from "@tanstack/react-router";
import { createPdf } from "../../lib/createPdf";
import FileSaver from "file-saver";
import { DataEdits } from "../../types/DataProcessor30ListingData";
import { Log } from "../log/log";
import { putListing } from "../../lib/api";
import { useState } from "react";

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
      dataEdits,
   } = listing;

   dataEdits.forEach(edit => {
      console.log(`ID: ${edit.id}`);
      console.log(`Edit Type: ${edit.editType}`);
      console.log(`Edit Time: ${edit.editTime}`);
      console.log(`Comment: ${edit.comment}`);
      console.log(`Data Processor ID: ${edit.dataProcessor30ListingDataId}`);
      console.log(`Fields Edited: ${edit.fieldsEdited}`);
   });

   async function exportHandeler() {
      console.log("handeling export");
      try {
         const blob = createPdf(listing);

         FileSaver.saveAs(blob, `${listing.name} - Listing.pdf`);
      } catch (error) {
         console.error("Failed to download: ", error);
      }
   }

   const [isArchived, setIsArchived] = useState(listing.archived);

   async function archiveHandler() {
      const newArchiveStatus = isArchived === 1 ? 0 : 1;
      putListing(listing.id, {
         ...listing,
         archived: newArchiveStatus,
      });
      setIsArchived(newArchiveStatus);
   }

   return (
      <div className={styles.listingBackground}>
         <div className={styles.listingContainer}>
            <div className={styles.listingHeader}>
               <section className={styles.infoContainer}>
                  <h1>{listing.name}</h1>
                  {isArchived === 1 && (
                     <div>
                        <span>Archived</span>
                     </div>
                  )}
                  <div>
                     <span>Created at: </span>
                     <span> {listing.creationTime.toUTCString()}</span>
                  </div>
                  <div>
                     <span>Updated at: </span>
                     <span>{listing.updateTime.toUTCString()}</span>
                  </div>
               </section>
               <div className="listingControls">
                  <button
                     onClick={exportHandeler}
                     className={styles.listingActionButtons}
                     title="Export listing"
                     style={{ all: "unset" }}
                  >
                     <img
                        src={exportListingSvg}
                        alt="Export listing"
                        className={styles.listingActionButtons}
                     />
                  </button>
                  <button
                     onClick={archiveHandler}
                     className={styles.listingActionButtons}
                     title="Export listing"
                     style={{ all: "unset" }}
                  >
                     <img
                        src={archiveListingSvg}
                        alt="Archive Listing"
                        title="Archive Listing"
                        className={styles.listingActionButtons}
                     />
                  </button>
                  <Link
                     to="/listing/$listingId/edit"
                     params={{ listingId: listing.id.toString() }}
                  >
                     <img
                        src={editListingSvg}
                        alt="Edit Listing"
                        title="Edit Listing"
                        className={styles.listingActionButtons}
                     />
                  </Link>
               </div>
            </div>
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
               {dataSubProcessors.map(subProcessor => (
                  <div key={subProcessor.id} className={styles.subProcessor}>
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

            <section>
               <h2>Category List</h2>
               <p>{dataCategories.categoryList}</p>
            </section>

            {dataSecurity.securityMeasures && (
               <section>
                  <h2>Security Measures</h2>
                  <p>{dataSecurity.securityMeasures}</p>
               </section>
            )}
            <Log dataEdits={dataEdits} />
         </div>
      </div>
   );
}
