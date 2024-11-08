import { useQuery } from "@tanstack/react-query";
import { getAllListings } from "../../lib/api";

import styles from "./listingSidebar.module.css";
import ListingSidebarDto from "../../types/ListingSidebarDto";

function SidebarTile({
   listingSidebarDto,
}: {
   listingSidebarDto: ListingSidebarDto;
}) {
   return (
      <div>
         <div
            key={listingSidebarDto.Id}
            className={`${styles.surveyTab} ${
               listingSidebarDto.Id % 2 === 0
                  ? styles.evenBackground
                  : styles.oddBackground
            }`}
         >
            <p className={styles.Date}>
               {listingSidebarDto.CreationTime.toLocaleDateString()}
            </p>
            <div className={styles.surveyTabInfo}>
               <h2>{listingSidebarDto.Name}</h2>
               <p>{listingSidebarDto.DataProcessorName}</p>
            </div>
         </div>
      </div>
   );
}

export function ListingSidebar({
   listingSidebarDtos,
}: {
   listingSidebarDtos: ListingSidebarDto[];
}) {
   return (
      <div className={styles.surveyTabContainer}>
         {listingSidebarDtos.map(listingSidebarDto => (
            <SidebarTile listingSidebarDto={listingSidebarDto} />
         ))}
      </div>
   );
}
