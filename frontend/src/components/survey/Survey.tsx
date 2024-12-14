import { useState } from "react"; // Importing useState to handle state management
import InputBox from "../inputBox/inputBox";
import { useForm, FieldApi } from "@tanstack/react-form";
import { Checkbox } from "../checkBox/CheckBox";
import styles from "./Survey.module.css";
import NullableDataProcessor30ListingData from "../../types/NullableDataProcessor30ListingData";
import { StandardButton } from "../buttons/Buttons";
import { DataProcessor30ListingDataDto } from "../../types/DataProcessor30ListingData";

function FieldInfo<TFieldValue>({
   field,
}: {
   // eslint-disable-next-line @typescript-eslint/no-explicit-any
   field: FieldApi<TFieldValue, any, any, any, any>;
}) {
   return (
      <>
         {field.state.meta.isTouched && field.state.meta.errors.length ? (
            <em>{field.state.meta.errors.join(", ")}</em>
         ) : null}
         {field.state.meta.isValidating ? "Validating..." : null}
      </>
   );
}

type TextBoxProps = {
   templateText: string;
   id: string;
   name: string;
   value: string;
   readOnly: boolean;
   onBlur: (e: React.FocusEvent<HTMLTextAreaElement>) => void;
   onChange: (e: React.ChangeEvent<HTMLTextAreaElement>) => void;
   required?: boolean;
};

function TextBox(props: TextBoxProps) {
   return (
      <textarea
         placeholder={props.templateText}
         className={styles.textBox}
         id={props.id}
         name={props.name}
         value={props.value}
         onBlur={props.onBlur}
         onChange={props.onChange}
         required={props.required}
         readOnly={props.readOnly}
         rows={5}
      />
   );
}

type SurveyProps = {
   listingData: NullableDataProcessor30ListingData;
   handleSubmit: (listing: DataProcessor30ListingDataDto) => void;
};

export function Survey({ listingData, handleSubmit }: SurveyProps) {
   const [
      hasJustAddedOrRemovedDataSubProcessor,
      setHasJustAddedOrRemovedDataSubProcessor,
   ] = useState(false); // Should be removed if possible (used to make sure the POST request is not posted when a subProcessor is added or removed)

   const form = useForm({
      defaultValues: {
         name: listingData.name || "",
         dataController: {
            name: listingData.dataController.name || "",
            cvr: listingData.dataController.cvr || "",
            address: listingData.dataController.address || "",
            phoneNo: listingData.dataController.phoneNo || "",
            mail: listingData.dataController.mail || "",
         },
         dataProcessor: {
            name: listingData.dataProcessor.name || "",
            cvr: listingData.dataProcessor.cvr || "",
            address: listingData.dataProcessor.address || "",
            phoneNo: listingData.dataProcessor.phoneNo || "",
            mail: listingData.dataProcessor.mail || "",
         },
         dataControllerRepresentative: {
            name: listingData.dataControllerRepresentative.name || "",
            role: listingData.dataControllerRepresentative.role || "",
            address: listingData.dataControllerRepresentative.address || "",
            phoneNo: listingData.dataControllerRepresentative.phoneNo || "",
            mail: listingData.dataControllerRepresentative.mail || "",
         },
         dataProcessorRepresentative: {
            name: listingData.dataProcessorRepresentative.name || "",
            role: listingData.dataProcessorRepresentative.role || "",
            address: listingData.dataProcessorRepresentative.address || "",
            phoneNo: listingData.dataProcessorRepresentative.phoneNo || "",
            mail: listingData.dataProcessorRepresentative.mail || "",
         },
         dataSubProcessors: listingData.dataSubProcessors.map(subProcessor => ({
            name: subProcessor.name || "",
            cvr: subProcessor.cvr || "",
            address: subProcessor.address || "",
            treatment: subProcessor.treatment || "",
            directSubProcessor: subProcessor.directSubProcessor || false,
            transferReason: subProcessor.transferReason || "",
            parentCompany: subProcessor.parentCompany || "",
         })),
         dataSecurity: {
            securityMeasures: listingData.dataSecurity.securityMeasures || "",
         },
         dataCategories: {
            categoryList:
               listingData.dataCategories.categoryList ||
               "Operation, maintenance & support of the solution",
         },
      },
      onSubmit: async values => {
         if (hasJustAddedOrRemovedDataSubProcessor) {
            setHasJustAddedOrRemovedDataSubProcessor(false);
            return;
         }
         console.log(await JSON.stringify(values.value));
         handleSubmit(values.value);
      },
   });

   const handleChange = (value: string) => {
      console.log(value);
   };

   return (
      <div className={styles.surveyContainer}>
         <form
            onSubmit={e => {
               e.preventDefault();
               e.stopPropagation();
               form.handleSubmit();
            }}
         >
            {/* Listing information */}
            <div className={styles.ContactInfoCont}>
               <form.Field name="name">
                  {field => (
                     <div className={styles.inputContainer}>
                        <h1>Data Processor 30 Listing information</h1>
                        <InputBox
                           templateText="Enter listing name"
                           id={field.name}
                           name={field.name}
                           value={field.state.value}
                           onBlur={field.handleBlur}
                           onChange={e => {
                              field.handleChange(e.target.value);
                              handleChange(e.target.value);
                           }}
                           required={false}
                        />
                        <FieldInfo field={field} />
                     </div>
                  )}
               </form.Field>
               <div />

               {/* Data controller */}
               <form.Field name="dataController">
                  {field => (
                     <div className={styles.inputContainer}>
                        <h2>Data Controller Info</h2>
                        <InputBox
                           id={`dataController.name`}
                           name={`dataController.name`}
                           templateText={"Company name"}
                           value={field.state.value?.name}
                           onBlur={field.handleBlur}
                           onChange={e => {
                              field.handleChange({
                                 ...field.state.value,
                                 name: e.target.value,
                              });
                              handleChange(e.target.value);
                           }}
                           required={false}
                        />
                        <FieldInfo field={field} />
                        <InputBox
                           id={`dataController.cvr`}
                           name={`dataController.cvr`}
                           templateText={"CVR"}
                           value={field.state.value?.cvr}
                           onBlur={field.handleBlur}
                           onChange={e => {
                              field.handleChange({
                                 ...field.state.value,
                                 cvr: e.target.value,
                              });
                              handleChange(e.target.value);
                           }}
                           required={false}
                        />
                        <FieldInfo field={field} />
                        <InputBox
                           id={`dataController.address`}
                           name={`dataController.address`}
                           templateText={"Address"}
                           value={field.state.value?.address}
                           onBlur={field.handleBlur}
                           onChange={e => {
                              field.handleChange({
                                 ...field.state.value,
                                 address: e.target.value,
                              });
                              handleChange(e.target.value);
                           }}
                           required={false}
                        />
                        <FieldInfo field={field} />
                        <InputBox
                           id={`dataController.phoneNo`}
                           name={`dataController.phoneNo`}
                           templateText={"Phone number"}
                           value={field.state.value?.phoneNo}
                           onBlur={field.handleBlur}
                           onChange={e => {
                              field.handleChange({
                                 ...field.state.value,
                                 phoneNo: e.target.value,
                              });
                              handleChange(e.target.value);
                           }}
                           required={false}
                        />
                        <FieldInfo field={field} />
                        <InputBox
                           id={`dataController.mail`}
                           name={`dataController.mail`}
                           templateText={"E-mail"}
                           value={field.state.value?.mail}
                           onBlur={field.handleBlur}
                           onChange={e => {
                              field.handleChange({
                                 ...field.state.value,
                                 mail: e.target.value,
                              });
                              handleChange(e.target.value);
                           }}
                           required={false}
                        />
                        <FieldInfo field={field} />
                     </div>
                  )}
               </form.Field>

               {/* Data processor */}
               <form.Field name="dataProcessor">
                  {field => (
                     <div className={styles.inputContainer}>
                        <h2>Data Processor Info</h2>
                        <InputBox
                           id={`dataProcessor.name`}
                           name={`dataProcessor.name`}
                           templateText={"Company name"}
                           value={field.state.value?.name}
                           onBlur={field.handleBlur}
                           onChange={e => {
                              field.handleChange({
                                 ...field.state.value,
                                 name: e.target.value,
                              });
                              handleChange(e.target.value);
                           }}
                           required={false}
                        />
                        <FieldInfo field={field} />
                        <InputBox
                           id={`dataProcessor.cvr`}
                           name={`dataProcessor.cvr`}
                           templateText={"CVR"}
                           value={field.state.value?.cvr}
                           onBlur={field.handleBlur}
                           onChange={e => {
                              field.handleChange({
                                 ...field.state.value,
                                 cvr: e.target.value,
                              });
                              handleChange(e.target.value);
                           }}
                           required={false}
                        />
                        <FieldInfo field={field} />
                        <InputBox
                           id={`dataProcessor.address`}
                           name={`dataProcessor.address`}
                           templateText={"Address"}
                           value={field.state.value?.address}
                           onBlur={field.handleBlur}
                           onChange={e => {
                              field.handleChange({
                                 ...field.state.value,
                                 address: e.target.value,
                              });
                              handleChange(e.target.value);
                           }}
                           required={false}
                        />
                        <FieldInfo field={field} />
                        <InputBox
                           id={`dataProcessor.phoneNo`}
                           name={`dataProcessor.phoneNo`}
                           templateText={"Phone number"}
                           value={field.state.value?.phoneNo}
                           onBlur={field.handleBlur}
                           onChange={e => {
                              field.handleChange({
                                 ...field.state.value,
                                 phoneNo: e.target.value,
                              });
                              handleChange(e.target.value);
                           }}
                           required={false}
                        />
                        <FieldInfo field={field} />
                        <InputBox
                           id={`dataProcessor.mail`}
                           name={`dataProcessor.mail`}
                           templateText={"E-mail"}
                           value={field.state.value?.mail}
                           onBlur={field.handleBlur}
                           onChange={e => {
                              field.handleChange({
                                 ...field.state.value,
                                 mail: e.target.value,
                              });
                              handleChange(e.target.value);
                           }}
                           required={false}
                        />
                        <FieldInfo field={field} />
                     </div>
                  )}
               </form.Field>

               {/* Data controller representative */}
               <form.Field name="dataControllerRepresentative">
                  {field => (
                     <div className={styles.inputContainer}>
                        <h2>Data Controller Representative info</h2>
                        <InputBox
                           id={`dataControllerRepresentative.name`}
                           name={`dataControllerRepresentative.name`}
                           templateText={"Name"}
                           value={field.state.value?.name}
                           onBlur={field.handleBlur}
                           onChange={e => {
                              field.handleChange({
                                 ...field.state.value,
                                 name: e.target.value,
                              });
                              handleChange(e.target.value);
                           }}
                           required={false}
                        />
                        <FieldInfo field={field} />
                        <InputBox
                           id={`dataControllerRepresentative.role`}
                           name={`dataControllerRepresentative.role`}
                           templateText={"Role"}
                           value={field.state.value?.role}
                           onBlur={field.handleBlur}
                           onChange={e => {
                              field.handleChange({
                                 ...field.state.value,
                                 role: e.target.value,
                              });
                              handleChange(e.target.value);
                           }}
                           required={false}
                        />
                        <FieldInfo field={field} />
                        <InputBox
                           id={`dataControllerRepresentative.address`}
                           name={`dataControllerRepresentative.address`}
                           templateText={"Address"}
                           value={field.state.value?.address}
                           onBlur={field.handleBlur}
                           onChange={e => {
                              field.handleChange({
                                 ...field.state.value,
                                 address: e.target.value,
                              });
                              handleChange(e.target.value);
                           }}
                           required={false}
                        />
                        <FieldInfo field={field} />
                        <InputBox
                           id={`dataControllerRepresentative.phoneNo`}
                           name={`dataControllerRepresentative.phoneNo`}
                           templateText={"Phone number"}
                           value={field.state.value?.phoneNo}
                           onBlur={field.handleBlur}
                           onChange={e => {
                              field.handleChange({
                                 ...field.state.value,
                                 phoneNo: e.target.value,
                              });
                              handleChange(e.target.value);
                           }}
                           required={false}
                        />
                        <FieldInfo field={field} />
                        <InputBox
                           id={`dataControllerRepresentative.mail`}
                           name={`dataControllerRepresentative.mail`}
                           templateText={"E-mail"}
                           value={field.state.value?.mail}
                           onBlur={field.handleBlur}
                           onChange={e => {
                              field.handleChange({
                                 ...field.state.value,
                                 mail: e.target.value,
                              });
                              handleChange(e.target.value);
                           }}
                           required={false}
                        />
                        <FieldInfo field={field} />
                     </div>
                  )}
               </form.Field>

               {/* Data processor representative */}
               <form.Field name="dataProcessorRepresentative">
                  {field => (
                     <div className={styles.inputContainer}>
                        <h2>Data Processor Representative info</h2>
                        <InputBox
                           id={`dataProcessorRepresentative.name`}
                           name={`dataProcessorRepresentative.name`}
                           templateText={"Name"}
                           value={field.state.value?.name}
                           onBlur={field.handleBlur}
                           onChange={e => {
                              field.handleChange({
                                 ...field.state.value,
                                 name: e.target.value,
                              });
                              handleChange(e.target.value);
                           }}
                           required={false}
                        />
                        <FieldInfo field={field} />
                        <InputBox
                           id={`dataProcessorRepresentative.role`}
                           name={`dataProcessorRepresentative.role`}
                           templateText={"Role"}
                           value={field.state.value?.role}
                           onBlur={field.handleBlur}
                           onChange={e => {
                              field.handleChange({
                                 ...field.state.value,
                                 role: e.target.value,
                              });
                              handleChange(e.target.value);
                           }}
                           required={false}
                        />
                        <FieldInfo field={field} />
                        <InputBox
                           id={`dataProcessorRepresentative.address`}
                           name={`dataProcessorRepresentative.address`}
                           templateText={"Address"}
                           value={field.state.value?.address}
                           onBlur={field.handleBlur}
                           onChange={e => {
                              field.handleChange({
                                 ...field.state.value,
                                 address: e.target.value,
                              });
                              handleChange(e.target.value);
                           }}
                           required={false}
                        />
                        <FieldInfo field={field} />
                        <InputBox
                           id={`dataProcessorRepresentative.phoneNo`}
                           name={`dataProcessorRepresentative.phoneNo`}
                           templateText={"Phone number"}
                           value={field.state.value?.phoneNo}
                           onBlur={field.handleBlur}
                           onChange={e => {
                              field.handleChange({
                                 ...field.state.value,
                                 phoneNo: e.target.value,
                              });
                              handleChange(e.target.value);
                           }}
                           required={false}
                        />
                        <FieldInfo field={field} />
                        <InputBox
                           id={`dataProcessorRepresentative.mail`}
                           name={`dataProcessorRepresentative.mail`}
                           templateText={"E-mail"}
                           value={field.state.value?.mail}
                           onBlur={field.handleBlur}
                           onChange={e => {
                              field.handleChange({
                                 ...field.state.value,
                                 mail: e.target.value,
                              });
                              handleChange(e.target.value);
                           }}
                           required={false}
                        />
                        <FieldInfo field={field} />
                     </div>
                  )}
               </form.Field>

               {/* Sub processors */}
               <h2>Data Sub Processors</h2>
               <form.Field name="dataSubProcessors" mode="array">
                  {subProcessorField => (
                     <div
                        className={`${styles.inputContainer} ${styles.subProcessorContainer}`}
                     >
                        {subProcessorField.state.value.map((_, index) => (
                           <>
                              <form.Field
                                 name={`dataSubProcessors[${index}].name`}
                              >
                                 {field => (
                                    <>
                                       <h3>
                                          Data Sub Processor Info {index + 1}
                                          <StandardButton
                                             backgroundColor="#ff4d4f"
                                             color="white"
                                             onClick={() => {
                                                setHasJustAddedOrRemovedDataSubProcessor(
                                                   true
                                                );
                                                subProcessorField.removeValue(
                                                   index
                                                );
                                             }}
                                          >
                                             X
                                          </StandardButton>
                                       </h3>
                                       <InputBox
                                          id={`dataSubProcessor[${index}].name`}
                                          name={`dataSubProcessor[${index}].name`}
                                          templateText={"Company name"}
                                          value={field.state.value}
                                          onBlur={field.handleBlur}
                                          onChange={e => {
                                             field.handleChange(e.target.value);
                                             handleChange(e.target.value);
                                          }}
                                          required={false}
                                       />
                                       <FieldInfo field={field} />
                                    </>
                                 )}
                              </form.Field>
                              <form.Field
                                 name={`dataSubProcessors[${index}].cvr`}
                              >
                                 {field => (
                                    <>
                                       <InputBox
                                          id={`dataSubProcessor[${index}].cvr`}
                                          name={`dataSubProcessor[${index}].cvr`}
                                          templateText={"CVR"}
                                          value={field.state.value}
                                          onBlur={field.handleBlur}
                                          onChange={e => {
                                             field.handleChange(e.target.value);
                                             handleChange(e.target.value);
                                          }}
                                          required={false}
                                       />
                                       <FieldInfo field={field} />
                                    </>
                                 )}
                              </form.Field>
                              <form.Field
                                 name={`dataSubProcessors[${index}].address`}
                              >
                                 {field => (
                                    <>
                                       <InputBox
                                          id={`dataSubProcessor[${index}].address`}
                                          name={`dataSubProcessor[${index}].address`}
                                          templateText={"Address"}
                                          value={field.state.value}
                                          onBlur={field.handleBlur}
                                          onChange={e => {
                                             field.handleChange(e.target.value);
                                             handleChange(e.target.value);
                                          }}
                                          required={false}
                                       />
                                       <FieldInfo field={field} />
                                    </>
                                 )}
                              </form.Field>
                              <form.Field
                                 name={`dataSubProcessors[${index}].treatment`}
                              >
                                 {field => (
                                    <>
                                       <InputBox
                                          id={`dataSubProcessor[${index}].treatment`}
                                          name={`dataSubProcessor[${index}].treatment`}
                                          templateText={"treatment"}
                                          value={field.state.value}
                                          onBlur={field.handleBlur}
                                          onChange={e => {
                                             field.handleChange(e.target.value);
                                             handleChange(e.target.value);
                                          }}
                                          required={false}
                                       />
                                       <FieldInfo field={field} />
                                    </>
                                 )}
                              </form.Field>
                              <form.Field
                                 name={`dataSubProcessors[${index}].directSubProcessor`}
                              >
                                 {field => (
                                    <>
                                       <Checkbox
                                          id={`dataSubProcessor[${index}].directSubProcessor`}
                                          name={`dataSubProcessor[${index}].directSubProcessor`}
                                          value={field.state.value}
                                          onBlur={field.handleBlur}
                                          onChange={e => {
                                             field.handleChange(
                                                e.target.checked
                                             );
                                             handleChange(
                                                e.target.checked.toString()
                                             );
                                          }}
                                       >
                                          Is KMD the sub-processor
                                       </Checkbox>
                                       <FieldInfo field={field} />
                                    </>
                                 )}
                              </form.Field>
                              <form.Field
                                 name={`dataSubProcessors[${index}].transferReason`}
                              >
                                 {field => (
                                    <>
                                       <h4>Transfer reason</h4>
                                       <TextBox
                                          id={`dataSubProcessor[${index}].transferReason`}
                                          name={`dataSubProcessor[${index}].transferReason`}
                                          templateText={"Enter transfer reason"}
                                          readOnly={false}
                                          value={field.state.value}
                                          onBlur={field.handleBlur}
                                          onChange={e => {
                                             field.handleChange(e.target.value);
                                             handleChange(e.target.value);
                                          }}
                                          required={false}
                                       />
                                       <FieldInfo field={field} />
                                    </>
                                 )}
                              </form.Field>
                              <form.Field
                                 name={`dataSubProcessors[${index}].parentCompany`}
                              >
                                 {field => (
                                    <>
                                       <h4>Parent Company</h4>
                                       <InputBox
                                          id={`dataSubProcessor[${index}].parentCompany`}
                                          name={`dataSubProcessor[${index}].parentCompany`}
                                          templateText={"Enter parent company"}
                                          value={field.state.value}
                                          onBlur={field.handleBlur}
                                          onChange={e => {
                                             field.handleChange(e.target.value);
                                             handleChange(e.target.value);
                                          }}
                                          required={false}
                                       />
                                       <FieldInfo field={field} />
                                    </>
                                 )}
                              </form.Field>
                           </>
                        ))}
                        <StandardButton
                           onClick={() => {
                              setHasJustAddedOrRemovedDataSubProcessor(true);
                              subProcessorField.pushValue({
                                 name: "",
                                 cvr: "",
                                 address: "",
                                 treatment: "",
                                 directSubProcessor: false,
                                 transferReason: "",
                                 parentCompany: "",
                              });
                           }}
                        >
                           Add Data Processor
                        </StandardButton>
                     </div>
                  )}
               </form.Field>

               <form.Field name={`dataCategories.categoryList`}>
                  {field => (
                     <>
                        <h2>
                           Beskrivelse af de katagorier af information der
                           bliver behandlet.
                        </h2>
                        <TextBox
                           id={`dataCategories.categoryList`}
                           name={`dataCategories.categoryList`}
                           templateText={"Enter description"}
                           readOnly={false}
                           value={field.state.value}
                           onBlur={field.handleBlur}
                           onChange={e => {
                              field.handleChange(e.target.value);
                              handleChange(e.target.value);
                           }}
                           required={false}
                        />
                        <FieldInfo field={field} />
                     </>
                  )}
               </form.Field>

               <form.Field name={`dataSecurity.securityMeasures`}>
                  {field => (
                     <>
                        <h2>
                           Beskrivelse af tekniske og organisatoriske
                           sikkerhedsforanstaltninger.
                        </h2>
                        <TextBox
                           id={`dataSecurity.securityMeasures`}
                           name={`dataSecurity.securityMeasures`}
                           templateText={"Enter technical description"}
                           readOnly={false}
                           value={field.state.value}
                           onBlur={field.handleBlur}
                           onChange={e => {
                              field.handleChange(e.target.value);
                              handleChange(e.target.value);
                           }}
                           required={false}
                        />
                        <FieldInfo field={field} />
                     </>
                  )}
               </form.Field>
            </div>
            <StandardButton type="submit" disabled={!form.state.canSubmit}>
               {form.state.isSubmitting ? "..." : "Submit"}
            </StandardButton>
         </form>
      </div>
   );
}
