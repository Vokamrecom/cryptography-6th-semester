using Crypto_Lab03.Cezar;
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

namespace Crypto_Lab03
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        Caesar caesar = new Caesar();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            textBox2.Text = caesar.CaesarChipher(textBox1.Text, Convert.ToInt32(numericUpDown1.Text));

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            textBox3.Text = caesar.CaesarChipher(textBox2.Text, -Convert.ToInt32(numericUpDown1.Text));

        }
    }
}
