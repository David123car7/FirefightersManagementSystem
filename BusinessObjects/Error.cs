/*
*	<copyright file="BusinessObjects.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>David Carvalho</author>
*   <date>20/12/2024 10:46:52</date>
*	<description></description>
**/
using System;

namespace BusinessObjects
{
    /// <summary>
    /// Purpose: Class of the error
    /// Created by: David Carvalho
    /// Created on: 20/12/2024 10:46:52
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    [Serializable]
    public class Error
    {
        #region Attributes
        int code;
        DateTime timeError;
        string description;
        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// The default Constructor.
        /// </summary>
        public Error()
        {
        }

        public Error(int code, DateTime timeError, string description)
        {
            this.code = code;
            this.timeError = timeError;
            this.description = description;
        }

        #endregion

        #region Properties
        public int Code
        {
            get { return code; }
            set { code = value; }
        }

        public DateTime TimeError
        {
            get { return timeError; }
            set { timeError = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        #endregion

        #region Functions
        #endregion

        #region Overrides
        public override bool Equals(object obj)
        {
            Error c = obj as Error;
            if (c == null) return false;
            return this.Code == c.Code;
        }
        #endregion

        #region Destructor
        /// <summary>
        /// The destructor.
        /// </summary>
        ~Error()
        {
        }
        #endregion

        #endregion
    }
}
