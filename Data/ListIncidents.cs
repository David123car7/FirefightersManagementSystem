/*
*	<copyright file="TrabalhoPratico_Tentativa_.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>David Carvalho</author>
*   <date>06/11/2024 20:00:10</date>
*	<description></description>
**/
using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using BusinessObjects;

namespace Data
{
    /// <summary>
    /// Purpose: Class that manages the list of Incidents
    /// Created by: David Carvalho
    /// Created on: 06/11/2024 20:00:10
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class ListIncidents : IListManagment<IncidentRealTime>, IListObjectManagment<IncidentRealTime>, IListFilesManagment
    {
        #region Attributes
        List<IncidentRealTime> incidentsList;
        HistoricIncidents historicIncidents;
        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// The default Constructor.
        /// </summary>
        public ListIncidents()
        {
            incidentsList = new List<IncidentRealTime>();
            historicIncidents = new HistoricIncidents();
        }
        #endregion

        #region Properties
        public HistoricIncidents HistoricIncidents
        {
            set { historicIncidents = value; }
            get { return historicIncidents; }
        }
        #endregion

        #region Functions

        #region ListManagment
        /// <summary>
        /// Check if the incident with a certain id exists
        /// </summary>
        /// <param name="id">incident id</param>
        /// <returns>Returns true if the incident exists, returns false if the incident does not exist</returns>
        public bool ContainsList(int id)
        {
            IncidentRealTime aux = GetObject(id);
            if (incidentsList.Contains(aux))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Inserts a incidentRealTime in the list of incidents
        /// </summary>
        /// <param name="x">incidentRealTime to be inserted</param>
        /// <returns>Returns -1 if the incidentRealTime is null, returns 0 if the incidentRealTime allready exists in the list,returns 1 if the incidentRealTime was inserted</returns>
        public int InsertList(IncidentRealTime x)
        {
            if (x == null)
                return -1;

            if (incidentsList.Contains(x))
                return 0;

            incidentsList.Add(x);
            return 1;
        }

        /// <summary>
        /// Creates a incident real time and inserts it in the list of incidents
        /// </summary>
        /// <returns>Returns -1 if the incidentRealTime is null, returns 0 if the incidentRealTime allready exists in the list,returns 1 if the incidentRealTime was inserted</returns>
        public int CreateInsertList(Incident incident)
        {
            IncidentRealTime x = CreateIncidentRealTime(incident);
            return InsertList(x);
        }

        /// <summary>
        /// Removes a incidentRealTime in the list of incidents
        /// </summary>
        /// <param name="id">incidentRealTime id</param>
        /// <returns>Returns -1 if the incidentRealTime does not exist with the id given, returns 1 if the incidentRealTime was removed</returns>
        public int RemoveList(int id)
        {
            IncidentRealTime aux = GetObject(id);
            if (aux == null) return -1;
            incidentsList.Remove(aux);
            return 1;
        }

        /// <summary>
        /// Call the IncidentRealTime constructor to create a IncidentRealTime
        /// </summary>
        /// <param name="incidentId">Incident id</param>
        /// <param name="incidentTime">Time</param>
        /// <param name="location">Location</param>
        /// <param name="typeIncident">Type incident</param>
        /// <param name="priorityLevel">Priority level</param>
        /// <param name="fireFightersReq">fireFighters required</param>
        /// <returns>Returns the incident realTime, returns null if the incident real time was not created</returns>
        public IncidentRealTime CreateIncidentRealTime(Incident incident)
        {
            IncidentRealTime x = new IncidentRealTime(incident.IncidentId, incident.IncidentStartTime, incident.Location, incident.IncidentType.TypeIncident, incident.IncidentType.PriorityLevel, incident.IncidentType.FirefightersReq);
            if(x == null) return null;
            return x;
        }

        /// <summary>
        /// Gets the incidentRealTime that has a certain id
        /// </summary>
        /// <param name="id">incidentRealTime id</param>
        /// <returns>Returns the incidentRealTime if he exists in the list, returns null if the incidentRealTime does not exist</returns>
        public IncidentRealTime GetObject(int id)
        {
            foreach (IncidentRealTime x in incidentsList)
            {
                if (x.Incident.IncidentId == id) return x;
            }

            return null;
        }
        #endregion

        #region ListIdsInIncidentsRealTime
        /// <summary>
        /// Inserts a id inside the list of firefighter ids in the IncidentRealTime with a certain id
        /// </summary>
        /// <param name="incidentId">IncidentRealTime id to add the firefighter id</param>
        /// <param name="id">firefighter Id to add</param>
        /// <returns>Returns 0 if the integer allready exists in the list,returns 1 if the integer was inserted, returns -1 if the incident does not exist</returns>
        public int InsertListFirefighterIds(int incidentId, int id)
        {
            if (ContainsList(incidentId))
                return -1;

            IncidentRealTime x = GetObject(incidentId);
            return x.InsertList(id);
        }

        /// <summary>
        /// Removes a id inside the list of firefighter ids in the IncidentRealTime with a certain id
        /// </summary>
        /// <param name="incidentId">IncidentRealTime id to add the firefighter id</param>
        /// <param name="id">firefighter Id to remove</param>
        /// <returns>Returns 0 if the integer does not exist in the list, returns 1 if the integer was removed, returns -1 if the incident does not exist</returns>
        public int RemoveListFirefighterIds(int incidentId, int id)
        {
            if (!ContainsList(incidentId))
                return -1;

            IncidentRealTime x = GetObject(incidentId);
            return x.RemoveList(id);
        }

        /// <summary>
        /// Checks if exists a number in the list of numbers
        /// </summary>
        /// <param name="incidentId">Incident id</param>
        /// <param name="id">Id do add</param>
        /// <returns>Returns -1 if the incident does not exist, returns 1 if the number exists, returns 0 if the number does not exist</returns>
        public int ContainsIdListFirefighterIds(int incidentId, int id)
        {
            if (!ContainsList(incidentId))
                return -1;

            IncidentRealTime x = GetObject(incidentId);
            return x.ExistsNum(id);
        }
        #endregion

        #region HistoricIncidents
        /// <summary>
        /// Inserts a incident in the dicionaty
        /// </summary>
        /// <param name="id">incident id</param>
        /// <returns>Returns -1 if the incident is null, returns 1 if the incident was added to the dicionaty</returns>
        public int InsertHistoricIncidents(int id)
        {
            Incident aux = GetObject(id).Incident;
            if(aux == null) return -1;
            historicIncidents.InsertDictionary(aux);
            return 1; 
        }
        #endregion

        #region GetAttributes
        /// <summary>
        /// Gets the IncidentStartTime of the incident with a certain id
        /// </summary>
        /// <param name="id">Id of the incident</param>
        /// <returns>Returns the minValue of the dateTime if the incident does not exist, returns the IncidentStartTime of the incident</returns>
        public DateTime GetStartTime(int id)
        {
            if (!ContainsList(id))
                return DateTime.MinValue;

            Incident aux = GetObject(id).Incident;
            return aux.IncidentStartTime;
        }

        /// <summary>
        /// Gets the IncidentEndTime of the incident with a certain id
        /// </summary>
        /// <param name="id">Id of the incident</param>
        /// <returns>Returns the minValue of the dateTime if the incident does not exist, returns the IncidentEndTime of the incident</returns>
        public DateTime GetEndTime(int id)
        {
            if (!ContainsList(id))
                return DateTime.MinValue;

            Incident aux = GetObject(id).Incident;
            return aux.IncidentEndTime;
        }

        /// <summary>
        /// Gets the location of the incident with a certain id
        /// </summary>
        /// <param name="id">Id of the incident</param>
        /// <returns>Returns a empty string if the incident does not exist, returns the location of the incident</returns>
        public string GetLocation(int id)
        {
            if (!ContainsList(id))
                return string.Empty;

            Incident aux = GetObject(id).Incident;
            return aux.Location;
        }

        /// <summary>
        /// Gets the TypeIncident of the incident with a certain id
        /// </summary>
        /// <param name="id">Id of the incident</param>
        /// <returns>Returns 0 the incident does not exist, returns the TypeIncident of the incident</returns>
        public TypeIncidentEnum GetTypeIncident(int id)
        {
            if (!ContainsList(id))
                return 0;

            IncidentType aux = GetObject(id).Incident.IncidentType;
            return aux.TypeIncident;
        }

        /// <summary>
        /// Gets the PriorityLevel of the incident with a certain id
        /// </summary>
        /// <param name="id">Id of the incident</param>
        /// <returns>Returns 0 the incident does not exist, returns the PriorityLevel of the incident</returns>
        public int GetPriorityLevel(int id)
        {
            if (!ContainsList(id))
                return 0;

            IncidentType aux = GetObject(id).Incident.IncidentType;
            return aux.PriorityLevel;
        }

        /// <summary>
        /// Gets the FirefightersReq of the incident with a certain id
        /// </summary>
        /// <param name="id">Id of the incident</param>
        /// <returns>Returns 0 the incident does not exist, returns the FirefightersReq of the incident</returns>
        public int GetFireFightersReq(int id)
        {
            if (!ContainsList(id))
                return 0;

            IncidentType aux = GetObject(id).Incident.IncidentType;
            return aux.FirefightersReq;
        }
        #endregion

        #region SetAttributes
        /// <summary>
        /// Sets the IncidentStartTime of the incident with a certain id
        /// </summary>
        /// <param name="id">Id of the incident</param>
        /// <returns>Returns 0 if the incident does not exist, returns 1 if the IncidentStartTime of the incident was changed</returns>
        public int SetStartTime(int id, DateTime startTime)
        {
            if (!ContainsList(id))
                return 0;

            Incident aux = GetObject(id).Incident;
            aux.IncidentStartTime = startTime;
            return 1;
        }

        /// <summary>
        /// Sets the IncidentEndTime of the incident with a certain id
        /// </summary>
        /// <param name="id">Id of the incident</param>
        /// <returns>Returns 0 if the incident does not exist, returns 1 if the IncidentEndTime of the incident was changed</returns>
        public int SetEndTime(int id, DateTime endTime)
        {
            if (!ContainsList(id))
                return 0;

            Incident aux = GetObject(id).Incident;
            aux.IncidentEndTime = endTime;
            return 1;
        }

        /// <summary>
        /// Sets the Location of the incident with a certain id
        /// </summary>
        /// <param name="id">Id of the incident</param>
        /// <returns>Returns 0 if the incident does not exist, returns 1 if the Location of the incident was changed</returns>
        public int SetLocation(int id, string location)
        {
            if (!ContainsList(id))
                return 0;

            Incident aux = GetObject(id).Incident;
            aux.Location = location;
            return 1;
        }

        /// <summary>
        /// Sets the TypeIncident of the incident with a certain id
        /// </summary>
        /// <param name="id">Id of the incident</param>
        /// <returns>Returns 0 if the incident does not exist, returns 1 if the TypeIncident of the incident was changed</returns>
        public int SetIncidentType(int id, TypeIncidentEnum incidentType)
        {
            if (!ContainsList(id))
                return 0;

            IncidentType aux = GetObject(id).Incident.IncidentType;
            aux.TypeIncident = incidentType;
            return 1;
        }

        /// <summary>
        /// Sets the PriorityLevel of the incident with a certain id
        /// </summary>
        /// <param name="id">Id of the incident</param>
        /// <returns>Returns 0 if the incident does not exist, returns 1 if the PriorityLevel of the incident was changed</returns>
        public int SetPriorityLevel(int id, int priorityLevel)
        {
            if (!ContainsList(id))
                return 0;

            IncidentType aux = GetObject(id).Incident.IncidentType;
            aux.PriorityLevel = priorityLevel;
            return 1;
        }

        /// <summary>
        /// Sets the FirefightersReq of the incident with a certain id
        /// </summary>
        /// <param name="id">Id of the incident</param>
        /// <returns>Returns 0 if the incident does not exist, returns 1 if the FirefightersReq of the incident was changed</returns>
        public int SetFirefightersReq(int id, int firefightersReq)
        {
            if (!ContainsList(id))
                return 0;

            IncidentType aux = GetObject(id).Incident.IncidentType;
            aux.FirefightersReq = firefightersReq;
            return 1;
        }
        #endregion

        #region IncidentsManagment
        /// <summary>
        /// Adds a incident to the system
        /// </summary>
        /// <param name="incident">Incident id</param>
        /// <returns>Returns 1 if the if the incident was added, returns 0 if the incident was allredy in the list, returns -1 if the incident is null</returns>
        public int CreateAddIncidents(Incident incident)
        {            
           if (CreateInsertList(incident) == 0) 
                return 0;
           OrderIncidents();
           return 1;
        }

        /// <summary>
        /// Removes a incident from the list of incidents
        /// </summary>
        /// <param name="incidentId">Incident id</param>
        /// <returns>Returns 1 if the if the incident was removed, returns 0 if the incident was not in the list</returns>
        public int RemoveIncidents(int incidentId)
        {
            return RemoveList(incidentId);
        }

        /// <summary>
        /// Checks if the incident needs support
        /// </summary>
        /// <param name="incidentId"></param>
        /// <returns>Returns 1 if the incident needs suport, returns 0 if the incident does not need support, returns -1 if the incident does not exist</returns>
        public int CheckIncidentNeedsSupport(int incidentId)
        {
            if(!ContainsList(incidentId))
                return -1;

            IncidentRealTime incident = GetObject(incidentId);
            return incident.NeedsFirefighterSupport();
        }

        /// <summary>
        /// Orders the incident lists by priority of the incidents and by the time
        /// </summary>
        /// <returns></returns>
        private int OrderIncidents()
        {
            for (int i = 0; i < incidentsList.Count; i++)
            {
                for (int j = 0; j < incidentsList.Count; j++)
                {
                    int k = j + 1;
                    if (k != incidentsList.Count)
                    {
                        if (incidentsList[j].Incident.IncidentType.PriorityLevel != 0 && incidentsList[k].Incident.IncidentType.PriorityLevel != 0)
                        {
                            if (incidentsList[j].Incident.IncidentType.PriorityLevel > incidentsList[k].Incident.IncidentType.PriorityLevel)
                            {
                                IncidentRealTime aux = incidentsList[k];
                                incidentsList[k] = incidentsList[j];
                                incidentsList[j] = aux;
                            }
                            else if (incidentsList[j].Incident.IncidentType.PriorityLevel == incidentsList[k].Incident.IncidentType.PriorityLevel)
                            {
                                if (incidentsList[j].Incident.IncidentStartTime > incidentsList[k].Incident.IncidentStartTime)
                                {
                                    IncidentRealTime aux = incidentsList[k];
                                    incidentsList[k] = incidentsList[j];
                                    incidentsList[j] = aux;
                                }
                            }
                        }
                    }
                }
            }

            return 1;
        }
        #endregion

        #region Files
        /// <summary>
        /// Stores a list of incidentsRealtime in a binary file
        /// </summary>
        /// <param name="filePath">Path of th file</param>
        /// <returns>Returns 1 if the list was stored</returns>
        public int StoreListBinaryFile(string filePath)
        {
            try
            {
                Stream stream = File.Open(filePath, FileMode.Create);
                BinaryFormatter bin = new BinaryFormatter();
                bin.Serialize(stream, incidentsList);
                stream.Close();
                return 1;
            }
            catch (IOException e)
            {
                throw new DataException(-10);
            }
        }

        /// <summary>
        /// Reads a list of incidentsRealtime in a binary file
        /// </summary>
        /// <param name="filePath">Path of the file</param>
        /// <returns>Returns 0 if the file does not exist, returns 1 if the list was readed</returns>
        public int ReadListBinaryFile(string filePath)
        {
            if (!File.Exists(filePath))
                return 0;

            try
            {
                Stream stream = File.Open(filePath, FileMode.Open, FileAccess.Read);
                BinaryFormatter bin = new BinaryFormatter();
                incidentsList = (List<IncidentRealTime>)bin.Deserialize(stream);
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
        ~ListIncidents()
        {
        }
        #endregion

        #endregion
    }
}
