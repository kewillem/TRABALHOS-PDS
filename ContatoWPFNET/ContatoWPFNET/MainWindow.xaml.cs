using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data;
using ContatoWPFNET.Formulario;

namespace ContatoWPFNET
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btListar_Click_1(object sender, RoutedEventArgs e)
        {
            Lista form = new Lista();
            form.ShowDialog();
        }

        private void btCadastro_Click(object sender, RoutedEventArgs e)
        {
            var form = new Cadastro();
            form.ShowDialog();
        }
    }
}
