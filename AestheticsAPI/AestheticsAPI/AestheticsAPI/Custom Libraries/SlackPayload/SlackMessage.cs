using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace AestheticsAPI.Custom_Libraries.SlackPayload
{
    //SlackPayload provides the basic framework of a Slack JSON payload for sending Slack messages
    public class SlackMessage
    {
        public string text { get; set; }
        public string username { get; set; }
        public Boolean mrkdwn { get; set; }

        public SlackMessage(string txt, string un, bool md)
        {
            text = txt;
            username = un;
            mrkdwn = md;

            cleanPayload();
        }

        //Catch-all clean command
        public void cleanPayload()
        {
            text = cleanText(text);
            username = cleanText(username);
        }

        //Slack states in its documentation that the following characters are disallowed and must be converted:
        // - Replace the ampersand, &, with &amp;
        // - Replace the less-than sign, < with &lt;
        // - Replace the greater-than sign, > with &gt;
       
        public static string cleanText(string inText)
        {
            StringBuilder sb = new StringBuilder(inText);

            for (int i = 0; i < sb.Length; i++)
            {
                //check if there is a slack-escape next to a disallowed character
                //if there is not one, proceed with disallowed character sanitation
                if (!((sb[i] == '&') && ((sb[i + 1] == 'a') || (sb[i + 1] == 'l') || (sb[i + 1] == 'g'))))
                {
                    if (sb[i] == '&')
                    {
                        sb.Remove(i, 1);
                        sb.Insert(i, "&amp");
                    }
                    else if (sb[i] == '<')
                    {
                        sb.Remove(i, 1);
                        sb.Insert(i, "&lt");
                    }
                    else if (sb[i] == '>')
                    {
                        sb.Remove(i, 1);
                        sb.Insert(i, "&gt");
                    }
                }
            }

            return sb.ToString();
        }
    }
}