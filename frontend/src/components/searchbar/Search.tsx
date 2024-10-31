import React, { useState } from "react";
import { Searchbar } from "./Searchbar"; 
import styles from "./Search.module.css";

export function Search() {
  const [searchValue, setSearchValue] = useState("");
  const [showSuggestions, setShowSuggestions] = useState(false);

  const handleSearchChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const value = e.target.value;
    setSearchValue(value);

    if (value.length > 0) {
      setShowSuggestions(true);
    } else {
      setShowSuggestions(false);
    }
  };

  return (
    <div className={styles.searchContainer}>
      <Searchbar
        value={searchValue}
        searchHandler={handleSearchChange}
        placeholder="Search..."
      />
      
      {showSuggestions && (
        <div className={styles.suggestionBox}>
          {}
          <p>Suggestions will appear here</p>
        </div>
      )}
    </div>
  );
}
