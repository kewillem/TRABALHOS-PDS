using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MySql.Data;
using MySql.Data.MySqlClient;
using ContatoWPFNET;
using ContatoWPFNET.Formulario;
using System.IO;

namespace ContatoWPFNET.Formulario
{
    /// <summary>
    /// Lógica interna para Cadastro.xaml
    /// </summary>
    public partial class Cadastro : Window
    {
        private MySqlConnection conexao;

        private MySqlCommand comando;

        public Cadastro()
        {

            InitializeComponent();  

        }

        private void Conexao()
        {
            string conexaoString = "server=localhost;database=app_contato_bd;user=root;password=root;port=3360";
            conexao = new MySqlConnection(conexaoString);
            comando = conexao.CreateCommand();

            conexao.Open();
        }

        private void btnSalvar_Click_1(object sender, RoutedEventArgs e)
        {
            Conexao();

            bool sexo1 = Convert.ToBoolean(rdSexo1);
            bool sexo2 = Convert.ToBoolean(rdSexo2);

            try
            {
                if (!sexo1 && !sexo2 || dateDataNascimento.Text == "" || txtNome.Text == "" || txtEmail.Text == "" || txtTelefone.Text == "")
                {
                    MessageBox.Show("Marque uma opção!");
                }
                else
                {
                    var nome = txtNome.Text;
                    var email = txtEmail.Text;
                    var tel = txtTelefone.Text;
                    var data_nasc = dateDataNascimento.Text;
                    var sexo = "Feminino";

                    if (sexo1)
                    {
                        sexo = "Masculino";
                    }

                    string query = "INSERT INTO contato_cont (nome_cont, email_cont, telefone_cont, data_nasc_cont, sexo_cont) VALUES (@_nome, @_email, @_telefone, @_data_nasc, @_sexo)";
                    var comando = new MySqlCommand(query, conexao);

                    comando.Parameters.AddWithValue("@_nome", nome);
                    comando.Parameters.AddWithValue("@_email", email);
                    comando.Parameters.AddWithValue("@_telefone", tel);
                    comando.Parameters.AddWithValue("@_data_nasc", data_nasc);
                    comando.Parameters.AddWithValue("@_sexo", sexo);

                    comando.ExecuteNonQuery();
                    conexao.Close();
                    MessageBox.Show("Salvo com sucesso!");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro ao salvar os dados({ex.GetHashCode()})");
            }
        }
    }
}
