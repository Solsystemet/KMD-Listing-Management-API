import styles from "./Buttons.module.css";
import React from "react";

type StandardButtonProps = {
   children: React.ReactNode;
   color: string;
   backgroundColor?: string;
   fontSize: string;
   border?: string;
   onClick?: () => void;
};

export function StandardButton(props: StandardButtonProps) {
   return (
      <button
         style={{
            color: props.color,
            backgroundColor: props.backgroundColor,
            fontSize: props.fontSize,
            border: props.border,
         }}
         className={styles.standardButton}
         onClick={props.onClick}
      >
         {props.children}
      </button>
   );
}

type NavButtonProps = {
   children: React.ReactNode;
   fontSize: string;
   color: string;
   href?: string;
};

export function NavButton(props: NavButtonProps) {
   return (
      <div className={styles.navButton}>
         <a
            href={props.href}
            style={{ fontSize: props.fontSize, color: props.color }}
         >
            {props.children}
         </a>
      </div>
   );
}
