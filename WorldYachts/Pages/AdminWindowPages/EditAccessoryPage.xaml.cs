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
    /// Логика взаимодействия для EditAccessoryPage.xaml
    /// </summary>
    public partial class EditAccessoryPage : Page
    {
        bdWorldYachtsEntities context;
        public EditAccessoryPage(bdWorldYachtsEntities context, Accessory user)
        {
            InitializeComponent();
            this.context = context;
            this.DataContext = user;
            cmbPartner.ItemsSource = context.Partner.ToList();
            if (user.Partner_ID != null)
            {
                cmbPartner.SelectedItem = user.Partner;
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            context.Accessory.ToList();
            context.SaveChanges();
            FrameManager.usedFrame.Navigate(new AccessoryPage());
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.usedFrame.Navigate(new MenuPage());
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !e.Text.All(checkChar);
        }
        bool checkChar(char c)
        {
            if (c >= '0' && c <= '9')
                return true;
            if (c == ',')
                return true;
            if (c == '-')
                return true;
            return false;
        }
    }
}
