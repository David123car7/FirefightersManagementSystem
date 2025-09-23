/*
*	<copyright file="TrabalhoPratico_Tentativa_.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>David Carvalho</author>
*   <date>12/11/2024 21:47:40</date>
*	<description></description>
**/
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using BusinessObjects;

namespace Data
{
    /// <summary>
    /// Purpose: Class that manages the list of firefighters
    /// Created by: David Carvalho
    /// Created on: 12/11/2024 21:47:40
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class ListFireFighters : IListManagment<FireFighter> , IListObjectManagment<FireFighter>, IListFilesManagment
    {
        #region Attributes      
        List<FireFighter> firefightersList;
        #endregion

        #region Methods

        #region Constructors
        public ListFireFighters()
        {
            firefightersList = new List<FireFighter>();
        }
        #endregion

        #region Properties
        #endregion

        #region Functions

        #region ListManagment
        /// <summary>
        /// Check if the firefighter with a certain id exists
        /// </summary>
        /// <param name="id">Firefighter id</param>
        /// <returns>Returns true if the firefighter exists, returns false if the firefighter does not exist</returns>
        public bool ContainsList(int id)
        {
            FireFighter aux = GetObject(id);
            if (firefightersList.Contains(aux))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Inserts a firefighter in the list of firefighters
        /// </summary>
        /// <param name="x">Firefigher to be inserted</param>
        /// <returns>Returns -1 if the firefighter is null, returns 0 if the firefighter allready exists in the list,returns 1 if the firefighter was inserted</returns>
        public int InsertList(FireFighter x)
        {
            if (x == null)
                return -1;

            if (firefightersList.Contains(x))
                return 0;

            firefightersList.Add(x);
            return 1;
        }

        /// <summary>
        /// Removes a firefighter in the list of firefighters
        /// </summary>
        /// <param name="id">Firefighter id</param>
        /// <returns>Returns -1 if the firefighter does not exist with the id given, returns 1 if the firefighter was removed</returns>
        public int RemoveList(int id)
        {
            FireFighter aux = GetObject(id);
            if (aux == null) return -1;
            firefightersList.Remove(aux);
            return 1;
        }

        /// <summary>
        /// Gets the firefighter that has a certain id
        /// </summary>
        /// <param name="id">Firefighter id</param>
        /// <returns>Returns the firefighter if he exists in the list, returns null if the firefighter does not exist</returns>
        public FireFighter GetObject(int id)
        {
            foreach (FireFighter x in firefightersList)
            {
                if(x.FiremanId == id) return x;
            }

            return null;
        }
        #endregion

        #region GetAttributes
        /// <summary>
        /// Gets the name of the firefighter with a certain id
        /// </summary>
        /// <param name="id">Id of the firefighter</param>
        /// <returns>Returns a empty string if the firefighter does not exist, returns the name of the firefighter</returns>
        public string GetName(int id)
        {
            if (!ContainsList(id))
                return string.Empty;

            FireFighter aux = GetObject(id);
            return aux.Name;
        }

        /// <summary>
        /// Gets the sex of the firefighter with a certain id
        /// </summary>
        /// <param name="id">Id of the firefighter</param>
        /// <returns>Returns 0 if the firefighter does not exist, returns the sex of the firefighter</returns>
        public Sex GetSex(int id)
        {
            if (!ContainsList(id))
                return 0;

            FireFighter aux = GetObject(id);
            return aux.Sex;
        }

        /// <summary>
        /// Gets the cc of the firefighter with a certain id
        /// </summary>
        /// <param name="id">Id of the firefighter</param>
        /// <returns>Returns string emtpty if the firefighter does not exist, returns the cc of the firefighter</returns>
        public string GetCC(int id)
        {
            if (!ContainsList(id))
                return string.Empty;

            FireFighter aux = GetObject(id);
            return aux.CC;
        }

        /// <summary>
        /// Gets the age of the firefighter with a certain id
        /// </summary>
        /// <param name="id">Id of the firefighter</param>
        /// <returns>Returns 0 if the firefighter does not exist, returns the age of the firefighter</returns>
        public int GetAge(int id)
        {
            if (!ContainsList(id))
                return 0;

            FireFighter aux = GetObject(id);
            return aux.Age;
        }

        /// <summary>
        /// Gets the available of the firefighter with a certain id
        /// </summary>
        /// <param name="id">Id of the firefighter</param>
        /// <returns>Returns 0 if the firefighter does not exist, returns the available of the firefighter</returns>
        public int GetAvailable(int id)
        {
            if (!ContainsList(id))
                return 0;

            FireFighter aux = GetObject(id);
            return aux.Available;
        }
        #endregion

        #region SetAttributes
        /// <summary>
        /// Sets the name of the firefighter with a certain id
        /// </summary>
        /// <param name="id">Id of the firefighter</param>
        /// <returns>Returns 0 if the firefighter does not exist, returns 1 if the name of the firefighter was changed</returns>
        public int SetName(int id, string name)
        {
            if (!ContainsList(id))
                return 0;

            FireFighter aux = GetObject(id);
            aux.Name = name;
            return 1;
        }

        /// <summary>
        /// Sets the sex of the firefighter with a certain id
        /// </summary>
        /// <param name="id">Id of the firefighter</param>
        /// <returns>Returns 0 if the firefighter does not exist, returns 1 if the sex of the firefighter was changed</returns>
        public int SetSex(int id, Sex sex)
        {
            if (!ContainsList(id))
                return 0;

            FireFighter aux = GetObject(id);
            aux.Sex = sex;
            return 1;
        }

        /// <summary>
        /// Sets the CC of the firefighter with a certain id
        /// </summary>
        /// <param name="id">Id of the firefighter</param>
        /// <returns>Returns 0 if the firefighter does not exist, returns 1 if the CC of the firefighter was changed</returns>
        public int SetCC(int id, string CC)
        {
            if (!ContainsList(id))
                return 0;

            FireFighter aux = GetObject(id);
            aux.CC = CC;
            return 1;
        }

        /// <summary>
        /// Sets the age of the firefighter with a certain id
        /// </summary>
        /// <param name="id">Id of the firefighter</param>
        /// <returns>Returns 0 if the firefighter does not exist, returns 1 if the age of the firefighter was changed</returns>
        public int SetAge(int id, int age)
        {
            if (!ContainsList(id))
                return 0;

            FireFighter aux = GetObject(id);
            aux.Age = age;
            return 1;
        }

        /// <summary>
        /// Sets the available of the firefighter with a certain id
        /// </summary>
        /// <param name="id">Id of the firefighter</param>
        /// <returns>Returns 0 if the firefighter does not exist, returns 1 if the available of the firefighter was changed</returns>
        public int SetAvailable(int id, int available)
        {
            if (!ContainsList(id))
                return 0;

            FireFighter aux = GetObject(id);
            aux.Available = available;
            return 1;
        }
        #endregion

        #region FirefightersManagment
        /// <summary>
        /// Adds a firefighter in the system
        /// </summary>
        /// <param name="fireFighter">Firefighter to be added</param>
        /// <returns>Returns 1 if the if the firefighters was added, returns 0 if the firefighter was allredy in the list, returns -1 if the fireFighter is null</returns>
        public int AddFirefighter(FireFighter fireFighter)
        {
            if (fireFighter != null)
            {
                if (InsertList(fireFighter) == 0)
                    return 0;
                return 1;
            }
            return -1;
        }

        /// <summary>
        /// Removes a firefighter from the system
        /// </summary>
        /// <param name="id">Id of the firefighter</param>
        /// <returns>Returns 1 if the if the firefighters was removed, returns 0 if the firefighter was not in the list</returns>
        public int RemoveFirefighter(int id)
        {
            if (RemoveList(id) == 0)
                return 0;
            else return 1;
        }

        /// <summary>
        /// Sends the firefighter to the incident
        /// </summary>
        /// <param name="fireFighterId">Firefighter id</param>
        /// <returns>Returns 1 if the firefighter was send to the incident, returns -1 if the firefighter does not exist, returns 0 if the firefighter was not available</returns>
        public int SendFirefighter(int fireFighterId)
        {
            FireFighter auxFirefighter = GetObject(fireFighterId);
            if (auxFirefighter == null)
                return -1;

            if (auxFirefighter.Available == 1)
            {
                auxFirefighter.Available = 0;

                return 1;
            }

            return 0;
        }

        /// <summary>
        /// Returns the firefighter from the incident
        /// </summary>
        /// <param name="fireFighterId">Firefighter id</param>
        /// <returns>Returns -1 if the firefighter does not exist, returns 0 if the firefighter was available, returns 1 if the firefighter was returned</returns>
        public int ReturnFirefighter(int fireFighterId)
        {
            FireFighter auxFirefighter = GetObject(fireFighterId);
            if (auxFirefighter == null)
                return -1;

            if (auxFirefighter.Available == 0)
            {
                auxFirefighter.Available = 1;
                return 1;
            }

            return 0;
        }
        #endregion

        #region Files
        /// <summary>
        /// Stores a list of FireFighters in a binary file
        /// </summary>
        /// <param name="filePath">Path of th file</param>
        /// <returns>Returns -1 if the list is was not stored, returns 1 if the list was stored</returns>
        public int StoreListBinaryFile(string filePath)
        {
            try
            {
                Stream stream = File.Open(filePath, FileMode.Create);
                BinaryFormatter bin = new BinaryFormatter();
                bin.Serialize(stream, firefightersList);
                stream.Close();
                return 1;
            }
            catch (IOException e)
            {
                throw new DataException(-10);
            }
        }

        /// <summary>
        /// Reads a list of firefighters in a binary file
        /// </summary>
        /// <param name="filePath">Path of the file</param>
        /// <returns>Returns -1 if the file does not exist, returns 1 if the list was readed</returns>
        public int ReadListBinaryFile(string filePath)
        {
            if (!File.Exists(filePath))
                return -1;

            try
            {
                Stream stream = File.Open(filePath, FileMode.Open, FileAccess.Read);
                BinaryFormatter bin = new BinaryFormatter();
                firefightersList = (List<FireFighter>)bin.Deserialize(stream);
                stream.Close();
                return 1;
            }
            catch (IOException e)
            {
                throw new DataException(-11);
            }
        }
        #endregion

        #endregion

        #region Overrides
        #endregion

        #region Destructor
        /// <summary>
        /// The destructor.
        /// </summary>
        ~ListFireFighters()
        {
        }
        #endregion

        #endregion
    }
}