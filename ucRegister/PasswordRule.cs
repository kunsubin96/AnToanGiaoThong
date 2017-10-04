using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ucRegister
{
    public class PasswordRule
    {
        const int MIN_LEN = 5;
        const int MAX_LEN = 15;


        bool ishaslenRequire = false;
        bool ishaslowerChar = false;
        bool ishasupperChar = false;
        bool isdemicalDigit = false;

        public PasswordRule()
        {

        }
        public bool IsPassword(string password, ref string reason)
        {

            if (password==null)
            {
                reason="Password không được bỏ trống";
                throw new ArgumentNullException();
            }

            ishaslenRequire=password.Length>=MIN_LEN&&password.Length<=MAX_LEN ? true : false;

            if (ishaslenRequire)
            {
                foreach (char c in password)
                {
                    if (char.IsUpper(c)) ishasupperChar=true;
                    else if (char.IsLower(c)) ishaslowerChar=true;
                    else if (char.IsDigit(c)) isdemicalDigit=true;

                }
            }

            if (ishaslenRequire==false)
            {
                reason="Từ 5-15 kí tự";
            }
            else if (ishaslowerChar==false)
            {
                reason="Có ít nhất 1 kí tự thường";
            }
            else if (ishasupperChar==false)
            {
                reason="Có ít nhất 1 kí tự hoa";
            }
            else if (isdemicalDigit==false)
            {
                reason="Có ít nhất 1 kí tự số";
            }


            return ishaslenRequire&&ishasupperChar&&ishasupperChar&&ishasupperChar;
        }
    }//end class
}
