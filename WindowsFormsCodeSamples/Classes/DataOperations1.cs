using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WindowsFormsCodeSamples.Classes.Base.BaseExceptionsLibrary;

namespace WindowsFormsCodeSamples.Classes
{
    public class DataOperations1 : BaseExceptionProperties
    {
        public static readonly string ConnectionString =
            "Data Source=.\\SQLEXPRESS;Initial Catalog=NorthWind2020;" +
            "Integrated Security=True";


        public static async Task<DataTable> ReadCustomersWithTuple(CancellationToken ct)
        {
            mHasException = false;

            SqlConnection cn = new(ConnectionString);

            SqlCommand cmd = new() { Connection = cn };
            DataTable customerDataTable = new();

            cmd.CommandText = _selectCustomersWithJoinsQuery;

            try
            {

                await cn.OpenAsync(ct);
                customerDataTable.Load(await cmd.ExecuteReaderAsync(ct));

            }
            catch (Exception exception)
            {
                mHasException = true;
                mLastException = exception;
                return null;
            }

            return customerDataTable;

        }
        /// <summary>
        /// Shared select query
        /// </summary>
        private static string _selectCustomersWithJoinsQuery =>
            "SELECT C.CustomerIdentifier, C.CompanyName, C.ContactId, CT.ContactTitle, CN.FirstName, CN.LastName, C.Street, C.City, C.PostalCode, C.CountryIdentifier, C.Phone, C.ContactTypeIdentifier, CO.Name AS CountryName " +
            "FROM Customers AS C " +
            "INNER JOIN ContactType AS CT ON C.ContactTypeIdentifier = CT.ContactTypeIdentifier " +
            "INNER JOIN Countries   AS CO ON C.CountryIdentifier = CO.CountryIdentifier " +
            "INNER JOIN Contacts    AS CN ON C.ContactId = CN.ContactId AND CT.ContactTypeIdentifier = CN.ContactTypeIdentifier";
    }
}
