import { createLazyFileRoute } from "@tanstack/react-router";
import { ListingSidebar } from "../components/listingSidebar/listingSidebar";
import { useQuery } from "@tanstack/react-query";
import { getAllListings } from "../lib/api";

export const Route = createLazyFileRoute("/")({
   component: Index,
});
async function getAll30Listings() {
   return await getAllListings();
}
function Index() {
   const { isPending, error, data } = useQuery({
      queryKey: ["get-all-30-listings"],
      queryFn: getAll30Listings,
   });

   return (
      <main>
         {isPending ? (
            "Loading..."
         ) : error ? (
            error.message
         ) : (
            <ListingSidebar listingSidebarDtos={data} />
         )}
      </main>
   );
}
