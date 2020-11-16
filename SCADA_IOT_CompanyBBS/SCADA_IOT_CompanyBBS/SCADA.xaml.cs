using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using SCADA_IOT_CompanyBBS.Models;

namespace SCADA_IOT_CompanyBBS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class SCADA : Window
    {
        private const string Account = "root";
        private const string Password = "00000000";

        AdvantechHttpWebUtility m_httpRequest12;
        //Thread m_threadLayDuLieu;
        public ObservableCollection<Machine> MachineCollection;

        public static Machine _Machine01;
        public static Machine _Machine02;

        DispatcherTimer timer;

        public SCADA()
        {
            InitializeComponent();

            m_httpRequest12 = new AdvantechHttpWebUtility();
            m_httpRequest12.RequestResponded += OnGetRequestData12;
            m_httpRequest12.RequestOccurredError += OnGetErrorRequest12;


            _Machine01 = new Machine();
            _Machine02 = new Machine();

            MachineCollection = new ObservableCollection<Machine>();
            MachineCollection.Add(_Machine01);
            MachineCollection.Add(_Machine02);

            this.lblStatus01.DataContext = _Machine01;
            this.lblStattusDoor01.DataContext = _Machine01;
            this.elpStatus01.DataContext = _Machine01;
            this.elpStatusDoor01.DataContext = _Machine01;
            this.lblMachine01.DataContext = _Machine01;

            this.lblStatus02.DataContext = _Machine02;
            this.lblStattusDoor02.DataContext = _Machine02;
            this.elpStatus02.DataContext = _Machine02;
            this.elpStatusDoor02.DataContext = _Machine02;
            this.lblMachine02.DataContext = _Machine02;

            this.lblCaLamViec.DataContext = CaLamViec.Instance();

            //Lấy id cuối cùng trong bảng ghi dữ liệu
            using (var db = new DbScadaContext())
            {

            }

            //m_threadLayDuLieu = new Thread(RequestStatusMachine);
            //m_threadLayDuLieu.Start();
            //m_threadLayDuLieu.IsBackground = true;

            //timer blink
            timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 0, 0, 1000);
            timer.Start();
        }
        private async void Asyn12()
        {
            Action myAction = () =>
            {
                m_httpRequest12.SendGETRequest(Account, Password, URL.Url_may1);
            };
            Task task = new Task(myAction);
            task.Start();
            await task;
        }
        //void RequestStatusMachine()
        //{
        //    while (true)
        //    {
        //        m_httpRequest.SendGETRequest(Account, Password, URL.Url_may1);
        //        Thread.Sleep(10);
        //    }
        //}
        private void OnGetErrorRequest12(Exception e)
        {

        }
        bool _flagChay01, _flagDung01;
        int _id1 = 1, _id2 = 1;
        private async void OnGetRequestData12(string raw_data)
        {
            var value = AdvantechHttpWebUtility.ParserJsonToObj<ObjectMappingJSON>(raw_data);

            //máy 1
            if (value.DIVal[0].Val == 1)
            {
                _Machine01.MachineState = Machine.Machine3State.RUNNING;
                if (!_flagChay01)
                {
                    using (var db = new DbScadaContext())
                    {
                        var check = db.ThoiGianDungMay01
                            .FirstOrDefault(x => x.ID == _id2);
                        if (check != null)
                        {
                            check.To = DateTime.Now.ToString("HH:mm:ss");
                            var period = Convert.ToDateTime(check.To).Subtract(Convert.ToDateTime(check.From));
                            check.PeriodTime = period.ToString();

                            await db.SaveChangesAsync();
                            _id2++;
                        }
                    }
                }
                if (!_flagChay01)
                {
                    _flagChay01 = true;
                    _flagDung01 = false;
                    using (var db = new DbScadaContext())
                    {
                        int idMax=0;
                        try
                        {
                            idMax = db.ThoiGianChayMay01
                                .Max(x => x.ID);
                        }
                        catch
                        {

                        }
                        finally
                        {
                            idMax = 0;
                        }
                        if (idMax != 0)
                        {
                            var check = db.ThoiGianChayMay01
                                .FirstOrDefault(x => x.ID == idMax);
                            if (check.To == null)
                            {
                                check.To = DateTime.Now.ToString("HH:mm:ss");
                                var period = Convert.ToDateTime(check.To).Subtract(Convert.ToDateTime(check.From));
                                check.PeriodTime = period.ToString();
                                await db.SaveChangesAsync();
                                _id1 = idMax + 1;
                            }
                        }
                        db.Add(new ThoiGianChayMay01 { Ca = CaLamViec.Instance().CaHienTai, Date = DateTime.Now.ToString("dd/MM/yyyy"), From = DateTime.Now.ToString("HH:mm:ss") });
                        await db.SaveChangesAsync();
                    }
                }
            }
            else if (value.DIVal[1].Val == 1)
            {
                _Machine01.MachineState = Machine.Machine3State.STOPPING;

                if (!_flagDung01)
                {
                    using (var db = new DbScadaContext())
                    {
                        var check = db.ThoiGianChayMay01
                            .FirstOrDefault(x => x.ID == _id1);
                        if (check != null)
                        {
                            check.To = DateTime.Now.ToString("HH:mm:ss");
                            var period = Convert.ToDateTime(check.To).Subtract(Convert.ToDateTime(check.From));
                            check.PeriodTime = period.ToString();

                            await db.SaveChangesAsync();
                            _id1++;
                        }
                    }
                }
                if (!_flagDung01)
                {
                    _flagDung01 = true;
                    _flagChay01 = false;
                    using (var db = new DbScadaContext())
                    {
                        db.Add(new ThoiGianDungMay01 { Ca = CaLamViec.Instance().CaHienTai, Date = DateTime.Now.ToString("dd/MM/yyyy"), From = DateTime.Now.ToString("HH:mm:ss"), Reason = "Dừng Máy" });
                        await db.SaveChangesAsync();
                    }
                }

            }
            else if (value.DIVal[2].Val == 1)
            {
                _Machine01.MachineState = Machine.Machine3State.FAILING;
                if (!_flagDung01)
                {
                    using (var db = new DbScadaContext())
                    {
                        var check = db.ThoiGianChayMay01
                            .FirstOrDefault(x => x.ID == _id1);
                        if (check != null)
                        {
                            check.To = DateTime.Now.ToString("HH:mm:ss");
                            var period = Convert.ToDateTime(check.To).Subtract(Convert.ToDateTime(check.From));
                            check.PeriodTime = period.ToString();

                            await db.SaveChangesAsync();
                            _id1++;
                        }
                    }
                }
                if (!_flagDung01)
                {
                    _flagDung01 = true;
                    _flagChay01 = false;
                    using (var db = new DbScadaContext())
                    {
                        db.Add(new ThoiGianDungMay01 { Ca = CaLamViec.Instance().CaHienTai, Date = DateTime.Now.ToString("dd/MM/yyyy"), From = DateTime.Now.ToString("HH:mm:ss"), Reason = "Dừng Máy" });
                        await db.SaveChangesAsync();
                    }
                }
            }
            else
            {
                _Machine01.MachineState = Machine.Machine3State.NONE;
            }
            if (value.DIVal[3].Val == 0)
            {
                _Machine01.DoorState = Machine.MachineDoorStatus.OPEN;
            }
            else
            {
                _Machine01.DoorState = Machine.MachineDoorStatus.CLOSE;
            }

            //máy 2

            if (value.DIVal[4].Val == 1)
            {
                _Machine02.MachineState = Machine.Machine3State.RUNNING;
            }
            else if (value.DIVal[5].Val == 1)
            {
                _Machine02.MachineState = Machine.Machine3State.STOPPING;
            }
            else if (value.DIVal[6].Val == 1)
            {
                _Machine02.MachineState = Machine.Machine3State.FAILING;
            }
            else
            {
                _Machine02.MachineState = Machine.Machine3State.NONE;
            }
            if (value.DIVal[7].Val == 0)
            {
                _Machine02.DoorState = Machine.MachineDoorStatus.OPEN;
            }
            else
            {
                _Machine02.DoorState = Machine.MachineDoorStatus.CLOSE;
            }
        }

        bool BlinkOn = false;
        private void Timer_Tick(object sender, EventArgs e)
        {
            //if(BlinkOn)
            // {
            //     lblWarning.Foreground = Brushes.Black;
            //     lblWarning.Background = Brushes.Yellow;
            // }
            //else
            // {
            //     lblWarning.Foreground = Brushes.Black;
            //     lblWarning.Background = Brushes.Blue;
            // }
            // BlinkOn = !BlinkOn;
            Asyn12();
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void EventEscPush(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }

        private void Viewbox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            var x = sender as Viewbox;
            switch (x.Tag.ToString())
            {
                case "1":
                    Machine.NameMachine = Machine.ListMachine.MACHINE01;
                    break;
                case "2":
                    Machine.NameMachine = Machine.ListMachine.MACHINE02;
                    break;
                case "3":
                    break;
                case "4":
                    break;
                case "5":
                    break;
                case "6":
                    break;
                case "7":
                    break;
                case "8":
                    break;
                case "9":
                    break;
                case "10":
                    break;
                case "11":
                    break;
                case "12":
                    break;
                case "13":
                    break;
                case "14":
                    break;
                default:
                    break;
            }
            wdMachineDetail wd = new wdMachineDetail();
            wd.ShowDialog();
        }

        private void WdSCADA_Loaded(object sender, RoutedEventArgs e)
        {
            lblMachine01.Content = Machine.ListMachine.MACHINE01.ToString();
            lblMachine02.Content = Machine.ListMachine.MACHINE02.ToString();

            //using (var db = new DbScadaContext())
            //{
            //    var lastId = db.ThoiGianChayMay01
            //        .Max(x => x.ID);
            //}
        }
    }
}
