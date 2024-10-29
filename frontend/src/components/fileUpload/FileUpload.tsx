import React, { useCallback, useState } from "react";
import styles from "./FileUpload.module.css";
import { useDropzone } from "react-dropzone";
import axios from "axios";
import { FileText } from "lucide-react";

export function FileUpload() {
   const [uploadStatus, setUploadStatus] = useState("select");
   const [selectedFile, setSelectedFile] = useState<File | null>(null);
   const [progress, setProgress] = useState(0);

   const clearFileInput = () => {
      setSelectedFile(null);
      setProgress(0);
   };

   const handleUpload = async (file: File) => {
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
      } catch (error) {
         setUploadStatus("select");
      }
   };

   const doDrop = useCallback(acceptedFiles => {
      if (acceptedFiles.length > 0) {
         const file = acceptedFiles[0];
         setSelectedFile(file);
         handleUpload(file);
      }
   }, []);

   const { getRootProps, getInputProps, isDragActive } = useDropzone({
      onDrop: doDrop,
   });

   return (
      <>
         <div {...getRootProps()} className={styles.dropZone}>
            <input {...getInputProps()} />
            {isDragActive ? (
               <p>Drop the file here</p>
            ) : (
               <p>Drag and drop the contact here, or click to select files</p>
            )}
         </div>

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
      </>
   );
}
