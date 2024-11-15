import React, { Dispatch, SetStateAction, useState } from "react";
import styles from "./Searchbar.module.css";
import { Search } from "lucide-react";
import QueryObject from "../../types/QueryObject";

type SearchbarUIProps = {
   value: string;
   placeholder: string;
   onSearch: (e: React.FormEvent<HTMLFormElement>) => void;
   onChange: (e: React.ChangeEvent<HTMLInputElement>) => void;
};

function SearchbarUI(props: SearchbarUIProps) {
   return (
      <form className={styles.searchbar} onSubmit={props.onSearch}>
         <input
            type="text"
            className={styles.searchTextbox}
            placeholder={props.placeholder}
            value={props.value}
            onChange={props.onChange}
         />
         <button className={styles.searchIcon} type="submit">
            <Search size={20} />
         </button>
      </form>
   );
}

type SearchbarProps = {
   setQueryObject: Dispatch<SetStateAction<QueryObject>>;
};

export function Searchbar({ setQueryObject }: SearchbarProps) {
   const [searchValue, setSearchValue] = useState("");

   const handleSearchChange = (e: React.ChangeEvent<HTMLInputElement>) => {
      const value = e.target.value;
      setSearchValue(value);
      console.log(value);

      setQueryObject((prevQueryObject: QueryObject) => {
         const newQueryObject: QueryObject = {
            ...prevQueryObject,
            name: value,
         };
         return newQueryObject;
      });
   };

   const handleSearchSubmit = (e: React.FormEvent<HTMLFormElement>) => {
      e.preventDefault();
   };

   return (
      <SearchbarUI
         value={searchValue}
         onSearch={handleSearchSubmit}
         onChange={handleSearchChange}
         placeholder="Search..."
      />
   );
}
