/*
*	<copyright file="TrabalhoPOO_27973.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>David Carvalho</author>
*   <date>18/12/2024 20:06:09</date>
*	<description></description>
**/
using System;
using BusinessObjects;
using Data;

namespace Validations
{
    /// <summary>
    /// Purpose: Class that haves all validations about the incidents
    /// Created by: David Carvalho
    /// Created on: 18/12/2024 20:06:09
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class IncidentValidation
    {
        /// <summary>
        /// Checks if the incidentRealtime is valid
        /// </summary>
        /// <param name="incidentRealTime">Incident realtime</param>
        /// <returns>Returns a code if it is not valid, returns 1 if is valid</returns>
        public int CheckIncidenRealtime(IncidentRealTime incidentRealTime)
        {
            if (incidentRealTime == null) return -1;
            return CheckIncident(incidentRealTime.Incident);
        }

        /// <summary>
        /// Checks if the incident is valid
        /// The incident can not be null
        /// </summary>
        /// <param name="incident">Incident</param>
        /// <returns>Returns a code if it is not valid, returns 1 if is valid</returns>
        public int CheckIncident(Incident incident)
        {
            if (incident == null) return -207;
            if (CheckId(incident.IncidentId) != 1) return -201;
            if (CheckTime(incident.IncidentStartTime) != 1) return -202;
            if (CheckLocation(incident.Location) != 1) return -203;
            if (CheckTypeIncident(incident.IncidentType.TypeIncident) != 1) return -204;
            if (CheckPriorityLevel(incident.IncidentType.PriorityLevel) != 1) return -205;
            if (CheckFirefightersReq(incident.IncidentType.FirefightersReq) != 1) return -206;
            return 1;
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
        /// Checks if the Datetime is valid
        /// The datetime cant equal to the min value of the date time
        /// </summary>
        /// <param name="time">Time</param>
        /// <returns>Returns -1 if it is not valid, returns 1 if is valid</returns>
        public int CheckTime(DateTime time)
        { 
            if(time == DateTime.MinValue) return -1; 
            else return 1;
        }

        /// <summary>
        /// Checks if the location is valid
        /// The string cant be empty or null
        /// </summary>
        /// <param name="location">Location</param>
        /// <returns>Returns -1 if it is not valid, returns 1 if is valid</returns>
        public int CheckLocation(string location)
        {
            if(string.IsNullOrEmpty(location)) return -1;
            else return 1;
        }

        /// <summary>
        /// Checks if the location is valid
        /// </summary>
        /// <param name="type">TypeIncidentEnum</param>
        /// <returns>Returns -1 if it is not valid, returns 1 if is valid</returns>
        public int CheckTypeIncident(TypeIncidentEnum type)
        {
            if (type == 0) return -1;
            return 1;
        }

        /// <summary>
        /// Checks if the priorityLevel is valid
        /// The priorityLevel must be 1, 2 or 3
        /// </summary>
        /// <param name="priorityLevel">PriorityLevel</param>
        /// <returns>Returns -1 if it is not valid, returns 1 if is valid</returns>
        public int CheckPriorityLevel(int priorityLevel) 
        {
            if (priorityLevel != 1 && priorityLevel != 2 && priorityLevel != 3) return -1;
            else return 1;
        }

        /// <summary>
        /// Checks if the firefightersReq is valid 
        /// Must be higher than 0
        /// </summary>
        /// <param name="firefightersReq">firefighters required</param>
        /// <returns>Returns -1 if it is not valid, returns 1 if is valid</returns>
        public int CheckFirefightersReq(int firefightersReq)
        {
            if(firefightersReq < 0) return -1;
            return 1;
        }     
    }
}
