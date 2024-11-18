using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    [Owned]
    public class DataSubProcessor
    {
        public string name { get; set; } = String.Empty;
        public string CVR { get; set; } = String.Empty;
        public string Adress { get; set; } = String.Empty;
        public string Treatment { get; set; } = String.Empty;
        public bool directSubProcessor { get; set; } = false;
        public string transferReason { get; set; } = String.Empty;
    }
}
