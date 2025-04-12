using System;
using System.Collections;
using System.Data;
using System.Globalization;
using System.Reflection;

namespace Toolshed
{
    public static class Datatables
    {
        /// <summary>
        /// Converts an IList object to a DataTable
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static DataTable ToDataTable(this IList list, string dataTableName = "data")
        {
            if (list.Count == 0) return null;

            var returnTable = new DataTable(dataTableName);
            returnTable.Locale = CultureInfo.InvariantCulture;
            object baseObj = list[0];
            var objectType = baseObj.GetType();
            var properties = objectType.GetProperties();
            DataColumn col;
            foreach (var property in properties)
            {
                col = new DataColumn();
                col.ColumnName = property.Name; col.AllowDBNull = true;
                if (property.PropertyType.Name.Contains("Nullable"))
                {
                    col.DataType = Nullable.GetUnderlyingType(property.PropertyType);
                }
                else
                {
                    col.DataType = property.PropertyType;
                }

                returnTable.Columns.Add(col);
            }

            foreach (object objItem in list)
            {
                var row = returnTable.NewRow();
                foreach (PropertyInfo property in properties)
                {
                    var va = property.GetValue(objItem, null);
                    row[property.Name] = va ?? DBNull.Value;
                }
                returnTable.Rows.Add(row);
            }
            return returnTable;
        }

        /// <summary>
        /// Returns a provided DataTable in a CrossTab formatted DataTable.
        /// <para>The DataTable returns the specified row values as column headers, grouping the data</para>
        /// </summary>
        /// <param name="source">The datatable provided that will be used to return a crosstabbed datatable</param>
        /// <param name="uniqueRow">This is the column that will be unique when pivoted. Other values (not columntopivot and pivotvalues) will find a math here</param>
        /// <param name="columnToPivot">The column with the values that will be used as the header for the datatable returned</param>
        /// <param name="pivotValues">The column to use that will b ein the table as values) </param>
        /// <returns>Returns a DataTable formatted as a CrossTab report using teh specified parameters</returns>
        public static DataTable ConvertToCrossTab(this DataTable source, int uniqueRow, int columnToPivot, int pivotValues)
        {
            // create the table we're going to return
            var resultTable = new DataTable("PIVOT");

            // how many column does our source table have
            int sourceColumnCount = source.Columns.Count;

            // let's add the columns that are not being pivoted to the result table
            for (int i = 0; i < sourceColumnCount - 1; i++)
            {
                if (i != columnToPivot && i != pivotValues)
                {
                    var newColumn = new DataColumn(source.Columns[i].ColumnName);
                    newColumn.DataType = source.Columns[i].DataType;
                    resultTable.Columns.Add(newColumn);
                }
            }

            // all the columns have been added let's create the primary key for the unique column
            resultTable.PrimaryKey = new[] { resultTable.Columns[uniqueRow] };

            string column;
            foreach (DataRow row in source.Rows)
            {
                // let's create a column in the results table for every value in the pivot column from the source
                // check if the column has been previously added, if not we'll add it now
                column = row[columnToPivot].ToString();
                if (!resultTable.Columns.Contains(column))
                {
                    resultTable.Columns.Add(column);
                }

                // adding the values for the columns that are not being pivoted, this is based on the primary key
                // if it doesn't exist we add it
                if (!resultTable.Rows.Contains(row[uniqueRow]))
                {
                    DataRow dr = resultTable.NewRow();
                    for (int i = 0; i < sourceColumnCount - 1; i++)
                    {
                        if (i != columnToPivot && i != pivotValues)
                        {
                            dr[i] = row[i];
                        }
                    }

                    resultTable.Rows.Add(dr);
                }
            }

            // fill each pivoted column in the results table with the values form the source table
            foreach (DataRow row in source.Rows)
            {
                // let's find he unique row that we want to fill with our pivoted values
                DataRow currentRow = resultTable.Rows.Find(row[uniqueRow]);

                // let's find the column in the results table that reflects the value we're looking for
                column = row[columnToPivot].ToString();
                int columnToUpdate = resultTable.Columns.IndexOf(column);

                // let's update the corrcet column in the results row that we're working in
                currentRow[columnToUpdate] = row[pivotValues];

                // accept the changes
                currentRow.AcceptChanges();
            }

            // ReSharper disable AssignNullToNotNullAttribute
            resultTable.PrimaryKey = null;
            // ReSharper restore AssignNullToNotNullAttribute
            source.Dispose();
            return resultTable;
        }

    }
}
