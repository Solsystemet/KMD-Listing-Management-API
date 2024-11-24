type ListingData = {
   id: number;
   name: string;
   creationTime: Date;
   updateTime: Date;
   dataController: {
      cvr: number;
      name: string;
      address: string;
      phoneNo: string;
      mail: string;
   };
   dataProcessor: {
      cvr: number;
      name: string;
      address: string;
      phoneNo: string;
      mail: string;
   };
   dataSecurityAdvisor: {
      name: string;
      address: string;
      phoneNo: string;
      mail: string;
   };
   dataCategories: {
      categoryList: string;
   };
   dataTransfer: {
      transferInformation: string;
   };
   dataSecurity: {
      securityMeasures: string;
   };
};

export default ListingData;
