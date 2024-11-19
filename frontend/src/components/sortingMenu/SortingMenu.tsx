import React, { useState } from "react";
import styles from "./SortingMenu.module.css";
import {
   ArrowDownNarrowWide,
   ArrowDownWideNarrow,
   ChevronDown,
} from "lucide-react";

function SortingItem({ children, isSelected, onClick }: SortingItemProps) {
   const [isAscending, setIsAscending] = useState(true);

   function handleToggleSortingOrder() {
      setIsAscending(!isAscending);
      onClick(children, !isAscending);
   }

   return (
      <div className={styles.sortingItem}>
         <button
            onClick={() => onClick(children, isAscending)}
            className={`${styles.sortingItemButton} ${isSelected ? styles.selected : ""}`}
         >
            {children}
         </button>
         <button
            onClick={handleToggleSortingOrder}
            className={styles.sortingOrderButton}
         >
            {isAscending ? (
               <ArrowDownWideNarrow size={20} color="var(--primary-color)" />
            ) : (
               <ArrowDownNarrowWide size={20} color="var(--primary-color)" />
            )}
         </button>
      </div>
   );
}

type SortingItemProps = {
   children: string;
   isSelected: boolean;
   onClick: (value: string, isAscending: boolean) => void;
};

export default SortingItem;

export function SortingMenu() {
   const [isShown, setIsShown] = useState(false);
   const [selectedSorting, setSelectedSorting] = useState<string | null>(null);
   const [isAscending, setIsAscending] = useState(true);

   function handleToggleShown() {
      setIsShown(!isShown);
   }

   function handleSortingItemClick(value: string, ascending: boolean) {
      setSelectedSorting(value);
      setIsAscending(ascending);
   }

   return (
      <div className={styles.sortingMenuContainer}>
         <button onClick={handleToggleShown} className={styles.toggleButton}>
            <p>Sort</p>
            <ChevronDown color="var(--background-color)" />
         </button>
         <div className={`${styles.menu} ${isShown ? styles.isShown : ""}`}>
            <SortingItem
               isSelected={selectedSorting === "Creation date"}
               onClick={handleSortingItemClick}
            >
               Creation date
            </SortingItem>
            <SortingItem
               isSelected={selectedSorting === "Edit date"}
               onClick={handleSortingItemClick}
            >
               Edit date
            </SortingItem>
            <SortingItem
               isSelected={selectedSorting === "Name"}
               onClick={handleSortingItemClick}
            >
               Name
            </SortingItem>
         </div>
      </div>
   );
}
