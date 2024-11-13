import styles from "./createListing.module.css";
import { createLazyFileRoute } from "@tanstack/react-router";
import { Survey } from "../../components/survey/Survey";

export const Route = createLazyFileRoute("/create-listing/")({
   component: Index,
});

function Index() {
   return (
      <main className={styles.createListing}>
         <div>
            <Survey numberOfContact={2} numberOfDataTransfers={0}></Survey>
         </div>
      </main>
   );
}
