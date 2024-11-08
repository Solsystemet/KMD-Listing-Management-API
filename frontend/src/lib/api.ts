import axios from "axios";
import ListingSidebarDto from "../types/ListingSidebarDto";
type ListingSidebarDtoWithStringDate = {
   id: number;
   name: string;
   creationTime: string;
   dataProcessorName: string;
   dataTransfer: string;
};
export async function getAllListings() {
   const res = await axios.get("/api/dataProcessor30listingData");
   const listingsStringDate: ListingSidebarDtoWithStringDate[] = res.data;

   const listings: ListingSidebarDto[] = [];
   for (const listing of listingsStringDate) {
      listings.push({
         Id: listing.id,
         Name: listing.name,
         CreationTime: new Date(listing.creationTime),
         DataProcessorName: listing.dataProcessorName,
         DataTransfer: listing.dataTransfer,
      });
   }

   return listings;
}
