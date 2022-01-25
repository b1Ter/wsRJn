using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для AccessoryPage.xaml
    /// </summary>
    public partial class AccessoryPage : Page
    {
        bdWorldYachtsEntities context = new bdWorldYachtsEntities();
        GridLengthConverter gridLengthConverter = new GridLengthConverter();
        public AccessoryPage()
        {
            InitializeComponent();
            dataGrid.ItemsSource = context.Accessory.ToList();
            gridPrice.Visibility = Visibility.Collapsed;
            rowPrice.Height = new GridLength(0);

            //pricePanel.Visibility = Visibility.Hidden;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.usedFrame.Navigate(new MenuPage());
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Accessory user = new Accessory();
            context.Accessory.Add(user);
            FrameManager.usedFrame.Navigate(new EditAccessoryPage(context, user));
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Accessory accessory = dataGrid.SelectedItem as Accessory;
            if (accessory == null)
            {
                MessageBox.Show("Аксессуар не выбран!");
                return;
            }
            FrameManager.usedFrame.Navigate(new EditAccessoryPage(context, accessory));
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem == null)
            {
                MessageBox.Show("Аксессуар не выбран!");
                return;
            }
            Accessory accessory = dataGrid.SelectedItem as Accessory;
            context.Accessory.Remove(accessory);
            context.SaveChanges();
            MessageBox.Show("Аксессуар успешно удалён.");
            dataGrid.UpdateLayout();
        }

        private void btnChangeSingle_Click(object sender, RoutedEventArgs e)
        {
            Accessory accessory = dataGrid.SelectedItem as Accessory;
            double oldPrice = Convert.ToDouble(accessory.Price);
            if (accessory == null)
            {
                MessageBox.Show("Аксессуар не выбран!");
                return;
            }
            if (rbInc.IsChecked == true)
            {
                accessory.Price += Convert.ToDouble(accessory.Price) * Convert.ToDouble(txtEditedPrice.Text);
                MessageBox.Show("Цена на аксессуар повысилась на " + (accessory.Price - oldPrice));
            }
            else
            {
                accessory.Price -= Convert.ToDouble(accessory.Price) * Convert.ToDouble(txtEditedPrice.Text);
                MessageBox.Show("Цена на аксессуар уменьшилась на " + (oldPrice - accessory.Price));
            }
            context.SaveChanges();
            dataGrid.UpdateLayout();
            FrameManager.usedFrame.UpdateLayout();
        }

        private void btnEditPrices_Click(object sender, RoutedEventArgs e)
        {
            gridPrice.Visibility = Visibility.Visible;
            rowPrice.Height = new GridLength(80);
        }

        private void btnChangeAll_Click(object sender, RoutedEventArgs e)
        {
            var accessoties = context.Accessory.ToList();
            if (rbInc.IsChecked == true)
            {
                foreach (var x in accessoties)
                {
                    x.Price += Convert.ToDouble(x.Price) * Convert.ToDouble(txtEditedPrice.Text);
                    MessageBox.Show("Цены аксессуаров повысились на " + txtEditedPrice.Text);
                }
            }
            else
            {
                foreach (var x in accessoties)
                {
                    x.Price -= Convert.ToDouble(x.Price) * Convert.ToDouble(txtEditedPrice.Text);
                    MessageBox.Show("Цены аксессуаров понизились на " + txtEditedPrice.Text);
                }
            }
            context.SaveChanges();
            dataGrid.UpdateLayout();
            FrameManager.usedFrame.UpdateLayout();
        }

        private void btnHide_Click(object sender, RoutedEventArgs e)
        {
            gridPrice.Visibility = Visibility.Collapsed;
            rowPrice.Height = new GridLength(0);
        }

        bool checkChar(char c)
        {
            if (c >= '0' && c <= '9')
                return true;
            if (c == ',')
                return true;
            return false;
        }

        private void txtEditedPrice_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !e.Text.All(checkChar);
        }
    }
}
