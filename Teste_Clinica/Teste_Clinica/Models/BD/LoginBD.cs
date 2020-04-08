using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Teste_Clinica.Models.BD
{
    public class LoginBD
    {
        public bool T = false; //para retornar se deu certo (true) ou não (false)
        public String mensagem = ""; //para salvar mensagens de erro
        SqlCommand cmd = new SqlCommand();
        Conexao con = new Conexao();
        SqlDataReader dr; //DataReader, para ler e salvar info do banco
      
        public bool verificarLogin(String usuario, String senha)
        {
            // comandos SQl para verificar se tem no banco de dados:
            cmd.CommandText = "select * from LOGIN where USUARIO = @usuario and SENHA =@senha";
            cmd.Parameters.AddWithValue("@usuario", usuario);
            cmd.Parameters.AddWithValue("@senha", senha);

            try
            {
                cmd.Connection = con.Conectar();
                dr = cmd.ExecuteReader();
                if (dr.HasRows) //se tiver alguma linha, ou seja, se tiver encontrado uma combinação (tem no banco)
                {
                    T = true;
                }
                con.Desconectar();

            }
            catch (SqlException)
            {
                this.mensagem = "ERRO COM BANCO DE DADOS!";
            }

            return T; //retorna o bool dizendo se pode entrar (True) ou não (False)
        }


    }
}