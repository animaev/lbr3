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
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using System.IO;
using Microsoft.Win32;
using System.Diagnostics;
using System.Globalization;

namespace лб3
{
	/// <summary>
	/// Логика взаимодействия для CreateWindow.xaml
	/// </summary>
	public partial class CreateWindow : Window
	{
		public CreateWindow()
		{
			InitializeComponent();
            List<string> phone = new List<string>();
            phone.Add("+7");
            phone.Add("8");
            ComTel.ItemsSource = phone;
        }

        Regex InputID = new Regex(@"[0-9]"); // [а-яА-Я]
        private void TbID_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Match matchID = InputID.Match(e.Text);
            if (!matchID.Success)
            {
                e.Handled = true;
            }
        }
        Regex InputSur = new Regex(@"[а-яА-Я]");
        private void TbSurName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Match matchSur = InputSur.Match(e.Text);
            if (!matchSur.Success)
            {
                e.Handled = true;
            }
        }

        Regex InputEmail = new Regex(@"[a-zA-Z0-9_\-\.]");
        private void tbEmail_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Match Email = InputEmail.Match(e.Text);
            InputEmail.Match(e.Text);
            if (!Email.Success)
            {
                e.Handled = true;
            }
        }
        bool asd = false;
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string temp = $"{tbID.Text}";
            bool pro = true;
            List<string> personal = new List<string>();
            StringBuilder errors = new StringBuilder();

            StreamReader idreader = new StreamReader(@"E:\employee.txt");
            {
                string[] sas = idreader.ReadToEnd().Split('\t');
                if (!idreader.EndOfStream)
                {
                    sas = idreader.ReadToEnd().Split('\t');
                }
                //  for (int i = 0; i < sas.Length; i++) { MessageBox.Show(sas[i]); }               
                for (int i = 0; i < sas.Length; i++)
                {

                    if (temp == sas[i])
                    {
                        errors.AppendLine("Идентификатор занят");
                        pro = false;
                    }
                }
                if (pro == true)
                {
                    MessageBox.Show("ID не занят");
                }
                idreader.Close();
            }

            string tempMail = "";
            string Email = tbEmail.Text;
            if (tbPassport1.Text.Length != 4 || tbPassport2.Text.Length != 6)
            {
                errors.AppendLine("Данные паспорта не верны");
            }
            if (tbNumber.Text.Length != 10)
            {
                errors.AppendLine("Данные номера не корректны");
            }
            if (tbID.Text == "" || tbSurName.Text == "" || tbName.Text == "" || tbPatro.Text == "" || tbPassport1.Text == "" || tbPassport2.Text == "" || tbEmail.Text == "" || tbNumber.Text == "")
            {
                errors.AppendLine("Есть пустые ячейки");

            }
            /*if (string.IsNullOrEmpty(tbEmail.Text))
            {
                errors.AppendLine("Email адрес не может юыть пустым\n");
            }
            else
            {
                char h = tbEmail.Text[0];
                char[] h1 = tbEmail.Text.ToCharArray();
                for (int i = 0; i < tbEmail.Text.Length - 9; i++)
                {
                    if (h1[i] == '@')
                    {
                        errors.AppendLine("Email адрес не может начинаться с цифры или символа\n");
                    }
                    if (h == '_' || h == '1' || h == '2' || h == '3' || h == '4' ||
                        h == '5' || h == '6' || h == '7' || h == '8' || h == '9' || h == '0')
                    {
                        errors.Append("");
                    }
                }
            }*/
            if (Email != "" && char.IsLetter(Email, 0) == true)
            {
                tempMail = $"{tbEmail.Text}@firma.ru";
            }
            else
            {
                errors.AppendLine("Некорректно указан email адрес\n");
            }
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
            }
            else
            {
                using (StreamWriter sw = new StreamWriter(@"E:\employee.txt", true))
                {
                    sw.Write("ID: \t");
                    sw.Write($"{tbID.Text}\t");
                    sw.Write($"{tbSurName.Text}\t");
                    sw.Write($"{tbName.Text}\t");
                    sw.Write($"{tbPatro.Text}\t");
                    sw.Write($"{tbPassport1.Text} {tbPassport2.Text}\t");
                    sw.Write($"{tempMail}\t");
                    sw.WriteLine($"{ComTel.SelectedItem}{tbNumber.Text}\t");
                    asd = true;
                }

                if (asd == true)
                {
                    MessageBox.Show("Данные записаны в файл");
                }
                else { MessageBox.Show("Данные не записаны в файл изза неопределенной ошибки"); }
            }

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            tbID.Clear();
            tbSurName.Clear();
            tbName.Clear();
            tbPatro.Clear();
            tbEmail.Clear();
            tbPassport1.Clear();
            tbPassport2.Clear();
            ComTel.SelectedIndex = 0;
            tbNumber.Clear();
        }
        public int n = 0;
        private void TbSurNameTextChanged(object sender, TextChangedEventArgs e)
        {
            n++;
            if (n == 1)
            {
                tbSurName.Text = tbSurName.Text[0].ToString().ToUpper();
            }
            else
            {
                tbSurName.SelectionStart = tbSurName.Text.Length;
            }
            if (tbSurName.Text.Length == 0)
            {
                n = 0;
            }
        }
        public int p = 0;
        private void TbName_TextChanged(object sender, TextChangedEventArgs e)
        {
            p++;
            if (p == 1)
            {
                tbName.Text = tbName.Text[0].ToString().ToUpper();
            }
            else
            {
                tbName.SelectionStart = tbName.Text.Length;
            }
            if (tbName.Text.Length == 0)
            {
                p = 0;
            }
        }
        public int t = 0;
        private void TbPatro_TextChanged(object sender, TextChangedEventArgs e)
        {
            t++;
            if (t == 1)
            {
                tbPatro.Text = tbPatro.Text[0].ToString().ToUpper();
            }
            else
            {
                tbPatro.SelectionStart = tbPatro.Text.Length;
            }
            if (tbPatro.Text.Length == 0)
            {
                t = 0;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}