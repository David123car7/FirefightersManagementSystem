/*
*	<copyright file="TrabalhoPratico_Tentativa_.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>David Carvalho</author>
*   <date>30/10/2024 21:38:36</date>
*	<description></description>
**/
using System;


namespace BusinessObjects
{
    /// <summary>
    /// Purpose: Class of the firefighter
    /// Created by: David Carvalho
    /// Created on: 30/10/2024 21:38:36
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>

    [Serializable]
    public class FireFighter : Person
    {
        #region Attributes
        int firemanId;
        int available; //1- is available 0- is not available
        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// The default Constructor.
        /// </summary>
        public FireFighter()
        {
        }

        public FireFighter(int firemanId, int available)
        {
            FiremanId = firemanId;
            Available = available;
        }

        public FireFighter(int firemanId, string name, int age, string cc, Sex sex, int available)
        {
            FiremanId = firemanId;
            Name = name;
            Age = age;
            CC = cc;
            Sex = sex;
            Available = available;
        }

        #endregion

        #region Properties
        public int FiremanId
        {
            set { firemanId = value; }
            get { return firemanId; }
        }

        public int Available
        {
            set { available = value; }
            get { return available; }
        }
        #endregion

        #region Functions

        #endregion

        #region Overrides
        public override bool Equals(object obj)
        {
            FireFighter c = obj as FireFighter;
            if (c == null) return false;
            return this.firemanId == c.firemanId;
        }
        #endregion

        #region Destructor
        /// <summary>
        /// The destructor.
        /// </summary>
        ~FireFighter()
        {
        }
        #endregion

        #endregion
    }
}
