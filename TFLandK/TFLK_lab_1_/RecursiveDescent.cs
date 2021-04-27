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
        private void A()
        {
            this.log += " A";
            if (nowIndex >= str.Length)
            {
                this.log += " ε";
                return ;
            }
            if (str[this.nowIndex] == '+')
            {
                this.log += " +";
                nowIndex++;
                T();
                A();
                return ;
            }
            else if (str[this.nowIndex] == '-')
            {
                this.log += " -";
                nowIndex++;
                T();
                A();
                return;
            }
            this.log += " ε";
            return ;
        }
        private void T()
        {
            this.log += " T";
            O();
            B();
        }
        private void O()
        {
            this.log += " O";
            if (nowIndex >= str.Length)
            {
                this.log += " Error(ε)";
                return;
            }
            if (num())
                return;
            else if (id())
                return;
            else if (str[this.nowIndex] == '(')
            {
                this.log += " (";
                nowIndex++;
                E();
                if (nowIndex >= str.Length)
                {
                    this.log += " Error(ε)";
                    return ;
                }
                if (str[this.nowIndex] == ')')
                {
                    this.log += " )";
                    nowIndex++;
                    return;
                }
                else
                {
                    this.log += " Error(')')";
                    return;
                }
            }
            else
            {
                this.log += " Error(ε)";
                return;
            }
        }
        private void B()
        {
            this.log += " B";
            if (nowIndex >= str.Length)
            {
                this.log += " ε";
                return ;
            }
            if (str[this.nowIndex] == '*')
            {
                this.log += " *";
                nowIndex++;
                O();
                B();
                return ;

            }
            else if (str[this.nowIndex] == '/')
            {
                this.log += " /";
                nowIndex++;
                O();
                B();
                return;
            }
            this.log += " ε";
            return ;
        }
        private bool num()
        {
            if (nowIndex >= str.Length)
            {
                return false;
            }
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
            if (nowIndex >= str.Length)
            {
                return false;
            }
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
        private void E()
        {
            this.log += " E";
            T();
            A();
            if (nowIndex >= str.Length)
            {
                return;
            }
        }
        private void LA()
        {
            this.log += " LA";
            int oldPos = this.nowIndex;
            E();
            if (nowIndex >= str.Length)
            {
                this.log += " Error(;)";
                return;
            }

            if (str[this.nowIndex] == ';')
            {
                this.log += " ;";
                nowIndex++;
            }
            else
                this.log += " Error(;)";

            if (nowIndex >= str.Length)
            {
                return;
            }

            if (oldPos == nowIndex)
                nowIndex++;

            if (nowIndex < str.Length)
            {
                this.log += "&";
                LA();
            }
        }

        public void isRelate()
        {
            this.log = "";    
            LA();
        }
    }
}
