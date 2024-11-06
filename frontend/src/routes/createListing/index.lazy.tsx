import styles from "./createListing.module.css";
import { createLazyFileRoute } from "@tanstack/react-router";
import { Survey } from "../../components/survey/Survey";

export const Route = createLazyFileRoute("/createListing/")({
   component: Index,
});

function Index() {
   return (
      <main className={styles.createListing}>
         <div>
            <Survey numberOfContact={3} numberOfDataTransfers={3}></Survey>
         </div>
      </main>
   );
}
