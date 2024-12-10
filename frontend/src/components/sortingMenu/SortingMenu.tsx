import { Dispatch, SetStateAction, useState } from "react";
import styles from "./SortingMenu.module.css";
import {
   ArrowDownNarrowWide,
   ArrowDownWideNarrow,
   ChevronDown,
} from "lucide-react";
import QueryObject from "../../types/QueryObject";

type SortingItemProps = {
   children: string;
   sortingParameter: "Name" | "Creation Time" | "Update Time";
   isSelected: boolean;
   isAscending: boolean;
   onClick: (value: string) => void;
   onToggleOrder: () => void;
};

function SortingItem({
   children,
   sortingParameter,
   isSelected,
   isAscending,
   onClick,
   onToggleOrder,
}: SortingItemProps) {
   return (
      <div className={styles.sortingItem}>
         <button
            onClick={() => onClick(sortingParameter)}
            className={`${styles.sortingItemButton} ${isSelected ? styles.selected : ""}`}
         >
            {children}
         </button>
         {isSelected && (
            <button
               onClick={onToggleOrder}
               className={styles.sortingOrderButton}
            >
               {isAscending ? (
                  <ArrowDownWideNarrow size={20} color="var(--primary-color)" />
               ) : (
                  <ArrowDownNarrowWide size={20} color="var(--primary-color)" />
               )}
            </button>
         )}
      </div>
   );
}

type SortingMenuProps = {
   setQueryObject: Dispatch<SetStateAction<QueryObject>>;
};

export function SortingMenu({ setQueryObject }: SortingMenuProps) {
   const [isShown, setIsShown] = useState(false);
   const [selectedSorting, setSelectedSorting] = useState<
      "Name" | "Creation Time" | "Update Time" | null
   >(null);
   const [isAscending, setIsAscending] = useState(true);

   function handleToggleShown() {
      setIsShown(!isShown);
   }

   function handleSortingItemClick(
      value: "Name" | "Creation Time" | "Update Time"
   ) {
      setSelectedSorting(value);
      setQueryObject((prevQueryObject: QueryObject) => {
         const newQueryObject: QueryObject = {
            ...prevQueryObject,
            sortBy: value,
         };
         return newQueryObject;
      });
   }

   function handleToggleSortingOrder() {
      setIsAscending(!isAscending);
      setQueryObject((prevQueryObject: QueryObject) => ({
         ...prevQueryObject,
         isDescending: !isAscending,
      }));
   }

   return (
      <div className={styles.sortingMenuContainer}>
         <button onClick={handleToggleShown} className={styles.toggleButton}>
            <p>Sort</p>
            <ChevronDown color="var(--background-color)" />
         </button>
         <div className={`${styles.menu} ${isShown ? styles.isShown : ""}`}>
            <SortingItem
               sortingParameter="Creation Time"
               isSelected={selectedSorting === "Creation Time"}
               isAscending={isAscending}
               onClick={() => handleSortingItemClick("Creation Time")}
               onToggleOrder={handleToggleSortingOrder}
            >
               Creation date
            </SortingItem>
            <SortingItem
               sortingParameter="Update Time"
               isSelected={selectedSorting === "Update Time"}
               isAscending={isAscending}
               onClick={() => handleSortingItemClick("Update Time")}
               onToggleOrder={handleToggleSortingOrder}
            >
               Edit date
            </SortingItem>
            <SortingItem
               sortingParameter="Name"
               isSelected={selectedSorting === "Name"}
               isAscending={isAscending}
               onClick={() => handleSortingItemClick("Name")}
               onToggleOrder={handleToggleSortingOrder}
            >
               Name
            </SortingItem>
         </div>
      </div>
   );
}

export default SortingItem;
