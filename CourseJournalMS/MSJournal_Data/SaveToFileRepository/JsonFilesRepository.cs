using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSJournal_Data.Models;
using MSJournal_Data.SaveToFileMappers;
using Ninject;

namespace MSJournal_Data.SaveToFileRepository
{
    public class JsonFilesRepository
    {
        private readonly IJsonMapper _mapper;

        public JsonFilesRepository()
        {
            _mapper = new JsonMapper();
        }

        [Inject]
        public JsonFilesRepository(IJsonMapper mapper)
        {
            _mapper = mapper;
        }
        
        public void SaveToFile(string filepath, Report report)
        {
            File.WriteAllText(filepath, _mapper.FromContent(report));
        }

        public Report ReadFromFile(string path)
        {
            var result = File.ReadAllText(path);

            return _mapper.ToContent(result);
        }
    }
}
