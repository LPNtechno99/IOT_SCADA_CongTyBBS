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

namespace SCADA_IOT_CompanyBBS
{
    /// <summary>
    /// Interaction logic for wdChonCa.xaml
    /// </summary>
    public partial class wdChonCa : Window
    {

        public wdChonCa()
        {
            InitializeComponent();
        }

        private void EventF1Push(object sender, ExecutedRoutedEventArgs e)
        {
            
        }

        private void EventF2Push(object sender, ExecutedRoutedEventArgs e)
        {
           
        }

        private void EventF3Push(object sender, ExecutedRoutedEventArgs e)
        {
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (var db = new DbScadaContext())
            {
                var calamviec = db.CacCaLamViec.ToList();

                lblFrom1.Content = calamviec[0].Ca1From;
                lblTo1.Content = calamviec[0].Ca1To;
                //tính tổng thời gian của ca 1
                CaLamViec.Instance().ThoiGianCa1 = Convert.ToDateTime(lblTo1.Content).Subtract(Convert.ToDateTime(lblFrom1.Content));
                lblTongThoiGianCa1.Content = CaLamViec.Instance().ThoiGianCa1.ToString();

                lblFrom2.Content = calamviec[0].Ca2From;
                lblTo2.Content = calamviec[0].Ca2To;
                //tính tổng thời gian của ca 2
                CaLamViec.Instance().ThoiGianCa2 = Convert.ToDateTime(lblTo2.Content).Subtract(Convert.ToDateTime(lblFrom2.Content));
                lblTongThoiGianCa2.Content = CaLamViec.Instance().ThoiGianCa2.ToString();

                lblFrom3.Content = calamviec[0].Ca3From;
                lblTo3.Content = calamviec[0].Ca3To;
                //Tính tổng thời gian của ca 3
                TimeSpan ts1 = Convert.ToDateTime("23:59").Subtract(Convert.ToDateTime(lblFrom3.Content)).Add(new TimeSpan(0, 1, 0));
                TimeSpan ts2 = Convert.ToDateTime(lblTo3.Content).Subtract(Convert.ToDateTime("00:00"));
                CaLamViec.Instance().ThoiGianCa3 = ts1 + ts2;
                lblTongThoiGianCa3.Content = CaLamViec.Instance().ThoiGianCa3.ToString();
            }
            string date = DateTime.Now.ToString("HH:mm");

            int result1 = DateTime.Compare(Convert.ToDateTime(date), Convert.ToDateTime(lblFrom1.Content));
            int result2 = DateTime.Compare(Convert.ToDateTime(date), Convert.ToDateTime(lblTo1.Content));

            int result3 = DateTime.Compare(Convert.ToDateTime(date), Convert.ToDateTime(lblFrom2.Content));
            int result4 = DateTime.Compare(Convert.ToDateTime(date), Convert.ToDateTime(lblTo2.Content));

            int result5 = DateTime.Compare(Convert.ToDateTime(date), Convert.ToDateTime(lblFrom3.Content));
            int result6 = DateTime.Compare(Convert.ToDateTime(date), Convert.ToDateTime(lblTo3.Content));

            if (result1 == 1 && result2 == -1)
            {
                CaLamViec.Instance().CaHienTai = "CA 1";
                lblCa1.Background = new SolidColorBrush(Color.FromRgb(132, 185, 103));
            }
            if(result3 == 1 && result4 == -1)
            {
                CaLamViec.Instance().CaHienTai = "CA 2";
                lblCa2.Background = new SolidColorBrush(Color.FromRgb(132, 185, 103));
            }
            if (result5 == 1 && result6 == -1)
            {
                CaLamViec.Instance().CaHienTai = "CA 3";
                lblCa3.Background = new SolidColorBrush(Color.FromRgb(132, 185, 103));
            }
        }

        private void EventEscPush(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }

        private void EventENTERPush(object sender, ExecutedRoutedEventArgs e)
        {
            SCADA wd = new SCADA();
            wd.Show();
        }
    }
}
