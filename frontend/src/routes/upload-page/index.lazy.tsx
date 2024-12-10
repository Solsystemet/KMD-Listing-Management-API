import { createLazyFileRoute, useNavigate } from "@tanstack/react-router";
import { StandardButton } from "../../components/buttons/Buttons";
import { FileUpload } from "../../components/fileUpload/FileUpload";
import styles from "./uploadPage.module.css";
import NullableDataProcessor30ListingData from "../../types/NullableDataProcessor30ListingData";
import { useState } from "react";

export const Route = createLazyFileRoute("/upload-page/")({
   component: Index,
});

function Index() {
   const navigate = useNavigate({ from: "/upload-page" });
   const [listingData, setListingData] =
      useState<NullableDataProcessor30ListingData | null>(null);

   function handleSubmit() {
      localStorage.setItem("listingData", JSON.stringify(listingData));
      navigate({ to: "/create-listing" });
   }
   function handleSkip() {
      navigate({ to: "/create-listing" });
   }

   return (
      <main className={styles.layout}>
         <div className={styles.contentContainer}>
            <div className={styles.fileUploadContainer}>
               <FileUpload setListingData={setListingData} />
            </div>
            <div className={styles.submitButton}>
               <StandardButton
                  children={"Skip"}
                  color={"white"}
                  fontSize={"16px"}
                  onClick={handleSkip}
               />
               <StandardButton
                  children={"Submit"}
                  color={"white"}
                  fontSize={"16px"}
                  disabled={!listingData}
                  onClick={handleSubmit}
               />
            </div>
         </div>
      </main>
   );
}
