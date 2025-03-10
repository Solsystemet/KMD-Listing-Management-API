import axios from "axios";
import ListingSidebarDto from "../types/ListingSidebarDto";
import QueryObject from "../types/QueryObject";
import { Dispatch, SetStateAction } from "react";
import NullableDataProcessor30ListingData from "../types/NullableDataProcessor30ListingData";
import DataProcessor30ListingData, {
   DataProcessor30ListingDataDto,
} from "../types/DataProcessor30ListingData";

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
         Name: queryObject.name,
         Archived: queryObject.archived,
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

type DataProcessor30ListingDataWithStringDate = Omit<
   DataProcessor30ListingData,
   "creationTime" | "updateTime"
> & { creationTime: string; updateTime: string };

export async function getListingById(id: number) {
   if (isNaN(id) || !isFinite(id)) return null;

   const res = await axios.get(`/api/data-processor-30-listing-data/${id}`);
   const listingWithStringDate: DataProcessor30ListingDataWithStringDate =
      res.data;
   const listing: DataProcessor30ListingData = {
      ...listingWithStringDate,
      creationTime: new Date(listingWithStringDate.creationTime),
      updateTime: new Date(listingWithStringDate.updateTime),
   };

   return listing;
}

export async function scrapeFile(
   formData: FormData,
   setProgress: Dispatch<SetStateAction<number>>
) {
   const response = await axios.post("/api/file-scraper", formData, {
      onUploadProgress: progressEvent => {
         let percentCompleted = 0;

         if (!progressEvent.total) {
            percentCompleted = 66;
         } else {
            percentCompleted = Math.round(
               (progressEvent.loaded * 66) / progressEvent.total
            );
         }

         setProgress(percentCompleted);
      },
   });

   const ListingData: NullableDataProcessor30ListingData = response.data;
   return ListingData;
}

export async function postListing(
   listing: DataProcessor30ListingDataDto
): Promise<number> {
   const result = await axios.post(
      "/api/data-processor-30-listing-data",
      listing
   );
   return result.data.id;
}

export async function putListing(
   id: number,
   listing: DataProcessor30ListingDataDto
) {
   await axios.put(`/api/data-processor-30-listing-data/${id}`, listing);
}
