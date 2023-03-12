using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace DeveloperChallenge.Models.Shared
{
    public  class SqlHelper
    {
            private string ConnectionString { get; set; }
            private SqlConnection SqlConnection { get; set; }
            private SqlTransaction SqlTransaction { get; set; }

            public SqlHelper(string connectionString)
            {
                ConnectionString = connectionString;
            }

            public SqlConnection GetConnection()
            {
                return SqlConnection;
            }

            public bool CheckIfConnectionExists()
            {
                if (SqlConnection == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }

            public SqlTransaction GetTransaction()
            {
                return SqlTransaction;
            }

            public void CreateConnection()
            {
                SqlConnection = new SqlConnection(ConnectionString);
            }

            public void OpenConnection()
            {
                SqlConnection.Open();
            }

            public void VerifyConnection()
            {
                if (SqlConnection == null) CreateConnection();
                if (SqlConnection.State == ConnectionState.Closed) OpenConnection();
            }

            public void SqlBeginTransaction()
            {
                SqlTransaction = SqlConnection.BeginTransaction();
            }

            public void SqlCommitTransaction()
            {
                SqlTransaction.Commit();
            }

            public void SqlRollbackTransaction()
            {
                SqlTransaction.Rollback();
            }

            public void CloseConnection()
            {
                SqlConnection.Close();
            }

            public SqlParameter CreateParameter(string name, object value, DbType dbType)
            {
                return CreateParameter(name, 0, value, dbType, ParameterDirection.Input);
            }

            public SqlParameter CreateParameter(string name, int size, object value, DbType dbType)
            {
                return CreateParameter(name, size, value, dbType, ParameterDirection.Input);
            }

            public SqlParameter CreateParameter(string name, int size, object value, DbType dbType,
                ParameterDirection direction)
            {
                return new SqlParameter
                {
                    DbType = dbType,
                    ParameterName = name,
                    Size = size,
                    Direction = direction,
                    Value = value
                };
            }

            public DataTable GetDataTable(string commandText, CommandType commandType, SqlParameter[] parameters = null)
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    using (var command = new SqlCommand(commandText, connection))
                    {
                        command.CommandTimeout = 20;
                        command.CommandType = commandType;
                        if (parameters != null)
                        {
                            foreach (var parameter in parameters)
                            {
                                command.Parameters.Add(parameter);
                            }
                        }

                        var dataSet = new DataSet();
                        var dataAdapter = new SqlDataAdapter(command);
                        dataAdapter.Fill(dataSet);

                        return dataSet.Tables[0];
                    }
                }
            }
           
        }

}

