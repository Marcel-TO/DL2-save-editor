namespace Editor_View
{
    using Editor_View.Views;
    using Editor_ViewModel;
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

        private void ChangeToInfoPage(object sender, RoutedEventArgs e)
        {
            pageContent.Navigate(new InfoPage(this.DataContext));
        }

        private void ChangeToInventoryPage(object sender, RoutedEventArgs e)
        {
            pageContent.Navigate(new InventoryPage(this.DataContext));
        }
    }
}
