using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OurFirstApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // https://localhost:[port]/api/values
        [HttpGet] //no additional info
        public IEnumerable<string> GetStrings()
        {
            return new List<String> { "value1", "value2" };
        }
   
    [HttpGet("info")]
    public string GetInfo()
        {
            return "This is our values controller";
        }
    }
}

