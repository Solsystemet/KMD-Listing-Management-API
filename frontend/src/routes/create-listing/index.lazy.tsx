import styles from "./createListing.module.css";
import { createLazyFileRoute } from "@tanstack/react-router";
import { Survey } from "../../components/survey/Survey";
import { useEffect, useRef, useState } from "react";
import NullableDataProcessor30ListingData from "../../types/NullableDataProcessor30ListingData";

export const Route = createLazyFileRoute("/create-listing/")({
   component: Index,
});

const nullListingData: NullableDataProcessor30ListingData = {
   name: null,
   dataController: {
      name: null,
      address: null,
      phoneNo: null,
      mail: null,
      cvr: null,
   },
   dataProcessor: {
      name: null,
      address: null,
      phoneNo: null,
      mail: null,
      cvr: null,
   },
   dataControllerRepresentative: {
      name: null,
      address: null,
      phoneNo: null,
      mail: null,
      role: null,
   },
   dataProcessorRepresentative: {
      name: null,
      address: null,
      phoneNo: null,
      mail: null,
      role: null,
   },
   dataSecurityAdvisor: {
      name: null,
      address: null,
      phoneNo: null,
      mail: null,
      categoryList: null,
   },
   dataCategories: {
      categoryList: null,
   },
   dataSecurity: {
      securityMeasures: null,
   },
   dataTransfer: {
      transferInformation: null,
   },
   dataSubProcessors: [
      {
         name: null,
         cvr: null,
         address: null,
         treatment: null,
         directSubProcessor: null,
         transferReason: null,
      },
   ],
};

function Index() {
   const [listingData, setListingData] =
      useState<NullableDataProcessor30ListingData | null>(null);
   const effectRan = useRef(false);
   useEffect(() => {
      if (!effectRan.current) {
         const listingData = localStorage.getItem("listingData");
         localStorage.removeItem("listingData");
         console.log("odjaspoijpokasdmf");
         console.log(listingData);
         if (listingData) {
            setListingData(JSON.parse(listingData));
         } else {
            setListingData(nullListingData);
         }
      }
      effectRan.current = true;
   }, []);

   return (
      <main className={styles.createListing}>
         <div>
            {listingData ? (
               <Survey listingDataProp={listingData}></Survey>
            ) : (
               "Loading..."
            )}
         </div>
      </main>
   );
}
