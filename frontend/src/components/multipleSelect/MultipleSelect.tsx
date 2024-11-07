import { useState } from "react";
import styles from "./MultipleSelect.module.css";

type SelectButtonProps = {
   children: string | string[];
};

export function MultipleSelect(props: SelectButtonProps) {
   const options = Array.isArray(props.children)
      ? props.children
      : [props.children];
   const [isChecked, setIsChecked] = useState<boolean[]>(
      new Array(options.length).fill(false)
   );

   const handleChange = (index: number) => {
      setIsChecked(prevState => {
         const newState = [...prevState];
         newState[index] = !newState[index];
         return newState;
      });
   };

   return (
      <div className={styles.checkBox}>
         {options.map((option, index) => (
            <div key={index} className={styles.option}>
               <label className={styles.customCheckbox}>
                  <input
                     type="checkbox"
                     checked={isChecked[index]}
                     onChange={() => handleChange(index)}
                  />
                  <span className={styles.checkmark}></span>
                  {option}
               </label>
            </div>
         ))}
      </div>
   );
}