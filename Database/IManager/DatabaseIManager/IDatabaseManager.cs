using DatabaseResult;
using System;

namespace DatabaseIManager
{
    public interface IDatabaseManager
    {
        public DbResult ExecuteNonQuery();
        public DbResult ExecuteQuery(string qry);
    }
}
