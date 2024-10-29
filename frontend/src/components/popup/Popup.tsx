import React from "react";
import styles from "./Popup.module.css";
import { StandardButton } from "../buttons/Buttons";

type PopUpType = {
   header: string;
   text: string;
   color: string;
   isShown: boolean;
   buttonText: string[];
   onClickOptions: (() => void)[];
};

export function PopUp(props: PopUpType) {
   return (
      <div
         className={`${styles.popUp} ${
            props.isShown ? styles.show : styles.hide
         }`}
         style={{ backgroundColor: props.color }}
      >
         <div className={styles.textContainer}>
            <h3>{props.header}</h3>
            <p>{props.text}</p>
         </div>
         <div className={styles.buttonContainer}>
            <StandardButton
               color={"black"}
               backgroundColor={"white"}
               fontSize={"1rem"}
               onClick={props.onClickOptions[0]}
            >
               {props.buttonText[0]}
            </StandardButton>
            <StandardButton
               color="white"
               backgroundColor={"var(--secondary-color)"}
               fontSize={"1rem"}
               onClick={props.onClickOptions[1]}
            >
               {props.buttonText[1]}
            </StandardButton>
         </div>
      </div>
   );
}
