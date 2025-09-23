/*
*	<copyright file="TrabalhoPOO_27973.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>David Carvalho</author>
*   <date>18/12/2024 19:33:18</date>
*	<description></description>
**/
using System.Linq;
using BusinessObjects;


namespace Validations
{
    /// <summary>
    /// Purpose: Class that haves all validations about the firefighters
    /// Created by: David Carvalho
    /// Created on: 18/12/2024 19:33:18
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class FirefighterValidation
    {
        public FirefighterValidation()
        {

        }

        /// <summary>
        /// Checks if the fireFighter is valid
        /// The firefighter can not be null
        /// </summary>
        /// <param name="fireFighter">Firefighter</param>
        /// <returns>Returns -107 if it is firefighter object isnot valid, returns -101 if the id is invalid, returns -103 if the name is invalid, 
        /// returns -102 if the availble is invalid, returns -106 if the age is invalid
        /// returns -105 if the cc is invalid, returns -104 if the sex is invalid,returns 1 if is valid</returns>
        public int CheckFirefighter(FireFighter fireFighter)
        {
            if (fireFighter == null) return -107;
            if (CheckId(fireFighter.FiremanId) == -1) return -101;
            if (CheckName(fireFighter.Name) == -1) return -103;
            if (CheckAvailable(fireFighter.Available) == -1) return -102;
            if (CheckAge(fireFighter.Age) == -1) return -106;
            if (CheckCC(fireFighter.CC) == -1) return -105;
            if (CheckSex(fireFighter.Sex) == -1) return -104;

            else return 1;
        }

        /// <summary>
        /// Checks if the id is valid
        /// The id must be higher than 0
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Returns -1 if it is not valid, returns 1 if is valid</returns>
        public int CheckId(int id)
        {
            if (id < 0) return -1;
            else return 1;
        }

        /// <summary>
        /// Checks if the available is valid
        /// The available must be 1 or 0
        /// </summary>
        /// <param name="available">Available</param>
        /// <returns>Returns -1 if it is not valid, returns 1 if is valid</returns>
        public int CheckAvailable(int available)
        {
            if (available != 1 && available != 0) return -1;
            else return 1;
        }

        /// <summary>
        /// Checks if the name is valid
        /// The string cant be empty or null
        /// </summary>
        /// <param name="name">Name</param>
        /// <returns>Returns -1 if it is not valid, returns 1 if is valid</returns>
        public int CheckName(string name)
        {
            if (string.IsNullOrEmpty(name)) return -1;
            else return 1;
        }

        /// <summary>
        /// Checks if the sex is valid
        /// </summary>
        /// <param name="sex">Sex</param>
        /// <returns>Returns -1 if it is not valid, returns 1 if is valid</returns>
        public int CheckSex(Sex sex)
        {
            return 1;
        }

        /// <summary>
        /// Checks if the cc is valid
        /// The cc must contain 16 digits
        /// </summary>
        /// <param name="cc">CC</param>
        /// <returns>Returns -1 if it is not valid, returns 1 if is valid</returns>
        public int CheckCC(string cc)
        {
            if (cc.Count() != 16) return -1;
            else return 1;
        }

        /// <summary>
        /// Checks if the age is valid
        /// The age must be higher than 18
        /// </summary>
        /// <param name="age">Age</param>
        /// <returns>Returns -1 if it is not valid, returns 1 if is valid</returns>
        public int CheckAge(int age)
        {
            if (age < 18) return -1;
            else return 1;
        }
    }
}