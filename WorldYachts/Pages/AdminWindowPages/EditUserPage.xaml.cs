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

namespace WorldYachts.Pages.AdminWindowPages
{
    /// <summary>
    /// Логика взаимодействия для EditUserPage.xaml
    /// </summary>
    public partial class EditUserPage : Page
    {
        bdWorldYachtsEntities context;
        public EditUserPage(bdWorldYachtsEntities context, AppUser user)
        {
            InitializeComponent();
            this.context = context;
            this.DataContext = user;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            context.SaveChanges();
            FrameManager.usedFrame.Navigate(new UserPage());
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.usedFrame.Navigate(new UserPage());
        }
    }
}
