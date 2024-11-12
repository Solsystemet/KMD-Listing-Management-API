import InputBox from "../inputBox/inputBox";
import { Checkbox } from "../checkBox/Checkbox";
import styles from "./Survey.module.css";
import { useForm } from "@tanstack/react-form";

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
   const form = useForm({
      onSubmit: async ({ value }) => {
         console.log(value);
      },
   });

   return (
      <form
         onSubmit={e => {
            e.preventDefault();
            e.stopPropagation();
            form.handleSubmit();
         }}
      >
         <div className={styles.ContactInfoController}>
            <h3>Contact info of controller</h3>
            {Array.from({ length: numberOfContact }).map((_, index) => (
               <form.Field name={`contactInfoController.${index}`} key={index}>
                  {field => (
                     <>
                        <p>Contact Info {index}</p>
                        <InputBox templateText={"Name"} />
                        <InputBox templateText={"Position"} />
                        <InputBox templateText={"Telephone number"} />
                        <InputBox templateText={"E-mail"} />
                     </>
                  )}
               </form.Field>
            ))}
         </div>

         <div className={styles.dataCategories}>
            <h3>Data categories</h3>
            <form.Field name="dataCategories" mode="array">
               {field => (
                  <>
                     <Checkbox>{"School administrators"}</Checkbox>
                     <Checkbox>{"School management"}</Checkbox>
                     <Checkbox>{"Teachers"}</Checkbox>
                     <Checkbox>{"Other employees"}</Checkbox>
                     <Checkbox>{"Students"}</Checkbox>
                     <Checkbox>
                        {"Parents to students under 18 years old"}
                     </Checkbox>
                  </>
               )}
            </form.Field>
         </div>
         <div className={styles.dataTransfersContainer}>
            <h3>Data transfer info</h3>
            {Array.from({ length: numberOfDataTransfers }).map((_, index) => (
               <form.Field name={`dataTransfers.${index}`} key={index}>
                  {field => (
                     <>
                        <p>Contact Info {index}</p>
                        <InputBox templateText={"Company name"} />
                        <InputBox templateText={"Address"} />
                        <InputBox templateText={"Treatment of data"} />
                        <InputBox templateText={"Transfer basis"} />
                        <Checkbox>{"Is it KMDs sub data-processor?"}</Checkbox>
                     </>
                  )}
               </form.Field>
            ))}
         </div>
         <div>
            <h3>
               Beskrivelse af tekniske og organisatoriske
               sikkerhedsforanstaltninger.
            </h3>

            <form.Field name="securityMeasures">
               {field => <TextBox />}
            </form.Field>
         </div>
      </form>
   );
}
