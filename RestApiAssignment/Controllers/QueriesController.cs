using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestApiAssignment.FileService;

namespace RestApiAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QueriesController : ControllerBase
    {
        private readonly IQueryService _queryService;
        public QueriesController(IQueryService queryService)
        {
            _queryService = queryService;
        }

        [HttpGet("count/{datePrefix}")]
        public IActionResult Get(string datePrefix) 
        {

            var count = _queryService.GetDistinctQueryCount(datePrefix);
            return Ok(new { count = count });


        }
    }
}
