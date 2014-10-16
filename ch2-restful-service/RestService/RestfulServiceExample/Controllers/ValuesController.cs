using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace RestfulServiceExample.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public HttpResponseMessage Post([FromBody]string value)
        {
            return new HttpResponseMessage
            {
                Content = new StringContent(string.Format("You said: '{0}'", value), Encoding.UTF8, "text/html")
            };
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // HEAD api/values
        public void Head()
        {

        }

        // OPTIONS api/values
        public void Options()
        {

        }

        // PATCH api/values
        public void Patch()
        {

        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}