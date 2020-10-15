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
using SCADA_IOT_CompanyBBS.ViewModel;

namespace SCADA_IOT_CompanyBBS
{
    /// <summary>
    /// Interaction logic for UserControlMenuItem.xaml
    /// </summary>
    public partial class UserControlMenuItem : UserControl
    {
        public UserControlMenuItem(ItemMenu itemMenu)
        {
            InitializeComponent();

            ExpanderMenu.Visibility = itemMenu.SubItems == null ? Visibility.Collapsed : Visibility.Visible;
            ListViewItemMenu.Visibility = itemMenu.SubItems == null ? Visibility.Visible : Visibility.Collapsed;

            this.DataContext = itemMenu;
        }

        private void ExpanderMenu_Expanded(object sender, RoutedEventArgs e)
        {
           
        }

        private void StackPanel_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            var x = sender as StackPanel;
            switch (x.Tag)
            {
                case 1:
                    MessageBox.Show("Stack 01");
                    break;
                case 2:
                    MessageBox.Show("Stack 02");
                    break;
                case 3:
                    MessageBox.Show("Stack 03");
                    break;
                case 4:
                    MessageBox.Show("Stack 04");
                    break;
                case 5:
                    MessageBox.Show("Stack 05");
                    break;
                default:
                    break;
            }
        }
    }
}
