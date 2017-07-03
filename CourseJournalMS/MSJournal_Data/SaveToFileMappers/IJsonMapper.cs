using MSJournal_Data.Models;

namespace MSJournal_Data.SaveToFileMappers
{
    internal interface IJsonMapper
    {
        string FromContent(Report report);
        Report ToContent(string report);
    }
}