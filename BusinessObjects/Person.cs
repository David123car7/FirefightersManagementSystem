/*
*	<copyright file="TrabalhoPratico_Tentativa_.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>David Carvalho</author>
*   <date>30/10/2024 21:38:16</date>
*	<description></description>
**/
using System;


namespace BusinessObjects
{
    public enum Sex
    {
        Masculine = 1,
        Feminine = 2
    }

    public enum Permissions
    {
        HIGH = 1,
        MEDIUM = 2,
        LOW = 3
    }

    /// <summary>
    /// Purpose: Class of the person
    /// Created by: David Carvalho
    /// Created on: 30/10/2024 21:38:16
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    [Serializable]
    public class Person
    {
        #region Attributes
        string name;
        Sex sex;
        string cc;
        int age;
        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// The default Constructor.
        /// </summary>
        public Person()
        {
        }


        /// <summary>
        /// Creates the person
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="sex">Sex</param>
        /// <param name="sex">CC</param>
        /// <param name="age">Age</param>
        public Person(string name, Sex sex, string cc, int age)
        {
            Name = name;
            Sex = sex;
            CC = cc;
            Age = age;
        }

        #endregion

        #region Properties
        public string Name
        {
            set { name = value; }
            get { return name; }
        }

        public Sex Sex
        {
            set { sex = value; }
            get { return sex; }
        }

        public string CC
        {
            set { cc = value; }
            get { return cc; }
        }

        public int Age
        {
            set { age = value; }
            get { return age; }
        }
        #endregion

        #region Functions
        #endregion

        #region Overrides
        public override bool Equals(object obj)
        {
            Person c = obj as Person;
            if (c == null) return false;
            return this.cc == c.cc;
        }
        #endregion

        #region Destructor
        /// <summary>
        /// The destructor.
        /// </summary>
        ~Person()
        {
        }
        #endregion

        #endregion
    }
}
