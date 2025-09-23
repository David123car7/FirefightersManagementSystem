/*
*	<copyright file="TrabalhoPOO_27973Fase1.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>David Carvalho</author>
*   <date>16/12/2024 18:14:48</date>
*	<description></description>
**/
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using BusinessObjects;

namespace Data
{
    /// <summary>
    /// Purpose: Class that manages the dictionary of Incidents (historic of incidents)
    /// Created by: David Carvalho
    /// Created on: 16/12/2024 18:14:48
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class HistoricIncidents  
    {
        #region Attributes
        Dictionary<int, List<Incident>> dictionary;
        const int maxCollisions = 11;
        #endregion

        #region Methods

        #region Constructors

        public HistoricIncidents()
        {
            dictionary = new Dictionary<int, List<Incident>>();
        }

        #endregion

        #region Properties

        #endregion

        #region Functions

        #region DictionaryManagment
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nome"></param>
        /// <returns></returns>
        public bool ExistsIncident(int id, Incident x)
        {
            int key = CreateKey(x);
            if (dictionary.ContainsKey(key))
            {
                foreach (Incident inc in dictionary[key])
                {
                    if (inc.IncidentId == id) return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Inserts a incident in the dictionary using a key
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="x">Incident to add</param>
        /// <returns>Returns -1 if the incident is null, returns 1 if the incident was added to the dictionary</returns>
        private int InsertDictionaryUsingKey(int key, Incident x)
        {
            if (x == null)
                return -1;

            if (!dictionary.ContainsKey(key))
                dictionary.Add(key, new List<Incident>());

            dictionary[key].Add(x);
            return 1;
        }

        /// <summary>
        /// Inserts a incident in the dictionary 
        /// </summary>
        /// <param name="x">Incident</param>
        /// <returns>Returns -1 if the incident is null, returns 1 if the incident was added to the dictionary</returns>
        public int InsertDictionary(Incident x)
        {
            if (x == null)
                return -1;

            int key = CreateKey(x);
            InsertDictionaryUsingKey(key, x);
           
            return 1;
        }


        /// <summary>
        /// Creates the key for the dictionary
        /// </summary>
        /// <param name="x">Incident</param>
        /// <returns>Returns 1 if the key was created, returns -1 if the incident was null</returns>
        private int CreateKey(Incident x)
        {
            if (x == null)
                return -1;

            string aux = x.GetHashCode().ToString();
            int key = 0;
            foreach (char c in aux)
            {
                key += (int)c;
            }
            return (key % maxCollisions);
        }
        #endregion

        #region Files
        /// <summary>
        /// Stores a dictionary of Incidents in a binary file
        /// </summary>
        /// <param name="filePath">Path of th file</param>
        /// <returns>Returns 1 if the dictionary was stored</returns>
        public int StoreDictionaryBinaryFile(string filePath)
        {
            try
            {
                Stream stream = File.Open(filePath, FileMode.Create);
                BinaryFormatter bin = new BinaryFormatter();
                bin.Serialize(stream, dictionary);
                stream.Close();
                return 1;
            }
            catch (IOException e)
            {
                throw new DataException(-10);
            }
        }

        /// <summary>
        /// Reads a dictionary of Incidents in a binary file
        /// </summary>
        /// <param name="filePath">Path of the file</param>
        /// <returns>Returns -1 if the dictionary was not readed, returns 0 if the file path was invlalid, returns 1 if the dictionary was readed</returns>
        public int ReadDictionaryBinaryFile(string filePath)
        {
            if (!File.Exists(filePath))
                return 0;

            try
            {
                Stream stream = File.Open(filePath, FileMode.Open, FileAccess.Read);
                BinaryFormatter bin = new BinaryFormatter();
                dictionary = (Dictionary<int, List<Incident>>)bin.Deserialize(stream);
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
        ~HistoricIncidents()
        {
        }
        #endregion

        #endregion
    }
}
