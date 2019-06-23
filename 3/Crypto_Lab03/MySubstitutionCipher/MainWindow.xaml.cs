using System;
using System.Collections.Generic;
using System.IO;
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

namespace MySubstitutionCipher
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            textBox1.Text = File.ReadAllText("text.txt", Encoding.GetEncoding(1251));

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string[] alf = File.ReadAllLines("alf.txt", Encoding.GetEncoding(1251));
                string[] key = File.ReadAllLines("key.txt", Encoding.GetEncoding(1251));
                string text = File.ReadAllText("text.txt", Encoding.GetEncoding(1251));
                var substitution = new Dictionary<string, string>();

                for (int i = 0; i < alf.Length; i++)
                    substitution[alf[i]] = key[i];

                StringBuilder ans = new StringBuilder();
                for (int i = 0; i < text.Length; i++)
                {
                    if (substitution.ContainsKey(text[i].ToString()))
                        ans.Append(substitution[text[i].ToString()]);

                    else
                        ans.Append(text[i]);
                    textBox2.Text = ans.ToString();
                }
                File.WriteAllText("code.txt", ans.ToString(), Encoding.GetEncoding(1251));
            }
            catch { }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string[] alf = File.ReadAllLines("alf.txt", Encoding.GetEncoding(1251));
            string[] key = File.ReadAllLines("key.txt", Encoding.GetEncoding(1251));
            string code = File.ReadAllText("code.txt", Encoding.GetEncoding(1251));
            var substitution = new Dictionary<string, string>();

            for (int i = 0; i < alf.Length; i++)
                substitution[key[i]] = alf[i];

            StringBuilder ans = new StringBuilder();
            for (int i = 0; i < code.Length; i++)
            {
                if (substitution.ContainsKey(code[i].ToString()))
                    ans.Append(substitution[code[i].ToString()]);
                else
                    ans.Append(code[i]);
                textBox3.Text = ans.ToString();
            }
            File.WriteAllText("decode.txt", ans.ToString(), Encoding.GetEncoding(1251));

        }
    }
}
