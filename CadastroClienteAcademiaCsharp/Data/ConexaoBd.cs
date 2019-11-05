using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroClienteAcademiaCsharp.Data
{
    class ConexaoBd
    {
        private const string _connectionString = "Server=(localDb)\\mssqllocaldb;Database=AulaBancoDeDados;Trusted_connection=true;";

        private List<SqlParameter> _parametros = new List<SqlParameter>();

        public void AddParametro(string nome, object value)
        {
            _parametros.Add(new SqlParameter(nome, value));
        }

        public int ExecuteNonQuery(string query) //updates e inserts e deletes
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand(query, connection))
                {
                    _parametros.ForEach(x => sqlCommand.Parameters.Add(x));
                    try
                    {
                        connection.Open();
                        return sqlCommand.ExecuteNonQuery();
                    }
                    finally
                    {

                        connection.Close();
                    }
                }
            }
        }

        public DataTable ExecuteReader(string query) //selects
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand(query, connection))
                {
                    _parametros.ForEach(x => sqlCommand.Parameters.Add(x));
                    try
                    {
                        connection.Open();
                        using (SqlDataReader dataReader = sqlCommand.ExecuteReader()) //datareader = le dados
                        {
                            var dataTable = new DataTable();
                            dataTable.Load(dataReader);
                            dataReader.Close();
                            return dataTable;
                        }
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }
    }
}
