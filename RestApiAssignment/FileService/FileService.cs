using RestApiAssignment.Entities;

namespace RestApiAssignment.FileService
{
    public class FileService : IFileService
    {
        public List<QueryRecord> ReadQueryRecordsFromFile()
        {
            var records = new List<QueryRecord>();
            var lines = File.ReadAllLines(Path.Combine(Directory.GetCurrentDirectory(), "LogFile", "hn_logs.tsv"));

            foreach (var line in lines)
            {
                var parts = line.Split('\t');
                if (parts.Length == 2 && DateTime.TryParse(parts[0], out DateTime timestamp))
                {
                    records.Add(new QueryRecord
                    {
                        Timestamp = timestamp,
                        URL = Uri.UnescapeDataString(parts[1])
                    });
                }
            }

            return records;
        }
    }
}
