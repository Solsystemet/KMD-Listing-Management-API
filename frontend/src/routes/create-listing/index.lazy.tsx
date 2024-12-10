import styles from "./createListing.module.css";
import { createLazyFileRoute, useNavigate } from "@tanstack/react-router";
import { Survey } from "../../components/survey/Survey";
import { useEffect, useRef, useState } from "react";
import NullableDataProcessor30ListingData, {
   nullListingData,
} from "../../types/NullableDataProcessor30ListingData";
import DataProcessor30ListingData from "../../types/DataProcessor30ListingData";
import { postListing } from "../../lib/api";

export const Route = createLazyFileRoute("/create-listing/")({
   component: Index,
});

function Index() {
   const navigate = useNavigate({ from: "/create-listing" });

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

   async function handleSubmit(listing: DataProcessor30ListingData) {
      const id = await postListing(listing);
      navigate({
         to: "/listing/$listingId",
         params: { listingId: id.toString() },
      });
   }

   return (
      <main className={styles.createListing}>
         <div>
            {listingData ? (
               <Survey
                  listingDataProp={listingData}
                  handleSubmit={handleSubmit}
               ></Survey>
            ) : (
               "Loading..."
            )}
         </div>
      </main>
   );
}
