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

export type NullableDataContactInfo = {
  name?: string | null;
  address?: string | null;
  phoneNo?: string | null;
  mail?: string | null;
};

export type NullableDataController = NullableDataContactInfo & {
  cvr?: string | null;
};

export type NullableDataProcessor = NullableDataContactInfo & {
  cvr?: string | null;
};

export type NullableDataControllerRepresentative = NullableDataContactInfo & {
  role?: string | null;
};

export type NullableDataProcessorRepresentative = NullableDataContactInfo & {
  role?: string | null;
};

export type NullableDataSecurityAdvisor = NullableDataContactInfo;

export type NullableDataCategories = {
  categoryList?: string | null;
};

export type NullableDataSecurity = {
  securityMeasures?: string | null;
};

export type NullableDataTransfer = {
  transferInformation?: string | null;
};

export type NullableSubProcessor = {
  name?: string | null;
  cvr?: string | null;
  address?: string | null;
  treatment?: string | null;
  directSubProcessor?: boolean | null;
  transferReason?: string | null;

  // Utility variable
  parentCompany?: string | null;
};

export default NullableDataProcessor30ListingData;
