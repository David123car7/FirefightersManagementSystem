/*
*	<copyright file="BusinessRules.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>David Carvalho</author>
*   <date>19/12/2024 14:51:05</date>
*	<description></description>
**/
using BusinessObjects;
using Data;
using System;
using Validations;

namespace BusinessRules
{
    /// <summary>
    /// Purpose: Class that contains all rules about the incidents
    /// Created by: David Carvalho
    /// Created on: 19/12/2024 14:51:05
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class IncidentRules
    {
        #region Attributes
        ListIncidents listIncidents;
        IncidentValidation incidentValidation;
        GeneralValidations generalValidations;

        ErrorsLog errorsLog;
        const string fileLog = "IncidentLog";
        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// The default Constructor.
        /// </summary>
        public IncidentRules()
        {
            listIncidents = new ListIncidents();
            incidentValidation = new IncidentValidation();
            generalValidations = new GeneralValidations();
            errorsLog = new ErrorsLog();
        }

        #endregion

        #region Gets
        /// <summary>
        /// Trys to get the startTime of the incident by validating the incident id and checking if there is sufficient permissions
        /// </summary>
        /// <param name="incidentId">Incident id</param>
        /// <param name="permission">Permission</param>
        /// <returns>Returns DateTime.MinValue if ocurred some error, returns the start time if there was not any error
        /// Out returns -201 if firefighter id is invalid, returns -51 if there is not sufficient permissions
        /// returns -208 if incident does not exist
        /// </returns>
        public DateTime TryGetStartTime(int incidentId, Permissions permission, out int error)
        {
            
            if (incidentValidation.CheckId(incidentId) == -1)
            {
                error = -201;
                errorsLog.CreateGetInsertList(error, DateTime.Now);
                return DateTime.MinValue;
            }
                
            if (permission == Permissions.LOW)
            {
                error = -51;
                errorsLog.CreateGetInsertList(error, DateTime.Now);
                return DateTime.MinValue;
            }

            DateTime aux = listIncidents.GetStartTime(incidentId);
            if (aux == DateTime.MinValue)
            {
                error = -208;
                errorsLog.CreateGetInsertList(error, DateTime.Now);
                return aux;
            }
            error = 1;
            return aux;
        }

        /// <summary>
        /// Trys to get the endTime of the incident by validating the incident id and checking if there is sufficient permissions
        /// </summary>
        /// <param name="incidentId">Incident id</param>
        /// <param name="permission">Permission</param>
        /// <returns>Returns DateTime.MinValue if ocurred some error, returns the start time if there was not any error
        /// Out returns -201 if firefighter id is invalid, returns -51 if there is not sufficient permissions
        /// returns -208 if incident does not exist
        /// </returns>
        public DateTime TryGetEndTime(int incidentId, Permissions permission, out int error)
        {
            if (incidentValidation.CheckId(incidentId) == -1)
            {
                error = -201;
                errorsLog.CreateGetInsertList(error, DateTime.Now);
                return DateTime.MinValue;
            }

            if (permission == Permissions.LOW)
            {
                error = -51;
                errorsLog.CreateGetInsertList(error, DateTime.Now);
                return DateTime.MinValue;
            }

            DateTime aux = listIncidents.GetEndTime(incidentId);
            if (aux == DateTime.MinValue)
            {
                error = -208;
                errorsLog.CreateGetInsertList(error, DateTime.Now);
                return aux;
            }
            error = 1;
            return aux;
        }

        /// <summary>
        /// Trys to get the location of the incident by validating the incident id and checking if there is sufficient permissions
        /// </summary>
        /// <param name="incidentId">Incident id</param>
        /// <param name="permission">Permission</param>
        /// <returns>Returns string.Empty if ocurred some error, returns the location if there was not any error
        /// Out returns -201 if firefighter id is invalid, returns -51 if there is not sufficient permissions
        /// returns -208 if incident does not exist
        /// </returns>
        public string TryGetLocation(int incidentId, Permissions permission, out int error)
        {
            if (incidentValidation.CheckId(incidentId) == -1)
            {
                error = -201;
                errorsLog.CreateGetInsertList(error, DateTime.Now);
                return string.Empty;
            }

            if (permission == Permissions.LOW)
            {
                error = -51;
                errorsLog.CreateGetInsertList(error, DateTime.Now);
                return string.Empty;
            }

            string aux = listIncidents.GetLocation(incidentId);
            if (aux == string.Empty)
            {
                error = -208;
                errorsLog.CreateGetInsertList(error, DateTime.Now);
                return aux;
            }
            error = 1;
            return aux;
        }

        /// <summary>
        /// Trys to get the TypeIncidentEnum of the incident by validating the incident id and checking if there is sufficient permissions
        /// </summary>
        /// <param name="incidentId">Incident id</param>
        /// <param name="permission">Permissions</param>
        /// <returns>Returns 0 if ocurred some error, returns the TypeIncident if there was not any error
        /// Out returns -201 if firefighter id is invalid, returns -51 if there is not sufficient permissions
        /// returns -208 if incident does not exist
        /// </returns>
        public TypeIncidentEnum GetTypeIncident(int incidentId, Permissions permission, out int error)
        {
            if (incidentValidation.CheckId(incidentId) == -1)
            {
                error = -201;
                errorsLog.CreateGetInsertList(error, DateTime.Now);
                return 0;
            }

            if (permission == Permissions.LOW)
            {
                error = -51;
                errorsLog.CreateGetInsertList(error, DateTime.Now);
                return 0;
            }

            TypeIncidentEnum aux = listIncidents.GetTypeIncident(incidentId);
            if (aux == 0)
            {
                error = -208;
                errorsLog.CreateGetInsertList(error, DateTime.Now);
                return aux;
            }

            error = 1;
            return aux;
        }

        /// <summary>
        /// Trys to get the priotity level of the incident by validating the incident id and checking if there is sufficient permissions
        /// </summary>
        /// <param name="incidentId">Incident id</param>
        /// <param name="permission">Permissions</param>
        /// <returns>Returns 0 if ocurred some error, returns the priorityLevel if there was not any error
        /// Out returns -201 if firefighter id is invalid, returns -51 if there is not sufficient permissions
        /// returns -208 if incident does not exist
        /// </returns>
        public int TryGetPriorityLevel(int incidentId, Permissions permission, out int error)
        {
            if (incidentValidation.CheckId(incidentId) == -1)
            {
                error = -201;
                errorsLog.CreateGetInsertList(error, DateTime.Now);
                return 0;
            }

            if (permission == Permissions.LOW)
            {
                error = -51;
                errorsLog.CreateGetInsertList(error, DateTime.Now);
                return 0;
            }

            int aux = listIncidents.GetPriorityLevel(incidentId);
            if (aux == 0)
            {
                error = -208;
                errorsLog.CreateGetInsertList(error, DateTime.Now);
                return aux;
            }

            error = 1;
            return aux;
        }

        /// <summary>
        /// Trys to get the FightersReq of the incident by validating the incident id and checking if there is sufficient permissions
        /// </summary>
        /// <param name="incidentId">Incident id</param>
        /// <param name="permission">Permissions</param>
        /// <returns>Returns 0 if ocurred some error, returns the fireFighters req if there was not any error
        /// Out returns -201 if firefighter id is invalid, returns -51 if there is not sufficient permissions
        /// returns -208 if incident does not exist
        /// </returns>
        public int TryGetFireFightersReq(int incidentId, Permissions permission, out int error)
        {
            if (incidentValidation.CheckId(incidentId) == -1)
            {
                error = -201;
                errorsLog.CreateGetInsertList(error, DateTime.Now);
                return 0;
            }

            if (permission == Permissions.LOW)
            {
                error = -51;
                errorsLog.CreateGetInsertList(error, DateTime.Now);
                return 0;
            }

            int aux = listIncidents.GetFireFightersReq(incidentId);
            if (aux == 0)
            {
                error = -208;
                errorsLog.CreateGetInsertList(error, DateTime.Now);
                return aux;
            }

            error = 1;
            return aux;
        }
        #endregion

        #region Sets
        /// <summary>
        /// Trys to set the startTime of the incident by validating the incident id and the startTime, and checking if there is sufficient permissions
        /// </summary>
        /// <param name="incidentId">Incident id</param>
        /// <param name="startTime">Start time</param>
        /// <param name="permission">Permissions</param>
        /// <returns>Returns -201 if the incident id is not valid, returns -202 if the startTime is not valid, returns -51 if there is not sufficient permissions, returns -208 if the incident does not exist, returns 1 if the startTime was seted</returns>
        public int TrySetStartTime(int incidentId, DateTime startTime, Permissions permission)
        {
            if (incidentValidation.CheckId(incidentId) == -1)
            {
                errorsLog.CreateGetInsertList(-201, DateTime.Now);
                return -201;
            }
                
            if (incidentValidation.CheckTime(startTime) == -1)
            {
                errorsLog.CreateGetInsertList(-202, DateTime.Now);
                return -202;
            }
                
            if (permission == Permissions.LOW)
            {
                errorsLog.CreateGetInsertList(-51, DateTime.Now);
                return -51;
            }
              
            if (listIncidents.SetStartTime(incidentId, startTime) == 0)
            {
                errorsLog.CreateGetInsertList(-208, DateTime.Now);
                return -208;
            }
            else
                return 1;
        }

        /// <summary>
        /// Trys to set the endTime of the incident by validating the incident id and the endTime, and checking if there is sufficient permissions
        /// </summary>
        /// <param name="incidentId">Incident id</param>
        /// <param name="endTime">End time</param>
        /// <param name="permission">Permissions</param>
        /// <returns>Returns -201 if the incident id is not valid, returns -202 if the startTime is not valid, returns -51 if there is not sufficient permissions, returns -208 if the incident does not exist, returns 1 if the startTime was seted</returns>
        public int TrySetEndTime(int incidentId, DateTime endTime, Permissions permission)
        {
            if (incidentValidation.CheckId(incidentId) == -1)
            {
                errorsLog.CreateGetInsertList(-201, DateTime.Now);
                return -201;
            }

            if (incidentValidation.CheckTime(endTime) == -1)
            {
                errorsLog.CreateGetInsertList(-202, DateTime.Now);
                return -202;
            }

            if (permission == Permissions.LOW)
            {
                errorsLog.CreateGetInsertList(-51, DateTime.Now);
                return -51;
            }

            if (listIncidents.SetEndTime(incidentId, endTime) == 0)
            {
                errorsLog.CreateGetInsertList(-208, DateTime.Now);
                return -208;
            }
            else
                return 1;
        }

        /// <summary>
        ///  Trys to set the location of the incident by validating the incident id and the endTime, and checking if there is sufficient permissions
        /// </summary>
        /// <param name="incidentId"></param>
        /// <param name="location"></param>
        /// <param name="permission"></param>
        /// <returns>Returns -201 if the incident id is not valid, returns -203 if the location is not valid, returns -51 if there is not sufficient permissions, returns -208 if the incident does not exist, returns 1 if the startTime was seted</returns>
        public int TrySetLocation(int incidentId, string location, Permissions permission)
        {
            if (incidentValidation.CheckId(incidentId) == -1)
            {
                errorsLog.CreateGetInsertList(-201, DateTime.Now);
                return -201;
            }

            if (incidentValidation.CheckLocation(location) == -1)
            {
                errorsLog.CreateGetInsertList(-203, DateTime.Now);
                return -203;
            }

            if (permission == Permissions.LOW)
            {
                errorsLog.CreateGetInsertList(-51, DateTime.Now);
                return -51;
            }

            if (listIncidents.SetLocation(incidentId, location) == 0)
            {
                errorsLog.CreateGetInsertList(-208, DateTime.Now);
                return -208;
            }
            else
                return 1;
        }

        /// <summary>
        /// Trys to set the incidentType of the incident by validating the incident id and the incidentType, and checking if there is sufficient permissions
        /// </summary>
        /// <param name="incidentId">incident ID</param>
        /// <param name="incidentType">IncidentType</param>
        /// <param name="permission">Permissions</param>
        /// <returns>Returns -201 if the incident id is not valid, returns -204 if the location is not valid, returns -51 if there is not sufficient permissions, returns -208 if the incident does not exist, returns 1 if the startTime was seted</returns>
        public int TrySetIncidentType(int incidentId, TypeIncidentEnum incidentType, Permissions permission)
        {
            if (incidentValidation.CheckId(incidentId) == -1)
            {
                errorsLog.CreateGetInsertList(-201, DateTime.Now);
                return -201;
            }

            if (incidentValidation.CheckTypeIncident(incidentType) == -1)
            {
                errorsLog.CreateGetInsertList(-204, DateTime.Now);
                return -204;
            }

            if (permission == Permissions.LOW)
            {
                errorsLog.CreateGetInsertList(-51, DateTime.Now);
                return -51;
            }

            if (listIncidents.SetIncidentType(incidentId, incidentType) == 0)
            {
                errorsLog.CreateGetInsertList(-208, DateTime.Now);
                return -208;
            }
            else
                return 1;
        }

        /// <summary>
        /// Trys to set the priorityLevel of the incident by validating the incident id and the priorityLevel, and checking if there is sufficient permissions
        /// </summary>
        /// <param name="incidentId">incident ID</param>
        /// <param name="priorityLevel">PrioityLevel</param>
        /// <param name="permission">Permissions</param>
        /// <returns>Returns -201 if the incident id is not valid, returns -205 if the location is not valid, returns -51 if there is not sufficient permissions, returns -208 if the incident does not exist, returns 1 if the startTime was seted</returns>
        public int TrySetPriorityLevel(int incidentId, int priorityLevel, Permissions permission)
        {
            if (incidentValidation.CheckId(incidentId) == -1)
            {
                errorsLog.CreateGetInsertList(-201, DateTime.Now);
                return -201;
            }

            if (incidentValidation.CheckPriorityLevel(priorityLevel) == -1)
            {
                errorsLog.CreateGetInsertList(-204, DateTime.Now);
                return -205;
            }

            if (permission == Permissions.LOW)
            {
                errorsLog.CreateGetInsertList(-51, DateTime.Now);
                return -51;
            }

            if (listIncidents.SetPriorityLevel(incidentId, priorityLevel) == 0)
            {
                errorsLog.CreateGetInsertList(-208, DateTime.Now);
                return -208;
            }
            else
                return 1;
        }

        /// <summary>
        /// Trys to set the firefightersReq of the incident by validating the incident id and the firefightersReq, and checking if there is sufficient permissions
        /// </summary>
        /// <param name="incidentId">incident ID</param>
        /// <param name="firefightersReq">Firefighters required</param>
        /// <param name="permission">Permissions</param>
        /// <returns>Returns -201 if the incident id is not valid, returns -206 if the location is not valid, returns -51 if there is not sufficient permissions, returns -208 if the incident does not exist, returns 1 if the startTime was seted</returns>
        public int TrySetFirefightersReq(int incidentId, int firefightersReq, Permissions permission)
        {

            if (incidentValidation.CheckId(incidentId) == -1)
            {
                errorsLog.CreateGetInsertList(-201, DateTime.Now);
                return -201;
            }

            if (incidentValidation.CheckFirefightersReq(firefightersReq) == -1)
            {
                errorsLog.CreateGetInsertList(-51, DateTime.Now);
                return -206;
            }

            if (permission == Permissions.LOW)
            {
                errorsLog.CreateGetInsertList(-51, DateTime.Now);
                return -51;
            }

            if (listIncidents.SetFirefightersReq(incidentId, firefightersReq) == 0)
            {
                errorsLog.CreateGetInsertList(-208, DateTime.Now);
                return -208;
            }
            else
                return 1;
        }
        #endregion

        #region ListIdsInIncidentsRealTime
        /// <summary>
        /// Trys to insert a id inside the list of firefighter ids in the IncidentRealTime with a certain id
        /// </summary>
        /// <param name="incidentId">Incident id of the list of firefighter ids</param>
        /// <param name="firefighterId">Id to add to the list</param>
        /// <param name="permission">Permissions</param>
        /// <returns>Returns -101 if the incident id is not valid, returns -201 if the firefighterId is not valid, returns -51 if there is not sufficient permissions, returns -301 if the id was allredy in the list, returns -208 if the incident does not exist,returns 1 if the id was added</returns>
        public int TryInsertListFirefighterIds(int incidentId, int firefighterId, Permissions permission)
        {
            if (incidentValidation.CheckId(incidentId) == -1)
            {
                errorsLog.CreateGetInsertList(-201, DateTime.Now);
                return -201;
            }

            if (incidentValidation.CheckId(firefighterId) == -1)
            {
                errorsLog.CreateGetInsertList(-101, DateTime.Now);
                return -101;
            }

            if (permission == Permissions.LOW)
            {
                errorsLog.CreateGetInsertList(-51, DateTime.Now);
                return -51;
            }

            int x = listIncidents.InsertListFirefighterIds(incidentId, firefighterId);
            if(x == 0)
            {
                errorsLog.CreateGetInsertList(-301, DateTime.Now);
                return -301;
            }
            else if (x == -1)
            {
                errorsLog.CreateGetInsertList(-302, DateTime.Now);
                return -208;
            }
            else
                return x;
        }

        /// <summary>
        /// Trys to remove a id inside the list of firefighter ids in the IncidentRealTime with a certain id
        /// </summary>
        /// <param name="incidentId">Incident id of the list of firefighter ids</param>
        /// <param name="firefighterId">Id to add to the list</param>
        /// <param name="permission">Permissions</param>
        /// <returns>Returns -101 if the incident id is not valid, returns -201 if the firefighterId is not valid, returns -51 if there is not sufficient permissions, returns -302 if the id was not in the list, returns 1 if the id was added, returns -208 if the incident does not exist</returns>
        public int TryRemoveListFirefighterIds(int incidentId, int firefighterId, Permissions permission)
        {
            if (incidentValidation.CheckId(incidentId) == -1)
            {
                errorsLog.CreateGetInsertList(-201, DateTime.Now);
                return -201;
            }

            if (incidentValidation.CheckId(firefighterId) == -1)
            {
                errorsLog.CreateGetInsertList(-101, DateTime.Now);
                return -101;
            }

            if (permission == Permissions.LOW)
            {
                errorsLog.CreateGetInsertList(-51, DateTime.Now);
                return -51;
            }

            int x = listIncidents.RemoveListFirefighterIds(incidentId, firefighterId);
            if (x == 0)
            {
                errorsLog.CreateGetInsertList(-302, DateTime.Now);
                return -302;
            }
            else if(x == -1)
            {
                errorsLog.CreateGetInsertList(-302, DateTime.Now);
                return -208;
            }
            else
                return x;
        }

        /// <summary>
        /// Trys to checks if exists a number in the list of numbers in the incident realtime with a certain id
        /// </summary>
        /// <param name="incidentId">Incident id</param>
        /// <param name="id">Id do add</param>
        /// <param name="permission">Permissions</param>
        /// <returns>Returns -101 if the incident id is not valid, returns -201 if the firefighterId is not valid, returns -51 if there is not sufficient permissions, returns -302 if the id was not in the list, returns 1 if the id was added, returns -208 if the incident does not exist, returns 1 if exists in the list, returns 0 if does not exist</returns>
        public int TryContainsIdListFirefighterIds(int incidentId, int id, Permissions permission)
        {
            if (incidentValidation.CheckId(incidentId) == -1)
            {
                errorsLog.CreateGetInsertList(-201, DateTime.Now);
                return -201;
            }

            if (incidentValidation.CheckId(id) == -1)
            {
                errorsLog.CreateGetInsertList(-101, DateTime.Now);
                return -101;
            }

            if (permission == Permissions.LOW)
            {
                errorsLog.CreateGetInsertList(-51, DateTime.Now);
                return -51;
            }

            int x = listIncidents.ContainsIdListFirefighterIds(incidentId, id);
            if (x == -1)
            {
                return -208;
            }
            else
                return x;
        }
        #endregion

        #region HistoricIncidents
        /// <summary>
        /// Trys to insert incident inside the dictionary of historic of incidents
        /// </summary>
        /// <param name="incidentId"></param>
        /// <param name="permission"></param>
        /// <returns>Returns -101 if the incident id is not valid, returns -51 if there is not sufficient permissions, returns -208 if the incident does not exist, returns 1 if the incident was inserted in the dictionary </returns>
        public int TryInsertHistoricIncidents(int incidentId, Permissions permission)
        {
            if (incidentValidation.CheckId(incidentId) == -1)
            {
                errorsLog.CreateGetInsertList(-201, DateTime.Now);
                return -201;
            }

            if (permission == Permissions.LOW)
            {
                errorsLog.CreateGetInsertList(-51, DateTime.Now);
                return -51;
            }

            if (listIncidents.InsertHistoricIncidents(incidentId) == -1)
            {
                errorsLog.CreateGetInsertList(-208, DateTime.Now);
                return -208;
            }
            else
                return 1;
        }

        /// <summary>
        /// Trys to store a dictionary of incidents by validating the id of the IncidentRealTime and checking if there is sufficient permissions
        /// </summary>
        /// <param name="filePath">Path of the file</param>
        /// <param name="permission">Permission</param>
        /// <returns>Returns -50 if the string is not valid, returns -51 if there is not sufficient permissions, returns 1 if the dictionary was stored</returns>
        public int TryStoreDictionaryBinaryFile(string filePath, Permissions permission)
        {
            if (generalValidations.CheckString(filePath) == -1)
            {
                errorsLog.CreateGetInsertList(-50, DateTime.Now);
                return -50;
            }

            if (permission == Permissions.LOW)
            {
                errorsLog.CreateGetInsertList(-51, DateTime.Now);
                return -51;
            }

            return listIncidents.HistoricIncidents.StoreDictionaryBinaryFile(filePath);
        }

        /// <summary>
        /// Trys to read a dictionary of incidents by validating the id of the IncidentRealTime and checking if there is sufficient permissions
        /// </summary>
        /// <param name="filePath">Path of the file</param>
        /// <param name="permission">Permission</param>
        /// <returns>Returns -50 if the string is not valid, returns -51 if there is not sufficient permissions, returns -52 if the files does not exist,returns 1 if the dictionary was readed</returns>
        public int TryReadDictionaryBinaryFile(string filePath, Permissions permission)
        {
            if (generalValidations.CheckString(filePath) == -1)
                return -50;

            if (permission == Permissions.LOW)
                return -51;

            int aux = listIncidents.HistoricIncidents.ReadDictionaryBinaryFile(filePath);
            if (aux == 0)
                return -52;
            else
                return 1;
        }
        #endregion

        #region GeneralFunctions
        /// <summary>
        /// Trys to check if a incident with a certain id exists by validating the incidentId id and checking if there is sufficient permissions
        /// </summary>
        /// <param name="incidentId">firefighter id</param>
        /// <param name="permission">Permissions</param>
        /// <param name="error">Error</param>
        /// <returns>Returns false if the incident does not exists, return true if exits.
        /// Returns the error -201 when id is invalid, returns the error -51 if there is not sufficient permissions, returns -208 if the incident does not exist
        /// </returns>
        public bool TryContainsList(int incidentId, Permissions permission, out int error)
        {
            if (incidentValidation.CheckId(incidentId) == -1)
            {
                error = -201;
                errorsLog.CreateGetInsertList(error, DateTime.Now);
                return false;
            }

            if (permission == Permissions.LOW)
            {
                error = -51;
                errorsLog.CreateGetInsertList(error, DateTime.Now);
                return false;
            }

            if (listIncidents.ContainsList(incidentId) == false)
            {
                error = -208;
                errorsLog.CreateGetInsertList(error, DateTime.Now);
                return false;
            }

            error = 1;
            return true;
        }

        /// <summary>
        /// Trys to add a IncidentRealTime by validating the IncidentRealTime and checking if there is sufficient permissions
        /// </summary>
        /// <param name="incident">IncidentRealTime object</param>
        /// <param name="permission">Permission</param>
        /// <returns>Returns a code if the IncidentRealTime is not valid, returns -51 if there is not sufficient permissions, returns -209 if the IncidentRealTime was allready in the list, returns 1 if the IncidentRealTime was added</returns>
        public int TryCreateAddIncidents(Incident incident, Permissions permission)
        {
            int aux = incidentValidation.CheckIncident(incident);
            if (aux != 1)
            {
                errorsLog.CreateGetInsertList(aux, DateTime.Now);
                return aux;
            }

            if (permission == Permissions.LOW)
            {
                errorsLog.CreateGetInsertList(-51, DateTime.Now);
                return -51;
            }

            if (listIncidents.CreateAddIncidents(incident) == 0)
            {
                errorsLog.CreateGetInsertList(-209, DateTime.Now);
                return -209;
            }

            return 1;
        }

        /// <summary>
        /// Trys to remove a IncidentRealTime by validating the id of the  IncidentRealTime and checking if there is sufficient permissions
        /// </summary>
        /// <param name="fireFighterId">firefighter id</param>
        /// <param name="permission">Permission</param>
        /// <returns>Returns -201 if the id is not valid, returns -51 if there is not sufficient permissions, returns -208 if the IncidentRealTime was not in the list, returns 1 if the IncidentRealTime was removed</returns>
        public int TryRemoveIncidents(int incidentId, Permissions permission)
        {
            if (incidentValidation.CheckId(incidentId) == -1)
            {
                errorsLog.CreateGetInsertList(-201, DateTime.Now);
                return -201;
            }

            if (permission == Permissions.LOW)
            {
                errorsLog.CreateGetInsertList(-51, DateTime.Now);
                return -51;
            }

            if (listIncidents.RemoveIncidents(incidentId) == 0)
            {
                errorsLog.CreateGetInsertList(-208, DateTime.Now);
                return -208;
            }

            return 1;
        }

        /// <summary>
        /// Trys to checks if the incident needs support
        /// </summary>
        /// <param name="incidentId"></param>
        /// <param name="permission"></param>
        /// <returns>Returns -201 if the id is not valid, returns -51 if there is not sufficient permissions, returns -208 if the IncidentRealTime was not in the list, returns 1 if the inciden needs support, returns 0 if the incident does not need support</returns>
        public int TryCheckIncidentNeedsSupport(int incidentId, Permissions permission)
        {
            if (incidentValidation.CheckId(incidentId) == -1)
            {
                errorsLog.CreateGetInsertList(-201, DateTime.Now);
                return -201;
            }

            if (permission == Permissions.LOW)
            {
                errorsLog.CreateGetInsertList(-51, DateTime.Now);
                return -51;
            }

            int x = listIncidents.CheckIncidentNeedsSupport(incidentId);
            if (x == -1)
            {
                errorsLog.CreateGetInsertList(-208, DateTime.Now);
                return -208;
            }
            else return x;
        }

        /// <summary>
        /// Trys to store a list of IncidentRealTime to a incident by validating the filePath and checking if there is sufficient permissions
        /// </summary>
        /// <param name="filePath">Path of the file</param>
        /// <param name="permission">Permission</param>
        /// <returns>Returns -50 if the filePath is not valid, returns -51 if there is not sufficient permissions, returns 1 if the list was stored</returns>
        public int TryStoreListBinaryFile(string filePath, Permissions permission)
        {
            if (generalValidations.CheckString(filePath) == -1)
            {
                errorsLog.CreateGetInsertList(-50, DateTime.Now);
                return -50;
            }

            if (permission == Permissions.LOW)
            {
                errorsLog.CreateGetInsertList(-51, DateTime.Now);
                return -51;
            }

            return listIncidents.StoreListBinaryFile(filePath);
        }

        /// <summary>
        /// Trys to store a list of IncidentRealTime to a incident by validating the id of the IncidentRealTime and checking if there is sufficient permissions
        /// </summary>
        /// <param name="filePath">Path of the file</param>
        /// <param name="permission">Permission</param>
        /// <returns>Returns -50 if the filePath is not valid, returns -51 if there is not sufficient permissions, returns -52 if the file does not exist, returns 1 if the list was read</returns>
        public int TryReadListBinaryFile(string filePath, Permissions permission)
        {
            if (generalValidations.CheckString(filePath) == -1)
            {
                errorsLog.CreateGetInsertList(-50, DateTime.Now);
                return -50;
            }

            if (permission == Permissions.LOW)
            {
                errorsLog.CreateGetInsertList(-51, DateTime.Now);
                return -51;
            }

            int aux = listIncidents.ReadListBinaryFile(filePath);
            if (aux == 0)
            {
                errorsLog.CreateGetInsertList(-52, DateTime.Now);
                return -52;
            }
            return aux;
        }
        #endregion

        #region Destructor
        /// <summary>
        /// The destructor.
        /// </summary>
        ~IncidentRules()
        {
        }
        #endregion

        #region Logs
        /// <summary>
        /// Trys to store the logs list in a file 
        /// </summary>
        /// <param name="filePath">File path of the file</param>
        /// <returns>Returns -50 if the file path is invalid, returns 1 the logs list was stored</returns>
        public int TryStoreLogsListFileXML()
        {
            if(generalValidations.CheckString(fileLog) == -1)
                return -50;

            errorsLog.StoreLogsListFileXML(fileLog);
            return 1;
        }
        #endregion

        #endregion

    }
}