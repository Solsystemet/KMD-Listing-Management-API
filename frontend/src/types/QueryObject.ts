type QueryObject = {
   name?: string | null;
   sortBy?: "Name" | "Creation Time" | "Update Time";
   isDescending: boolean;
   pageNumber: number;
   pageSize: number;
};

export default QueryObject;
