using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace SCADA_IOT_CompanyBBS
{
    /// <summary>
    /// Interaction logic for wdMachineDetail.xaml
    /// </summary>
    public partial class wdMachineDetail : Window
    {
        
        public wdMachineDetail()
        {
            InitializeComponent();

            this.lblStatus.DataContext = SCADA._Machine01;
            this.lblStatusDoor.DataContext = SCADA._Machine02;
        }
        TimeSpan timeSpan1;
        TimeSpan timeSpan2;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lblMachineName.Content = Machine.NameMachine;
            lblCaHienTai1.Content = CaLamViec.Instance().CaHienTai;
            lblCaHienTai2.Content = CaLamViec.Instance().CaHienTai;
            switch (Machine.NameMachine)
            {
                case Machine.ListMachine.MACHINE01:
                    using (var db = new DbScadaContext())
                    {
                        var thoigianchaymay01 = db.ThoiGianChayMay01.ToList();
                        dgThoiGianChay.ItemsSource = thoigianchaymay01;
                        
                        if (thoigianchaymay01[0].PeriodTime != null)
                        {
                            timeSpan1 = TimeSpan.Parse(thoigianchaymay01[0].PeriodTime);
                        }
                        else
                        {
                            timeSpan1 = timeSpan1.Subtract(TimeSpan.Parse(DateTime.Now.ToString("HH:mm:ss")));
                        }
                        for (int i = 1; i < thoigianchaymay01.Count; i++)
                        {
                            if (thoigianchaymay01[i].PeriodTime != null)
                            {
                                timeSpan1 = timeSpan1.Add(TimeSpan.Parse(thoigianchaymay01[i].PeriodTime));
                            }
                            else
                                continue;
                        }
                        lblTongThoiGianChay.Content = timeSpan1.ToString();
                        double tile1 = (timeSpan1.TotalSeconds / CaLamViec.Instance().ThoiGianCa1.TotalSeconds) * 100;
                        lblTiLe1.Content = tile1.ToString("0.000") + " %";


                        var thoigiandungmay01 = db.ThoiGianDungMay01.ToList();
                        dgThoiGianDung.ItemsSource = thoigiandungmay01;

                        if (thoigiandungmay01[0].PeriodTime != null)
                        {
                            timeSpan2 = TimeSpan.Parse(thoigiandungmay01[0].PeriodTime);
                        }
                        else
                        {
                            timeSpan2 = timeSpan2.Subtract(TimeSpan.Parse(DateTime.Now.ToString("HH:mm:ss")));
                        }
                        for (int i = 1; i < thoigiandungmay01.Count; i++)
                        {
                            if (thoigiandungmay01[i].PeriodTime != null)
                            {
                                timeSpan2 = timeSpan2.Add(TimeSpan.Parse(thoigiandungmay01[i].PeriodTime));
                            }
                            else
                                continue;
                        }
                        lblTongThoiGianDung.Content = timeSpan2.ToString();
                        double tile2 = (timeSpan2.TotalSeconds / CaLamViec.Instance().ThoiGianCa1.TotalSeconds) * 100;
                        lblTiLe2.Content = tile2.ToString("0.000") + " %";
                    }
                        break;
                case Machine.ListMachine.MACHINE02:
                    break;
                case Machine.ListMachine.MACHINE03:
                    break;
                case Machine.ListMachine.MACHINE04:
                    break;
                case Machine.ListMachine.MACHINE05:
                    break;
                case Machine.ListMachine.MACHINE06:
                    break;
                case Machine.ListMachine.MACHINE07:
                    break;
                case Machine.ListMachine.MACHINE08:
                    break;
                case Machine.ListMachine.MACHINE09:
                    break;
                case Machine.ListMachine.MACHINE10:
                    break;
                case Machine.ListMachine.MACHINE11:
                    break;
                case Machine.ListMachine.MACHINE12:
                    break;
                case Machine.ListMachine.MACHINE13:
                    break;
                case Machine.ListMachine.MACHINE14:
                    break;
                default:
                    break;
            }
        }

        private void EventEscPush(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }
    }
}
