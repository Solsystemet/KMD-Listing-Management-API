type DataProcessor30ListingData = {
   name: string;
   dataController: DataController;
   dataProcessor: DataProcessor;
   dataControllerRepresentative: DataControllerRepresentative;
   dataProcessorRepresentative: DataProcessorRepresentative;
   dataSecurityAdvisor: DataSecurityAdvisor;
   dataCategories: DataCategories;
   dataSecurity: DataSecurity;
   dataTransfer: DataTransfer;
   dataSubProcessors: SubProcessor[];
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

export type DataSecurityAdvisor = DataContactInfo;

export type DataCategories = {
   categoryList: string;
};

export type DataSecurity = {
   securityMeasures: string;
};

export type DataTransfer = {
   transferInformation: string;
};

export type SubProcessor = {
   name: string;
   cvr: string;
   address: string;
   treatment: string;
   directSubProcessor: boolean;
   transferReason: string;
};

export default DataProcessor30ListingData;
