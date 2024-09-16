using RestApiAssignment.Entities;

namespace RestApiAssignment.FileService
{
    public interface IFileService
    {
        List<QueryRecord> ReadQueryRecordsFromFile();
    }
}
