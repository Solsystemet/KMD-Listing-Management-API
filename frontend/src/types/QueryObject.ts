type QueryObject = {
   name?: string | null;
   sortBy?: "Name" | "Creation Time" | "Update Time";
   isDescending: boolean;
   pageNumber: number;
   pageSize: number;
   archived: 0 | 1;
};

export default QueryObject;
