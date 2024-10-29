import React, { useState } from "react";
import { Navbar } from "../components/navbar/Navbar";
import { FileUpload } from "../components/fileUpload/FileUpload";
import styles from "./CreateListing.module.css";
import { StandardButton } from "../components/buttons/Buttons";

export function CreateListing() {
   return (
      <>
         <Navbar
            children={[
               { url: "/CreateListing", label: "Create Listing" },
               { url: "/Listings", label: "Listings" },
            ]}
         />
         <div className={styles.fileUploadContainer}>
            <FileUpload />
            <div className={styles.buttons}>
               <StandardButton
                  children={"Choose file"}
                  color={"white"}
                  fontSize={"16px"}
               />
               <StandardButton
                  children={"Skip"}
                  color={"black"}
                  fontSize={"14px"}
                  backgroundColor="white"
               />
            </div>
         </div>

         <div className={styles.submitButton}>
            <StandardButton
               children={"Submit"}
               color={"white"}
               fontSize={"16px"}
            />
         </div>
      </>
   );
}
