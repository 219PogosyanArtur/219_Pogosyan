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

namespace _219_Pogosyan.Pages
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
        private void ButtonMouseEnter(object sender, MouseEventArgs e)
        {
            //popup1.IsOpen = true;
     
        }
        private void TextBoxLogin_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtHintLogin.Visibility = Visibility.Visible;
            if (TextBoxLogin.Text.Length > 0)
            {
                txtHintLogin.Visibility = Visibility.Hidden;
            }
        }
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            txtHintPassword.Visibility = Visibility.Visible;
            if (PasswordBox.Password.Length > 0)
            {
                txtHintPassword.Visibility = Visibility.Hidden;
            }
        }
        private void ButtonEnter_OnClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TextBoxLogin.Text) || string.IsNullOrEmpty(PasswordBox.Password))
            {
                
                MessageBox.Show("Введите логин или пароль!");
                return;
            }
            using (var db = new Entities())
            {
                var user = db.User .AsNoTracking() .FirstOrDefault( u => u.Login == TextBoxLogin.Text && u.Password == PasswordBox.Password);
                if (user == null)
                {
                    MessageBox.Show("Пользователь с такими данными не найден!");
                    return;
                }
                MessageBox.Show("Пользователь успешно найден!");

                switch (user.Role)
                {
                    case "Ученик":
                        NavigationService?.Navigate(new Student());
                            break;
                    case "Учитель":
                        NavigationService?.Navigate(new Teacher());
                        break;
                    case "Библиотекарь":
                        NavigationService?.Navigate(new Lybrarian());
                            break;
                }
            }
        }
    }
}

