using System.Collections.Generic;
using System.Threading.Tasks;
using AnkietyUW.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace AnkietyUW.Services.Controllers.TestControllers
{
    [Route("Token")]
    public class TokenGenController : Controller
    {
        private IJwtUtility JwtUtility { get; set; }
        public TokenGenController(IJwtUtility jwtUtility)
        {
            JwtUtility = jwtUtility;
        }

        [HttpGet]
        [Route("")]
        public async Task<string> GetToken()
        {
            var d = new Dictionary<string, string>();
            d.Add("UserId", "085f2cd0-1bb9-42a5-9389-4b65208de07e");
            d.Add("SecretId", "c85225c8-e9a9-48f7-94fe-7734c2c538b2");
            d.Add("TestTimeId", "c85225c8-e9a9-48f7-94fe-7734c2c538b2");
            d.Add("SeriesNumber","12");
            return JwtUtility.Encode(d);
        }

    }
}
