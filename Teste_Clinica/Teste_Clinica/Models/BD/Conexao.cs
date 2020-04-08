using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Teste_Clinica.Models.BD
{
    public class Conexao
    {
        SqlConnection con = new SqlConnection();

        public Conexao()
        {
            //inserir a string de conexão
            con.ConnectionString = @"Data Source=localhost;Initial Catalog=Projeto_Tcm_Estetica;Integrated Security = True";

        }

        public SqlConnection Conectar()
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            return con;
        }
        public void Desconectar()
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }

    }
}