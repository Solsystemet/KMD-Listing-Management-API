import styles from "./index.module.css";
import {
   createFileRoute,
   useNavigate,
   useParams,
} from "@tanstack/react-router";
import DataProcessor30ListingData from "../../../../types/DataProcessor30ListingData";
import { getListingById, putListing } from "../../../../lib/api";
import { Survey } from "../../../../components/survey/Survey";
import { useQuery } from "@tanstack/react-query";

export const Route = createFileRoute("/listing/$listingId/edit/")({
   component: Index,
});

function Index() {
   const navigate = useNavigate({ from: "/listing/$listingId/edit" });

   const listingId = parseInt(
      useParams({
         from: "/listing/$listingId/edit/",
      }).listingId
   );

   const { data, error } = useQuery({
      queryKey: ["get-listing-by-id", listingId],
      queryFn: () => getListingById(listingId),
   });

   async function handleSubmit(listing: DataProcessor30ListingData) {
      await putListing(listingId, listing);
      navigate({
         to: "/listing/$listingId",
         params: { listingId: listingId.toString() },
      });
   }

   return (
      <main className={styles.createListing}>
         <div>
            {data ? (
               <Survey
                  listingDataProp={data}
                  handleSubmit={handleSubmit}
               ></Survey>
            ) : error ? (
               error.message
            ) : (
               "Loading..."
            )}
         </div>
      </main>
   );
}
