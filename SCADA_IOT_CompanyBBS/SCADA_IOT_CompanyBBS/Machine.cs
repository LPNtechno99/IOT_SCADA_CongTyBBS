using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SCADA_IOT_CompanyBBS
{
    public class Machine : INotifyPropertyChanged
    {
        private static Machine _instance = null;
        public static Machine Instance()
        {
            if (_instance == null)
                _instance = new Machine();
            return _instance;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public enum MachineDoorStatus
        {
           OPEN, CLOSE
        }
        public enum Machine3State
        {
           NONE, RUNNING, STOPPING, FAILING
        }

        private MachineDoorStatus _doorstatus = MachineDoorStatus.OPEN;
        public MachineDoorStatus DoorState
        {
            get { return _doorstatus; }
            set
            {
                _doorstatus = value;
                OnPropertyChanged("DoorState");
            }
        }

        private Machine3State _machinestate = Machine3State.NONE;
        public Machine3State MachineState
        {
            get { return _machinestate; }
            set
            {
                _machinestate = value;
                OnPropertyChanged("MachineState");
            }
        }

        public enum ListMachine
        {
            MACHINE01,
            MACHINE02,
            MACHINE03,
            MACHINE04,
            MACHINE05,
            MACHINE06,
            MACHINE07,
            MACHINE08,
            MACHINE09,
            MACHINE10,
            MACHINE11,
            MACHINE12,
            MACHINE13,
            MACHINE14,
        }
        private static ListMachine _nameMachine;
        public static ListMachine NameMachine
        {
            get { return _nameMachine; }
            set
            {
                _nameMachine = value;
            }
        }
    }
}
