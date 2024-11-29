import { useState } from "react"; // Importing useState to handle state management
import InputBox from "../inputBox/inputBox";
import { MultipleSelect } from "../multipleSelect/MultipleSelect";
import styles from "./Survey.module.css";
import NullableDataProcessor30ListingData, {
   NullableDataContactInfo,
   NullableDataController,
   NullableDataControllerRepresentative,
   NullableDataProcessor,
   NullableDataProcessorRepresentative,
   NullableSubProcessor,
} from "../../types/NullableDataProcessor30ListingData";

function ContactInfo({
   contactInfo,
   hasCvr,
   cvr,
   hasRole,
   role,
}: {
   contactInfo?: NullableDataContactInfo;
   hasCvr?: boolean;
   cvr?: string;
   hasRole?: boolean;
   role?: string;
}) {
   return (
      <>
         <InputBox
            templateText={"Name"}
            value={contactInfo && contactInfo.name ? contactInfo.name : ""}
         />
         {hasCvr && <InputBox templateText={"CVR"} value={cvr} />}
         {hasRole && <InputBox templateText={"Role"} value={role} />}
         <InputBox
            templateText={"Address"}
            value={
               contactInfo && contactInfo.address ? contactInfo.address : ""
            }
         />
         <InputBox
            templateText={"Telephone number"}
            value={
               contactInfo && contactInfo.phoneNo ? contactInfo.phoneNo : ""
            }
         />
         <InputBox
            templateText={"E-mail"}
            value={contactInfo && contactInfo.mail ? contactInfo.mail : ""}
         />
      </>
   );
}

function DataController({
   dataController,
}: {
   dataController: NullableDataController;
}) {
   return (
      <form className={styles.inputContainer}>
         <h2>Data Controller Info</h2>
         <ContactInfo
            hasCvr={true}
            cvr={dataController && dataController.cvr ? dataController.cvr : ""}
            contactInfo={dataController}
         />
      </form>
   );
}
function DataProcessor({
   dataProcessor,
}: {
   dataProcessor: NullableDataProcessor;
}) {
   return (
      <form className={styles.inputContainer}>
         <h2>Data Processor Info</h2>
         <ContactInfo
            hasCvr={true}
            cvr={dataProcessor && dataProcessor.cvr ? dataProcessor.cvr : ""}
            contactInfo={dataProcessor}
         />
      </form>
   );
}
function DataControllerRepresentative({
   dataControllerRepresentative,
}: {
   dataControllerRepresentative: NullableDataControllerRepresentative;
}) {
   return (
      <form className={styles.inputContainer}>
         <h2>Data Controller Representative Info</h2>
         <ContactInfo
            hasRole={true}
            role={
               dataControllerRepresentative && dataControllerRepresentative.role
                  ? dataControllerRepresentative.role
                  : ""
            }
            contactInfo={dataControllerRepresentative}
         />
      </form>
   );
}
function DataProcessorRepresentative({
   dataProcessorRepresentative,
}: {
   dataProcessorRepresentative: NullableDataProcessorRepresentative;
}) {
   return (
      <form className={styles.inputContainer}>
         <h2>Data Processor Representative Info</h2>
         <ContactInfo
            hasRole={true}
            role={
               dataProcessorRepresentative && dataProcessorRepresentative.role
                  ? dataProcessorRepresentative.role
                  : ""
            }
            contactInfo={dataProcessorRepresentative}
         />
      </form>
   );
}

function DataSubProcessors({
   index,
   subProcessor,
}: {
   index: number;
   subProcessor: NullableSubProcessor;
}) {
   return (
      <form className={styles.inputContainer}>
         <h3>Data Sub Processor Info {index}</h3>
         <InputBox
            templateText={"Company name"}
            value={subProcessor.name ? subProcessor.name : ""}
         />
         <InputBox
            templateText={"CVR"}
            value={subProcessor.cvr ? subProcessor.cvr : ""}
         />
         <InputBox
            templateText={"Address"}
            value={subProcessor.address ? subProcessor.address : ""}
         />
         <InputBox
            templateText={"Treatment of data"}
            value={subProcessor.treatment ? subProcessor.treatment : ""}
         />
         <MultipleSelect
            checked={
               subProcessor.directSubProcessor
                  ? "Is it KMD's sub data-processor?"
                  : undefined
            }
         >
            {"Is it KMD's sub data-processor?"}
         </MultipleSelect>
         <h4>Transfer basis</h4>
         <TextBox
            value={
               subProcessor.transferReason ? subProcessor.transferReason : ""
            }
         />
      </form>
   );
}

function TextBox({ value }: { value?: string }) {
   return (
      <textarea name="description" rows={5} className={styles.textBox}>
         {value}
      </textarea>
   );
}

type SurveyProps = {
   listingDataProp: NullableDataProcessor30ListingData;
};

export function Survey({ listingDataProp }: SurveyProps) {
   const [listingData, SetListingData] = useState(listingDataProp);

   function addDataProcessors() {
      SetListingData({
         ...listingData,
         dataSubProcessors: [
            ...listingData.dataSubProcessors,
            {
               name: "",
               cvr: "",
               address: "",
               treatment: "",
               directSubProcessor: false,
               transferReason: "",
            },
         ],
      });
   }

   return (
      <div className={styles.surveyContainer}>
         <div className={styles.ContactInfoCont}>
            <h1>Data Processor 30 Listing information</h1>
            <InputBox templateText={"Listing Name"} />

            <DataController dataController={listingData.dataController} />
            <DataProcessor dataProcessor={listingData.dataProcessor} />

            <DataControllerRepresentative
               dataControllerRepresentative={
                  listingData.dataControllerRepresentative
               }
            />
            <DataProcessorRepresentative
               dataProcessorRepresentative={
                  listingData.dataProcessorRepresentative
               }
            />

            <h2>Data Sub Processors</h2>
            {listingData.dataSubProcessors.map((subProcessor, index) => (
               <DataSubProcessors
                  key={index}
                  index={index + 1}
                  subProcessor={subProcessor}
               />
            ))}
            <button onClick={addDataProcessors} className={styles.addButton}>
               Add Data Processor
            </button>
            <h2>Beskrivelse af det information der bliver behandlet.</h2>
            <TextBox></TextBox>
            <h2>
               Beskrivelse af tekniske og organisatoriske
               sikkerhedsforanstaltninger.
            </h2>
            <TextBox></TextBox>
         </div>
      </div>
   );
}
