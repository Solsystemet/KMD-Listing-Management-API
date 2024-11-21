import axios from "axios";
import ListingSidebarDto from "../types/ListingSidebarDto";
import QueryObject from "../types/QueryObject";

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
