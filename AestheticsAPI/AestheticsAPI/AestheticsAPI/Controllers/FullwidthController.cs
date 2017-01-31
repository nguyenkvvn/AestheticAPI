using AestheticsAPI.AestiLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AestheticsAPI.Controllers
{
    public class FullwidthController : ApiController
    {
        // GET: api/Fullwidth
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Fullwidth/5
        public string Get(string id)
        {
            //dynamic inJSON = JsonConvert.DeserializeObject();

            FullwidthConverter fwc = new FullwidthConverter();

            string converted = fwc.convert(id);
            return converted;
            //return "This command is not supported.";
        }

        // POST: api/Fullwidth
        public void Post([FromBody]string value)
        {
            
            return;
        }

        // PUT: api/Fullwidth/5
        public void Put(int id, [FromBody]string value)
        {
            return;
        }

        // DELETE: api/Fullwidth/5
        public void Delete(int id)
        {
            return;
        }
    }
}
