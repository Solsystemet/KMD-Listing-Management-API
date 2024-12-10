import { useState } from "react"; // Importing useState to handle state management
import InputBox from "../inputBox/inputBox";
import { useForm, Field, FieldApi } from "@tanstack/react-form";
import { Checkbox } from "../checkBox/CheckBox";
import styles from "./Survey.module.css";
import NullableDataProcessor30ListingData from "../../types/NullableDataProcessor30ListingData";
import { StandardButton } from "../buttons/Buttons";
import DataProcessor30ListingData from "../../types/DataProcessor30ListingData";
import { postListing } from "../../lib/api";

function FieldInfo<TFieldValue>({
  field,
}: {
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
      rows={5}
    />
  );
}

type SurveyProps = {
  listingDataProp: NullableDataProcessor30ListingData;
};

export function Survey({ listingDataProp }: SurveyProps) {
  const [listingData, SetListingData] = useState(listingDataProp);
  const [hasJustAddedDataSubProcessor, setHasJustAddedDataSubProcessor] =
    useState(false); // Should be removed if possible (used to make sure the POST request is not posted when a subProcessor is added)

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
    setHasJustAddedDataSubProcessor(true);
  }

  const form = useForm({
    defaultValues: {
      name: "",
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
      dataSecurityAdvisor: {
        name: listingData.dataSecurityAdvisor.name || "",
        address: listingData.dataSecurityAdvisor.address || "",
        phoneNo: listingData.dataSecurityAdvisor.phoneNo || "",
        mail: listingData.dataSecurityAdvisor.mail || "",
      },
      dataSubProcessors: listingData.dataSubProcessors.map((subProcessor) => ({
        name: subProcessor.name || "",
        cvr: subProcessor.cvr || "",
        address: subProcessor.address || "",
        treatment: subProcessor.treatment || "",
        directSubProcessor: subProcessor.directSubProcessor || false,
        transferReason: subProcessor.transferReason,
        parentCompany: subProcessor.parentCompany,
      })),
      dataTransfer: {
        transferInformation: "",
      },
      dataSecurity: {
        securityMeasures: "",
      },
      dataCategories: {
        categoryList: "",
      },
    },
    onSubmit: async (values) => {
      if (hasJustAddedDataSubProcessor) {
        setHasJustAddedDataSubProcessor(false);
        return;
      }
      console.log(values);
      console.log(await JSON.stringify(values.value));
      const id = await postListing(values.value);
      console.log(id);
    },
  });

  const handleChange = (value: string) => {
    console.log(value);
  };

  return (
    <div className={styles.surveyContainer}>
      <form
        onSubmit={(e) => {
          e.preventDefault();
          e.stopPropagation();
          form.handleSubmit();
        }}
      >
        {/* Listing information */}
        <div className={styles.ContactInfoCont}>
          <Field form={form} name="name">
            {(field) => (
              <div className={styles.inputContainer}>
                <h1>Data Processor 30 Listing information</h1>
                <InputBox
                  templateText="Enter listing name"
                  id={field.name}
                  name={field.name}
                  value={field.state.value}
                  onBlur={field.handleBlur}
                  onChange={(e) => {
                    field.handleChange(e.target.value);
                    handleChange(e.target.value);
                  }}
                  required={false}
                />
                <FieldInfo field={field} />
              </div>
            )}
          </Field>
          <div />

          {/* Data controller */}
          <Field form={form} name="dataController">
            {(field) => (
              <div className={styles.inputContainer}>
                <h2>Data Controller Info</h2>
                <InputBox
                  id={`dataController.name`}
                  name={`dataController.name`}
                  templateText={"Company name"}
                  value={field.state.value?.name}
                  onBlur={field.handleBlur}
                  onChange={(e) => {
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
                  onChange={(e) => {
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
                  onChange={(e) => {
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
                  onChange={(e) => {
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
                  onChange={(e) => {
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
          </Field>

          {/* Data processor */}
          <Field form={form} name="dataProcessor">
            {(field) => (
              <div className={styles.inputContainer}>
                <h2>Data Processor Info</h2>
                <InputBox
                  id={`dataProcessor.name`}
                  name={`dataProcessor.name`}
                  templateText={"Company name"}
                  value={field.state.value?.name}
                  onBlur={field.handleBlur}
                  onChange={(e) => {
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
                  onChange={(e) => {
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
                  onChange={(e) => {
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
                  onChange={(e) => {
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
                  onChange={(e) => {
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
          </Field>

          {/* Data controller representative */}
          <Field form={form} name="dataControllerRepresentative">
            {(field) => (
              <div className={styles.inputContainer}>
                <h2>Data Controller Representative info</h2>
                <InputBox
                  id={`dataControllerRepresentative.name`}
                  name={`dataControllerRepresentative.name`}
                  templateText={"Name"}
                  value={field.state.value?.name}
                  onBlur={field.handleBlur}
                  onChange={(e) => {
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
                  onChange={(e) => {
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
                  onChange={(e) => {
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
                  onChange={(e) => {
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
                  onChange={(e) => {
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
          </Field>

          {/* Data processor representative */}
          <Field form={form} name="dataProcessorRepresentative">
            {(field) => (
              <div className={styles.inputContainer}>
                <h2>Data Processor Representative info</h2>
                <InputBox
                  id={`dataProcessorRepresentative.name`}
                  name={`dataProcessorRepresentative.name`}
                  templateText={"Name"}
                  value={field.state.value?.name}
                  onBlur={field.handleBlur}
                  onChange={(e) => {
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
                  onChange={(e) => {
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
                  onChange={(e) => {
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
                  onChange={(e) => {
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
                  onChange={(e) => {
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
          </Field>

          {/* Data Security Advisor */}
          <Field form={form} name="dataSecurityAdvisor">
            {(field) => (
              <div className={styles.inputContainer}>
                <h2>Data Security Advisor info</h2>
                <InputBox
                  id={`dataSecurityAdvisor.name`}
                  name={`dataSecurityAdvisor.name`}
                  templateText={"Name"}
                  value={field.state.value?.name}
                  onBlur={field.handleBlur}
                  onChange={(e) => {
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
                  id={`dataSecurityAdvisor.address`}
                  name={`dataSecurityAdvisor.address`}
                  templateText={"Address"}
                  value={field.state.value?.address}
                  onBlur={field.handleBlur}
                  onChange={(e) => {
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
                  id={`dataSecurityAdvisor.phoneNo`}
                  name={`dataSecurityAdvisor.phoneNo`}
                  templateText={"Phone number"}
                  value={field.state.value?.phoneNo}
                  onBlur={field.handleBlur}
                  onChange={(e) => {
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
                  id={`dataSecurityAdvisor.mail`}
                  name={`dataSecurityAdvisor.mail`}
                  templateText={"E-mail"}
                  value={field.state.value?.mail}
                  onBlur={field.handleBlur}
                  onChange={(e) => {
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
          </Field>

          {/* Sub processors */}
          <h2>Data Sub Processors</h2>
          {listingData.dataSubProcessors.map((subProcessor, index) => (
            <div key={index}>
              <Field form={form} name={`dataSubProcessors.${index}`}>
                {(field) => (
                  <div className={styles.inputContainer}>
                    <h3>Data Sub Processor Info {index + 1}</h3>
                    <InputBox
                      id={`dataSubProcessor.${index}.name`}
                      name={`dataSubProcessor.${index}.name`}
                      templateText={"Company name"}
                      value={field.state.value?.name}
                      onBlur={field.handleBlur}
                      onChange={(e) => {
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
                      id={`dataSubProcessor.${index}.cvr`}
                      name={`dataSubProcessor.${index}.cvr`}
                      templateText={"CVR"}
                      value={field.state.value?.cvr}
                      onBlur={field.handleBlur}
                      onChange={(e) => {
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
                      id={`dataSubProcessor.${index}.address`}
                      name={`dataSubProcessor.${index}.address`}
                      templateText={"Address"}
                      value={field.state.value?.address}
                      onBlur={field.handleBlur}
                      onChange={(e) => {
                        field.handleChange({
                          ...field.state.value,
                          address: e.target.value,
                        });
                        handleChange(e.target.value);
                      }}
                      required={false}
                    />
                    <InputBox
                      id={`dataSubProcessor.${index}.treatment`}
                      name={`dataSubProcessor.${index}.treatment`}
                      templateText={"treatment"}
                      value={field.state.value?.treatment}
                      onBlur={field.handleBlur}
                      onChange={(e) => {
                        field.handleChange({
                          ...field.state.value,
                          treatment: e.target.value,
                        });
                        handleChange(e.target.value);
                      }}
                      required={false}
                    />
                    <FieldInfo field={field} />
                    <Checkbox
                      id={`dataSubProcessor.${index}.directSubProcessor`}
                      name={`dataSubProcessor.${index}.directSubProcessor`}
                      value={field.state.value?.directSubProcessor}
                      onBlur={field.handleBlur}
                      onChange={(e) => {
                        field.handleChange({
                          ...field.state.value,
                          directSubProcessor: e.target.checked,
                        });
                        handleChange(e.target.checked.toString());
                      }}
                    >
                      Is KMD the sub-processor
                    </Checkbox>
                    <FieldInfo field={field} />
                    <h4>Transfer reason</h4>
                    <TextBox
                      id={`dataSubProcessor.${index}.transferReason`}
                      name={`dataSubProcessor.${index}.transferReason`}
                      templateText={"Enter transfer reason"}
                      value={field.state.value?.transferReason}
                      onBlur={field.handleBlur}
                      onChange={(e) => {
                        field.handleChange({
                          ...field.state.value,
                          transferReason: e.target.value,
                        });
                        handleChange(e.target.value);
                      }}
                      required={false}
                    />
                  </div>
                )}
              </Field>
            </div>
          ))}
          <button onClick={addDataProcessors} className={styles.addButton}>
            Add Data Processor
          </button>
          {/*
          <Field form={form} name={`dataCategories.categoryList`}>
            {(field) => (
              <>
                <h2>
                  Beskrivelse af de katagorier af information der bliver
                  behandlet.
                </h2>
                <TextBox
                  id={`dataCategories.categoryList`}
                  name={`dataCategories.categoryList`}
                  templateText={"Enter description"}
                  value={field.state.value}
                  onBlur={field.handleBlur}
                  onChange={(e) => {
                    field.handleChange(e.target.value);
                    handleChange(e.target.value);
                  }}
                  required={false}
                />
                <FieldInfo field={field} />
              </>
            )}
          </Field>

          <Field form={form} name={`dataSecurity.securityMeasures`}>
            {(field) => (
              <>
                <h2>
                  Beskrivelse af tekniske og organisatoriske
                  sikkerhedsforanstaltninger.
                </h2>
                <TextBox
                  id={`dataSecurity.securityMeasures`}
                  name={`dataSecurity.securityMeasures`}
                  templateText={"Enter technical description"}
                  value={field.state.value || ""}
                  onBlur={field.handleBlur}
                  onChange={(e) => {
                    field.handleChange(e.target.value);
                    handleChange(e.target.value);
                  }}
                  required={false}
                />
                <FieldInfo field={field} />
              </>
            )}
          </Field>

          <Field form={form} name={`dataTransfer.transferInformation`}>
            {(field) => (
              <>
                <h2>
                  Beskrivelse af tekniske og organisatoriske
                  sikkerhedsforanstaltninger.
                </h2>
                <TextBox
                  id={`dataTransfer.transferInformation`}
                  name={`dataTransfer.transferInformation`}
                  templateText={"Enter technical description"}
                  value={field.state.value || ""}
                  onBlur={field.handleBlur}
                  onChange={(e) => {
                    field.handleChange(e.target.value);
                    handleChange(e.target.value);
                  }}
                  required={false}
                />
                <FieldInfo field={field} />
              </>
            )}
          </Field>*/}
        </div>
        <StandardButton type="submit" disabled={!form.state.canSubmit}>
          {form.state.isSubmitting ? "..." : "Submit"}
        </StandardButton>
      </form>
    </div>
  );
}
