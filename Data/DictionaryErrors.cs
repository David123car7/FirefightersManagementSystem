/*
*	<copyright file="Logs.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>David Carvalho</author>
*   <date>20/12/2024 10:50:04</date>
*	<description></description>
**/
using System.Collections.Generic;

namespace Data
{
    /// <summary>
    /// Purpose: Class that manages and contains the dictionary of exceptions
    /// Created by: David Carvalho
    /// Created on: 20/12/2024 10:50:04
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public static class DictionaryErrors
    {
        private static readonly Dictionary<int, string> programErros = new Dictionary<int, string>()
        {
            { -101, "Firefighter id is invalid" },
            { -102, "Firefighter Available is invalid" },
            { -103, "Firefighter name is invalid" },
            { -104, "Firefighter Sex is invalid" },
            { -105, "Firefighter CC is invalid" },
            { -106, "Firefighter Age is invalid" },
            { -107, "Firefighter object is null" },
            { -108, "Firefighter with the id does not exist in the list" },
            { -109, "Firefighter is not available" },
            { -110, "Firefighter is available" },
            { -111, "Firefighter with the is allready in the list" },
            { -201, "Incident id is invalid" },
            { -202, "Incident DateTime is invalid" },
            { -203, "Incident location is invalid" },
            { -204, "Incident TypeIncident is invalid" },
            { -205, "Incident PriorityLevel is invalid" },
            { -206, "Incident Firefighters required is invalid" },
            { -207, "Incident object is null"},
            { -208, "Incident with the id does not exist in the list" },
            { -209, "Incident was allready in the list" },
            { -50, "String is invalid" },
            { -51, "Not sufficient permissions" },
            { -52, "File does not exist" },
            { -301, "The integer inside the list of integers is allready inside the list"},
            { -302, "The integer does not exist in the list of integers"}
        };

        public static bool ExistsError(int code)
        {
            return programErros.ContainsKey(code);
        }

        public static string GetErrorDescription(int code)
        {
            if (ExistsError(code))
            {
                return programErros[code];
            }
            return string.Empty;
        }
    }
}
