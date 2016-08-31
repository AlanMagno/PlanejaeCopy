﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planejae.DAL.Util
{
    public class ProcedureExecuter
    {
        private DataTable CurrentDataTable = null;

        public ProcedureExecuter()
        {

        }

        public ProcedureExecuter(DataTable dataTable)
        {
            this.CurrentDataTable = dataTable;
        }

        public void Execute(string procedureName)
        {
            using (var conn = new Connection().GetInstance())
            {
                using (var cmd = new SqlCommand(procedureName, conn))
                {
                    ExecuteCommand(conn, cmd);
                }
            }
        }

        public void Execute(string procedureName, ParList inParameters)
        {
            using (var conn = new Connection().GetInstance())
            {                
                using (var cmd = new SqlCommand(procedureName, conn))
                {
                    foreach (var par in inParameters)
                    {
                        cmd.Parameters.AddWithValue(par.Key, par.Value);
                    }
                    ExecuteCommand(conn, cmd);
                }
            }
        }

        public void Execute(string procedureName, ParList inParameters, ref ParList outParameters)
        {
            using (var conn = new Connection().GetInstance())
            {                
                using (var cmd = new SqlCommand(procedureName, conn))
                {
                    foreach (var par in inParameters)
                    {
                        cmd.Parameters.AddWithValue(par.Key, par.Value);
                    }

                    foreach (var par in outParameters)
                    {
                        if (par.Value != null) cmd.Parameters.AddWithValue(par.Key, par.Value);
                    }
                    ExecuteCommand(conn, cmd);

                    foreach (var par in outParameters)
                    {
                        if (par.Value != null) cmd.Parameters.AddWithValue(par.Key, par.Value);
                    }
                }
            }
        }

        private void ExecuteCommand(SqlConnection conn, SqlCommand cmd)
        {
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            conn.Open();
            if(this.CurrentDataTable == null)
            {
                cmd.ExecuteNonQuery();
                return;
            }

            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                adapter.Fill(this.CurrentDataTable);
            }
            conn.Close();
        }
    }
}
