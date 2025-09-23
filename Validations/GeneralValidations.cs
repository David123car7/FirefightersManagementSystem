/*
*	<copyright file="BusinessRules.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>David Carvalho</author>
*   <date>19/12/2024 00:28:57</date>
*	<description></description>
**/

using System.IO;

namespace Validations
{
    /// <summary>
    /// Purpose: Class that haves all general validations 
    /// Created by: David Carvalho
    /// Created on: 19/12/2024 00:28:57
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class GeneralValidations
    {
        public GeneralValidations() 
        { 
        }

        /// <summary>
        /// Checks if the string is valid
        /// </summary>
        /// <param name="str">String</param>
        /// <returns>Returns -1 if it is not valid, returns 1 if is valid</returns>
        public int CheckString(string str)
        {
            if (string.IsNullOrEmpty(str)) return -1;
            else return 1;
        }

        /// <summary>
        /// Checks if the file exists
        /// </summary>
        /// <param name="str">String</param>
        /// <returns>Returns -1 if it is not valid, returns 1 if is valid</returns>
        public int CheckFile(string str)
        {
            if (!File.Exists(str)) return -1;
            else return 1;
        }
    }
}
