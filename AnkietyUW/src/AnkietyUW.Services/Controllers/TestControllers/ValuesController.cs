using AnkietyUW.DataLayer.UnitOfWork;
using AnkietyUW.Services.Infrastructure.BaseControllers;
using AnkietyUW.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace AnkietyUW.Services.Controllers.TestControllers
{
    [Route("api/[controller]")]
    public class ValuesController : BaseUserController
    {
        private IJwtUtility UtlJwtUtility { get; set; }
        // GET api/values
        public ValuesController(IJwtUtility utlJwtUtility, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            UtlJwtUtility = utlJwtUtility;
        }

        [HttpGet]
        public string Get()
        {
            return UserId.ToString() + " " + SecretId.ToString() + " " + TestTimeId.ToString();

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
