import axios from "axios";
import ListingSidebarDto from "../types/ListingSidebarDto";
import QueryObject from "../types/QueryObject";
import { Dispatch, SetStateAction } from "react";
import NullableDataProcessor30ListingData from "../types/NullableDataProcessor30ListingData";

type ListingSidebarDtoWithStringDate = {
   id: number;
   name: string;
   creationTime: string;
   dataProcessorName: string;
};

export async function getAllListings(queryObject: QueryObject) {
   const res = await axios.get("/api/data-processor-30-listing-data", {
      params: {
         SortBy: queryObject.sortBy,
         IsDescending: queryObject.isDescending,
      },
   });
   const listingsStringDate: ListingSidebarDtoWithStringDate[] = res.data;

   const listings: ListingSidebarDto[] = [];
   for (const listing of listingsStringDate) {
      listings.push({
         Id: listing.id,
         Name: listing.name,
         CreationTime: new Date(listing.creationTime),
         DataProcessorName: listing.dataProcessorName,
      });
   }

   return listings;
}

export async function scrapeFile(
   formData: FormData,
   setProgress: Dispatch<SetStateAction<number>>
) {
   const response = await axios.post("/api/file-scraper", formData, {
      onUploadProgress: progressEvent => {
         let percentCompleted = 0;

         if (!progressEvent.total) {
            percentCompleted = 100;
         } else {
            percentCompleted = Math.round(
               (progressEvent.loaded * 100) / progressEvent.total
            );
         }

         setProgress(percentCompleted);
      },
   });

   const ListingData: NullableDataProcessor30ListingData = response.data;
   return ListingData;
}
