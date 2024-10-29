import React, { ChangeEventHandler } from "react";
import styles from "./Searchbar.module.css";
import { Search } from 'lucide-react';  

type SearchbarProps = {
  value: string;
  searchHandler: ChangeEventHandler<HTMLInputElement>;
  placeholder: string;
};

export function Searchbar(props: SearchbarProps) {
  return (
    <div className={styles.searchbarWrapper}> 
      <input
        type="text"
        className={styles.Searchbar}  
        placeholder={props.placeholder}
        value={props.value}
        onChange={props.searchHandler}
      />
      <div className={styles.searchIcon}> 
        <Search size={20} />
      </div>
    </div>
  );
}
