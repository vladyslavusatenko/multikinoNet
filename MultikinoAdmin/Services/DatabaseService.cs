using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MultikinoAdmin.Services
{
    public class DatabaseService
    {
        private readonly string connectionString;

        public DatabaseService()
        {
            // Pobierz string połączenia z App.config
            connectionString = ConfigurationManager.ConnectionStrings["MultikinoEntities"].ConnectionString
                ?? throw new ArgumentNullException("Connection string 'MultikinoEntities' not found in App.config");
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        public DataTable ExecuteQuery(string query, Dictionary<string, object> parameters = null)
        {
            using (SqlConnection connection = GetConnection())
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            command.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                        }
                    }
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        try
                        {
                            connection.Open();
                            adapter.Fill(dataTable);
                            return dataTable;
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("Błąd podczas wykonywania zapytania: " + ex.Message, ex);
                        }
                    }
                }
            }
        }

        public int ExecuteNonQuery(string query)
        {
            using (SqlConnection connection = GetConnection())
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        return command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Błąd podczas wykonywania operacji: " + ex.Message, ex);
                    }
                }
            }
        }

        public object ExecuteScalar(string query)
        {
            using (SqlConnection connection = GetConnection())
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        return command.ExecuteScalar();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Błąd podczas wykonywania operacji: " + ex.Message, ex);
                    }
                }
            }
        }

        public void ExecuteStoredProcedure(string procedureName, SqlParameter[] parameters)
        {
            using (SqlConnection connection = GetConnection())
            {
                using (SqlCommand command = new SqlCommand(procedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"Błąd podczas wykonywania procedury {procedureName}: " + ex.Message, ex);
                    }
                }
            }
        }

        public bool TestConnection()
        {
            using (SqlConnection connection = GetConnection())
            {
                try
                {
                    connection.Open();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public void ExecuteNonQueryWithParams(string query, Dictionary<string, object> parameters)
        {
            using (SqlConnection connection = GetConnection())
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            command.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                        }
                    }
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Błąd podczas wykonywania operacji z parametrami: " + ex.Message, ex);
                    }
                }
            }
        }
    }
}