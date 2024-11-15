type QueryObject = {
   name?: string | null;
   sortBy?: string | null;
   isDescending: boolean;
   pageNumber: number;
   pageSize: number;
};

export default QueryObject;
