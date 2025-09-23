/*
*	<copyright file="TrabalhoPOO_27973Fase1.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>David Carvalho</author>
*   <date>16/12/2024 15:45:51</date>
*	<description></description>
**/
using System;
using System.Collections.Generic;
using BusinessObjects;

namespace Data
{
    /// <summary>
    /// Purpose: Class that manages the IncidentsRealTime
    /// Created by: David Carvalho
    /// Created on: 16/12/2024 15:45:51
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    [Serializable]//IListManagment<int>
    public class IncidentRealTime 
    {
        #region Attributes
        Incident incident;
        List<int> firefightersIds;
        #endregion

        #region Methods

        #region Constructors
        /// <summary>
        /// Constructor that build the IncidentRealTime Class only assigning the value of the id to the incident class(attribute)
        /// </summary>
        public IncidentRealTime(int incidentId)
        {
            incident = new Incident(incidentId);
            firefightersIds = new List<int>();
        }

        /// <summary>
        /// Constructor that build the IncidentRealTime Class 
        /// </summary>
        /// <param name="incidentId">Id of the incident</param>
        /// <param name="incidentTime">Date of the incident</param>
        /// <param name="location">Location of the incident</param>
        public IncidentRealTime(int incidentId, DateTime incidentTime, string location, TypeIncidentEnum typeIncident, int priorityLevel, int fireFightersReq)
        {
            incident = new Incident(incidentId, incidentTime, location, typeIncident, priorityLevel, fireFightersReq);
            firefightersIds = new List<int>();
        }
        #endregion

        #region Properties
        public Incident Incident
        {
            set { incident = value; }
            get { return incident; }
        }
        #endregion

        #region Functions

        #region ListManagment
        /// <summary>
        /// Inserts a integer in the list of integers
        /// </summary>
        /// <param name="num">integer to be inserted</param>
        /// <returns>Returns 0 if the integer allready exists in the list,returns 1 if the integer was inserted</returns>
        public int InsertList(int num)
        {
            if (firefightersIds.Contains(num))
                return 0;

            firefightersIds.Add(num);
            return 1;
        }

        /// <summary>
        /// Removes a integer in the list of integer
        /// </summary>
        /// <param name="num">integer to be removed</param>
        /// <returns>Returns 0 if the integer does not exist in the list, returns 1 if the integer was removed</returns>
        public int RemoveList(int num)
        {
            if (!firefightersIds.Contains(num))
                return 0;

            firefightersIds.Remove(num);
            return 1;
        }

        /// <summary>
        /// Checks if exists a number in the list o numbers
        /// </summary>
        /// <param name="num"></param>
        /// <returns>Returns 1 if exists, returns 0 if does not exist</returns>
        public int ExistsNum(int num)
        {
            if (firefightersIds.Contains(num))
                return 1;
            else return 0;
        }
        #endregion

        /// <summary>
        /// Checks if the incident needs support of more firefighters
        /// </summary>
        /// <returns>Returns 1 if the incident needs suport, returns 0 if the incident does not need support</returns>
        public int NeedsFirefighterSupport()
        {
            if (incident.IncidentType.FirefightersReq >= firefightersIds.Count)
                return 1;
            else
                return 0;
        }

        /// <summary>
        /// Gets the number of firefighters needed to fill the required amount 
        /// </summary>
        /// <returns>Returns -1 if the incident does not need support, returns the number of firefighters needed if they are needed</returns>
        public int GetFirefightersNeeded()
        {
            int x = incident.IncidentType.FirefightersReq - firefightersIds.Count;
            if (x < 0)
            {
                return -1;
            }
            return incident.IncidentType.FirefightersReq - firefightersIds.Count;
        }
        #endregion

        #region Overrides
        public override bool Equals(object obj)
        {
            IncidentRealTime c = obj as IncidentRealTime;
            if (c == null) return false;
            return this.Incident.IncidentId == c.Incident.IncidentId;
        }
        #endregion

        #region Destructor
        /// <summary>
        /// The destructor.
        /// </summary>
        ~IncidentRealTime()
        {
        }
        #endregion

        #endregion
    }
}
