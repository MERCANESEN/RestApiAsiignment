namespace RestApiAssignment.FileService
{
    public class QueryService :IQueryService
    {
        private readonly IFileService _fileService;

        public QueryService(IFileService fileService)
        {
            _fileService = fileService;
        }

        public int GetDistinctQueryCount(string datePrefix)
        {
            var records = _fileService.ReadQueryRecordsFromFile();
            var filteredRecords = records
                .Where(r => r.Timestamp.ToString("yyyy-MM-dd HH:mm").StartsWith(datePrefix)).Select(r => r.URL.Trim('"'))
                .Select(u => Uri.UnescapeDataString(u))
                .Select(u => u.ToLowerInvariant())
                .Distinct()
                .ToList();
            return filteredRecords.Count;
        }
      


    }

}

