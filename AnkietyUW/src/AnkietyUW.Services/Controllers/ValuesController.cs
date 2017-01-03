using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnkietyUW.Services.Infrastructure.BaseControllers;
using AnkietyUW.Utilities;
using Jose;
using Microsoft.AspNetCore.Mvc;

namespace AnkietyUW.Services.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : BaseUserController
    {
        private IJwtUtility UtlJwtUtility { get; set; }
        // GET api/values
        public ValuesController(IJwtUtility utlJwtUtility)
        {
            UtlJwtUtility = utlJwtUtility;
        }

        [HttpGet]
        public string Get()
        {
            var d = new Dictionary<string, string>();
            d.Add("UserId", "085f2cd0-1bb9-42a5-9389-4b65208de07e");
            d.Add("SecretId", "c85225c8-e9a9-48f7-94fe-7734c2c538b2");
            d.Add("TestTimeId", "c85225c8-e9a9-48f7-94fe-7734c2c538b2");
            return UtlJwtUtility.Encode(d);
             
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return UserId.ToString() + " " + SecretId.ToString() + " " + TestTimeId.ToString();
           return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
