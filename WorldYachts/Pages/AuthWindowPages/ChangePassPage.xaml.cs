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
    /// Логика взаимодействия для ChangePassPage.xaml
    /// </summary>
    public partial class ChangePassPage : Page
    {
        AppUser user;
        bdWorldYachtsEntities context = new bdWorldYachtsEntities();
        public ChangePassPage(AppUser user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            if (txtPassNow.Password == user.Password)
            {
                if (txtPassNew.Password == txtRepeatedPass.Password)
                {
                    if (txtPassNow.Password != txtPassNew.Password)
                    {
                        user.Password = txtPassNew.Password;
                        context.SaveChanges();
                        AdminWindow window = new AdminWindow();
                        window.Activate();
                        window.Show();
                        Application.Current.MainWindow.Hide();
                    }
                    else
                        MessageBox.Show("Текущий пароль и новый не должны совпадать!");
                }
                else
                    setWarningText("Введённые новые пароли не совпадают.");
            }
            else setWarningText("Текущий пароль не совпадает с логином.");
        }
        public void setWarningText(string warning)
        {
            txtWarning.Text = warning;
        }
    }
}
