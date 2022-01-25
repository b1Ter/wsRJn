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
    /// Логика взаимодействия для AddUserPage.xaml
    /// </summary>
    public partial class AddUserPage : Page
    {
        bdWorldYachtsEntities context = new bdWorldYachtsEntities();
        public AppUser user;
        public AddUserPage()
        {
            InitializeComponent();
            AppUser user = new AppUser();
            this.user = user;
            this.DataContext = user;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.usedFrame.GoBack();
        }

        private void btnRegNewUser_Click(object sender, RoutedEventArgs e)
        {
            var dublicated = (from x in context.AppUser
                             where x.Login == user.Login
                             select x).Count();
            if (dublicated > 0)
            {
                setWarningText("Такой пользователь уже существует.");
                UpdateLayout();
                return;
            }
            if (txtPass.Password != txtRepeatedPass.Password)
            {
                setWarningText("Введённые пароли не совпадают.");
                UpdateLayout();
                return;
            }
            user.DateLastVisit = DateTime.Now.Date;
            user.Password = txtPass.Password;
            user.IsBlocked = false;
            context.AppUser.Add(user);
            context.SaveChanges();

            AdminWindow window = new AdminWindow();
            window.Activate();
        }
        public void setWarningText(string warning)
        {
            MessageBox.Show(warning);
        }
    }
}
