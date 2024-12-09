import { useEffect, useState } from "react";
import styles from "./MultipleSelect.module.css";

type SelectButtonProps = {
   children: string | string[];
   checked?: string | string[];
};

export function MultipleSelect(props: SelectButtonProps) {
   const options = Array.isArray(props.children)
      ? props.children
      : [props.children];
   const [isChecked, setIsChecked] = useState<boolean[]>(
      new Array(options.length).fill(false)
   );

   // If checked prop is passed, set the checked options

   useEffect(() => {
      if (props.checked !== undefined) {
         const preCheckedList = Array.isArray(props.checked)
            ? props.checked
            : [props.checked];
         options.map((option, index) => {
            preCheckedList.map(checkedOption => {
               if (option === checkedOption) {
                  setIsChecked(prevState => {
                     const newState = [...prevState];
                     newState[index] = true;
                     return newState;
                  });
               }
            });
         });
      }
   });

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
