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
using System.IO;

namespace VegenerChipher
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
        Vegener vegener = new Vegener();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (radioButtonGamma.IsChecked.Value)
            {
                string s;

                StreamReader sr = new StreamReader("in.txt", Encoding.GetEncoding(1251));
                StreamWriter sw = new StreamWriter("out.txt", true, Encoding.GetEncoding(1251));

                while (!sr.EndOfStream)
                {
                    s = sr.ReadLine();
                    sw.WriteLine(vegener.Encode(s, vegener.Generate_Pseudorandom_KeyWord(s.Length, 100)));
                }

                sr.Close();
                sw.Close();
            }
            else
            {
                if (textBoxKeyWord.Text.Length > 0)
                {
                    string s;

                    StreamReader sr = new StreamReader("in.txt", Encoding.GetEncoding(1251));
                    StreamWriter sw = new StreamWriter("out.txt", true, Encoding.GetEncoding(1251));

                    while (!sr.EndOfStream)
                    {
                        s = sr.ReadLine();
                        sw.WriteLine(vegener.Encode(s, textBoxKeyWord.Text));
                    }

                    sr.Close();
                    sw.Close();
                    MessageBox.Show("Сообщение зашифровано");
                }
                else
                    MessageBox.Show("Введите ключевое слово!");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (radioButtonGamma.IsChecked.Value)
            {
                string s;

                StreamReader sr = new StreamReader("out.txt", Encoding.GetEncoding(1251));
                StreamWriter sw = new StreamWriter("decode.txt", true, Encoding.GetEncoding(1251));

                while (!sr.EndOfStream)
                {
                    s = sr.ReadLine();
                    sw.WriteLine(vegener.Decode(s, vegener.Generate_Pseudorandom_KeyWord(s.Length, 100)));
                }

                sr.Close();
                sw.Close();
            }
            else
            {
                if (textBoxKeyWord.Text.Length > 0)
                {
                    string s;

                    StreamReader sr = new StreamReader("out.txt", Encoding.GetEncoding(1251));
                    StreamWriter sw = new StreamWriter("decode.txt", true, Encoding.GetEncoding(1251));

                    while (!sr.EndOfStream)
                    {
                        s = sr.ReadLine();
                        sw.WriteLine(vegener.Decode(s, textBoxKeyWord.Text));
                    }

                    sr.Close();
                    sw.Close();
                    MessageBox.Show("Сообщение расшифровано");
                }
                else
                    MessageBox.Show("Введите ключевое слово!");
            }
        }
    }
}
