import styles from "./listingSidebar.module.css";
import ListingSidebarDto from "../../types/ListingSidebarDto";

function SidebarTile({
   listingSidebarDto,
   index,
   onClick,
   selected,
}: {
   listingSidebarDto: ListingSidebarDto;
   index: number;
   onClick: (id: number) => void;
   selected: boolean;
}) {
   return (
      <div
         className={`${styles.surveyTab} ${
            index % 2 === 0 ? styles.evenBackground : styles.oddBackground
         } ${selected ? styles.selected : ""}`}
         onClick={() => onClick(listingSidebarDto.Id)}
      >
         <div className={styles.surveyTabInfo}>
            <h2>{listingSidebarDto.Name}</h2>
            <p>{listingSidebarDto.DataProcessorName}</p>
         </div>
         <p className={styles.date}>
            {listingSidebarDto.CreationTime.toLocaleDateString()}
         </p>
      </div>
   );
}

export function ListingSidebar({
   listingSidebarDtos,
   onClick,
   selectedListingId,
}: {
   listingSidebarDtos: ListingSidebarDto[];
   onClick: (id: number) => void;
   selectedListingId: number | null;
}) {
   return (
      <div className={styles.surveyTabContainer}>
         {listingSidebarDtos.map((listingSidebarDto, index) => (
            <SidebarTile
               key={listingSidebarDto.Id}
               listingSidebarDto={listingSidebarDto}
               index={index}
               onClick={onClick}
               selected={listingSidebarDto.Id === selectedListingId}
            />
         ))}
      </div>
   );
}
