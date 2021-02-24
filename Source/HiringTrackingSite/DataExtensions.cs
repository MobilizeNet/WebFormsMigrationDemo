using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HiringTrackingSite
{
    public static class DataExtensions
    {


        public static void AddNewParameter(this SqlCommand cmd, string name, SqlDbType type, object value)
        {
            cmd.Parameters.Add(name, type);
            cmd.Parameters[name].Value = value;
        }
    }
}