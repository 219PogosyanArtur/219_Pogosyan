using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void Reg_TextBoxFIO_TextChanged(object sender, TextChangedEventArgs e)
        {
            Reg_txtHintFIO.Visibility = Visibility.Visible;
            if (Reg_TextBoxFIO.Text.Length > 0)
            {
                Reg_txtHintFIO.Visibility = Visibility.Hidden;
            }
        }

        private void Reg_TextBoxLogin_TextChanged(object sender, TextChangedEventArgs e)
        {
            Reg_txtHintLogin.Visibility = Visibility.Visible;
            if (Reg_TextBoxLogin.Text.Length > 0)
            {
                Reg_txtHintLogin.Visibility = Visibility.Hidden;
            }
        }

        private void Reg_PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            Reg_txtHintPassword.Visibility = Visibility.Visible;
            if (Reg_PasswordBox.Password.Length > 0)
            {
                Reg_txtHintPassword.Visibility = Visibility.Hidden;
            }
        }

        private void Reg_RepeatPasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            Reg_txtHintRepeatPassword.Visibility = Visibility.Visible;
            if (Reg_RepeatPasswordBox.Password.Length > 0)
            {
                Reg_txtHintRepeatPassword.Visibility = Visibility.Hidden;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page());
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Auth(Reg_TextBoxLogin.Text, Reg_PasswordBox.Password);
        }

        public bool Auth(string login, string password)
        {
            int test = 0;
            if (string.IsNullOrEmpty(Reg_TextBoxFIO.Text) || string.IsNullOrEmpty(Reg_TextBoxLogin.Text) || string.IsNullOrEmpty(Reg_PasswordBox.Password) || string.IsNullOrEmpty(Reg_RepeatPasswordBox.Password) || string.IsNullOrEmpty(CmbRole.Text))
            {
                MessageBox.Show("Пусто");
                test++;
            }

            using (var db = new TRPOLIBRARYEntities1())
            {
                var user = db.User.AsNoTracking().FirstOrDefault(u => u.Login == Reg_TextBoxLogin.Text);

                if (user != null)
                {
                    MessageBox.Show("Такой пользователь уже существует");
                    test++;
                    return false;
                }
            }

            if (Reg_PasswordBox.Password.Length >= 6)
            {
                bool en = true; // английская раскладка
                bool symbol = false; // символ
                bool number = false; // цифра

                for (int i = 0; i < Reg_PasswordBox.Password.Length; i++) // перебираем символы
                {
                    if (Reg_PasswordBox.Password[i] >= 'А' && Reg_PasswordBox.Password[i] <= 'Я') en = false; // если русская раскладка
                    if (Reg_PasswordBox.Password[i] >= '0' && Reg_PasswordBox.Password[i] <= '9') number = true; // если цифры
                    if (Reg_PasswordBox.Password[i] == '_' || Reg_PasswordBox.Password[i] == '-' || Reg_PasswordBox.Password[i] == '!') symbol = true; // если символ
                }

                if (!en)
                {
                    MessageBox.Show("Доступна только английская раскладка"); // выводим сообщение
                    test++;
                }
                else if (!symbol)
                {
                    MessageBox.Show("Добавьте один из следующих символов: _ - !"); // выводим сообщение
                    test++;
                }
                else if (!number)
                {
                    MessageBox.Show("Добавьте хотя бы одну цифру"); // выводим сообщение
                    test++;
                }
                if (en && symbol && number) // проверяем соответствие
                {
                    if (Reg_PasswordBox.Password == Reg_RepeatPasswordBox.Password) // проверка на совпадение паролей
                    {
                        TRPOLIBRARYEntities1 db = new TRPOLIBRARYEntities1();
                        User userObject = new User
                        {
                            Login = Reg_TextBoxLogin.Text,
                            Password = hashirovanie.GetHash(Reg_PasswordBox.Password),
                            Role = CmbRole.Text
                        };
                        db.User.Add(userObject);
                        db.SaveChanges();
                        MessageBox.Show("Пользователь зарегистрирован");
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Пароли не совпадают");
                    }
                }
            }
            else
            {
                MessageBox.Show("Пароль слишком короткий, минимум 6 символов");
                test++;

            }
            return false;
        }
    }
}
