type NullableDataProcessor30ListingData = {
   name?: string | null;
   dataController: NullableDataController;
   dataProcessor: NullableDataProcessor;
   dataControllerRepresentative: NullableDataControllerRepresentative;
   dataProcessorRepresentative: NullableDataProcessorRepresentative;
   dataSecurityAdvisor: NullableDataSecurityAdvisor;
   dataCategories: NullableDataCategories;
   dataSecurity: NullableDataSecurity;
   dataTransfer: NullableDataTransfer;
   dataSubProcessors: NullableSubProcessor[];
};

type NullableDataContactInfo = {
   name?: string | null;
   address?: string | null;
   phoneNo?: string | null;
   mail?: string | null;
};

type NullableDataController = NullableDataContactInfo & {
   cvr?: string | null;
};

type NullableDataProcessor = NullableDataContactInfo & {
   cvr?: string | null;
};

type NullableDataControllerRepresentative = NullableDataContactInfo & {
   role?: string | null;
};

type NullableDataProcessorRepresentative = NullableDataContactInfo & {
   role?: string | null;
};

type NullableDataSecurityAdvisor = NullableDataContactInfo & {
   categoryList?: string | null;
};

type NullableDataCategories = {
   categoryList?: string | null;
};

type NullableDataSecurity = {
   securityMeasures?: string | null;
};

type NullableDataTransfer = {
   transferInformation?: string | null;
};

type NullableSubProcessor = {
   name?: string | null;
   cvr?: string | null;
   address?: string | null;
   treatment?: string | null;
   directSubProcessor?: boolean | null;
   transferReason?: string | null;
};

export default NullableDataProcessor30ListingData;
