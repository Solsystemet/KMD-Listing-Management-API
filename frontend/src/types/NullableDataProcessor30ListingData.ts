export const nullListingData: NullableDataProcessor30ListingData = {
   name: null,
   dataController: {
      name: null,
      address: null,
      phoneNo: null,
      mail: null,
      cvr: null,
   },
   dataProcessor: {
      name: null,
      address: null,
      phoneNo: null,
      mail: null,
      cvr: null,
   },
   dataControllerRepresentative: {
      name: null,
      address: null,
      phoneNo: null,
      mail: null,
      role: null,
   },
   dataProcessorRepresentative: {
      name: null,
      address: null,
      phoneNo: null,
      mail: null,
      role: null,
   },
   dataCategories: {
      categoryList: null,
   },
   dataSecurity: {
      securityMeasures: null,
   },
   dataSubProcessors: [
      {
         name: null,
         cvr: null,
         address: null,
         treatment: null,
         directSubProcessor: null,
         transferReason: null,
      },
   ],
};

type NullableDataProcessor30ListingData = {
   name?: string | null;
   dataController: NullableDataController;
   dataProcessor: NullableDataProcessor;
   dataControllerRepresentative: NullableDataControllerRepresentative;
   dataProcessorRepresentative: NullableDataProcessorRepresentative;
   dataCategories: NullableDataCategories;
   dataSecurity: NullableDataSecurity;
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

export type NullableDataCategories = {
   categoryList?: string | null;
};

export type NullableDataSecurity = {
   securityMeasures?: string | null;
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
