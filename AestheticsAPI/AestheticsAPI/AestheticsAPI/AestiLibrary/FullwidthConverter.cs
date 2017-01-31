using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AestheticsAPI.AestiLibrary
{
    public class FullwidthConverter
    {

        public static string convert(string inText)
        {
            //convert the input text String into a character array
            char[] inTextCharArray = inText.ToCharArray();

            //change each character in the array into its full width equivalent (by adding 0xFEE0)
            for (int i = 0; i < inText.Length; i++)
            {
                if (inTextCharArray[i] != ' ')
                {
                    inTextCharArray[i] = (char)(inTextCharArray[i] + (char)0xFEE0);
                }
                
            }

            //return the converted text
            return new String(inTextCharArray);

        }
    }
}