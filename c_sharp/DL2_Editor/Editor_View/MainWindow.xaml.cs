namespace Editor_View
{
    using Editor_View.Views;
    using Editor_ViewModel;
    using Editor_ViewModel.Logic;
    using Microsoft.Win32;
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

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Gets the DataContext for this application.
        /// </summary>
        /// <value> The ViewModel of the chessboard as DataContext.</value>
        public MainViewModel ViewModel
        {
            get
            {
                return this.DataContext as MainViewModel;
            }
        }

        /// <summary>
        /// Occurs if the top border is pressed.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        /// <summary>
        /// Occurs if the load level button is clicked.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The arguments of the event.</param>
        private void LoadSaveFile(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();

            if (openFile.ShowDialog() == true)
            {
                string path = openFile.FileName;
                this.ViewModel.LoadFile(path);
            }
        }

        private void ChangeToPage(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is PageNameEnum enumValue)
            {
                switch (enumValue)
                {
                    case PageNameEnum.InfoPage:
                        pageContent.Navigate(new InfoPage(this.DataContext));
                        break;
                    case PageNameEnum.SkillPage:
                        pageContent.Navigate(new SkillsPage(this.DataContext));
                        break;
                    case PageNameEnum.ExperiencePage:
                        pageContent.Navigate(new ExperiencePage(this.DataContext));
                        break;
                    case PageNameEnum.InventoryPage:
                        pageContent.Navigate(new InventoryPage(this.DataContext));
                        break;
                    case PageNameEnum.BackpackPage:
                        pageContent.Navigate(new BackpackPage(this.DataContext));
                        break;
                    case PageNameEnum.CampaignPage:
                        pageContent.Navigate(new CampaignPage(this.DataContext));
                        break;
                    case PageNameEnum.PlayerPage:
                        pageContent.Navigate(new PlayerPage(this.DataContext));
                        break;
                    case PageNameEnum.IdOverviewPage:
                        pageContent.Navigate(new IdOverviewPage(this.DataContext));
                        break;
                }
                
            }
            
        }

        private void ChangeToInventoryPage(object sender, RoutedEventArgs e)
        {
            pageContent.Navigate(new InventoryPage(this.DataContext));
        }

        private void ChangeToExperiencePage(object sender, RoutedEventArgs e)
        {
            pageContent.Navigate(new ExperiencePage(this.DataContext));
        }

        private void ChangeToNormalViewSize(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
            {
                // Change the window state to Maximized
                WindowState = WindowState.Maximized;
            }
            else
            {
                // Change the window state to Normal
                WindowState = WindowState.Normal;
            }
        }
    }
}
