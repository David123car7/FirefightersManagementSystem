/*
*	<copyright file="TrabalhoPratico_Tentativa_.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>David Carvalho</author>
*   <date>30/10/2024 21:39:03</date>
*	<description></description>
**/
using BusinessRules;
using BusinessObjects;


namespace Interface
{
    /// <summary>
    /// Purpose: Class that manages the firedepartment
    /// Created by: David Carvalho
    /// Created on: 30/10/2024 21:39:03
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class FireDepartment
    {
        #region Attributes
        FirefighterRules firefighterRules;
        IncidentRules incidentRules;
        #endregion

        #region Methods
        public FireDepartment()
        {
            firefighterRules = new FirefighterRules();
            incidentRules = new IncidentRules();
        }

        #region Properties
        public FirefighterRules FirefighterRules
        {
            get { return firefighterRules; }
        }

        public IncidentRules IncidentRules
        {
            get { return incidentRules; }
        }
        #endregion

        #region Functions

        #region Methods
        /// <summary>
        /// Starts the program by checking if exists files with data, if exits will read the data of the files
        /// </summary>
        /// <param name="incidentsFile">Path of the incidents file</param>
        /// <param name="firefightersFile">Path of the firefighters file</param>
        /// <returns>Returns -50 if any file path is invalid, returns -51 if there is not sufficient permissions, returns -52 if there is any file that does not exist,returns 1 if the program started successfully</returns>
        public int StartProgram(string incidentsFile, string firefightersFile, string historicIncidents, Permissions permissions)
        {

            int x1 = incidentRules.TryReadListBinaryFile(incidentsFile, permissions);
            if (x1 != 1) return x1;

            int x2 = firefighterRules.TryReadListBinaryFile(firefightersFile, permissions);
            if (x2 != 1) return x2;

            int x3 = incidentRules.TryReadDictionaryBinaryFile(historicIncidents, permissions);
            if (x3 != 1) return x3;

            return 1;
        }

        /// <summary>
        /// Ends the program by storing all data in binary files
        /// </summary>
        /// <param name="incidentsFile">Path of the incidents file</param>
        /// <param name="firefightersFile">Path of the firefighters file</param>
        /// <returns>Returns -50 if any file path is invalid, returns -51 if there is not sufficient permissions, returns 1 if the program ended successfully</returns>
        public int EndProgram(string incidentsFile, string firefightersFile, string historicIncidents, Permissions permissions)
        {
            int x1 = incidentRules.TryStoreListBinaryFile(incidentsFile, permissions);
            if (x1 != 1) return x1;

            int x2 = firefighterRules.TryStoreListBinaryFile(firefightersFile, permissions);
            if (x2 != 1) return x2;

            int x3 = incidentRules.TryStoreDictionaryBinaryFile(historicIncidents, permissions);
            if (x3 != 1) return x3;

            int x4 = incidentRules.TryStoreLogsListFileXML();
            if (x4 != 1) return x4;

            int x5 = incidentRules.TryStoreLogsListFileXML();
            if (x5 != 1) return x5;

            return 1;
        }

        /// <summary>
        /// Sends the firefighter to the incident
        /// </summary>
        /// <param name="fireFighterId">Firefighter id</param>
        /// <param name="incidentId">Incident id</param>
        /// <param name="permissions">Permissions</param>
        /// <returns>Returns -101 if the any id is not valid, returns -51 if there is not sufficient permissions, returns -108 if the fireFighter was not in the list, returns -109 if the firefighter was not available,returns 1 if the fireFighter was sended
        /// Returns the error -201 when id is invalid, returns the error -51 if there is not sufficient permissions, returns -208 if the incident does not exist, returns 1 if exists
        /// returns -301 if the firefighter was allredy in the incident
        ///</returns>
        public int SendFirefighterIncident(int fireFighterId, int incidentId, Permissions permissions, out int error)
        {
            if (!incidentRules.TryContainsList(fireFighterId, permissions, out error) || !firefighterRules.TryContainsList(fireFighterId, permissions, out error))
                return -208;

            int x = incidentRules.TryCheckIncidentNeedsSupport(incidentId, permissions);
            if (x == 1)
            {
                int x2 = firefighterRules.TrySendFirefighter(fireFighterId, permissions);
                if (x2 != 1) return x2;

                int x3 = incidentRules.TryInsertListFirefighterIds(incidentId, fireFighterId, permissions);
                if (x3 != 1) return x3;

                return 1;
            }
            return x;
        }

        /// <summary>
        /// Returns the firefighter from the incident
        /// </summary>
        /// <param name="fireFighterId"></param>
        /// <param name="incidentId"></param>
        /// <returns>Returns -101 if the id is not valid, returns -51 if there is not sufficient permissions, returns -108 if the fireFighter was not in the list, returns -110 if the firefighter was available, returns -302 if the id was not in the list ,returns 1 if the fireFighter was returned
        /// Returns the error -201 when id is invalid, returns the error -51 if there is not sufficient permissions, returns -208 if the incident does not exist, returns 1 if exists
        /// </returns>
        public int ReturnFirefighterIncident(int fireFighterId, int incidentId, Permissions permissions, out int error)
        {
            if (!incidentRules.TryContainsList(fireFighterId, permissions, out error) || !firefighterRules.TryContainsList(fireFighterId, permissions, out error))
                return -1;


            if (incidentRules.TryContainsIdListFirefighterIds(incidentId, fireFighterId, permissions) == 0)
                return 0;

            int x1 = firefighterRules.TryReturnFirefighter(fireFighterId, permissions);
            if (x1 != 1) return x1;

            int x2 = incidentRules.TryRemoveListFirefighterIds(incidentId, fireFighterId, permissions);
            if (x2 != 1) return x2;

            return 1;
        }

        /// <summary>
        /// Finished a incident 
        /// </summary>
        /// <param name="incidentId">Incident id</param>
        /// <returns>Returns -201 if the incident id is not valid, returns -202 if the startTime is not valid, returns -51 if there is not sufficient permissions, returns -208 if the incident does not exist
        /// Returns the error -201 when id is invalid, returns the error -51 if there is not sufficient permissions, returns -208 if the incident does not exist
        /// </returns>
        public int FinishIncident(int incidentId, DateTime endTime, Permissions permissions, out int error)
        {
            if (!incidentRules.TryContainsList(incidentId, permissions, out error))
                return -1;

            int x1 = incidentRules.TrySetEndTime(incidentId, endTime, permissions);
            if(x1 != 1) return x1;

            int x2 = incidentRules.TryInsertHistoricIncidents(incidentId, permissions);
            if (x2 != 1) return x2;

            int x3 = incidentRules.TryRemoveIncidents(incidentId, permissions);
            if (x3 != 1) return x3;

            return 1;
        }
        #endregion

        #region Overrides
        #endregion

        #endregion

        #endregion
    }
}
