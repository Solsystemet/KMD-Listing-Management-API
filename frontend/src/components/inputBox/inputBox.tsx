import React, { useState } from "react";
import styles from "./inputBox.module.css";

type InputBoxProps = {
   templateText: string;
};

function InputBox({ templateText }: InputBoxProps) {
   return (
      <input
         type="text"
         placeholder={templateText}
         className={styles.inputBox}
      />
   );
}

export default InputBox;