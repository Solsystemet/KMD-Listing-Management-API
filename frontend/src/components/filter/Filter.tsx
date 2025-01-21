import { Dispatch, SetStateAction, useState } from "react";
import styles from "./Filter.module.css";
import { ChevronDown } from "lucide-react";
import QueryObject from "../../types/QueryObject";

type FilterItemProps = {
   children: string;
   filterParameter: 0 | 1;
   isSelected: boolean;
   onClick: (value: 0 | 1) => void;
};

function FilterItem({
   children,
   filterParameter,
   isSelected,
   onClick,
}: FilterItemProps) {
   return (
      <button
         onClick={() => onClick(filterParameter)}
         className={`${styles.filterItemButton} ${isSelected ? styles.selected : ""}`}
      >
         {children}
      </button>
   );
}

type FilterMenuProps = {
   setQueryObject: Dispatch<SetStateAction<QueryObject>>;
};

export function FilterMenu({ setQueryObject }: FilterMenuProps) {
   const [isShown, setIsShown] = useState(false);
   const [selectedFilter, setSelectedFilter] = useState<0 | 1>(0);

   function handleToggleShown() {
      setIsShown(!isShown);
   }

   function handleFilterItemClick(value: 0 | 1) {
      setSelectedFilter(value);
      setQueryObject((prevQueryObject: QueryObject) => {
         const newQueryObject: QueryObject = {
            ...prevQueryObject,
            archived: selectedFilter,
         };
         return newQueryObject;
      });
      console.log(selectedFilter);
      setIsShown(false);
   }

   return (
      <div className={styles.filterMenuContainer}>
         <button onClick={handleToggleShown} className={styles.toggleButton}>
            <p>Filter</p>
            <ChevronDown color="var(--background-color)" />
         </button>
         <div className={`${styles.menu} ${isShown ? styles.isShown : ""}`}>
            <FilterItem
               filterParameter={1}
               isSelected={selectedFilter === 1}
               onClick={handleFilterItemClick}
            >
               Archived
            </FilterItem>
            <FilterItem
               filterParameter={0}
               isSelected={selectedFilter === 0}
               onClick={handleFilterItemClick}
            >
               Not Archived
            </FilterItem>
         </div>
      </div>
   );
}

export default FilterMenu;
