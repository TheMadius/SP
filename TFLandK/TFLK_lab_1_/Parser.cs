using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFLK_lab_1_
{
    public class Parser
    {
        string str;
        int nowIndex;
        string log;

        public string Log { get => log; }

        public Parser()
        {
            this.nowIndex = 0;
            this.str = "";
            this.log = "";
        }

        private void error(int pos, string e)
        {
            log += "Ошибка!! Строка " + e + " , Позиция " + pos + "\n";
        }

        public void setString(string str)
        {
            this.nowIndex = 0;
            this.str = str;
            this.log = "";
        }

        private void state0()
        {
            if (nowIndex >= str.Length)
            {
                error(nowIndex, "Отсутствует ;");
                return;
            }

            if (str[nowIndex] == 'r')
            {
                nowIndex++;
                state1();
                return;
            }
            else
            {
                string err = "";
                int pos = this.nowIndex;
                while(str[nowIndex] != 'r' && str[nowIndex] != ';')
                {
                    err += str[nowIndex];
                    nowIndex++;
                    if (nowIndex >= str.Length)
                    {
                        error(pos, err);
                        error(nowIndex, "Отсутствует ;");
                        return;
                    }
                }
                error(pos,err);

                if (str[nowIndex] == ';')
                {
                    nowIndex++;
                    state13();
                    return;
                }

                nowIndex++;
                state1();
                return;
            }
        }
        private void state1()
        {
            if (nowIndex >= str.Length)
            {
                error(nowIndex, "Отсутствует ;");
                return;
            }
            if (str[nowIndex] == 'e')
            {
                nowIndex++;
                state2();
                return;
            }
            else
            {
                string err = "";
                int pos = this.nowIndex;
                while (str[nowIndex] != 'e' && str[nowIndex] != ';')
                {
                    err += str[nowIndex];
                    nowIndex++;
                    if (nowIndex >= str.Length)
                    {
                        error(pos, err);
                        error(nowIndex, "Отсутствует ;");
                        return;
                    }
                }
                error(pos, err);

                if (str[nowIndex] == ';')
                {
                    nowIndex++;
                    state13();
                    return;
                }

                nowIndex++;
                state2();
                return;
            }
        }
        private void state2()
        {
            if (nowIndex >= str.Length)
            {
                error(nowIndex, "Отсутствует ;");
                return;
            }
            if (str[nowIndex] == 'a')
            {
                nowIndex++;
                state3();
                return;
            }
            else
            {
                string err = "";
                int pos = this.nowIndex;
                while (str[nowIndex] != 'a' && str[nowIndex] != ';')
                {
                    err += str[nowIndex];
                    nowIndex++;
                    if (nowIndex >= str.Length)
                    {
                        error(pos, err);
                        error(nowIndex, "Отсутствует ;");
                        return;
                    }
                }

                error(pos, err);

                if (str[nowIndex] == ';')
                {
                    nowIndex++;
                    state13();
                    return;
                }
                
                nowIndex++;
                state3();
                return;
            }
        }
        private void state3()
        {
            if (nowIndex >= str.Length)
            {
                error(nowIndex, "Отсутствует ;");
                return;
            }
            if (str[nowIndex] == 'd')
            {
                nowIndex++;
                state4();
                return;
            }
            else
            {
                string err = "";
                int pos = this.nowIndex;
                while (str[nowIndex] != 'd' && str[nowIndex] != ';')
                {
                    err += str[nowIndex];
                    nowIndex++;
                    if (nowIndex >= str.Length)
                    {
                        error(pos, err);
                        error(nowIndex, "Отсутствует ;");
                        return;
                    }
                }

                error(pos, err);

                if (str[nowIndex] == ';')
                {
                    nowIndex++;
                    state13();
                    return;
                }

                nowIndex++;
                state4();
                return;
            }
        }
        private void state4()
        {
            if (nowIndex >= str.Length)
            {
                error(nowIndex, "Отсутствует ;");
                return;
            }
            if (str[nowIndex] == '(')
            {
                nowIndex++;
                state5();
                return;
            }
            else
            {
                string err = "";
                int pos = this.nowIndex;
                while (str[nowIndex] != '(' && str[nowIndex] != ';')
                {
                    err += str[nowIndex];
                    nowIndex++;
                    if (nowIndex >= str.Length)
                    {
                        error(pos, err);
                        error(nowIndex, "Отсутствует ;");
                        return;
                    }
                }

                error(pos, err);

                if (str[nowIndex] == ';')
                {
                    nowIndex++;
                    state13();
                    return;
                }

                nowIndex++;
                state5();
                return;
            }
        }
        private void state5()
        {
            if (nowIndex >= str.Length)
            {
                error(nowIndex, "Отсутствует ;");
                return;
            }
            if (str[nowIndex] == '*')
            {
                nowIndex++;
                state6();
                return;
            }
            else
            {
                string err = "";
                int pos = this.nowIndex;
                while (str[nowIndex] != '*' && str[nowIndex] != ';')
                {
                    err += str[nowIndex];
                    nowIndex++;
                    if (nowIndex >= str.Length)
                    {
                        error(pos, err);
                        error(nowIndex, "Отсутствует ;");
                        return;
                    }
                }

                error(pos, err);

                if (str[nowIndex] == ';')
                {
                    nowIndex++;
                    state13();
                    return;
                }

                nowIndex++;
                state6();
                return;
            }
        }
        private void state6()
        {
            if (nowIndex >= str.Length)
            {
                error(nowIndex, "Отсутствует ;");
                return;
            }

            if (str[nowIndex] == ',')
            {
                nowIndex++;
                state7();
                return;
            }
            else
            {
                string err = "";
                int pos = this.nowIndex;
                while (str[nowIndex] != ',' && str[nowIndex] != ';')
                {
                    err += str[nowIndex];
                    nowIndex++;
                    if (nowIndex >= str.Length)
                    {
                        error(pos, err);
                        error(nowIndex, "Отсутствует ;");
                        return;
                    }
                }

                error(pos, err);

                if (str[nowIndex] == ';')
                {
                    nowIndex++;
                    state13();
                    return;
                }
                if (str[nowIndex] == ',')
                {
                    nowIndex++;
                    state7();
                    return;
                }
            }
        }
        private void state7()
        {
            if (nowIndex >= str.Length)
            {
                error(nowIndex, "Отсутствует ;");
                return;
            }
            if (str[nowIndex] == '*')
            {
                nowIndex++;
                state9();
                return;
            }

            if (IsDigit(str[nowIndex]))
            {
                nowIndex++;
                state8();
                return;
            }

            string err = "";
            int pos = this.nowIndex;
            while (str[nowIndex] != '*' && !IsDigit(str[nowIndex]) && str[nowIndex] != ';')
            {
                err += str[nowIndex];
                nowIndex++;
                if (nowIndex >= str.Length)
                {
                    error(pos, err);
                    error(nowIndex, "Отсутствует ;");
                    return;
                }
            }

            error(pos, err);

            if (str[nowIndex] == ';')
            {
                nowIndex++;
                state13();
                return;
            }
            if (str[nowIndex] == '*')
            {
                nowIndex++;
                state9();
                return;
            }
            if (IsDigit(str[nowIndex]))
            {
                nowIndex++;
                state8();
                return;
            }
        }
        private void state8()
        {
            if (nowIndex >= str.Length)
            {
                error(nowIndex, "Отсутствует ;");
                return;
            }
            if (str[nowIndex] == ')')
            {
                nowIndex++;
                state10();
                return;
            }
            if (IsDigit(str[nowIndex]))
            {
                nowIndex++;
                state8();
                return;
            }

            string err = "";
            int pos = this.nowIndex;
            while (str[nowIndex] != ')' && !IsDigit(str[nowIndex]) && str[nowIndex] != ';')
            {
                err += str[nowIndex];
                nowIndex++;
                if (nowIndex >= str.Length)
                {
                    error(pos, err);
                    error(nowIndex, "Отсутствует ;");
                    return;
                }
            }

            error(pos, err);

            if (str[nowIndex] == ';')
            {
                nowIndex++;
                state13();
                return;
            }
            if (str[nowIndex] == ')')
            {
                nowIndex++;
                state10();
                return;
            }
            if (IsDigit(str[nowIndex]))
            {
                nowIndex++;
                state8();
                return;
            }
        }
        private void state9()
        {
            if (nowIndex >= str.Length)
            {
                error(nowIndex, "Отсутствует ;");
                return;
            }

            if (str[nowIndex] == ')')
            {
                nowIndex++;
                state10();
                return;
            }
            else
            {
                string err = "";
                int pos = this.nowIndex;
                while (str[nowIndex] != ')' && !IsDigit(str[nowIndex]) && str[nowIndex] != ';')
                {
                    err += str[nowIndex];
                    nowIndex++;
                    if (nowIndex >= str.Length)
                    {
                        error(pos, err);
                        error(nowIndex, "Отсутствует ;");
                        return;
                    }
                }

                error(pos, err);

                if (str[nowIndex] == ';')
                {
                    nowIndex++;
                    state13();
                    return;
                }
                if (str[nowIndex] == ')')
                {
                    nowIndex++;
                    state10();
                    return;
                }
            }
        }
        private void state10()
        {
            if (nowIndex >= str.Length)
            {
                error(nowIndex, "Отсутствует ;");
                return;
            }

            if (isChar(str[nowIndex]))
            {
                nowIndex++;
                state11();
                return;
            }
            else
            {
                string err = "";
                int pos = this.nowIndex;
                while (!isChar(str[nowIndex]) && str[nowIndex] != ';')
                {
                    err += str[nowIndex];
                    nowIndex++;
                    if (nowIndex >= str.Length)
                    {
                        error(pos, err);
                        error(nowIndex, "Отсутствует ;");
                        return;
                    }
                }

                error(pos, err);

                if (str[nowIndex] == ';')
                {
                    nowIndex++;
                    state13();
                    return;
                }
                if (isChar(str[nowIndex]))
                {
                    nowIndex++;
                    state11();
                    return;
                }
            }
        }
        private void state11()
        {
            if(nowIndex >= str.Length)
            {
                error(nowIndex, "Отсутствует ;");
                return;
            }

            if (isChar(str[nowIndex]) || IsDigit(str[nowIndex]))
            {
                nowIndex++;
                state11();
                return;
            }
            if (str[nowIndex] == ',')
            {
                nowIndex++;
                state10();
                return;
            }
            if (str[nowIndex] == ';')
            {
                nowIndex++;
                state13();
                return;
            }

            string err = "";
            int pos = this.nowIndex;
            while (str[nowIndex] != ',' && !(IsDigit(str[nowIndex]) || isChar(str[nowIndex])) && str[nowIndex] != ';')
            {
                err += str[nowIndex];
                nowIndex++;
                if (nowIndex >= str.Length)
                {
                    error(pos, err);
                    error(nowIndex, "Отсутствует ;");
                    return;
                }
            }

            error(pos, err);

            if (str[nowIndex] == ';')
            {
                nowIndex++;
                state13();
                return;
            }
            if (str[nowIndex] == ',')
            {
                nowIndex++;
                state10();
                return;
            }
            if (IsDigit(str[nowIndex]) || isChar(str[nowIndex]))
            {
                nowIndex++;
                state11();
                return;
            }
        }
        
        private void state13()
        {
            return;
        }
        private bool isChar(char ch)
        {
            return char.IsLetter(ch);
        }
        private bool IsDigit(char ch)
        {
            return char.IsDigit(ch);
        }
       
        public void isRelate()
        {
            this.log = "";
            state0();
        }
    }
}
