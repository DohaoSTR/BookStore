﻿using System;
using System.Collections.Generic;

namespace BookStore.Model.DataBase
{
    public interface IDataAdapter
    {
        /// <summary>
        /// Get scalar value by query. Method return value of first cell for the first row.
        /// </summary>
        /// <typeparam name="T">Type of return value</typeparam>
        /// <param name="query">Query which contains one field for selection.</param>
        /// <returns></returns>
        T GetOne<T>(string query) where T : IConvertible;
        /// <summary>
        /// Method for selection table data.
        /// </summary>
        /// <param name="query">Custom query for data selection.</param>
        /// <returns>List of rows each of which represented by Dictionary with keys - field name, values - cell data</returns>
        List<Dictionary<string, string>> GetQueryResult(string query);

        //Метод для запуска запросов на модификацию данных возвращает количество измененных строк
        /// <summary>
        /// Execute SQL query for modification data and database entites.
        /// </summary>
        /// <param name="query">SQL query.</param>
        /// <returns>Number of affected rows</returns>
        int Execute(string query);
        /// <summary>
        /// Delete row from table by id.
        /// </summary>
        /// <param name="tableName">Table name.</param>
        /// <param name="id">Deleted row id.</param>
        /// <returns>Return true if one row deleted</returns>
        bool DeleteRow(string tableName, long id);
        /// <summary>
        /// Update table row by id.
        /// </summary>
        /// <param name="tableName">Table name.</param>
        /// <param name="id">Updated row id</param>
        /// <param name="values">Dictionary with pairs of field names and values in it.</param>
        /// <returns>Return true if one row updated.</returns>
        bool UpdateRow(string tableName, long id, Dictionary<string, object> values);
        /// <summary>
        /// Insert one row into table and return autogenerated primary key.
        /// </summary>
        /// <param name="query">SQL query for insertion one row.</param>
        /// <returns>New generated primary key (id).</returns>
        long InsertRow(string query);
        /// <summary>
        /// Insert one row into specified table with passed values.
        /// </summary>
        /// <param name="tableName">Name of the table where row must be inserted.</param>
        /// <param name="values">Dictionary with pairs of field names and values in it.</param>
        /// <returns>New generated primary key (id).</returns>
        long InsertRow(string tableName, Dictionary<string, object> values);
        /// <summary>
        /// Get indexed list. Select two column from DB where first is dictionary keys and second it's values.
        /// Helpful for selecting related field value by primary key.
        /// </summary>
        /// <param name="query">SQL query that select two columns.</param>
        /// <returns>Dictionary with index field and value field.</returns>
        Dictionary<string, string> GetIndexedList(string query);
        /// <summary>
        /// Status of current connection with DBMS.
        /// </summary>
        bool IsConnected { get; }
        /// <summary>
        /// Connect to DBMS.
        /// </summary>
        /// <param name="settings">ConnectionSettings object with connection parameters.</param>
        /// <returns>Return true if connection successful.</returns>
        bool Connect(ConnectionSettings settings);
        /// <summary>
        /// Disconnect from DBMS.
        /// </summary>
        void Disconnect();
    }
}
