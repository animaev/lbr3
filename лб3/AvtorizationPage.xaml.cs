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
using System.Windows.Threading;

namespace лб3
{
	/// <summary>
	/// Логика взаимодействия для AvtorizationPage.xaml
	/// </summary>
	public partial class AvtorizationPage : Page
	{
		public AvtorizationPage()
		{
			InitializeComponent();
		}
        string L = "employee";
        string P = "employee";
        int counter = 0;
        DispatcherTimer timer = new DispatcherTimer();
        private void BT1_Click(object sender, RoutedEventArgs e)
        {
            if (id.Text == L && password.Password == P)
            {
                MessageBox.Show("Вход выполнен успешно");
                Manager.MainFrame.Navigate(new CreatePage());

            }
            else if (id.Text != L || password.Password != P)
            {
                counter++;
                MessageBox.Show("Неверный логин и/или пароль");
            }
            if (counter >= 3)
            {
                MessageBox.Show($"Вход заблокирован на 1 минуту, т.к вы ввели пароль неверно {counter} раз(а)");
                timer.Tick += new EventHandler(timer_Tick);
                timer.Interval = new TimeSpan(0, 0, 60);
                BT1.Visibility = Visibility.Hidden;
                timer.Start();
            }
        }
        void timer_Tick(object sender, EventArgs e)
        {
            BT1.Visibility = Visibility.Visible;
        }
        private void BT2_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
