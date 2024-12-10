import { createFileRoute, useParams } from "@tanstack/react-router";
import { ListingSidebar } from "../../../components/listingSidebar/listingSidebar";
import { useQuery } from "@tanstack/react-query";
import { getAllListings, getListingById } from "../../../lib/api";
import { Searchbar } from "../../../components/searchbar/Searchbar";
import QueryObject from "../../../types/QueryObject";
import { useState } from "react";
import styles from "./index.module.css";
import { SortingMenu } from "../../../components/sortingMenu/SortingMenu";
import { DisplayListing } from "./../../../components/displayListing/DisplayListing";
import imgKMD from "../../../assets/imgKMD.svg";

export const Route = createFileRoute("/listing/$listingId/")({
   component: Index,
});

function Index() {
   const initListingId = useParams({ from: "/listing/$listingId/" }).listingId;

   const [listingId, setListingId] = useState(parseInt(initListingId));

   const [queryObject, setQueryObject] = useState<QueryObject>({
      isDescending: true,
      pageNumber: 1,
      pageSize: 20,
   });

   const currListing = useQuery({
      queryKey: ["get-listing-by-id", queryObject],
      queryFn: () => getListingById(listingId),
   });
   const listings = useQuery({
      queryKey: ["get-all-30-listings", queryObject],
      queryFn: () => getAllListings(queryObject),
   });
   return (
      <main className={styles.listingIndex}>
         <div className={styles.sidebar}>
            <Searchbar setQueryObject={setQueryObject} />
            <SortingMenu setQueryObject={setQueryObject} />
            {listings.isPending ? (
               "Loading..."
            ) : listings.error ? (
               listings.error.message
            ) : (
               <ListingSidebar listingSidebarDtos={listings.data} />
            )}
         </div>
         <div className={styles.listingDisplay}>
            {currListing.isPending || currListing.data === null ? (
               <img src={imgKMD} alt="Logo" className={styles.greyLogo} />
            ) : currListing.error ? (
               currListing.error.message
            ) : (
               <DisplayListing listing={currListing.data} />
            )}
         </div>
      </main>
   );
}
