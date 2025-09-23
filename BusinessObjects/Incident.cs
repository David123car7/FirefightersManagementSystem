/*
*	<copyright file="TrabalhoPratico_Tentativa_.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>David Carvalho</author>
*   <date>31/10/2024 20:27:11</date>
*	<description></description>
**/
using System;


namespace BusinessObjects
{
    public enum TypeIncidentEnum
    {
        Fire = 1,
        Transport = 2
        //Invalid = 0
    }

    /// <summary>
    /// Purpose: Class of the incident
    /// Created by: David Carvalho
    /// Created on: 31/10/2024 20:27:11
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    [Serializable]
    public class Incident 
    {
        #region Attributes
        int incidentId;
        DateTime incidentStartTime;
        DateTime incidentEndTime;
        string location;
        IncidentType incidentType;
        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// The default Constructor.
        /// </summary>
        public Incident()
        {
            
        }

        /// <summary>
        /// Constructor that build the Incident Class only assigning the value of the id
        /// </summary>
        public Incident(int incidentId)
        {
            IncidentId = incidentId;
            incidentType = new IncidentType();
        }

        /// <summary>
        /// Constructor that build the Incident Class without assigning values to the class IncidentType as a attribute
        /// </summary>
        /// <param name="incidentId">Id of the incident</param>
        /// <param name="incidentTime">Date of the incident</param>
        /// <param name="location">Location of the incident</param>
        public Incident(int incidentId, DateTime incidentTime, string location)
        {
            IncidentId = incidentId;
            IncidentStartTime = incidentTime;
            Location = location;
        }

        /// <summary>
        /// Constructor that build the Incident Class and also assigning values to the class IncidentType as a attribute
        /// </summary>
        /// <param name="incidentId">Id of the incident</param>
        /// <param name="incidentTime">Date of the incident</param>
        /// <param name="location">Location of the incident</param>
        /// <param name="typeIncident">Type of incident</param>
        /// <param name="priorityLevel">Level of priority</param>
        /// <param name="fireFightersReq">Number of firefighters required</param>
        /// <param name="vehiclesReq">Number of vehicles required</param>
        public Incident(int incidentId, DateTime incidentTime, string location, TypeIncidentEnum typeIncident, int priorityLevel, int fireFightersReq)
        {
            IncidentId = incidentId;
            IncidentStartTime = incidentTime;
            Location = location;
            incidentType = new IncidentType(typeIncident, priorityLevel, fireFightersReq);
        }

        #endregion

        #region Properties
        public int IncidentId
        {
            set { incidentId = value; }
            get { return incidentId; }
        }

        public IncidentType IncidentType
        {
            set { incidentType = value; }
            get { return incidentType; }
        }

        public DateTime IncidentStartTime
        { 
            set { incidentStartTime = value; }
            get { return incidentStartTime; }
        }

        public DateTime IncidentEndTime
        {
            set { incidentEndTime = value; }
            get { return incidentEndTime; }
        }

        public string Location
        {
            set { location = value; }
            get { return location; }
        }
        #endregion

        #region Functions
        #endregion

        #endregion

        #region Overrides
        public override bool Equals(object obj)
        {
            Incident c = obj as Incident;
            if (c == null) return false;
            return this.incidentId == c.incidentId;
        }
        #endregion

        #region Destructor
        /// <summary>
        /// The destructor.
        /// </summary>
        ~Incident()
        {
        }
        #endregion

    }

    /// <summary>
    /// Purpose: Class of the incident type
    /// Created by: David Carvalho
    /// Created on: 31/10/2024 20:27:11
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    [Serializable]
    public class IncidentType
    {
        TypeIncidentEnum incidentType;
        int priorityLevel; 
        int fireFightersReq;

        #region Constructors
        /// <summary>
        /// Default Constructor
        /// </summary>
        public IncidentType()
        {
        }

        /// <summary>
        /// Constructor that builds the IncidentType
        /// </summary>
        /// <param name="typeIncident"></param>
        /// <param name="priorityLevel"></param>
        /// <param name="fireFightersReq"></param>
        /// <param name="vehiclesReq"></param>
        public IncidentType(TypeIncidentEnum typeIncident, int priorityLevel, int fireFightersReq)
        {
            TypeIncident = typeIncident;
            PriorityLevel = priorityLevel;
            FirefightersReq = fireFightersReq;
        }
        #endregion

        #region Properties
        public TypeIncidentEnum TypeIncident
        {
            set { incidentType = value; }
            get { return incidentType; }
        }

        public int PriorityLevel
        {
            set { priorityLevel = value; }
            get { return priorityLevel; }
        }

        public int FirefightersReq
        {
            set { fireFightersReq = value; }
            get { return fireFightersReq; }
        }
        #endregion

    }
}
