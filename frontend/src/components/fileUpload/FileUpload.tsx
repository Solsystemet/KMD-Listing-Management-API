/* eslint-disable @typescript-eslint/no-explicit-any */
import { useCallback, useState } from "react";
import styles from "./FileUpload.module.css";
import { useDropzone } from "react-dropzone";
import axios from "axios";
import { FileText } from "lucide-react";
import { StandardButton } from "../buttons/Buttons";

export function FileUpload() {
   const [uploadStatus, setUploadStatus] = useState("select");
   const [selectedFile, setSelectedFile] = useState<File | null>(null);
   const [progress, setProgress] = useState(0);

   const clearFileInput = useCallback(() => {
      setSelectedFile(null);
      setProgress(0);
   }, []);
   const doDrop = useCallback(
      async (acceptedFiles: string | any[]) => {
         if (acceptedFiles.length > 0) {
            const file = acceptedFiles[0];
            setSelectedFile(file);

            if (uploadStatus === "done") {
               clearFileInput();
               return;
            }
            try {
               setUploadStatus("Uploading");
               const formData = new FormData();
               formData.append("file", file);

               await axios.post("http://localhost:5173/api/upload", formData, {
                  onUploadProgress: (progressEvent: any) => {
                     const percentCompleted = Math.round(
                        (progressEvent.loaded * 100) / progressEvent.total
                     );
                     setProgress(percentCompleted);
                  },
               });

               setUploadStatus("done");
            } catch {
               setUploadStatus("select");
            }
         }
      },
      [uploadStatus, clearFileInput]
   );

   const { getRootProps, getInputProps, isDragActive, open } = useDropzone({
      onDrop: doDrop,
      noClick: true,
      noKeyboard: true,
   });

   return (
      <div className={styles.fileUploadContainer}>
         <div className={styles.dropZoneWrap}>
            <div {...getRootProps()} className={styles.dropZone}>
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
