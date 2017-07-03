using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSJournal_Data.Models;
using Newtonsoft.Json;

namespace MSJournal_Data.SaveToFileMappers
{
    class JsonMapper : IJsonMapper
    {
        public string FromContent(Report report)
        {
            return JsonConvert.SerializeObject(report);
        }

        public Report ToContent(string report)
        {
            return JsonConvert.DeserializeObject<Report>(report);
        }
    }
}
