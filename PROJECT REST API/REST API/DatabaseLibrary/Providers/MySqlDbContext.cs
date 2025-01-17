﻿using DatabaseLibrary.Core;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace DatabaseLibrary.Providers
{
    /// <summary>
    /// MySQL implementation of the db context.
    /// </summary>
    public class MySqlDbContext : DbContext
    {

        #region Constructors

        /// <summary>
        /// Uses the connection string to connect to the database.
        /// </summary>
        public MySqlDbContext(string connectionString)
            : base (connectionString)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Performs an setup required before running any further commands or queries.
        /// Usually gets called once on startup.
        /// </summary>
        /// <param name="message">A detailed error message stating the reason when it fails.</param>
        /// <returns>States if the initialization has been completed without any issue.</returns>
        public override bool Initialize(out string message)
        {

            // Create a new connection
            MySqlConnection connection = new MySqlConnection(ConnectionString);

            try
            {
                
                // Open connection to database
                connection.Open();

                // Respond
                message = "Initialized successfully.";
                return true;
            }
            catch (Exception exception)
            {
                message = exception.Message;
                return false;
            }
            finally
            {
                // Close connection
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        /// <summary>
        /// Executes the provided command.
        /// </summary>
        /// <param name="message">A detailed error message stating the reason when it fails.</param>
        /// <returns>States the number of rows affected by the command.</returns>
        public override int ExecuteNonQueryCommand(string commandText, Dictionary<string, object> parameters, out string message)
        {
            // Create a new connection
            MySqlConnection connection = new MySqlConnection(ConnectionString);

            try
            {
                // Open connection to database
                connection.Open();

                // Prepare paramters
                List<MySqlParameter> parameterList = new List<MySqlParameter>();
                foreach (string key in parameters.Keys)
                    parameterList.Add(new MySqlParameter(key, parameters[key]));

                // Exexcute the command
                MySqlCommand command = new MySqlCommand(commandText, connection);
                command.Parameters.AddRange(parameterList.ToArray());
                int count = command.ExecuteNonQuery();

                // Respond
                message = "Executed Successfully: " + count.ToString("N0") + " rows affected.";
                return count;
            }
            catch (Exception exception)
            {
                message = exception.Message;
                return -1;
            }
            finally
            {
                // Close connection
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        /// <summary>
        /// Executes the provided command and retrieves some data.
        /// </summary>
        /// <param name="message">A detailed error message stating the reason when it fails.</param>
        /// <returns>Datatabe with all the rows that are retrieved.</returns>
        public override DataTable ExecuteDataQueryCommand(string commandText, Dictionary<string, object> parameters, out string message)
        {
            // Create a new connection
            MySqlConnection connection = new MySqlConnection(ConnectionString);

            try
            {
                // Open connection to database
                connection.Open();

                // Prepare paramters
                List<MySqlParameter> parameterList = new List<MySqlParameter>();
                foreach (string key in parameters.Keys)
                    parameterList.Add(new MySqlParameter(key, parameters[key]));

                // Exexcute the command
                MySqlDataAdapter adapter = new MySqlDataAdapter(commandText, connection);
                adapter.SelectCommand.Parameters.AddRange(parameterList.ToArray());
                DataTable table = new DataTable();
                adapter.Fill(table);
                adapter.Dispose();

                // Respond
                message = "Executed successfully.";
                return table;
            }
            catch (Exception exception)
            {
                message = exception.Message;
                return null;
            }
            finally
            {
                // Close connection
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        /// <summary>
        /// Executes the provided stored procedure.
        /// </summary>
        /// <param name="message">A detailed error message stating the reason when it fails.</param>
        /// <returns>States the number of rows affected by the command.</returns>
        public override int ExecuteNonQueryProcedure(string procedure, Dictionary<string, object> parameters, out string message)
        {
            // Create a new connection
            MySqlConnection connection = new MySqlConnection(ConnectionString);

            try
            {
                // Open connection to database
                connection.Open();

                // Prepare paramters
                List<MySqlParameter> parameterList = new List<MySqlParameter>();
                foreach (string key in parameters.Keys)
                    parameterList.Add(new MySqlParameter(key, parameters[key]));

                // Exexcute the command
                MySqlCommand command = new MySqlCommand(procedure, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddRange(parameterList.ToArray());
                int count = command.ExecuteNonQuery();

                // Respond
                message = "Executed Successfully: " + count.ToString("N0") + " rows affected.";
                return count;
            }
            catch (Exception exception)
            {
                message = exception.Message;
                return -1;
            }
            finally
            {
                // Close connection
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        /// <summary>
        /// Executes the provided stored procedure and retrieves some data.
        /// </summary>
        /// <param name="message">A detailed error message stating the reason when it fails.</param>
        /// <returns>Datatabe with all the rows that are retrieved.</returns>
        public override DataTable ExecuteDataQueryProcedure(string procedure, Dictionary<string, object> parameters, out string message)
        {
            // Create a new connection
            MySqlConnection connection = new MySqlConnection(ConnectionString);

            try
            {
                // Open connection to database
                connection.Open();

                // Prepare paramters
                List<MySqlParameter> parameterList = new List<MySqlParameter>();
                foreach (string key in parameters.Keys)
                    parameterList.Add(new MySqlParameter(key, parameters[key]));

                // Exexcute the command
                MySqlDataAdapter adapter = new MySqlDataAdapter(procedure, connection);
                adapter.SelectCommand.Parameters.AddRange(parameterList.ToArray());
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable table = new DataTable();
                adapter.Fill(table);
                adapter.Dispose();

                // Respond
                message = "Executed successfully.";
                return table;
            }
            catch (Exception exception)
            {
                message = exception.Message;
                return null;
            }
            finally
            {
                // Close connection
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        #endregion

    }
}
