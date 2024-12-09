import React from "react";
import styles from "./inputBox.module.css";

type InputBoxProps = {
   getFieldValuetemplateText: string;
   id: string;
   name: string;
   value: string;
   onBlur: (e: React.FocusEvent<HTMLInputElement>) => void;
   onChange: (e: React.ChangeEvent<HTMLInputElement>) => void;
   required?: boolean;
};

function InputBox(props: InputBoxProps) {
   return (
      <input
         type="text"
         placeholder={props.templateText}
         className={styles.inputBox}
         id={props.id}
         name={props.name}
         value={props.value}
         onBlur={props.onBlur}
         onChange={props.onChange}
         required={props.required}
      />
   );
}

export default InputBox;
