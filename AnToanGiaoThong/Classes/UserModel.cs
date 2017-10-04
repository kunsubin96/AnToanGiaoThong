using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnToanGiaoThong.Classes
{
    public class UserModel
    {
        private string _username;
        private string _password;
        private string _hoten;
        private string _ngaysinh;
        private string _quequan;
        private byte[] _avatar;
        public UserModel()
        {

        }

        public string Username
        {
            get
            {
                return _username;
            }

            set
            {
                _username=value;
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }

            set
            {
                _password=value;
            }
        }

        public string Hoten
        {
            get
            {
                return _hoten;
            }

            set
            {
                _hoten=value;
            }
        }

        public string Ngaysinh
        {
            get
            {
                return _ngaysinh;
            }

            set
            {
                _ngaysinh=value;
            }
        }

        public string Quequan
        {
            get
            {
                return _quequan;
            }

            set
            {
                _quequan=value;
            }
        }

        public byte[] Avatar
        {
            get
            {
                return _avatar;
            }

            set
            {
                _avatar=value;
            }
        }
    }//end class
}
