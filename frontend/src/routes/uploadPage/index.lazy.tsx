import { createLazyFileRoute } from "@tanstack/react-router";
import { StandardButton } from "../../components/buttons/Buttons";
import { FileUpload } from "../../components/fileUpload/FileUpload";
import styles from "./uploadPage.module.css";

export const Route = createLazyFileRoute("/uploadPage/")({
   component: Index,
});

function Index() {
   return (
      <main>
         <div className={styles.contentContainer}>
            <div className={styles.fileUploadContainer}>
               <FileUpload />
            </div>
            <div className={styles.submitButton}>
               <StandardButton
                  children={"Submit"}
                  color={"white"}
                  fontSize={"16px"}
               />
            </div>
         </div>
      </main>
   );
}
