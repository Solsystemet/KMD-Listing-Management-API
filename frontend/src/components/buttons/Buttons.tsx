import { Link } from "@tanstack/react-router";
import styles from "./Buttons.module.css";
import React from "react";

type StandardButtonProps = {
   children: React.ReactNode;
   color?: string;
   backgroundColor?: string;
   fontSize?: string;
   border?: string;
   type?: "button" | "submit" | "reset";
   onClick?: () => void;
   disabled?: boolean;
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
         type={props.type}
         disabled={props.disabled}
      >
         {props.children}
      </button>
   );
}

type NavButtonProps = {
   children: React.ReactNode;
   fontSize?: string;
   color: string;
   href?: string;
   params?: string;
};

export function NavButton(props: NavButtonProps) {
   return (
      <Link
         className={styles.navButton}
         to={props.href}
         {...(props.params != undefined
            ? { params: { listingId: props.params } }
            : {})}
      >
         <p style={{ fontSize: props.fontSize, color: props.color }}>
            {props.children}
         </p>
      </Link>
   );
}

type ExportButtonProps = {
   children: React.ReactNode;
   color?: string;
   backgroundColor?: string;
   fontSize?: string;
   border?: string;
   onClick?: (listingsList: object) => void;
   disabled?: boolean;
};
export function ExportButton(props: ExportButtonProps) {
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
         disabled={props.disabled}
      >
         {props.children}
      </button>
   );
}