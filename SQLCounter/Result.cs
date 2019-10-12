using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLCounter
{

    public class RecordsData
    {
        public List<Record> Records { get; set; }
    }

    public class Record
    {
        public string id { get; set; }
        public string record { get; set; }
        public string stamp { get; set; }
    }

}
