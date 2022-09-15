using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using FastMember;
using Microsoft.Data.SqlClient;

namespace Toolshed
{
    public static class SqlHelper
    {
        public static void LogToConsoleStringLengths<T>(List<T> data, bool stopWhenDone = true, Type[] ignoreColumnAttributes = null)
        {
            foreach (var item in typeof(T).GetProperties())
            {
                if (ignoreColumnAttributes != null)
                {
                    var d1 = item.CustomAttributes;
                    if (d1.Any(x => ignoreColumnAttributes.Contains(x.AttributeType)))
                    {
                        continue;
                    }
                }
                
                if (item.CustomAttributes.Any(x => x.AttributeType == typeof(IgnoreBulkImportAttribute)))
                {
                    continue;
                }

                if (item.PropertyType == typeof(string))
                {
                    var longest = 0;
                    for (int i = 0; i < data.Count; i++)
                    {
                        var l = (string)item.GetValue(data[i]);
                        if (l != null)
                        {
                            longest = longest > l.Length ? longest : l.Length;
                        }
                    }

                    Console.WriteLine($"{item.Name}: {longest}");
                }
            }

            if (stopWhenDone)
            {
                Console.WriteLine("Done - click a key to continue");
                Console.ReadLine();
            }
        }


        public static void BulkInsert<T>(SqlConnection connection, string tableName, IEnumerable<T> data, int batchSize = 5000, int commandTimeout = 3600, Type[] ignoreColumnAttributes = null)
        {
            using var bc = new SqlBulkCopy(connection)
            {
                BatchSize = batchSize,
                BulkCopyTimeout = commandTimeout,
                DestinationTableName = tableName,
                EnableStreaming = true                 
            };            

            foreach (var item in typeof(T).GetProperties())
            {
                if (item.CustomAttributes.Any(x => x.AttributeType == typeof(IgnoreBulkImportAttribute)))
                {
                    continue;
                }
                if (ignoreColumnAttributes != null)
                {
                    var d1 = item.CustomAttributes;
                    if (d1.Any(x => ignoreColumnAttributes.Contains(x.AttributeType)))
                    {
                        continue;
                    }
                }

                bc.ColumnMappings.Add(item.Name, item.Name);
            }

            using var reader = ObjectReader.Create(data);

            bc.WriteToServer(reader);
        }
        public static void BulkInsert<T>(SqlConnection connection, SqlTransaction sqlTransaction, string tableName, IEnumerable<T> data, int batchSize = 5000, int commandTimeout = 3600, Type[] ignoreColumnAttributes = null)
        {
            using var bc = new SqlBulkCopy(connection, SqlBulkCopyOptions.TableLock, sqlTransaction)
            {
                BatchSize = batchSize,
                BulkCopyTimeout = commandTimeout,
                DestinationTableName = tableName,
                EnableStreaming = true
            };

            foreach (var item in typeof(T).GetProperties())
            {
                if (item.CustomAttributes.Any(x => x.AttributeType == typeof(IgnoreBulkImportAttribute)))
                {
                    continue;
                }
                if (ignoreColumnAttributes != null)
                {
                    var d1 = item.CustomAttributes;
                    if (d1.Any(x => ignoreColumnAttributes.Contains(x.AttributeType)))
                    {
                        continue;
                    }
                }

                bc.ColumnMappings.Add(item.Name, item.Name);
            }

            using var reader = ObjectReader.Create(data);

            bc.WriteToServer(reader);
        }

        public static async Task BulkInsertAsync<T>(SqlConnection connection, string tableName, List<T> data, int batchSize = 5000, int commandTimeout = 3600, Type[] ignoreColumnAttributes = null)
        {
            using var bc = new SqlBulkCopy(connection)
            {
                BatchSize = batchSize,
                BulkCopyTimeout = commandTimeout,
                DestinationTableName = tableName,
                EnableStreaming = true
            };

            foreach (var item in typeof(T).GetProperties())
            {
                if (item.CustomAttributes.Any(x => x.AttributeType == typeof(IgnoreBulkImportAttribute)))
                {
                    continue;
                }
                if (ignoreColumnAttributes != null)
                {
                    var d1 = item.CustomAttributes;
                    if (d1.Any(x => ignoreColumnAttributes.Contains(x.AttributeType)))
                    {
                        continue;
                    }
                }

                bc.ColumnMappings.Add(item.Name, item.Name);
            }

            using var reader = ObjectReader.Create(data);

            await bc.WriteToServerAsync(reader);
        }
        public static async Task BulkInsertAsync<T>(SqlConnection connection, SqlTransaction sqlTransaction, string tableName, List<T> data, int batchSize = 5000, int commandTimeout = 3600, Type[] ignoreColumnAttributes = null)
        {
            using var bc = new SqlBulkCopy(connection, SqlBulkCopyOptions.TableLock, sqlTransaction)
            {
                BatchSize = batchSize,
                BulkCopyTimeout = commandTimeout,
                DestinationTableName = tableName,
                EnableStreaming = true
            };

            foreach (var item in typeof(T).GetProperties())
            {
                if (item.CustomAttributes.Any(x => x.AttributeType == typeof(IgnoreBulkImportAttribute)))
                {
                    continue;
                }
                if (ignoreColumnAttributes != null)
                {
                    var d1 = item.CustomAttributes;
                    if (d1.Any(x => ignoreColumnAttributes.Contains(x.AttributeType)))
                    {
                        continue;
                    }
                }

                bc.ColumnMappings.Add(item.Name, item.Name);
            }

            using var reader = ObjectReader.Create(data);

            await bc.WriteToServerAsync(reader);
        }
        public static async Task BulkInsertAsync<T>(SqlConnection connection, string tableName, ObjectReader objectReader, int batchSize = 5000, int commandTimeout = 3600, Type[] ignoreColumnAttributes = null, string[] ignoreColumns = null)
        {
            using var bc = new SqlBulkCopy(connection)
            {
                BatchSize = batchSize,
                BulkCopyTimeout = commandTimeout,
                DestinationTableName = tableName,
                EnableStreaming = true
            };

            foreach (var item in typeof(T).GetProperties())
            {
                if (item.CustomAttributes.Any(x => x.AttributeType == typeof(IgnoreBulkImportAttribute)))
                {
                    continue;
                }
                if (ignoreColumnAttributes != null)
                {
                    var d1 = item.CustomAttributes;
                    if (d1.Any(x => ignoreColumnAttributes.Contains(x.AttributeType)))
                    {
                        continue;
                    }
                }

                if (ignoreColumns != null)
                {
                    if (ignoreColumns.Contains(item.Name))
                    {
                        continue;
                    }
                }

                bc.ColumnMappings.Add(item.Name, item.Name);
            }

            await bc.WriteToServerAsync(objectReader);
        }
        public static async Task BulkInsertAsync<T>(SqlConnection connection, SqlTransaction sqlTransaction, string tableName, ObjectReader objectReader, int batchSize = 5000, int commandTimeout = 3600, Type[] ignoreColumnAttributes = null, string[] ignoreColumns = null)
        {
            using var bc = new SqlBulkCopy(connection, SqlBulkCopyOptions.TableLock, sqlTransaction)
            {
                BatchSize = batchSize,
                BulkCopyTimeout = commandTimeout,
                DestinationTableName = tableName,
                EnableStreaming = true
            };

            foreach (var item in typeof(T).GetProperties())
            {
                if (item.CustomAttributes.Any(x => x.AttributeType == typeof(IgnoreBulkImportAttribute)))
                {
                    continue;
                }
                if (ignoreColumnAttributes != null)
                {
                    var d1 = item.CustomAttributes;
                    if (d1.Any(x => ignoreColumnAttributes.Contains(x.AttributeType)))
                    {
                        continue;
                    }
                }

                if(ignoreColumns != null)
                {
                    if(ignoreColumns.Contains(item.Name))
                    {
                        continue;
                    }
                }

                bc.ColumnMappings.Add(item.Name, item.Name);
            }

            await bc.WriteToServerAsync(objectReader);
        }


        

        public static void UseDatabase(this SqlConnection connection, string databaseName)
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            connection.ChangeDatabase(databaseName);
        }

        public static int TruncateTable(string tableName, SqlConnection connection, SqlTransaction transaction = null)
        {
            return ExecuteNonQuery("TRUNCATE TABLE " + tableName, connection, transaction);
        }
        public async static Task<int> TruncateTableAsync(string tableName, SqlConnection connection, SqlTransaction transaction = null)
        {
            return await ExecuteNonQueryAsync("TRUNCATE TABLE " + tableName, connection, transaction);
        }

        public static int DropExistingTable(string tableName, SqlConnection connection, SqlTransaction transaction = null)
        {
            return ExecuteNonQuery(string.Format("IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'{0}') AND type in (N'U')) DROP TABLE {0}", tableName), connection, transaction);
        }        

        public static int RenameTable(string oldName, string newName, SqlConnection connection, SqlTransaction transaction = null)
        {
            return ExecuteNonQuery(string.Format("EXECUTE sp_rename N'{0}', N'{1}', 'OBJECT'", oldName, newName), connection, transaction);
        }



        public static T ExecuteScalar<T>(string sql, SqlConnection connection)
        {
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.CommandType = CommandType.Text;
                command.CommandTimeout = 0x8ca0;
                return (T)command.ExecuteScalar();
            }
        }
        public async static Task<T> ExecuteScalarAsync<T>(string sql, SqlConnection connection)
        {
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.CommandType = CommandType.Text;
                command.CommandTimeout = 0x8ca0;
                return (T)await command.ExecuteScalarAsync();
            }
        }

        public static T ExecuteScalar<T>(string sql, SqlConnection connection, SqlTransaction transaction)
        {
            using (SqlCommand command = new SqlCommand(sql, connection, transaction))
            {
                command.CommandType = CommandType.Text;
                command.CommandTimeout = 0x8ca0;
                return (T)command.ExecuteScalar();
            }
        }
        public async static Task<T> ExecuteScalarAsync<T>(string sql, SqlConnection connection, SqlTransaction transaction)
        {
            using (SqlCommand command = new SqlCommand(sql, connection, transaction))
            {
                command.CommandType = CommandType.Text;
                command.CommandTimeout = 0x8ca0;
                return (T)await command.ExecuteScalarAsync();
            }
        }


        public static int ExecuteNonQuery(string sql, SqlConnection connection, SqlTransaction transaction = null, int commandTimeout = 30)
        {
            if (transaction == null)
            {
                return ExecuteNonQuery(sql, connection, CommandType.Text, commandTimeout);
            }
            return ExecuteNonQuery(sql, connection, transaction, CommandType.Text, commandTimeout);
        }
        public static int ExecuteNonQuery(string sql, SqlConnection connection, CommandType commandType, int commandTimeout = 30)
        {
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.CommandType = commandType;
                command.CommandTimeout = commandTimeout;
                return command.ExecuteNonQuery();
            }
        }
        public static int ExecuteNonQuery(string sql, SqlConnection connection, SqlTransaction transaction, CommandType commandType, int commandTimeout = 30)
        {
            using (SqlCommand command = new SqlCommand(sql, connection, transaction))
            {
                command.CommandType = commandType;
                command.CommandTimeout = commandTimeout;
                return command.ExecuteNonQuery();
            }
        }
        public static int ExecuteNonQuery(string sql, SqlConnection connection, SqlParameter[] parameters, CommandType commandType, int commandTimeout = 30)
        {
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.CommandTimeout = commandTimeout;
                command.CommandType = commandType;
                command.CommandText = sql;
                command.Parameters.AddRange(parameters);
                return command.ExecuteNonQuery();
            }
        }
        public static int ExecuteNonQuery(string sql, SqlConnection connection, SqlTransaction transaction, SqlParameter[] parameters, CommandType commandType, int commandTimeout = 30)
        {
            using (SqlCommand command = new SqlCommand(sql, connection, transaction))
            {
                command.CommandTimeout = commandTimeout;
                command.CommandType = commandType;
                command.CommandText = sql;
                command.Parameters.AddRange(parameters);
                return command.ExecuteNonQuery();
            }
        }


        public async static Task<int> ExecuteNonQueryAsync(string sql, SqlConnection connection, CommandType commandType, int commandTimeout = 30)
        {
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.CommandType = commandType;
                command.CommandTimeout = commandTimeout;
                return await command.ExecuteNonQueryAsync();
            }
        }
        public async static Task<int> ExecuteNonQueryAsync(string sql, SqlConnection connection, SqlTransaction transaction = null, int commandTimeout = 30)
        {
            if (transaction == null)
            {
                return await ExecuteNonQueryAsync(sql, connection, CommandType.Text, commandTimeout);
            }
            return await ExecuteNonQueryAsync(sql, connection, transaction, CommandType.Text, commandTimeout);
        }
        public async static Task<int> ExecuteNonQueryAsync(string sql, SqlConnection connection, SqlTransaction transaction, CommandType commandType, int commandTimeout = 30)
        {
            using (SqlCommand command = new SqlCommand(sql, connection, transaction))
            {
                command.CommandType = commandType;
                command.CommandTimeout = commandTimeout;
                return await command.ExecuteNonQueryAsync();
            }
        }
        public async static Task<int> ExecuteNonQueryAsync(string sql, SqlConnection connection, SqlParameter[] parameters, CommandType commandType, int commandTimeout = 30)
        {
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.CommandTimeout = commandTimeout;
                command.CommandType = commandType;
                command.CommandText = sql;
                command.Parameters.AddRange(parameters);
                return await command.ExecuteNonQueryAsync();
            }
        }
        public async static Task<int> ExecuteNonQueryAsync(string sql, SqlConnection connection, SqlTransaction transaction, SqlParameter[] parameters, CommandType commandType, int commandTimeout = 30)
        {
            using (SqlCommand command = new SqlCommand(sql, connection, transaction))
            {
                command.CommandTimeout = commandTimeout;
                command.CommandType = commandType;
                command.CommandText = sql;
                command.Parameters.AddRange(parameters);
                return await command.ExecuteNonQueryAsync();
            }
        }


        








        /// <summary>
        /// This checks if a given statement is true. It checks for a return value of 1 or 0 NOT a null value.
        /// You shoudl use EXISTS to minimize the amount of work that SQL does. Something like:
        /// SELECT CASE WHEN EXISTS(SELECT 1 FROM your.table WHERE yourCriteria = 'something') THEN 1 ELSE 0 END");
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public async static Task<bool> ExistsAsync(string connectionString, string sql)
        {
            using var connection = new SqlConnection(connectionString);
            connection.Open();

            using var command = new SqlCommand(sql, connection);

            command.CommandType = CommandType.Text;
            command.CommandTimeout = 0x8ca0;
            return (int)await command.ExecuteScalarAsync() == 1;
        }

    }

}
