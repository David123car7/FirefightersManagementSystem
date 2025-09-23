/*
*	<copyright file="Data.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>David Carvalho</author>
*   <date>19/12/2024 19:51:06</date>
*	<description></description>
**/

namespace Data
{
    /// <summary>
    /// Interface with functions of managing a list
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IListManagment<T>
    {
        int InsertList(T item);
        int RemoveList(int id);
    }

    /// <summary>
    /// Interface with functions of managing a list with objects
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IListObjectManagment<T>
    {
        bool ContainsList(int id);
        T GetObject(int id);
    }

    /// <summary>
    /// Interface with functions of managing files
    /// </summary>
    public interface IListFilesManagment
    {
        int StoreListBinaryFile(string filePath);
        int ReadListBinaryFile(string filePath);
    }
}
