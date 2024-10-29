import React, { useState } from "react";
import styles from "./Radiobutton.module.css";

type RadioButtonProps = {
    children: string [];
};

export function RadioButtonSelect(props: RadioButtonProps) {
    const [selectedIndex, setSelectedIndex] =useState<number |null>(null);

    const handleChange = (index: number) => {
        setSelectedIndex(index);
    };

    return (
        <div className={styles.radioButton}>
            {props.children.map((option,index) => (
                <div key={index} className={styles.option}>
                    <label className={styles.customRadio}>
                        <input
                        type="radio"
                        name="radioGroup"
                        checked={selectedIndex === index}
                        onChange={() => handleChange(index)}
                        />
                        <span className={styles.radiomark}></span>
                        {option}
                    </label>
                </div>
            ))}
        </div>
    )
}