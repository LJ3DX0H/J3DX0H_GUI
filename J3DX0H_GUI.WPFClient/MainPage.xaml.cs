using J3DX0H_GUI.WPFClient.AlbumView;
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

namespace J3DX0H_GUI.WPFClient
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void NavigatePage1(object sender, MouseButtonEventArgs e)
        {
            //Page page1 = new AlbumPage();
            
            NavigationService.Navigate(new Uri("AlbumPage", UriKind.Relative));
        }

        private void NavigatePage2(object sender, MouseButtonEventArgs e)
        {

        }

        private void NavigatePage3(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
