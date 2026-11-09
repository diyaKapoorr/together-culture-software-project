using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace member_space
{
    public class EventData 
    {
        public int EventID { get; set; }
        public int AdminID { get; set; }
        public string Address { get; set; }
        public string Postcode { get; set; }
        public string BuildingName { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int Duration { get; set; }
        public int MaxCapacity { get; set; }
        public string EventName { get; set; }
    }
}
