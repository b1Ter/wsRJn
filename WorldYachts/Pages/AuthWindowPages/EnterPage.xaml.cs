using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace WorldYachts.Pages.AuthWindow
{
    /// <summary>
    /// Логика взаимодействия для EnterPage.xaml
    /// </summary>
    public partial class EnterPage : Page
    {
        bdWorldYachtsEntities context = new bdWorldYachtsEntities();

        DispatcherTimer timer = new DispatcherTimer();
        public int countMistakes = 0;
        public int countBlocks = 0;
        public int timeToBlick = 15;
        public int tickSeconds = 0;
        public EnterPage()
        {
            InitializeComponent();
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            AppUser user = checkLoginPassword(txtLogin.Text, txtPass.Password);
            if (user != null)
            {
                if (user.IsBlocked == false)
                {
                    if (checkPasswordDate(user))
                    {
                        user.DateLastVisit = DateTime.Now.Date;
                        context.SaveChanges();

                        AdminWindow window = new AdminWindow();
                        window.Activate();
                        window.Show();
                        Application.Current.MainWindow.Hide();
                    }
                }
                else setWarningText("Ваша учётная запись заблокирована. Обратитесь к администратору для получения доступа к ней.");
            }
            else
            {
                countMistakes++;
                setWarningText("Введённая связка логин-пароль не совпадают. Попробуйте ещё раз");
                blockEnter();
            }
        }

        private void btnNewUser_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.usedFrame.Navigate(new AddUserPage());
        }
        public void setWarningText(string warning)
        {
            MessageBox.Show(warning);
        }
        
        AppUser checkLoginPassword(string login, string password)
        {
            var user = from x in context.AppUser
                           where x.Login == login && x.Password == password
                           select x;

            if (user.Count() != 0)
            {
                return user.First();
            }

            return null;
        }
        bool checkPasswordDate(AppUser user)
        {
            TimeSpan duration = DateTime.Now.Date.Subtract(user.DateLastVisit.Date);
            if (duration.TotalDays >= 31)
            {
                setWarningText("Ваша учётная запись заблокирована ввиду отсутствия посещений в течение месяца. Для продолжения работы попросите администратора открыть доступ к ней.");
                user.IsBlocked = true;
                context.SaveChanges();
                return false;
            }
            if (duration.TotalDays >= 14)
            {
                goToChangePassword(user);
                return false;
            }
            else
                return true;
        }
        void goToChangePassword(AppUser user)
        {
            FrameManager.usedFrame.Navigate(new ChangePassPage(user));
        }
        
        void blockEnter()
        {
            if (countMistakes <= 3)
            {
                return;
            }
            timeToBlick += 20 * countBlocks;
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
            if (timeToBlick - tickSeconds <= 0)
            {
                timer.Stop();
            }
            btnEnter.IsEnabled = true;
            countMistakes--;
            countBlocks++;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            btnEnter.IsEnabled = false;
            tickSeconds++;
            int seconds = timeToBlick - tickSeconds;
            setWarningText("Вы совершили слишком много ошибок. Вход заблокирован на " + seconds + " секунд");
            if (seconds <= 0)
            {
                btnEnter.IsEnabled = true;
                setWarningText("");
                timer.Stop();
            }
        }
    }
}
