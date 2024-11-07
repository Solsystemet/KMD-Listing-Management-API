import React from "react";
import styles from "./SurveyTab.module.css";

type SurveyTabChild = {
    date: Date;
    company: string;
    projectName: string;
    dataProcessor: string;
};

type SurveyTabProps = {
    children: SurveyTabChild[];
};

export function SurveyTab({ children }: SurveyTabProps) {
    return (
        <div className={styles.surveyTabContainer}>
            {children.map((child, index) => (
                <div
                    key={index}
                    className={`${styles.surveyTab} ${
                        index % 2 === 0 ? styles.evenBackground : styles.oddBackground
                    }`}
                >
                    <p className={styles.date}>{child.date.toLocaleDateString()}</p>
                    <div className={styles.surveyTabInfo}>
                        <h2>{child.projectName}</h2>
                        <p>{child.company}</p>
                        <p>{child.dataProcessor}</p>
                    </div>
                </div>
            ))}
        </div>
    );
}