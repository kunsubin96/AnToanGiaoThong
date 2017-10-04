using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnToanGiaoThong.Classes
{
    public class CauHoiModel
    {
        int _MaCauHoi;
        string _NoiDungCauHoi;
        string _NoiDungDapAn_A;
        string _NoiDungDapAn_B;
        string _NoiDungDapAn_C;
        string _NoiDungDapAn_D;
        string _DapAnDung;

        public int MaCauHoi
        {
            get
            {
                return _MaCauHoi;
            }

            set
            {
                _MaCauHoi=value;
            }
        }

        public string NoiDungCauHoi
        {
            get
            {
                return _NoiDungCauHoi;
            }

            set
            {
                _NoiDungCauHoi=value;
            }
        }

        public string NoiDungDapAn_A
        {
            get
            {
                return _NoiDungDapAn_A;
            }

            set
            {
                _NoiDungDapAn_A=value;
            }
        }

        public string NoiDungDapAn_B
        {
            get
            {
                return _NoiDungDapAn_B;
            }

            set
            {
                _NoiDungDapAn_B=value;
            }
        }

        public string NoiDungDapAn_C
        {
            get
            {
                return _NoiDungDapAn_C;
            }

            set
            {
                _NoiDungDapAn_C=value;
            }
        }

        public string NoiDungDapAn_D
        {
            get
            {
                return _NoiDungDapAn_D;
            }

            set
            {
                _NoiDungDapAn_D=value;
            }
        }

        public string DapAnDung
        {
            get
            {
                return _DapAnDung;
            }

            set
            {
                _DapAnDung=value;
            }
        }

        public CauHoiModel()
        {

        }
        
    }//end class
}
