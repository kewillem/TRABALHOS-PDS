using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
using System.IO;
using Org.BouncyCastle.Asn1.TeleTrust;

namespace ContatoWPFNET.Formulario
{
    /// <summary>
    /// Lógica interna para Lista.xaml
    /// </summary>
    public partial class Lista : Window
    {
        private MySqlConnection conexao;

        private MySqlCommand comando;
        public Lista()
        {
            InitializeComponent();
            CarregarDados();
        }
        private void Conexao()
        {
            string conexaoString = "server=localhost;database=app_contato_bd;user=root;password=root;port=3360";
            conexao = new MySqlConnection(conexaoString);
            comando = conexao.CreateCommand();

            conexao.Open();
        }
        private void CarregarDados()
        {
            Conexao();
            string query = "SELECT * FROM contato_cont";
            var comando = new MySqlCommand(query, conexao);

            var reader = comando.ExecuteReader();
            
            List<Object> dados = new List<Object>();

            while (reader.Read())
            {
                var contato = new {
                    Nome = reader.GetString(1),
                    Telefone = reader.GetString(2),
                };

                dados.Add(contato);
            }



            dgvExibir1.ItemsSource = dados;


            //dt.Columns["id_cont"].ColumnName = "id";
            //dt.Columns["nome_cont"].ColumnName = "nome";
            //dt.Columns["email_cont"].ColumnName = "email";
            //dt.Columns["telefone_cont"].ColumnName = "telefone";
            //dt.Columns["data_nasc_cont"].ColumnName = "data de nascimento";
            //dt.Columns["sexo_cont"].ColumnName = "sexo";

        }
    }
}
