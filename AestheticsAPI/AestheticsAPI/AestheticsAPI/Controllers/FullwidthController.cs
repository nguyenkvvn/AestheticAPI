using AestheticsAPI.AestiLibrary;
using AestheticsAPI.Custom_Libraries.SlackPayload;
using AestheticsAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
        public SlackMessage Get(string id)
        {
            //create the SlackMessage
            SlackMessage message = new SlackMessage(FullwidthConverter.convert(id), "AestheticBot", true);

            return message;

            //This block below is the proof-of-concept testing the Fullwidth library.
            /*
            FullwidthConverter fwc = new FullwidthConverter();

            string converted = fwc.convert(id);
            return converted;
            */
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
