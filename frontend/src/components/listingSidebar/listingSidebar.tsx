import styles from "./listingSidebar.module.css";
import ListingSidebarDto from "../../types/ListingSidebarDto";

function SidebarTile({
   listingSidebarDto,
   index,
}: {
   listingSidebarDto: ListingSidebarDto;
   index: number;
}) {
   return (
      <>
         <div
            className={`${styles.surveyTab} ${
               index % 2 === 0 ? styles.evenBackground : styles.oddBackground
            }`}
         >
            <div className={styles.surveyTabInfo}>
               <h2>{listingSidebarDto.Name}</h2>
               <p>{listingSidebarDto.DataProcessorName}</p>
            </div>
            <p className={styles.date}>
               {listingSidebarDto.CreationTime.toLocaleDateString()}
            </p>
         </div>
      </>
   );
}

export function ListingSidebar({
   listingSidebarDtos,
}: {
   listingSidebarDtos: ListingSidebarDto[];
}) {
   return (
      <div className={styles.surveyTabContainer}>
         {listingSidebarDtos.map((listingSidebarDto, index) => (
            <SidebarTile listingSidebarDto={listingSidebarDto} index={index} />
         ))}
      </div>
   );
}
