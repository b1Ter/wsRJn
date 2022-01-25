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
    /// Логика взаимодействия для CategoriesPage.xaml
    /// </summary>
    public partial class CategoriesPage : Page
    {
        bdWorldYachtsEntities context = new bdWorldYachtsEntities();
        List<Category> categories = new List<Category>();

        public CategoriesPage()
        {
            InitializeComponent();
            getCategories();
            setCategoryAtFrame();
            
        }
        public void getCategories()
        {
            foreach (Category x in context.Category.ToList())
            {
                categories.Add(x);
            }
        }
        public List<Subcategory> getSubcategory(Category category)
        {
            List<Subcategory> subcategories = new List<Subcategory>();

            foreach (Subcategory x in context.Subcategory.ToList())
            {
                if (x.Category == category)
                {
                    subcategories.Add(x);
                }
            }

            return subcategories;
        }
        public void setCategoryAtFrame()
        {
            foreach (var x in categories)
            {
                StackPanel panel = new StackPanel();
                panel.Orientation = Orientation.Vertical;
                BrushConverter brush = new BrushConverter();

                TextBlock categoryBlock = new TextBlock();
                categoryBlock.Text = x.Name;
                categoryBlock.FontSize = 28;
                panel.Children.Add(categoryBlock);

                List<Subcategory> subcategories = new List<Subcategory>();
                subcategories = getSubcategory(x);
                foreach (var s in subcategories)
                {
                    TextBlock subcategoryBlock = new TextBlock();
                    subcategoryBlock.Text = s.Name;
                    subcategoryBlock.FontSize = 25;
                    subcategoryBlock.Margin = new Thickness(6,0,0,0);
                    subcategoryBlock.MouseDown += subcategory_PreviewMouseDown;
                    panel.Children.Add(subcategoryBlock);
                }

                Line line = new Line();
                line.Fill = Brushes.Black;
                panel.Children.Add(line);

                contentPanel.Children.Add(panel);
            }
        }
        private void subcategory_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock txt = (TextBlock)sender;
            Subcategory sub = context.Subcategory.Where(x => x.Name == txt.Text).First();
            ForumManager.rightFrame.Navigate(new ThemesPage(sub));
        }
    }
}
