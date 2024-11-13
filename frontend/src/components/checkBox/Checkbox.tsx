import styles from "./Checkbox.module.css";

type MultipleSelectProps = {
   children: string;
};

export function Checkbox({ children }: MultipleSelectProps) {
   return (
      <div className={styles.option}>
         <label className={styles.customCheckbox}>
            <input type="checkbox" />
            <span className={styles.checkmark}></span>
            {children}
         </label>
      </div>
   );
}
