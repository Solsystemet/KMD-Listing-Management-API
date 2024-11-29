import { useState } from "react"; // Importing useState to handle state management
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
      <p>Data Transfer Info {index}</p>
      <InputBox templateText={"Company name"} />
      <InputBox templateText={"Address"} />
      <InputBox templateText={"Treatment of data"} />
      <InputBox templateText={"Transfer basis"} />
      <MultipleSelect>{`Is it KMD's sub data-processor?`}</MultipleSelect>
    </form>
  );
}

function DataProcessors({ index }: { index: number }) {
  return (
    <form className={styles.inputContainer}>
      <p>Data Processor Info {index}</p>
      <InputBox templateText={"Company name"} />
      <InputBox templateText={"Address"} />
      <InputBox templateText={"Treatment of data"} />
      <InputBox templateText={"Transfer basis"} />
      <MultipleSelect>{`Is it KMD's sub data-processor?`}</MultipleSelect>
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
  numberofDataProcessors: number;
};

export function Survey({
  numberOfContact,
  numberOfDataTransfers,
  numberofDataProcessors,
}: SurveyProps) {
  const [contactInfoCount, setContactInfoCount] = useState<number[]>(
    new Array(numberOfContact).fill(1)
  );
  const [dataTransfersCount, setDataTransfersCount] = useState<number[]>(
    new Array(numberOfDataTransfers).fill(1)
  );
  const [dataProcessorsCount, setDataProcessorsCount] = useState<number[]>(
    new Array(numberofDataProcessors).fill(1)
  );

  const addContactInfo = () => {
    setContactInfoCount((prev) => [...prev, prev.length + 1]);
  };

  const addDataTransfers = () => {
    setDataTransfersCount((prev) => [...prev, prev.length + 1]);
  };

  const addDataProcessors = () => {
    setDataProcessorsCount((prev) => [...prev, prev.length + 1]);
  };

  return (
    <div className={styles.surveyContainer}>
      <div className={styles.ContactInfoCont}>
        <h3>Contact info of Data Controller</h3>

        {contactInfoCount.map((_, index) => (
          <ContactInfo key={index} index={index + 1} />
        ))}
        <button onClick={addContactInfo} className={styles.addButton}>
          Add Contact Info
        </button>
      </div>

      <div className={styles.ContactInfoCont}>
        <h3>Contact info of Data Processor</h3>

        {dataProcessorsCount.map((_, index) => (
          <DataProcessors key={index} index={index + 1} />
        ))}
        <button onClick={addDataProcessors} className={styles.addButton}>
          Add Data Processor
        </button>
      </div>

      <div className={styles.dataCategories}>
        <h3>Data categories</h3>
        <MultipleSelect>
          {"Opperation"}
          {"Maintenance"}
          {"Support of the solution"}
        </MultipleSelect>
      </div>
      <div className={styles.dataTransfersContainer}>
        <h3>Data transfer info</h3>
        {dataTransfersCount.map((_, index) => (
          <DataTransfers key={index} index={index + 1} />
        ))}
        <button onClick={addDataTransfers} className={styles.addButton}>
          Add Data Transfer
        </button>
      </div>
      <div>
        <h3>
          Beskrivelse af tekniske og organisatoriske sikkerhedsforanstaltninger.
        </h3>
        <TextBox></TextBox>
      </div>
    </div>
  );
}
