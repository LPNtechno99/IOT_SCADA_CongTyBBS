using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCADA_IOT_CompanyBBS
{
    public class CaLamViec : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private static CaLamViec _instance = null;
        public static CaLamViec Instance()
        {
            if(_instance==null)
            {
                _instance = new CaLamViec();
            }
            return _instance;
        }

        public const string _ca1 = "CA 1";
        public const string _ca2 = "CA 2";
        public const string _ca3 = "CA 3";

        public enum Ca { CA1, CA2, CA3 }

        private Ca _cahientai;
        public string CaHienTai
        {
            get
            {
                switch (_cahientai)
                {
                    case Ca.CA1:
                        return _ca1;
                    case Ca.CA2:
                        return _ca2;
                    case Ca.CA3:
                        return _ca3;
                    default:
                        return null;
                }
            }
            set
            {
                if (value == _ca1)
                    _cahientai = Ca.CA1;
                if (value == _ca2)
                    _cahientai = Ca.CA2;
                if (value == _ca3)
                    _cahientai = Ca.CA3;
                OnPropertyChanged("CaHienTai");
            }
        }
        private TimeSpan _thoigianCa1;
        public TimeSpan ThoiGianCa1
        {
            get { return _thoigianCa1; }
            set
            {
                _thoigianCa1 = value;
            }
        }
        private TimeSpan _thoigianCa2;
        public TimeSpan ThoiGianCa2
        {
            get { return _thoigianCa2; }
            set
            {
                _thoigianCa2 = value;
            }
        }
        private TimeSpan _thoigianCa3;
        public TimeSpan ThoiGianCa3
        {
            get { return _thoigianCa3; }
            set
            {
                _thoigianCa3 = value;
            }
        }
    }
}
