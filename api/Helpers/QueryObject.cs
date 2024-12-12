using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Helpers
{
    public class QueryObject
    {
        public string? Name { get; set; } = null;

        public string? DataController {get; set;} = null;

        public string? DataProcessor {get; set;} = null;

        public string? DataSubProcessor {get; set;} = null;
        public string? SortBy { get; set; } = null;

        public bool IsDescending { get; set; } = false;

        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 32;
        
        
    }
}