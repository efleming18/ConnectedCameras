using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConnectedCamerasWeb.ExtensionMethods
{
    public static class ExtensionMethods
    {
        /// <summary>
        /// Takes an array of integers and returns a string with each entity separated by a comma.
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public static string Stringify(this int[] numbers)
        {
            string numberString = "";
            bool isFirstNumberSet = false;
            foreach (var number in numbers) 
            {
                if (!isFirstNumberSet)
                {
                    numberString += string.Format("{0}", number);
                    isFirstNumberSet = true;
                    continue;
                }
                numberString += string.Format(",{0}", number);
            }
            return numberString;
        }
        /// <summary>
        /// Takes a string of integers separated by commas and returns them inside an array.
        /// </summary>
        /// <param name="numbersString"></param>
        /// <returns></returns>
        public static int[] UnStringify(this string numbersString)
        {
            return Array.ConvertAll(numbersString.Split(new char[] { ',' }), int.Parse);
        }
    }
}