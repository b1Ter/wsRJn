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
    /// Логика взаимодействия для UserPage.xaml
    /// </summary>
    public partial class UserPage : Page
    {
        bdWorldYachtsEntities context = new bdWorldYachtsEntities();
        public UserPage()
        {
            InitializeComponent();
            dataGrid.ItemsSource = context.AppUser.ToList();
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AppUser user = new AppUser();
            context.AppUser.Add(user);
            FrameManager.usedFrame.Navigate(new EditUserPage(context, user));
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem == null)
            {
                MessageBox.Show("Пользователь не выбран!");
                return;
            }
            AppUser user = dataGrid.SelectedItem as AppUser;
            FrameManager.usedFrame.Navigate(new EditUserPage(context, user));            
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem == null)
            {
                MessageBox.Show("Пользователь не выбран!");
                return;
            }
            AppUser user = dataGrid.SelectedItem as AppUser;
            context.AppUser.Remove(user);
            context.SaveChanges();
            dataGrid.UpdateLayout();
            MessageBox.Show("Пользователь успешно удалён");
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.usedFrame.Navigate(new MenuPage());
        }
    }
}
