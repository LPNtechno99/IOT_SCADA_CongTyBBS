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
using System.Windows.Shapes;
using MaterialDesignThemes.Wpf;
using SCADA_IOT_CompanyBBS.ViewModel;

namespace SCADA_IOT_CompanyBBS
{
    /// <summary>
    /// Interaction logic for SCADA02.xaml
    /// </summary>
    public partial class SCADA02 : Window
    {
        public SCADA02()
        {
            InitializeComponent();

            var menuMachine1 = new List<SubItem>();
            var menuMachine2 = new List<SubItem>();
            for (int i = 1; i < 8; i++)
            {
                menuMachine1.Add(new SubItem("MACHINE " + i, i));
            }
            var item1 = new ItemMenu("", menuMachine1, PackIconKind.ViewList);
            Menu1.Children.Add(new UserControlMenuItem(item1));

            for (int i = 8; i < 15; i++)
            {
                menuMachine2.Add(new SubItem("MACHINE " + i, i));
            }
            var item2 = new ItemMenu("", menuMachine2, PackIconKind.ViewList);
            Menu2.Children.Add(new UserControlMenuItem(item2));
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TbtnChange_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void TbtnChange_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void TbtnChange_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
