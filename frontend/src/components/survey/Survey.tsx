import { useState } from "react"; // Importing useState to handle state management
import InputBox from "../inputBox/inputBox";
import { useForm, Field } from "@tanstack/react-form";
import { Checkbox } from "../checkBox/CheckBox";
import styles from "./Survey.module.css";
import NullableDataProcessor30ListingData from "../../types/NullableDataProcessor30ListingData";

function FieldInfo({ field }: { field: Field<any, any, any, any> }) {
   return (
      <>
         {field.state.meta.isTouched && field.state.meta.errors.length ? (
            <em>{field.state.meta.errors.join(", ")}</em>
         ) : null}
         {field.state.meta.isValidating ? "Validating..." : null}
      </>
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

   const form = useForm({
      onSubmit: async values => {
         console.log(values);
      },
   });

   const handleSubmit = (event: React.FormEvent) => {
      event.preventDefault();
      form.handleSubmit();
   };

   const handleChange = () => {
      console.log("goodt!! 13:10");
   };

   return (
      <div className={styles.surveyContainer}>
         {/* Listing information */}
         <div className={styles.ContactInfoCont}>
            <Field form={form} name="listingName">
               {field => (
                  <div className={styles.inputContainer}>
                     <h1>Data Processor 30 Listing information</h1>
                     <InputBox
                        templateText="Enter listing name"
                        id={field.name}
                        name={field.name}
                        value={listingData.name || ""}
                        onBlur={field.handleBlur}
                        onChange={e => field.handleChange(e.target.value)}
                     />
                     <FieldInfo field={field} />
                  </div>
               )}
               <div />
            </Field>

            {/* Data controller representative */}
            <Field form={form} name="dataControllerRepresentative">
               {field => (
                  <div className={styles.inputContainer}>
                     <h2>Data Controller Representative info</h2>
                     <InputBox
                        id={`dataControllerRepresentative.name`}
                        name={`dataControllerRepresentative.name`}
                        templateText={"Name"}
                        value={
                           listingData.dataControllerRepresentative.name || ""
                        }
                        onBlur={field.handleBlur}
                        onChange={field.handleChange}
                     />
                     <FieldInfo field={field} />
                     <InputBox
                        id={`dataControllerRepresentative.role`}
                        name={`dataControllerRepresentative.role`}
                        templateText={"Role"}
                        value={
                           listingData.dataControllerRepresentative.role || ""
                        }
                        onBlur={field.handleBlur}
                        onChange={field.handleChange}
                     />
                     <FieldInfo field={field} />
                     <InputBox
                        id={`dataControllerRepresentative.address`}
                        name={`dataControllerRepresentative.address`}
                        templateText={"Address"}
                        value={
                           listingData.dataControllerRepresentative.address ||
                           ""
                        }
                        onBlur={field.handleBlur}
                        onChange={field.handleChange}
                     />
                     <FieldInfo field={field} />
                     <InputBox
                        id={`dataControllerRepresentative.phoneNo`}
                        name={`dataControllerRepresentative.phoneNo`}
                        templateText={"Phone number"}
                        value={
                           listingData.dataControllerRepresentative.phoneNo ||
                           ""
                        }
                        onBlur={field.handleBlur}
                        onChange={field.handleChange}
                     />
                     <FieldInfo field={field} />
                     <InputBox
                        id={`dataControllerRepresentative.mail`}
                        name={`dataControllerRepresentative.mail`}
                        templateText={"E-mail"}
                        value={
                           listingData.dataControllerRepresentative.mail || ""
                        }
                        onBlur={field.handleBlur}
                        onChange={field.handleChange}
                     />
                     <FieldInfo field={field} />
                  </div>
               )}
            </Field>

            {/* Data processor representative */}
            <Field form={form} name="dataProcessorRepresentative">
               {field => (
                  <div className={styles.inputContainer}>
                     <h2>Data Processor Representative info</h2>
                     <InputBox
                        id={`dataProcessorRepresentative.name`}
                        name={`dataProcessorRepresentative.name`}
                        templateText={"Name"}
                        value={
                           listingData.dataProcessorRepresentative.name || ""
                        }
                        onBlur={field.handleBlur}
                        onChange={field.handleChange}
                     />
                     <FieldInfo field={field} />
                     <InputBox
                        id={`dataProcessorRepresentative.role`}
                        name={`dataProcessorRepresentative.role`}
                        templateText={"Role"}
                        value={
                           listingData.dataProcessorRepresentative.role || ""
                        }
                        onBlur={field.handleBlur}
                        onChange={field.handleChange}
                     />
                     <FieldInfo field={field} />
                     <InputBox
                        id={`dataProcessorRepresentative.address`}
                        name={`dataProcessorRepresentative.address`}
                        templateText={"Address"}
                        value={
                           listingData.dataProcessorRepresentative.address || ""
                        }
                        onBlur={field.handleBlur}
                        onChange={field.handleChange}
                     />
                     <FieldInfo field={field} />
                     <InputBox
                        id={`dataProcessorRepresentative.phoneNo`}
                        name={`dataProcessorRepresentative.phoneNo`}
                        templateText={"Phone number"}
                        value={
                           listingData.dataProcessorRepresentative.phoneNo || ""
                        }
                        onBlur={field.handleBlur}
                        onChange={field.handleChange}
                     />
                     <FieldInfo field={field} />
                     <InputBox
                        id={`dataProcessorRepresentative.mail`}
                        name={`dataProcessorRepresentative.mail`}
                        templateText={"E-mail"}
                        value={
                           listingData.dataProcessorRepresentative.mail || ""
                        }
                        onBlur={field.handleBlur}
                        onChange={field.handleChange}
                     />
                     <FieldInfo field={field} />
                  </div>
               )}
            </Field>

            {/* Data controller */}
            <Field form={form} name="dataController">
               {field => (
                  <div className={styles.inputContainer}>
                     <h2>Data Controller Info</h2>
                     <InputBox
                        id={`dataController.name`}
                        name={`dataController.name`}
                        templateText={"Company name"}
                        value={listingData.dataController.name || ""}
                        onBlur={field.handleBlur}
                        onChange={field.handleChange}
                     />
                     <FieldInfo field={field} />
                     <InputBox
                        id={`dataController.cvr`}
                        name={`dataController.cvr`}
                        templateText={"CVR"}
                        value={listingData.dataController.cvr || ""}
                        onBlur={field.handleBlur}
                        onChange={field.handleChange}
                     />
                     <FieldInfo field={field} />
                     <InputBox
                        id={`dataController.address`}
                        name={`dataController.address`}
                        templateText={"Address"}
                        value={listingData.dataController.address || ""}
                        onBlur={field.handleBlur}
                        onChange={field.handleChange}
                     />
                     <FieldInfo field={field} />
                     <InputBox
                        id={`dataController.phoneNo`}
                        name={`dataController.phoneNo`}
                        templateText={"Phone number"}
                        value={listingData.dataController.phoneNo || ""}
                        onBlur={field.handleBlur}
                        onChange={field.handleChange}
                     />
                     <FieldInfo field={field} />
                     <InputBox
                        id={`dataController.mail`}
                        name={`dataController.mail`}
                        templateText={"E-mail"}
                        value={listingData.dataController.mail || ""}
                        onBlur={field.handleBlur}
                        onChange={field.handleChange}
                     />
                     <FieldInfo field={field} />
                  </div>
               )}
            </Field>

            {/* Sub processors */}
            <h2>Data Sub Processors</h2>
            {listingData.dataSubProcessors.map((subProcessor, index) => (
               <div key={index}>
                  <Field form={form} name={`dataSubProcessor.${index}`}>
                     {field => (
                        <div className={styles.inputContainer}>
                           <h3>Data Sub Processor Info {index}</h3>
                           <InputBox
                              id={`dataSubProcessor.${index}.name`}
                              name={`dataSubProcessor.${index}.name`}
                              templateText={"Company name"}
                              value={subProcessor.name ? subProcessor.name : ""}
                              onBlur={field.handleBlur}
                              onChange={handleChange}
                           />
                           <FieldInfo field={field} />
                           <InputBox
                              id={`dataSubProcessor.${index}.cvr`}
                              name={`dataSubProcessor.${index}.cvr`}
                              templateText={"CVR"}
                              value={subProcessor.cvr ? subProcessor.cvr : ""}
                              onBlur={field.handleBlur}
                              onChange={handleChange}
                           />
                           <FieldInfo field={field} />
                           <InputBox
                              id={`dataSubProcessor.${index}.address`}
                              name={`dataSubProcessor.${index}.address`}
                              templateText={"Address"}
                              value={
                                 subProcessor.address
                                    ? subProcessor.address
                                    : ""
                              }
                              onBlur={field.handleBlur}
                              onChange={handleChange}
                           />
                           <FieldInfo field={field} />
                           <Checkbox> "Is KMD the sub-processor" </Checkbox>
                           <FieldInfo field={field} />
                           <h4>Transfer reason</h4>
                           <TextBox></TextBox>
                        </div>
                     )}
                  </Field>
               </div>
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
