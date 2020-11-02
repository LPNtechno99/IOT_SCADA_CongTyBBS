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
        Machine _Machine01;
        Machine _Machine02;

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

            DataContext = MachineCollection;

            //m_threadLayDuLieu = new Thread(RequestStatusMachine);
            //m_threadLayDuLieu.Start();
            //m_threadLayDuLieu.IsBackground = true;

            //timer blink
            timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 0, 0, 10);
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

        private void OnGetRequestData12(string raw_data)
        {
            var value = AdvantechHttpWebUtility.ParserJsonToObj<ObjectMappingJSON>(raw_data);
            if (value.DIVal[0].Val == 1)
            {
                _Machine01.MachineState = Machine.Machine3State.RUNNING;
            }
            else if (value.DIVal[1].Val == 1)
            {
                _Machine01.MachineState = Machine.Machine3State.STOPPING;
            }
            else if (value.DIVal[2].Val == 1)
            {
                _Machine01.MachineState = Machine.Machine3State.FAILING;
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

        private void Viewbox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Machines.wdMachineDetail wdDetail = new Machines.wdMachineDetail();
            wdDetail.Show();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            var x = sender as CheckBox;
            switch (x.Name)
            {
                case "chbGreen":
                    MachineCollection[0].MachineState = Machine.Machine3State.RUNNING;
                    MachineCollection[0].DoorState = Machine.MachineDoorStatus.CLOSE;
                    lblWarning.BeginStoryboard(FindResource("FlashMe") as Storyboard);
                    break;
                case "chbYellow":
                    MachineCollection[0].MachineState = Machine.Machine3State.STOPPING;
                    break;
                case "chbRed":
                    MachineCollection[0].MachineState = Machine.Machine3State.FAILING;
                    break;
                default:
                    break;
            }
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            var x = sender as CheckBox;
            switch (x.Name)
            {
                case "chbGreen":
                    MachineCollection[0].MachineState = Machine.Machine3State.STOPPING;
                    MachineCollection[0].DoorState = Machine.MachineDoorStatus.OPEN;

                    break;
                case "chbYellow":
                    MachineCollection[0].MachineState = Machine.Machine3State.STOPPING;
                    break;
                case "chbRed":
                    MachineCollection[0].MachineState = Machine.Machine3State.STOPPING;
                    break;
                default:
                    break;
            }
        }
    }
}
