import styles from "./createListing.module.css";
import { createLazyFileRoute } from "@tanstack/react-router";
import { Survey } from "../../components/survey/Survey";
import { useEffect, useRef, useState } from "react";
import NullableDataProcessor30ListingData, {
   nullListingData,
} from "../../types/NullableDataProcessor30ListingData";

export const Route = createLazyFileRoute("/create-listing/")({
   component: Index,
});

function Index() {
   const [listingData, setListingData] =
      useState<NullableDataProcessor30ListingData | null>(null);
   const effectRan = useRef(false);
   useEffect(() => {
      if (!effectRan.current) {
         const listingData = localStorage.getItem("listingData");
         localStorage.removeItem("listingData");
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
