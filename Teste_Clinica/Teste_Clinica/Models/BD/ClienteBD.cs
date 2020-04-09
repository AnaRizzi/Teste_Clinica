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

        public void Cadastrar(Clientes cliente)
        {
            cmd.CommandText = "insert into CLIENTE (NOME, CPF, ENDERECO, TELEFONE, EMAIL, SEXO) values(@nome, @cpf, @endereco, @telefone, @email, @sexo)";
            cmd.Parameters.AddWithValue("@nome", cliente.Nome);
            cmd.Parameters.AddWithValue("@cpf", cliente.Cpf);
            cmd.Parameters.AddWithValue("@endereco", cliente.Endereco);
            cmd.Parameters.AddWithValue("@telefone", cliente.Telefone);
            cmd.Parameters.AddWithValue("@email", cliente.Email);
            cmd.Parameters.AddWithValue("@sexo", cliente.Sexo);

            try
            {
                cmd.Connection = con.Conectar();
                cmd.ExecuteNonQuery();
                con.Desconectar();

            }
            catch (SqlException ex)
            {
                this.mensagem = "ERRO COM BANCO DE DADOS!" + ex;
            }
            
        }

        public Clientes Buscar(int id)
        {
            Clientes cliente = new Clientes();
            cmd.CommandText = "select * from CLIENTE where ID = @id";
            cmd.Parameters.AddWithValue("@id", id);

            try
            {
                cmd.Connection = con.Conectar();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    AtribuirCliente(cliente, dr);
                }
                con.Desconectar();

            }
            catch (SqlException ex)
            {
                this.mensagem = "ERRO COM BANCO DE DADOS!" + ex;
            }

            return cliente;
        }

        public void Excluir (int id)
        {
       
            cmd.CommandText = "delete from CLIENTE where ID = @id";
            cmd.Parameters.AddWithValue("@id", id);

            try
            {
                cmd.Connection = con.Conectar();
                cmd.ExecuteNonQuery();
                con.Desconectar();

            }
            catch (SqlException ex)
            {
                this.mensagem = "ERRO COM BANCO DE DADOS!" + ex;
            }
        }

        public void Editar(Clientes cliente)
        {

            cmd.CommandText = "update CLIENTE set NOME = @nome, CPF = @cpf, ENDERECO = @endereco, TELEFONE = @telefone, EMAIL = @email, SEXO = @sexo where ID = @id";
            cmd.Parameters.AddWithValue("@nome", cliente.Nome);
            cmd.Parameters.AddWithValue("@cpf", cliente.Cpf);
            cmd.Parameters.AddWithValue("@endereco", cliente.Endereco);
            cmd.Parameters.AddWithValue("@telefone", cliente.Telefone);
            cmd.Parameters.AddWithValue("@email", cliente.Email);
            cmd.Parameters.AddWithValue("@sexo", cliente.Sexo);
            cmd.Parameters.AddWithValue("@id", cliente.IdCliente);

            try
            {
                cmd.Connection = con.Conectar();
                cmd.ExecuteNonQuery();
                con.Desconectar();

            }
            catch (SqlException ex)
            {
                this.mensagem = "ERRO COM BANCO DE DADOS!" + ex;
            }
        }


    }
}