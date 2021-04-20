using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFLK_lab_1_
{
    public class RecursiveDescent
    {
        string str;
        int nowIndex;
        string log;

        public string Log { get => log; }

        public RecursiveDescent()
        {
            this.nowIndex = 0;
            this.str = "";
            this.log = "";
        }

        public void setString(string str)
        {
            this.nowIndex = 0;
            this.str = str;
            this.log = "";
        }
        private bool A()
        {
            this.log += " A";
            if (nowIndex >= str.Length)
            {
                this.log += " ε";
                return true;
            }
            if (str[this.nowIndex] == '+')
            {
                this.log += " +";
                nowIndex++;
                if (nowIndex >= str.Length)
                {
                    this.log += " Error";
                    return false;
                }
                if (!T())
                    return false;
                if (!A())
                    return false;
                return true;
            }
            else if (str[this.nowIndex] == '-')
            {
                this.log += " -";
                nowIndex++;
                if (nowIndex >= str.Length)
                {
                    this.log += " Error";
                    return false;
                }
                if (!T())
                    return false;
                if (!A())
                    return false;
                return true;
            }
            this.log += " ε";
            return true;
        }
        private bool T()
        {
            this.log += " T";
            if (!O())
                return false;
            if (!B())
                return false;
            return true;
        }
        private bool O()
        {
            this.log += " O";
            if (num())
                return true;
            else if (id())
                return true;
            else if (str[this.nowIndex] == '(')
            {
                this.log += " (";
                nowIndex++;
                if (nowIndex >= str.Length)
                {
                    this.log += " Error";
                    return false;
                }
                E();
                if (str[this.nowIndex] == ')')
                {
                    this.log += " )";
                    return true;
                }
                else
                {
                    this.log += " Error";
                    return false;
                }
            }
            else
            {
                this.log += " Error";
                return false;
            }
        }
        private bool B()
        {
            this.log += " B";
            if (nowIndex >= str.Length)
            {
                this.log += " ε";
                return true;
            }
            if (str[this.nowIndex] == '*')
            {
                this.log += " *";
                nowIndex++;
                if (nowIndex >= str.Length)
                {
                    this.log += " Error";
                    return false;
                }
                if (!O())
                    return false;
                if (!B())
                    return false;
                return true;

            }
            else if (str[this.nowIndex] == '/')
            {
                this.log += " /";
                nowIndex++;
                if (nowIndex >= str.Length)
                {
                    this.log += " Error";
                    return false;
                }
                if (!O())
                    return false;
                if (!B())
                    return false;
                return true;
            }
            this.log += " ε";
            return true;
        }
        private bool num()
        {
            if (IsDigit(str[this.nowIndex]))
            {
                this.log += " num";
                while (IsDigit(str[this.nowIndex]))
                {
                    nowIndex++;
                    if (nowIndex >= str.Length)
                    {
                        return true;
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool id()
        {
            if (isChar(str[this.nowIndex]))
            {
                this.log += " id";
                while (IsDigit(str[this.nowIndex]) || isChar(str[this.nowIndex]))
                {
                    nowIndex++;
                    if (nowIndex >= str.Length)
                    {
                        return true;
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool isChar(char ch)
        {
            return char.IsLetter(ch);
        }
        private bool IsDigit(char ch)
        {
            return char.IsDigit(ch);
        }
        private bool E()
        {
            this.log += " E";

            if (!T())
                return false;
            if (!A())
                return false;
            return true;
        }
        private bool LA()
        {
            this.log += " LA";

            if (!E())
                return false;
            if (nowIndex >= str.Length)
            {
                this.log += " Error";
                return false;
            }
            if (str[this.nowIndex] == ';')
            {
                this.log += " ;";
                return true;
            }
            else
            {
                this.log += " Error";
                return false;
            }
        }

        public bool isRelate()
        {
            this.log = "";            
            return LA();
        }
    }
}
