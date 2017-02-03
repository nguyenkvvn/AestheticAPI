using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AestheticsAPI.Custom_Libraries.SlackPayload
{
    /*
    token=gIkuvaNzQIHg97ATvDxqgjtO
    team_id=T0001
    team_domain=example
    channel_id=C2147483705
    channel_name=test
    user_id=U2147483697
    user_name=Steve
    command=/weather
    text=94070
    response_url=https://hooks.slack.com/commands/1234/5678 */

    
    public class SlackPayload
    {
        public string Value { get; set; }
        public string token { get; set; }
        public string team_id { get; set; }
        public string team_domain { get; set; }
        public string channel_id { get; set; }
        public string channel_name { get; set; }
        public string user_id { get; set; }
        public string user_name { get; set; }
        public string command { get; set; }
        public string text { get; set; }
        public string response_url { get; set; }

        //SlackPayload interprets Slack's POST request and makes it a OOP-friendly object.
        public SlackPayload(string pl)
        {
            Value = pl;
            parsePayload(pl);

        }

        public void parsePayload(string p)
        {
            /*try
            {*/
            //string[] payload = p.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
            string[] payload = p.Split('&');

            //interpets a value using the formula: take the substring in between the '=' char up to the length of the whole value.
                token = payload[0].Substring(payload[0].IndexOf('='));
                team_id = payload[1].Substring(payload[1].IndexOf('='));
                team_domain = payload[2].Substring(payload[2].IndexOf('='));
                channel_id = payload[3].Substring(payload[3].IndexOf('='));
                channel_name = payload[4].Substring(payload[4].IndexOf('='));
                user_id = payload[5].Substring(payload[5].IndexOf('='));
                user_name = payload[6].Substring(payload[6].IndexOf('='));
                command = payload[7].Substring(payload[7].IndexOf('='));
                text = payload[8].Substring(payload[8].IndexOf('='));
                response_url = payload[9].Substring(payload[9].IndexOf('='));
            /*}
            catch (Exception e)
            {
                //print no input given
            }*/

            text = sanitize(text);
            
        }

        public static String sanitize(string s)
        {
            string sN = s;

            sN = sN.Remove(0, 1);
            sN = sN.Replace("+", " ");
            sN = sN.Replace("%2B", "+");

            return sN;
        }

        public string toString()
        {
            return "To be implemented.";
        }

        
    }
}