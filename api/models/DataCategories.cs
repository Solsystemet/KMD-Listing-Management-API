using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    [Owned]
    public class DataCategories
    {
        public string CategoryList { get; set; } = string.Empty;
        
        public bool IsEqual(DataCategories dataCategories){
            return dataCategories.CategoryList == this.CategoryList;
        }
    }
}