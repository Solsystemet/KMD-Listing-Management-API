import { createLazyFileRoute } from "@tanstack/react-router";
import { ListingSidebar } from "../components/listingSidebar/listingSidebar";
import { useQuery } from "@tanstack/react-query";
import { getAllListings } from "../lib/api";
import { Searchbar } from "../components/searchbar/Searchbar";
import QueryObject from "../types/QueryObject";
import { useState } from "react";

export const Route = createLazyFileRoute("/")({
   component: Index,
});

function Index() {
   const [queryObject, setQueryObject] = useState<QueryObject>({
      isDescending: true,
      pageNumber: 1,
      pageSize: 20,
   });

   const { isPending, error, data } = useQuery({
      queryKey: ["get-all-30-listings", queryObject],
      queryFn: () => getAllListings(queryObject),
   });

   return (
      <main>
         <div>
            <Searchbar setQueryObject={setQueryObject} />
         </div>
         <div>
            {isPending ? (
               "Loading..."
            ) : error ? (
               error.message
            ) : (
               <ListingSidebar listingSidebarDtos={data} />
            )}
         </div>
      </main>
   );
}
