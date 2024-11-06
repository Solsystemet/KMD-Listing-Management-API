import InputBox from "../inputBox/inputBox";
import { MultipleSelect } from "../multipleSelect/MultipleSelect";
import styles from "./Survey.module.css";

function ContactInfo({ index }: { index: number }) {
   return (
      <form className={styles.inputContainer}>
         <p>Contact Info {index}</p>
         <InputBox templateText={"Name"} />
         <InputBox templateText={"Position"} />
         <InputBox templateText={"Telephone number"} />
         <InputBox templateText={"E-mail"} />
      </form>
   );
}

function DataTransfers({ index }: { index: number }) {
   return (
      <form className={styles.inputContainer}>
         <p>Contact Info {index}</p>
         <InputBox templateText={"Company name"} />
         <InputBox templateText={"Address"} />
         <InputBox templateText={"Treatment of data"} />
         <InputBox templateText={"Transfer basis"} />
         <MultipleSelect>{"Is it KMDs sub data-processor?"}</MultipleSelect>
      </form>
   );
}

function TextBox() {
   return (
      <textarea
         name="description"
         rows={20}
         className={styles.textBox}
      ></textarea>
   );
}

type SurveyProps = {
   numberOfContact: number;
   numberOfDataTransfers: number;
};

export function Survey({
   numberOfContact,
   numberOfDataTransfers,
}: SurveyProps) {
   return (
      <div className={styles.surveyContainer}>
         <div className={styles.ContactInfoCont}>
            <h3>Contact info of controller</h3>

            {Array.from({ length: numberOfContact }).map((_, index) => (
               <ContactInfo index={index + 1} />
            ))}
         </div>
         <div className={styles.dataCategories}>
            <h3>Data categories</h3>
            <MultipleSelect>
               {"School administrators"}
               {"School management"}
               {"Teachers"}
               {"Other employees"}
               {"Students"}
               {"Parents to students under 18 years old"}
            </MultipleSelect>
         </div>
         <div className={styles.dataTransfersContainer}>
            <h3>Data transfer info</h3>

            {Array.from({ length: numberOfDataTransfers }).map((_, index) => (
               <DataTransfers index={index + 1} />
            ))}
         </div>
         <div>
            <h3>
               Beskrivelse af tekniske og organisatoriske
               sikkerhedsforanstaltninger.
            </h3>
            <TextBox></TextBox>
         </div>
      </div>
   );
}
