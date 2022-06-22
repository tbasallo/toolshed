using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using Microsoft.Data.SqlClient;

namespace Toolshed
{
    public static class SqlExtensions
    {
        public static void AddBulkCopyColumn(this SqlBulkCopy bc, string name)
        {
            bc.ColumnMappings.Add(name, name);
        }

        public static void AddBulkCopyColumns(this SqlBulkCopy bc, DataTable dataTable)
        {            
            foreach (DataColumn column in dataTable.Columns)
            {
                bc.ColumnMappings.Add(column.ColumnName, column.ColumnName);
            }
        }

        /// <summary>
        /// Queries the specified tables with the respective columns using a non-result query to determine if all columns exist on the table.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="connection"></param>
        /// <param name="table"></param>
        /// <param name="ignoreColumnAttributes"></param>
        /// <param name="ignoreColumns"></param>
        public static void CheckColumns<T>(this SqlConnection connection, string table, Type[] ignoreColumnAttributes = null, string[] ignoreColumns = null)
        {

            var list = new List<string>();
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
                if (ignoreColumns != null)
                {
                    if (ignoreColumns.Contains(item.Name))
                    {
                        continue;
                    }
                }

                list.Add(item.Name);
            }

            var sql = "SELECT TOP 1 " + list.ToDelimitedString() + " FROM " + table + " WHERE 1 = 0";
            using SqlCommand command = new SqlCommand(sql, connection);
            command.CommandType = CommandType.Text;
            command.CommandTimeout = 60;
            command.ExecuteNonQuery();
        }        
    }
}
