export type DataProcessor30ListingDataDto = Omit<
   DataProcessor30ListingData,
   "id" | "creationTime" | "updateTime"
>;

type DataProcessor30ListingData = {
   solution: string;
   id: number;
   name: string;
   creationTime: Date;
   updateTime: Date;
   dataController: DataController;
   dataProcessor: DataProcessor;
   dataControllerRepresentative: DataControllerRepresentative;
   dataProcessorRepresentative: DataProcessorRepresentative;
   dataCategories: DataCategories;
   dataSecurity: DataSecurity;
   dataSubProcessors: SubProcessor[];
   dataEdits: DataEdits[];
};

export type DataContactInfo = {
   name: string;
   address: string;
   phoneNo: string;
   mail: string;
};

export type DataController = DataContactInfo & {
   cvr: string;
};

export type DataProcessor = DataContactInfo & {
   cvr: string;
};

export type DataControllerRepresentative = DataContactInfo & {
   role: string;
};

export type DataProcessorRepresentative = DataContactInfo & {
   role: string;
};

export type DataCategories = {
   categoryList: string;
};

export type DataSecurity = {
   securityMeasures: string;
};

export type DataTransfer = {
   transferInformation: string;
};

export type DataEdits = {
   id: number;
   editType: string;
   editTime: Date;
   comment: string;
   dataProcessor30ListingDataId: number;
   fieldsEdited: string;
};

export type SubProcessor = {
   name: string;
   cvr: string;
   address: string;
   treatment: string;
   directSubProcessor: boolean;
   transferReason: string;

   // Utility variable
   parentCompany: string;
};

export default DataProcessor30ListingData;
