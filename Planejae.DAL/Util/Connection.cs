using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planejae.DAL.Util
{
    public static class Connection
    {


        private static string StringConnection;

        
        private SqlConnectionStringBuilder _connStringLocal =
            new SqlConnectionStringBuilder()
            {
                //DataSource = @"fernandoverago\SQLEXPRESS",
                //DataSource = @"LUCAS\SQLEXPRESS",
                DataSource = @"A e O\SQLEXPRESS",
                InitialCatalog = "planejae",
                IntegratedSecurity = true,
                Pooling = true
            };
        /*
        private  SqlConnectionStringBuilder _connStringAmazon =
            new SqlConnectionStringBuilder()
            {
                DataSource = "ec2-52-35-48-50.us-west-2.compute.amazonaws.com",
                UserID = "amagnnno",
                Password = "olaf2016",
                InitialCatalog = "planejae",
                Pooling = true
            };
        */


        public static void SetStringConnection(string stringConnection)
        {
            Connection.StringConnection = stringConnection;
        }

        public static SqlConnection GetInstance()
        {
            return new SqlConnection(Connection.StringConnection);            
        }
    }
}
