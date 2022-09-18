using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Threading;

namespace _219_Pogosyan
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += TimerTick;
            timer.Start();
        }
        public void TimerTick(object sender, EventArgs e)
        {
            DataTimeNow.Text = DateTime.Now.ToString("dd MMMM yyyy HH:mm:ss");
        }
        public void Button_Click(object sender, RoutedEventArgs e)
        {
            if (MainFrame.CanGoBack) MainFrame.GoBack();
        }
        private void MainFrame_OnNavigated(object sender, NavigationEventArgs e)
        {
            if (!(e.Content is Page page))
                return;
            this.Title = $"ProjectByKvashilavaAndPogosyan - {page.Title}";

            if (page is Pages.Page1) Button_Back.Visibility = Visibility.Hidden;
            else Button_Back.Visibility = Visibility.Visible;
        }
        private void WindowsClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("Вы уверены?", "Выход", MessageBoxButton.YesNo, MessageBoxImage.Question) != MessageBoxResult.Yes)
            {
                e.Cancel = true;
            }
        }
        void Export()
        {
            string path = "export.txt";
            StreamWriter sw = new StreamWriter(path);

            using (var db = new TRPOLIBRARYEntities1())
            {
                string IDline = String.Join(":", db.User.Select(x => x.ID));
                sw.Write(":");
                sw.WriteLine(IDline);

                string Loginline = String.Join(":", db.User.Select(x => x.Login));
                sw.Write(":");
                sw.WriteLine(Loginline);

                string Passwordline = String.Join(":", db.User.Select(x => x.Password));
                sw.Write(":");
                sw.WriteLine(Passwordline);

                string Rodeline = String.Join(":", db.User.Select(x => x.Role));
                sw.Write(":");
                sw.WriteLine(Rodeline);
            }
            sw.Close();
            Process.Start("notepad.exe", path);
        }
        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            Export();
        }
        void Import()
        {
            //ghtlkj;bnm afqk lkz bvgjhnf
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            if (ofd.FileName != "") // проверка на выбор файла
            {
            }
            else MessageBox.Show("Файл для импорта не выбран!");

            //Считайте данные из файла, если он выбран:
            StreamReader sr = new StreamReader(ofd.FileName); // открываем файл
            while (!sr.EndOfStream) // перебираем строки, пока они не закончены
            {
                string[] lines = new string[5];// массив данных 
                for (int i = 0; i < 5; i++) // читаем 5 строк 
                {
                    string line = sr.ReadLine(); // читаем строку  
                    string[] data = line.Split(':');
                    line = ""; // обнуляем переменную    
                    if (data.Length >= 2) // проверяем на целостность данных  
                    {
                        for (int j = 1; j < data.Length; j++) // складываем данные      
                        {
                            line += " ";
                            line += data[j]; // собираем строку  
                        }
                    }
                    lines[i] = line; // записываем значения в массив 
                }
                // выводим данные 
                MessageBox.Show("Данные в файле: \nID: " + lines[0] + "\nФИО: " + lines[1] + "\nЛогин: " + lines[2] + "\nПароль: " + lines[3] + "\nРоль: " + lines[4]);
            }
        }
        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            Import();
        }
    }
}
