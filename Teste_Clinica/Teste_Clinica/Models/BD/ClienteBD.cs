using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Teste_Clinica.Models.BD
{
    public class ClienteBD
    {
        public String mensagem = ""; //para salvar mensagens de erro
        SqlCommand cmd = new SqlCommand();
        Conexao con = new Conexao();
        SqlDataReader dr; //DataReader, para ler e salvar info do banco
        List<Clientes> Lista = new List<Clientes>();

        public List<Clientes> ListaClientes()
        {
            cmd.CommandText = "select * from CLIENTE";

            try
            {
                cmd.Connection = con.Conectar();
                dr = cmd.ExecuteReader();
                while (dr.Read()) 
                {
                    Clientes cliente = new Clientes();
                    AtribuirCliente(cliente, dr);
                    Lista.Add(cliente);
                }
                con.Desconectar();

            }
            catch (SqlException)
            {
                this.mensagem = "ERRO COM BANCO DE DADOS!";
            }

            return Lista;
        }


        public Clientes AtribuirCliente(Clientes cliente, SqlDataReader dr)
        {
            cliente.IdCliente = int.Parse(dr["ID"].ToString());
            cliente.Nome = dr["NOME"].ToString();
            cliente.Cpf = dr["CPF"].ToString();
            cliente.Endereco = dr["ENDERECO"].ToString();
            cliente.Telefone = dr["TELEFONE"].ToString();
            cliente.Email = dr["EMAIL"].ToString();
            cliente.Sexo = dr["SEXO"].ToString();
            
            return cliente;
        }
    }
}