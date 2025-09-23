/*
*	<copyright file="Logs.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>David Carvalho</author>
*   <date>20/12/2024 10:53:11</date>
*	<description></description>
**/
using System;
using System.Collections.Generic;
using System.IO;
using BusinessObjects;
using System.Xml.Serialization;

namespace Data
{
    /// <summary>
    /// Purpose: Class that manages the list of errors
    /// Created by: David Carvalho
    /// Created on: 20/12/2024 10:53:11
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class ErrorsLog
    {
        #region Attributes
        List<Error> listError;
        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// The default Constructor.
        /// </summary>
        public ErrorsLog()
        {
            listError = new List<Error>();  
        }

        #endregion

        #region Properties
        #endregion

        #region Functions
        /// <summary>
        /// Inserts a listError in the list of incidents
        /// </summary>
        /// <param name="x">error to be inserted</param>
        /// <returns>Returns -1 if the listError is null,returns 1 if the listError was inserted</returns>
        public int InsertList(Error x)
        {
            if (x == null)
                return -1;

            listError.Add(x);
            return 1;
        }

        /// <summary>
        /// Create a error and inserts it in the list of errors
        /// </summary>
        /// <param name="code">Code error</param>
        /// <param name="description">Description of error</param>
        /// <param name="timeError">Time of error</param>
        /// <returns>Returns -1 if the error created was null, returns 1 if the error was inserted in the list</returns>
        public int CreateInsertList(int code, DateTime timeError , string description)
        {
            Error x = new Error(code, timeError, description);
            if(x != null)
            {
                return InsertList(x);
            }

            return -1;
        }

        /// <summary>
        /// Create a error, gets the description of that error from a dictionary of erros and inserts it in the list of errors
        /// </summary>
        /// <param name="code">Code error</param>
        /// <param name="description">Description of error</param>
        /// <param name="timeError">Time of error</param>
        /// <returns>Returns -1 if the error created was null, returns 1 if the error was inserted in the list</returns>
        public int CreateGetInsertList(int code, DateTime timeError)
        {
            if (DictionaryErrors.ExistsError(code))
            {
                string desc = DictionaryErrors.GetErrorDescription(code);
                CreateInsertList(code, timeError, desc);
            }
            return -1;
        }

        /// <summary>
        /// Stores the logs list in a file 
        /// </summary>
        /// <param name="filePath">File path of the file</param>
        /// <returns>Returns 1 if the file was stored</returns>
        public int StoreLogsListFileXML(string filePath)
        {
            string fl = filePath + DateTime.Now.ToString("yyyy_MM_dd") + ".txt";

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Error>));
                TextWriter textWriter = new StreamWriter(fl);
                serializer.Serialize(textWriter, listError);
                textWriter.Close();
                return 1;
            }
            catch (IOException e)
            {
                throw new DataException(-10);
            }
        }
        #endregion

        #region Overrides
        #endregion

        #region Destructor
        /// <summary>
        /// The destructor.
        /// </summary>
        ~ErrorsLog()
        {
        }
        #endregion

        #endregion
    }
}
