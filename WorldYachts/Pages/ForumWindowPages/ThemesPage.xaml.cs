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

namespace WorldYachts.Pages.ForumWindowPages
{
    /// <summary>
    /// Логика взаимодействия для ThemesPage.xaml
    /// </summary>
    public partial class ThemesPage : Page
    {
        bdWorldYachtsEntities context = new bdWorldYachtsEntities();
        List<Theme> themes = new List<Theme>();
        public ThemesPage(Subcategory subcategory)
        {
            InitializeComponent();
            getThemes(subcategory);
            setThemes();
        }
        void getThemes(Subcategory subcategory)
        {
            foreach (Theme x in context.Theme.ToList())
                if (x.Subcategory_ID == subcategory.Subcategory_ID)
                    themes.Add(x);
        }
        Line getLine()
        {
            Line line = new Line();
            line.Fill = Brushes.Black;
            return line;
        }
        void setThemes()
        {
            foreach (var x in themes)
            {
                StackPanel panel = new StackPanel();
                panel.Orientation = Orientation.Vertical;
                panel.Background = new SolidColorBrush(Color.FromRgb(0, 159, 218));
                panel.Margin = new Thickness(20,10,10,10);

                TextBlock themeName = new TextBlock();
                themeName.Text = x.Name;
                themeName.Style = (Style)Application.Current.FindResource("txtSecondHeader");
                themeName.MouseDown += subcategory_PreviewMouseDown;
                panel.Children.Add(themeName);

                TextBlock themeDescription = new TextBlock();
                themeDescription.Style = (Style)Application.Current.FindResource("txtSimple");
                themeDescription.Text = x.Description;
                themeDescription.MouseDown += subcategory_PreviewMouseDown;
                panel.Children.Add(themeDescription);

                StackPanel infoPanel = new StackPanel();
                infoPanel.Orientation = Orientation.Horizontal;
                infoPanel.HorizontalAlignment = HorizontalAlignment.Right;
                panel.Children.Add(infoPanel);

                TextBlock nameBlock = new TextBlock();
                nameBlock.Text = ((AppUser)context.AppUser.Where(y => y.User_ID == x.User_ID).First()).Login.ToString();
                infoPanel.Children.Add(nameBlock);

                TextBlock dateBlock = new TextBlock();
                dateBlock.Text = x.Date.ToString();
                infoPanel.Children.Add(dateBlock);

                panel.Children.Add(getLine());

                panelThemes.Children.Add(panel);
            }
            panelThemes.UpdateLayout();
        }
        private void subcategory_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock txt = (TextBlock)sender;
            Theme sub = context.Theme.Where(x => x.Name == txt.Text).First();
            ForumManager.rightFrame.Navigate(new MessagePage(sub));
        }
    }
}
