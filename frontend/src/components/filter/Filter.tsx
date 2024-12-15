import { Dispatch, SetStateAction, useState } from "react";
import styles from "./Filter.module.css"
import { ChevronDown } from "lucide-react";
import QueryObject from "../../types/QueryObject";

type FilterItemProps = {
   children: string;
   filterParameter: "All" | "Archived" | "Not archived";
   isSelected: boolean;
   onClick: (value: "All" | "Archived" | "Not archived") => void;
};

function FilterItem({children, filterParameter, isSelected, onClick}: FilterItemProps) {
    return (
        <button
        onClick={() => onClick(filterParameter)}
        className={`${styles.filterItemButton} ${isSelected ? styles.selected : ""}`}
        >
            {children}
        </button>
    );
}

type FilterMenuProps= {
    setQueryObject: Dispatch<SetStateAction<QueryObject>>;
};

export function FilterMenu({setQueryObject}: FilterMenuProps) {
    const [isShown, setIsShown] = useState(false);
    const [selectedFilter, setSelectedFilter] = useState<"All" | "Archived" | "Not archived">("All");
    
    function handleToggleShown() {
        setIsShown(!isShown);
    }

    function handleFilterItemClick(value: "All" | "Archived" | "Not Archived") {
        setSelectedFilter(value);
        setQueryObject((prevQueryObject: QueryObject) => {
          const newQueryObject: QueryObject = {
            ...prevQueryObject,
            filterBy: value === "All" ? null : value.toLowerCase(),
          };
          return newQueryObject;
        });
        setIsShown(false); // Hide menu after selecting a filter
      }
    
      return (
        <div className={styles.filterMenuContainer}>
          <button onClick={handleToggleShown} className={styles.toggleButton}>
            <p>Filter</p>
            <ChevronDown color="var(--background-color)" />
          </button>
          <div className={`${styles.menu} ${isShown ? styles.isShown : ""}`}>
            <FilterItem
              filterParameter="All"
              isSelected={selectedFilter === "All"}
              onClick={handleFilterItemClick}
            >
              All
            </FilterItem>
            <FilterItem
              filterParameter="Archived"
              isSelected={selectedFilter === "Archived"}
              onClick={handleFilterItemClick}
            >
              Archived
            </FilterItem>
            <FilterItem
              filterParameter="Not Archived"
              isSelected={selectedFilter === "Not Archived"}
              onClick={handleFilterItemClick}
            >
              Not Archived
            </FilterItem>
          </div>
        </div>
      );
    }

export default FilterMenu;