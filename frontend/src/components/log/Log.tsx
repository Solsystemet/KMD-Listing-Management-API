import styles from "./Log.module.css";
import { DataEdits } from "../../types/DataProcessor30ListingData";
import updateLogSVG from "../../assets/UpdateLogSvg.svg";
import CurvedToNewNode from "../../assets/CurvedToNewNode.svg";
import CurvedLine from "../../assets/CurvedLine.svg";
import { useState } from "react";
import { Ellipsis } from "lucide-react";

function SeeMoreMenu({ edit }: { edit: DataEdits }) {
   const [isShown, setIsShown] = useState(false);
   function handleToggleShown() {
      setIsShown(!isShown);
   }

   return (
      <div className={styles.sortingMenuContainer}>
         <button onClick={handleToggleShown} className={styles.toggleButton}>
            <div className={styles.ellipsisContainer}>
               <Ellipsis color="white" size={15} />
            </div>
            <p>{isShown ? "See Less" : "See More"}</p>
         </button>
         <div className={`${styles.menu} ${isShown ? styles.isShown : ""}`}>
            <div className={styles.comment}>
               <span>Comment: </span>
               <span>{edit.comment}</span>
            </div>
            <div className={styles.fieldsEdited}>
               <span>Fields edited: </span>
               <span>{edit.fieldsEdited}</span>
            </div>
         </div>
      </div>
   );
}

function LogNode({ edit, isLast }: { edit: DataEdits; isLast: boolean }) {
   const getImageSrc = (editType: string) => {
      switch (editType) {
         case "Listing Updated":
            return updateLogSVG;
      }
   };

   const editTime = new Date(edit.editTime);

   return (
      <div className={styles.logNode}>
         <div className={styles.imgContainer}>
            <img src={getImageSrc(edit.editType)} alt={edit.editType} />
            <div className={styles.arrowContainer}>
               <img src={isLast ? CurvedLine : CurvedToNewNode} alt="" />
            </div>
         </div>
         <div className={styles.overviewContent}>
            <p>{editTime.toUTCString()}</p>
            <p>{edit.editType}</p>
            <div className={styles.seeMoreMenuContainer}>
               <SeeMoreMenu edit={edit} />
            </div>
         </div>
      </div>
   );
}

export function Log({ dataEdits }: { dataEdits: DataEdits[] }) {
   return (
      <div>
         <hr />
         {dataEdits.length > 0 && <h2>Log</h2>}
         {dataEdits.map((edit, index) => (
            <LogNode
               key={index}
               edit={edit}
               isLast={index === dataEdits.length - 1}
            />
         ))}
      </div>
   );
}
