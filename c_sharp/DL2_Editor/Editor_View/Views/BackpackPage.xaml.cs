using Editor_ViewModel;
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

namespace Editor_View.Views
{
    /// <summary>
    /// Interaction logic for InfoPage.xaml
    /// </summary>
    public partial class BackpackPage : Page
    {
        public BackpackPage(object dataContext)
        {
            InitializeComponent();
            this.DataContext = dataContext as MainViewModel;
        }
    }
}
