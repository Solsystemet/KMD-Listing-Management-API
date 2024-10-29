import style from "./ProgressBar.module.css";
import { Children, ReactNode, cloneElement } from "react";

type ProgressBarProps = {
   children: ReactNode;
   onClickHandlers: Array<() => void>;
};

export function ProgressBar({ children, onClickHandlers }: ProgressBarProps) {
   return (
      <div className={style.progressBarContainer}>
         {Children.map(children, (child, index) =>
            cloneElement(child as React.ReactElement, {
               onClick: onClickHandlers[index],
               className: style.childElement,
               key: index,
            })
         )}
      </div>
   );
}
