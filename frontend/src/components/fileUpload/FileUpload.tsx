import { Dispatch, SetStateAction, useCallback, useState } from "react";
import styles from "./FileUpload.module.css";
import { FileRejection, useDropzone } from "react-dropzone";
import axios from "axios";
import { FileText } from "lucide-react";
import { StandardButton } from "../buttons/Buttons";
import NullableDataProcessor30ListingData from "../../types/NullableDataProcessor30ListingData";

export function FileUpload({
   setListingData,
}: {
   setListingData: Dispatch<
      SetStateAction<NullableDataProcessor30ListingData | null>
   >;
}) {
   const [selectedFile, setSelectedFile] = useState<File | null>(null);
   const [progress, setProgress] = useState(0);
   const [isInvalidUpload, setIsInvalidUpload] = useState(false);

   const doDrop = useCallback(
      async <T extends File>(
         acceptedFiles: T[],
         fileRejections: FileRejection[]
      ) => {
         console.log(fileRejections);
         if (fileRejections.length > 0) {
            return setIsInvalidUpload(true);
         }
         const file = acceptedFiles[0];
         setSelectedFile(file);

         try {
            const formData = new FormData();
            formData.append("file", file);

            const response = await axios.post("/api/file-scraper", formData, {
               onUploadProgress: progressEvent => {
                  console.log(progressEvent.total);
                  let percentCompleted = 0;
                  if (!progressEvent.total) {
                     percentCompleted = 100;
                  } else {
                     percentCompleted = Math.round(
                        (progressEvent.loaded * 100) / progressEvent.total
                     );
                  }
                  setProgress(percentCompleted);
               },
            });

            const ListingData: NullableDataProcessor30ListingData =
               response.data;

            setListingData(ListingData);
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
            {isInvalidUpload && (
               <p className={styles.invalidUpload}>
                  Invalid upload type. Please upload only 1 PDF file.
               </p>
            )}
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
