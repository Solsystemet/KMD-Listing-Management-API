/* eslint-disable @typescript-eslint/no-explicit-any */
import { Dispatch, SetStateAction, useCallback, useState } from "react";
import styles from "./FileUpload.module.css";
import { useDropzone } from "react-dropzone";
import { FileText } from "lucide-react";
import { StandardButton } from "../buttons/Buttons";
import NullableDataProcessor30ListingData from "../../types/NullableDataProcessor30ListingData";
import { scrapeFile } from "../../lib/api";

export function FileUpload({
   setListingData,
}: {
   setListingData: Dispatch<
      SetStateAction<NullableDataProcessor30ListingData | null>
   >;
}) {
   const [selectedFile, setSelectedFile] = useState<File | null>(null);
   const [progress, setProgress] = useState(0);

   const doDrop = useCallback(
      async (acceptedFiles: string | any[]) => {
         if (acceptedFiles.length === 0) {
            return;
         }
         const file = acceptedFiles[0];
         setSelectedFile(file);

         try {
            const formData = new FormData();
            formData.append("file", file);

            const listingData = await scrapeFile(formData, setProgress);

            setListingData(listingData);
         } catch {
            setListingData(null);
         }
      },
      [setListingData]
   );

   const { getRootProps, getInputProps, isDragActive, open } = useDropzone({
      onDrop: doDrop,
      noClick: true,
      noKeyboard: true,
      accept: {
         "application/pdf": [".pdf"],
      },
      multiple: false,
   });

   return (
      <div className={styles.fileUploadContainer}>
         <div className={styles.dropZoneWrap}>
            <div {...getRootProps()} onClick={open} className={styles.dropZone}>
               <input {...getInputProps()} />
               {isDragActive ? (
                  <p>Drop the file here</p>
               ) : (
                  <p>
                     Drag and drop the contact here, or click to select files
                  </p>
               )}
            </div>
            <StandardButton onClick={open} color={""} fontSize={"1rem"}>
               Upload File
            </StandardButton>
         </div>
         <div className={styles.fileDetailContainer}>
            <h3>Uploaded files</h3>
            {selectedFile && (
               <div className={styles.fileDetails}>
                  <div className={styles.picCircle}>
                     <FileText size={"70%"} />
                  </div>
                  <p className={styles.fileName}>{selectedFile.name}</p>
                  <div className={styles.progressBg}>
                     <div
                        className={styles.progress}
                        style={{ width: `${progress}%` }}
                     />
                  </div>
               </div>
            )}
         </div>
      </div>
   );
}
