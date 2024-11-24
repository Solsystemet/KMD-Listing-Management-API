import styles from "./createListing.module.css";
import { createLazyFileRoute } from "@tanstack/react-router";
import { Survey } from "../../components/Survey/Survey";

export const Route = createLazyFileRoute("/create-listing/")({
  component: Index,
});

function Index() {
  return (
    <main className={styles.createListing}>
      <div>
        <Survey
          numberOfContact={1}
          numberofDataProcessors={1}
          numberOfDataTransfers={3}
        ></Survey>
      </div>
    </main>
  );
}
