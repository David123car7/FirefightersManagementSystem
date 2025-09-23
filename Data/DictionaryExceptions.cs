/*
*	<copyright file="Data.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>David Carvalho</author>
*   <date>21/12/2024 00:47:15</date>
*	<description></description>
**/
using System.Collections.Generic;

namespace Data
{
    /// <summary>
    /// Purpose: Class that manages and contains the dictionary of exceptions
    /// Created by: David Carvalho
    /// Created on: 21/12/2024 00:47:15
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public static class DictionaryExceptions
    {
        private static readonly Dictionary<int, string> dataExceptions = new Dictionary<int, string>()
        {
            { -10, "Was not possible to store the file" },
            { -11, "Was not possible to read the file"}
        };

        public static bool ExistsError(int code)
        {
            return dataExceptions.ContainsKey(code);
        }

        public static string GetErrorDescription(int code)
        {
            if (ExistsError(code))
            {
                return dataExceptions[code];
            }
            return string.Empty;
        }
    }
}
