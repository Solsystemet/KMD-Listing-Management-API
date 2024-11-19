import React, { useState } from "react";
import styles from "./SortingMenu.module.css";
import { ArrowDownUp } from "lucide-react";

function SortingItem({ children }: SortingItemProps) {
   const [isAscending, setIsAscending] = useState(true);

   function handleToggleSortingOrder() {
      setIsAscending(!isAscending);
   }
   return (
      <div>
         <button>{children}</button>
         <button onClick={handleToggleSortingOrder}></button>
      </div>
   );
}

type SortingItemProps = {
   children: string;
};

export default SortingItem;

export function SortingMenu() {
   const [isShown, setIsShown] = useState(false);

   function handleToggleShown() {
      setIsShown(!isShown);
   }
   return (
      <div className={styles.sortingMenuContainer}>
         <button onClick={handleToggleShown}>
            <ArrowDownUp color="black" />
         </button>
         <div className={`${styles.menu} ${isShown ? styles.isShown : ""}`}>
            <SortingItem>Sort Item</SortingItem>
         </div>
      </div>
   );
}
