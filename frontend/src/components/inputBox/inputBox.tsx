import styles from "./inputBox.module.css";

type InputBoxProps = {
   templateText: string;
   value?: string;
};

function InputBox({ templateText, value }: InputBoxProps) {
   return (
      <input
         type="text"
         placeholder={templateText}
         className={styles.inputBox}
         value={value}
      />
   );
}

export default InputBox;
