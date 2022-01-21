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

namespace WorldYachts.Pages.AuthWindow
{
    /// <summary>
    /// Логика взаимодействия для EnterPage.xaml
    /// </summary>
    public partial class EnterPage : Page
    {
        bdWorldYachtsEntities context = new bdWorldYachtsEntities();

        public string warnintText;
        public int countMistakes = 0;
        public int timeToBlick = 15;
        public EnterPage()
        {
            InitializeComponent();
            txtWarning.Text = warnintText;
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            AppUser user = checkLoginPassword(txtLogin.Text, txtPass.Password);
            if (countMistakes < 3)
            {
                if (user != null)
                {
                    if (checkPasswordDate(user))
                    {
                        AdminWindow window = new AdminWindow(user);
                        window.Activate();
                    }
                }
                else countMistakes++;
            }
            else blockEnter();
        }

        private void btnNewUser_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.usedFrame.Navigate(new AddUserPage());
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
            if ((user.DateLastVisit.Date - DateTime.Now.Date).Days >= 14)
            {
                goToChangePassword(user);
                return false;
            }
            if ((user.DateLastVisit.Date - DateTime.Now.Date).Days >= 31)
            {
                warnintText = "Ваша учётная запись заблокирована ввиду отсутствия посещений в течение месяца. Для продолжения работы попросите администратора открыть доступ к ней.";
                return false;
            }
            return true;
        }
        void goToChangePassword(AppUser user)
        {
            FrameManager.usedFrame.Navigate(new ChangePassPage(user));
        }
        
        void blockEnter()
        {
            warnintText = "Вы совершили слишком много ошибок. Вход заблокирован на " + timeToBlick + " секунд";
        }
    }
}
