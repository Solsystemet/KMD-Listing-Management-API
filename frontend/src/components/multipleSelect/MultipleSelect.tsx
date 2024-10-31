import { useState } from "react";
import styles from "./SelectButton.module.css";

type SelectButtonProps = {
   children: string[];
};

export function MultipleSelect(props: SelectButtonProps) {
   const [isChecked, setIsChecked] = useState<boolean[]>(
      new Array(props.children.length).fill(false)
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
         {props.children.map((option, index) => (
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
