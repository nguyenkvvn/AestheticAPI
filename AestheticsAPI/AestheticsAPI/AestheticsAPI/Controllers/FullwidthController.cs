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
        public string Get(string id)
        {
            //create the SlackMessage
            //SlackMessage message = new SlackMessage(FullwidthConverter.convert(id), "AestheticBot", true);

            return "Please use the HTTP POST Slack Command method, not HTTP GET.";

            //This block below is the proof-of-concept testing the Fullwidth library.
            /*
            FullwidthConverter fwc = new FullwidthConverter();

            string converted = fwc.convert(id);
            return converted;
            */
        }

        // POST: api/Fullwidth
        // The POST on this controller outputs a Slack-consumable JSON.
        // WebAPI doesn't play nice with the formatting of Slack's application/x-www-form-urlencoded with the [FromBody] prop- resulting in a null in value.
        //The solution was to accept the incoming HTTP POST as a HttpRequestMessage, then extract the data from the request.Content.
        public SlackMessage Post(/*[FromBody]string value*/ HttpRequestMessage request)
        {
            //process the HTML post body and process it in a SlackPayload
            SlackPayload inSlack = new SlackPayload(request.Content.ReadAsStringAsync().Result);

            //send out a new slack message
            SlackMessage message = new SlackMessage(FullwidthConverter.convert(inSlack.text), "AestheticBot", true, SlackMessage.in_channel);

            return message;
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
