import React from "react";
import { useForm, Field } from "@tanstack/react-form";
import styles from "./Survey.module.css";
import InputBox from "../inputBox/inputBox";
import { StandardButton } from "../buttons/Buttons";

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

type SurveyProps = {
   numberOfContact: number;
   numberOfDataTransfers: number;
};

export function Survey({
   numberOfContact,
   numberOfDataTransfers,
}: SurveyProps) {
   const contactNumbers = Array.from(
      { length: numberOfContact },
      (_, i) => `Contact ${i + 1}`
   );

   const form = useForm({
      defaultValues: {
         contactInfoController: contactNumbers.reduce(
            (acc, name) => {
               acc[name] = {
                  name: "",
                  position: "",
                  telephoneNumber: "",
                  email: "",
               };
               return acc;
            },
            {} as Record<
               string,
               {
                  name: string;
                  position: string;
                  telephoneNumber: string;
                  email: string;
               }
            >
         ),
         lastName: "",
      },
      onSubmit: async values => {
         // Do something with form data
         console.log(values);
      },
   });

   const handleSubmit = (event: React.FormEvent) => {
      event.preventDefault();
      form.handleSubmit();
   };

   return (
      <div className={styles.surveyForm}>
         <h1>Simple Form Example</h1>
         <form onSubmit={handleSubmit}>
            <div>
               {contactNumbers.map((key, index) => (
                  <Field
                     form={form}
                     name={`contactInfoController.${key}`}
                     key={index}
                  >
                     {field => (
                        <div className={styles.inputContainer}>
                           <InputBox
                              templateText="Enter name"
                              id={`name-${index}`}
                              name={`contactInfoController.${key}.name`}
                              value={field.state.value.name}
                              onBlur={field.handleBlur}
                              required={true}
                              onChange={e =>
                                 field.handleChange({
                                    ...field.state.value,
                                    name: e.target.value,
                                 })
                              }
                           />
                           <FieldInfo field={field} />
                           <InputBox
                              templateText="Enter position"
                              id={`position-${index}`}
                              name={`contactInfoController.${key}.position`}
                              value={field.state.value.position}
                              onBlur={field.handleBlur}
                              required={true}
                              onChange={e =>
                                 field.handleChange({
                                    ...field.state.value,
                                    position: e.target.value,
                                 })
                              }
                           />
                           <FieldInfo field={field} />
                           <InputBox
                              templateText="Enter telephone number"
                              id={`telephoneNumber-${index}`}
                              name={`contactInfoController.${key}.telephoneNumber`}
                              value={field.state.value.telephoneNumber}
                              onBlur={field.handleBlur}
                              required={true}
                              onChange={e =>
                                 field.handleChange({
                                    ...field.state.value,
                                    telephoneNumber: e.target.value,
                                 })
                              }
                           />
                           <FieldInfo field={field} />
                           <InputBox
                              templateText="Enter email"
                              id={`email-${index}`}
                              name={`contactInfoController.${key}.email`}
                              value={field.state.value.email}
                              onBlur={field.handleBlur}
                              required={true}
                              onChange={e =>
                                 field.handleChange({
                                    ...field.state.value,
                                    email: e.target.value,
                                 })
                              }
                           />
                           <FieldInfo field={field} />
                        </div>
                     )}
                  </Field>
               ))}
            </div>
            <div>
               <Field form={form} name="lastName">
                  {field => (
                     <>
                        <label htmlFor={field.name}>Last Name:</label>
                        <InputBox
                           templateText="Enter last name"
                           id={field.name}
                           name={field.name}
                           value={field.state.value}
                           onBlur={field.handleBlur}
                           onChange={e => field.handleChange(e.target.value)}
                        />
                        <FieldInfo field={field} />
                     </>
                  )}
               </Field>
            </div>
            <StandardButton type="submit" disabled={!form.state.canSubmit}>
               {form.state.isSubmitting ? "..." : "Submit"}
            </StandardButton>
         </form>
      </div>
   );
}
