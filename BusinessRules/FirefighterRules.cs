/*
*	<copyright file="BusinessRules.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>David Carvalho</author>
*   <date>19/12/2024 14:51:25</date>
*	<description></description>
**/
using BusinessObjects;
using Data;
using Validations;
using System;

namespace BusinessRules
{
    /// <summary>
    /// Purpose: Class that contains all rules about the firefighters
    /// Created by: David Carvalho
    /// Created on: 19/12/2024 14:51:25
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class FirefighterRules
    {
        #region Attributes
        ListFireFighters listFireFighters;
        FirefighterValidation firefighterValidation;
        GeneralValidations generalValidations;

        const string fileLog = "FirefighterLog";
        ErrorsLog errorsLog;
        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// The default Constructor.
        /// </summary>
        public FirefighterRules()
        {
            listFireFighters = new ListFireFighters();
            firefighterValidation = new FirefighterValidation();
            generalValidations = new GeneralValidations();
            errorsLog = new ErrorsLog();
        }

        #endregion

        #region TryGets
        /// <summary>
        /// Trys to get a name validating the firefighter and checking if there is sufficient permissions
        /// </summary>
        /// <param name="fireFighterId">FireFighter Id</param>
        /// <param name="permission">Permission</param>
        /// <returns>Returns string empty if ocurred some error, returns the name if there was not any error
        /// Out returns -101 if firefighter id is invalid, returns -51 if there is not sufficient permissions
        /// returns -108 if the firefighter does not exist
        /// </returns>
        public string TryGetName(int fireFighterId, Permissions permission, out int error)
        {
            if (firefighterValidation.CheckId(fireFighterId) == -1)
            {
                error = -101;
                errorsLog.CreateGetInsertList(error, DateTime.Now);
                return string.Empty;
            }

                
            if (permission == Permissions.LOW)
            {
                error = -51;
                errorsLog.CreateGetInsertList(error, DateTime.Now);
                return string.Empty;
            }

            string aux = listFireFighters.GetName(fireFighterId);
            if (aux == string.Empty)
            {
                error = -108;
                errorsLog.CreateGetInsertList(error, DateTime.Now);
                return aux;
            }

            error = 1;
            return aux;
        }

        /// <summary>
        /// Trys to get a name validating the firefighter and checking if there is sufficient permissions
        /// </summary>
        /// <param name="fireFighterId">FireFighter Id</param>
        /// <param name="permission">Permission</param>
        /// <returns>Returns 0 if ocurred some error, returns the Sex if there was not any error
        /// Out returns -101 if firefighter id is invalid, returns -51 if there is not sufficient permissions
        /// returns -108 if the firefighter does not exist
        /// </returns>
        public Sex TryGetSex(int fireFighterId, Permissions permission, out int error)
        {
            if (firefighterValidation.CheckId(fireFighterId) == -1)
            {
                error = -101;
                errorsLog.CreateGetInsertList(error, DateTime.Now);
                return 0;
            }
                

            if (permission == Permissions.LOW)
            {
                error = -51;
                errorsLog.CreateGetInsertList(error, DateTime.Now);
                return 0;
            }

            Sex aux = listFireFighters.GetSex(fireFighterId);
            if (aux == 0)
            {
                error = -108;
                errorsLog.CreateGetInsertList(error, DateTime.Now);
                return aux;
            }

            error = 1;
            return aux;
        }

        /// <summary>
        /// Trys to get a CC validating the firefighter and checking if there is sufficient permissions
        /// </summary>
        /// <param name="fireFighterId">FireFighter Id</param>
        /// <param name="permission">Permission</param>
        /// <returns>Returns string empty if ocurred some error, returns the CC if there was not any error
        /// Out returns -101 if firefighter id is invalid, returns -51 if there is not sufficient permissions
        /// returns -108 if the firefighter does not exist
        /// </returns>
        public string TryGetCC(int fireFighterId, Permissions permission, out int error)
        {
            if (firefighterValidation.CheckId(fireFighterId) == -1)
            {
                error = -101;
                errorsLog.CreateGetInsertList(error, DateTime.Now);
                return string.Empty;
            }

            if (permission == Permissions.LOW)
            {
                error = -51;
                errorsLog.CreateGetInsertList(error, DateTime.Now);
                return string.Empty;
            }

            string aux = listFireFighters.GetCC(fireFighterId);
            if (aux == string.Empty)
            {
                error = -108;
                errorsLog.CreateGetInsertList(error, DateTime.Now);
                return aux;
            }

            error = 1;
            return aux;
        }

        /// <summary>
        /// Trys to get the age of the firefighter by validating the firefighter and checking if there is sufficient permissions
        /// </summary>
        /// <param name="fireFighterId">Firefighter id</param>
        /// <param name="permission">Permission</param>
        /// <returns>Returns 0 if ocurred some error, returns the age if there was not any error
        /// Out returns -101 if firefighter id is invalid, returns -51 if there is not sufficient permissions
        /// returns -108 if the firefighter does not exist
        /// </returns>
        public int TryGetAge(int fireFighterId, Permissions permission, out int error)
        {
            if (firefighterValidation.CheckId(fireFighterId) == -1)
            {
                error = -101;
                errorsLog.CreateGetInsertList(error, DateTime.Now);
                return 0;
            }

            if (permission == Permissions.LOW)
            {
                error = -51;
                errorsLog.CreateGetInsertList(error, DateTime.Now);
                return 0;
            }

            int aux = listFireFighters.GetAge(fireFighterId);
            if (aux == 0)
            {
                error = -108;
                errorsLog.CreateGetInsertList(error, DateTime.Now);
                return aux;
            }

            error = 1;
            return aux;
        }

        /// <summary>
        /// Trys to get the available of the firefighter by validating the firefighter and checking if there is sufficient permissions
        /// </summary>
        /// <param name="fireFighterId">Firefighter id</param>
        /// <param name="permission">Permission</param>
        /// <returns>Returns 0 if ocurred some error, returns the available if there was not any error
        /// Out returns -101 if firefighter id is invalid, returns -51 if there is not sufficient permissions
        /// returns -108 if the firefighter does not exist
        /// </returns>
        public int TryGetAvailable(int fireFighterId, Permissions permission, out int error)
        {
            if (firefighterValidation.CheckId(fireFighterId) == -1)
            {
                error = -101;
                errorsLog.CreateGetInsertList(error, DateTime.Now);
                return 0;
            }

            if (permission == Permissions.LOW)
            {
                error = -51;
                errorsLog.CreateGetInsertList(error, DateTime.Now);
                return 0;
            }

            int aux = listFireFighters.GetAvailable(fireFighterId);
            if (aux == 0)
            {
                error = -108;
                errorsLog.CreateGetInsertList(error, DateTime.Now);
                return aux;
            }

            error = 1;
            return aux;
        }
        #endregion

        #region TrySets
        /// <summary>
        /// Trys to set a name validating the firefighter id and the name, and checking if there is sufficient permissions
        /// </summary>
        /// <param name="fireFighterId">FireFighter Id</param>
        /// <param name="name">Name</param>
        /// <param name="permission">Permissions</param>
        /// <returns>Returns -101 if the fireFighter is not valid, returns -103 if the name is not valid, returns -51 if there is not sufficient permissions, returns -108 if the firefighter does not exist, returns 1 if the name was seted</returns>
        public int TrySetName(int fireFighterId, string name, Permissions permission)
        {
            if (firefighterValidation.CheckId(fireFighterId) == -1)
                return -101;

            if (firefighterValidation.CheckName(name) == -1)
                return -103;

            if (permission == Permissions.LOW)
                return -51;

            if (listFireFighters.SetName(fireFighterId, name) == 0)
                return -108;

            return 1;
        }

        /// <summary>
        /// Trys to set a sex validating the firefighter id and the sex, and checking if there is sufficient permissions
        /// </summary>
        /// <param name="fireFighterId">FireFighter Id</param>
        /// <param name="sex">Sex</param>
        /// <param name="permission">Permissions</param>
        /// <returns>Returns -101 if the fireFighter is not valid, returns -104 if the sex is not valid, returns -51 if there is not sufficient permissions, returns -108 if the firefighter does not exist, returns 1 if the sex was seted</returns>
        public int TrySetSex(int fireFighterId, Sex sex, Permissions permission)
        {
            if (firefighterValidation.CheckId(fireFighterId) == -1)
                return -101;

            if (firefighterValidation.CheckSex(sex) == -1)
                return -104;

            if (permission == Permissions.LOW)
                return -51;

            if (listFireFighters.SetSex(fireFighterId, sex) == 0)
                return -108;

            return 1;
        }

        /// <summary>
        /// Trys to set a cc validating the firefighter id and the cc, and checking if there is sufficient permissions
        /// </summary>
        /// <param name="fireFighterId">FireFighter Id</param>
        /// <param name="CC">CC</param>
        /// <param name="permission">Permissions</param>
        /// <returns>Returns -101 if the fireFighter is not valid, returns -105 if the cc is not valid, returns -51 if there is not sufficient permissions, returns -108 if the firefighter does not exist, returns 1 if the cc was seted</returns>
        public int TrySetCC(int fireFighterId, string CC, Permissions permission)
        {
            if (firefighterValidation.CheckId(fireFighterId) == -1)
                return -101;

            if (firefighterValidation.CheckCC(CC) == -1)
                return -105;

            if (permission == Permissions.LOW)
                return -51;

            if (listFireFighters.SetCC(fireFighterId, CC) == 0)
                return -108;

            return 1;
        }

        /// <summary>
        /// Trys to set a age validating the firefighter id and the cc, and checking if there is sufficient permissions
        /// </summary>
        /// <param name="fireFighterId">FireFighter Id</param>
        /// <param name="age">Age</param>
        /// <param name="permission">Permissions</param>
        /// <returns>Returns -101 if the fireFighter is not valid, returns -106 if the age is not valid, returns -51 if there is not sufficient permissions, returns -108 if the firefighter does not exist, returns 1 if the age was seted</returns>
        public int TrySetAge(int fireFighterId, int age, Permissions permission)
        {
            if (firefighterValidation.CheckId(fireFighterId) == -1)
                return -101;

            if (firefighterValidation.CheckAge(age) == -1)
                return -106;

            if (permission == Permissions.LOW)
                return -51;

            if (listFireFighters.SetAge(fireFighterId, age) == 0)
                return -108;

            return 1;
        }

        /// <summary>
        /// Trys to set a available validating the firefighter id and the cc, and checking if there is sufficient permissions
        /// </summary>
        /// <param name="fireFighterId">FireFighter Id</param>
        /// <param name="available">Available</param>
        /// <param name="permission">Permissions</param>
        /// <returns>Returns -101 if the fireFighter is not valid, returns -102 if the available is not valid, returns -51 if there is not sufficient permissions, returns -108 if the firefighter does not exist, returns 1 if the available was seted</returns>
        public int TrySetAvailable(int fireFighterId, int available, Permissions permission)
        {
            if (firefighterValidation.CheckId(fireFighterId) == -1)
                return -101;

            if (firefighterValidation.CheckAvailable(available) == -1)
                return -102;

            if (permission == Permissions.LOW)
                return -51;

            if (listFireFighters.SetAvailable(fireFighterId, available) == 0)
                return -108;

            return 1;
        }
        #endregion

        #region GeneralFunctions
        /// <summary>
        /// Trys to check if a firefighter with a certain id exists by validating the firefighter id and checking if there is sufficient permissions
        /// </summary>
        /// <param name="firefighterId">firefighter id</param>
        /// <param name="permission">Permissions</param>
        /// <returns>Returns false if the firefighter does not exists, return true if exits.
        /// Returns the error -101 when id is invalid, returns the error -51 if there is not sufficient permissions, returns -108 if the firefighter does not exist, returns 1 if exists
        /// </returns>
        public bool TryContainsList(int firefighterId, Permissions permission, out int error)
        {
            if(firefighterValidation.CheckId(firefighterId) != 1)
            {
                error = -101;
                errorsLog.CreateGetInsertList(error, DateTime.Now);
                return false;
            }
                
            if (permission == Permissions.LOW)
            {
                error = -51;
                errorsLog.CreateGetInsertList(error, DateTime.Now);
                return false;
            }
               
            if(listFireFighters.ContainsList(firefighterId) == false)
            {
                error = -108;
                errorsLog.CreateGetInsertList(error, DateTime.Now);
                return false;
            }

            error = 1;
            return true;
        }

        /// <summary>
        /// Trys to add a firefighter by validating the firefighter and checking if there is sufficient permissions
        /// </summary>
        /// <param name="fireFighter">Firefighter object</param>
        /// <param name="permission">Permission</param>
        /// <returns>Returns -107 if it is firefighter object isnot valid, returns -101 if the id is invalid, returns -103 if the name is invalid, 
        /// returns -102 if the availble is invalid, returns -106 if the age is invalid
        /// returns -105 if the cc is invalid, returns -104 if the sex is invalid, returns -50 if the is not sufficient permissions,
        /// returns -108 if the firefighter does not exist, returns 1 if the firefighter was added
        /// </returns>
        public int TryAddFirefighter(FireFighter fireFighter, Permissions permission)
        {
            int aux = firefighterValidation.CheckFirefighter(fireFighter);
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

            if (listFireFighters.AddFirefighter(fireFighter) == 0)
            {
                errorsLog.CreateGetInsertList(-111, DateTime.Now);
                return -111;
            }

            return 1;
        }

        /// <summary>
        /// Trys to remove a firefighter by validating the id of the  firefighter and checking if there is sufficient permissions
        /// </summary>
        /// <param name="fireFighterId">firefighter id</param>
        /// <param name="permission">Permission</param>
        /// <returns>Returns -101 if the id is not valid, returns -51 if there is not sufficient permissions, returns -108 if the fireFighter was not in the list, returns 1 if the fireFighter was removed</returns>
        public int TryRemoveFirefighter(int fireFighterId, Permissions permission)
        {
            if (firefighterValidation.CheckId(fireFighterId) == -1)
            {
                errorsLog.CreateGetInsertList(-101, DateTime.Now);
                return -101;
            }

            if (permission == Permissions.LOW)
            {
                errorsLog.CreateGetInsertList(-51, DateTime.Now);
                return -51;
            }

            if (listFireFighters.RemoveFirefighter(fireFighterId) == 0)
            {
                errorsLog.CreateGetInsertList(-108, DateTime.Now);
                return -108;
            }

            return 1;
        }

        /// <summary>
        /// Trys to send a firefighter to a incident by validating the id of the firefighter and checking if there is sufficient permissions
        /// </summary>
        /// <param name="fireFighterId">firefighter id</param>
        /// <param name="permission">Permission</param>
        /// <returns>Returns -101 if the id is not valid, returns -51 if there is not sufficient permissions, returns -108 if the fireFighter was not in the list, returns -109 if the firefighter was not available,returns 1 if the fireFighter was sended</returns>
        public int TrySendFirefighter(int fireFighterId, Permissions permission)
        {
            if (firefighterValidation.CheckId(fireFighterId) == -1)
            {
                errorsLog.CreateGetInsertList(-101, DateTime.Now);
                return -101;
            }

            if (permission == Permissions.LOW)
            {
                errorsLog.CreateGetInsertList(-51, DateTime.Now);
                return -51;
            }

            int x = listFireFighters.SendFirefighter(fireFighterId);
            if (x == 0)
            {
                errorsLog.CreateGetInsertList(-109, DateTime.Now);
                return -109;
            }
            else if (x == -1)
            {
                errorsLog.CreateGetInsertList(-108, DateTime.Now);
                return -108;
            }

            return 1;
        }

        /// <summary>
        /// Trys to return a firefighter to a incident by validating the id of the firefighter and checking if there is sufficient permissions
        /// </summary>
        /// <param name="fireFighterId">firefighter id</param>
        /// <param name="permission">Permission</param>
        /// <returns>Returns -101 if the id is not valid, returns -51 if there is not sufficient permissions, returns -108 if the fireFighter was not in the list, returns -110 if the firefighter was available,returns 1 if the fireFighter was returned</returns>
        public int TryReturnFirefighter(int fireFighterId, Permissions permission)
        {
            if (firefighterValidation.CheckId(fireFighterId) == -1)
            {
                errorsLog.CreateGetInsertList(-101, DateTime.Now);
                return -101;
            }

            if (permission == Permissions.LOW)
            {
                errorsLog.CreateGetInsertList(-51, DateTime.Now);
                return -51;
            }

            int x = listFireFighters.ReturnFirefighter(fireFighterId);
            if (x == 0)
            {
                errorsLog.CreateGetInsertList(-110, DateTime.Now);
                return -110;
            }
            else if (x == -1)
            {
                errorsLog.CreateGetInsertList(-108, DateTime.Now);
                return -108;
            }

            return 1;
        }

        /// <summary>
        /// Trys to storer a list of firefighter to a incident by validating the id of the firefighter and checking if there is sufficient permissions
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

            listFireFighters.StoreListBinaryFile(filePath);

            return 1;
        }

        /// <summary>
        /// Trys to storer a list of firefighter to a incident by validating the id of the firefighter and checking if there is sufficient permissions
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

            if (listFireFighters.ReadListBinaryFile(filePath) == -1)
            {
                errorsLog.CreateGetInsertList(-51, DateTime.Now);
                return -52;
            }

            return 1;
        }

        /// <summary>
        /// Trys to store the logs list in a file 
        /// </summary>
        /// <param name="filePath">File path of the file</param>
        /// <returns>Returns -50 if the file path is invalid, returns 1 the logs list was stored</returns>
        public int TryStoreLogsListFileXML()
        {
            if (generalValidations.CheckString(fileLog) == -1)
                return -50;

            errorsLog.StoreLogsListFileXML(fileLog);
            return 1;
        }
        #endregion

        #region Overrides
        #endregion

        #region Destructor
        /// <summary>
        /// The destructor.
        /// </summary>
        ~FirefighterRules()
        {
        }
        #endregion

        #endregion
    }
}
