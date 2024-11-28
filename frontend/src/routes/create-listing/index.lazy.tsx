import styles from "./createListing.module.css";
import { createLazyFileRoute } from "@tanstack/react-router";
import { Survey } from "../../components/Survey/Survey";
import { useEffect, useState } from "react";
import NullableDataProcessor30ListingData from "../../types/NullableDataProcessor30ListingData";

export const Route = createLazyFileRoute("/create-listing/")({
   component: Index,
});

function Index() {
   const [listingData, setListingData] =
      useState<NullableDataProcessor30ListingData | null>(null);
   useEffect(() => {
      const listingData = localStorage.getItem("listingData");
      localStorage.removeItem("listingData");
      if (listingData) {
         setListingData(JSON.parse(listingData));
      }
   }, []);

   return (
      <main className={styles.createListing}>
         <div>
            <Survey
               numberOfContact={1}
               numberofDataProcessors={1}
               numberOfDataTransfers={3}
            ></Survey>
         </div>
      </main>
   );
}
