using System.Collections.Generic;
using System.Data.SqlClient;

namespace PayMaster.Framework.Data
{
    public class BaseDa
    {
        protected static readonly IList<SqlParameter> ListSqlParameters = new List<SqlParameter>();
        protected static string ProcQuery;
        protected static string ConnString;
    }
}
