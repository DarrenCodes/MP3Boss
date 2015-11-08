using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP3Boss.Source.Interfaces.Database
{
    interface IDatabase
    {
        SQLiteDataReader executeSQLQuery(string query);
    }
}
