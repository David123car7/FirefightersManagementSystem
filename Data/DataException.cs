/*
*	<copyright file="Validations.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>David Carvalho</author>
*   <date>19/12/2024 20:18:56</date>
*	<description></description>
**/
using System;

namespace Data
{
    /// <summary>
    /// Purpose: Excpetions of the Data layer
    /// Created by: David Carvalho
    /// Created on: 19/12/2024 20:18:56
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class DataException : ApplicationException
    {
        public int errorCode;

        public int ErrorCode
        {
            get { return errorCode; }
        }

        /// <summary>
        /// The default Constructor.
        /// </summary>
        public DataException() : base("Erro")
        {

        }

        public DataException(string g) : base(g) { }

        public DataException(int code)
        {
            string msg = DictionaryExceptions.GetErrorDescription(code);
            Console.WriteLine("Error " + code + msg );
        }
    }
}
