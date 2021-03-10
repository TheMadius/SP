using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFLK_lab_1_
{
    static public class Automat
    {
        private enum Q
        {
            q0, q1, q2, q3, q4, q5, q6, q7, q8
        }

        static private bool chechStart(int pos, string str)
        {
            string patern = " \t\n";
            if (pos == 0)
                return true;
            else if (patern.IndexOf(str[pos - 1]) != -1)
                return true;
            return false;
        }

        static private bool chechEnd(int pos, string str)
        {
            string patern = " \t,;.?!:\n";
            if (pos == str.Length - 1)
                return true;

            else if (patern.IndexOf(str[pos + 1]) != -1)
                return true;
            return false;
        }
        static private bool chechWord(char sim)
        {
            if ((sim >= 'a' && sim <= 'z') || (sim >= 'A' && sim <= 'Z') || (sim >= '0' && sim <= '9') || (sim == '_'))
                return true;
            return false;

        }

        static private bool chechDom(ref int pos, string str,ref string word)
        {
            string[] domens = new string[] { "com","ru","org", "de","net","uk","cn","info","nl","eu"};

            foreach (var item in domens)
            {
                string temp = str.Substring(pos, item.Length);
                if (item == temp)
                {
                    word += item;
                    pos += item.Length - 1;
                    return true;
                }
            }

            return false;
        }
            static public string checkString(string str)
        {
            string log = string.Empty;
            string word = string.Empty;
            string state = string.Empty;
            string res = string.Empty;

            Q stat = Q.q0;

            for (int i = 0; i < str.Length; ++i)
            {
                switch (stat)
                {
                    case Q.q0:
                        {
                            state += "q0 ";
                            if (chechStart(i, str))
                            {
                                stat = Q.q1;
                                i--;
                            }
                            else
                            {
                                word += str[i];
                                res = "false";
                                log += word + " " + state + res + '\n';
                                stat = Q.q0;
                                word = string.Empty;
                                state = string.Empty;
                            }
                            break;
                        }
                    case Q.q1:
                        {
                            word += str[i];
                            state += "q1 ";
                            if (chechWord(str[i]))
                                stat = Q.q2;
                            else
                            {
                                res = "false";
                                log += word + " " + state + res + '\n';
                                stat = Q.q0;
                                word = string.Empty;
                                state = string.Empty;
                            }
                            break;
                        }
                    case Q.q2:
                        {
                            word += str[i];
                            state += "q2 ";

                            if (chechWord(str[i]) || str[i] == '-')
                                stat = Q.q2;
                            else if(str[i] == '.')
                                stat = Q.q3;
                            else if (str[i] == '@')
                                stat = Q.q4;
                            else
                            {
                                res = "false";
                                log += word + " " + state + res + '\n';
                                stat = Q.q0;
                                word = string.Empty;
                                state = string.Empty;
                            }
                            break;
                        }
                    case Q.q3:
                        {
                            word += str[i];
                            state += "q3 ";
                            if (chechWord(str[i]))
                                stat = Q.q2;
                            else
                            {
                                res = "false";
                                log += word + " " + state + res + '\n';
                                stat = Q.q0;
                                word = string.Empty;
                                state = string.Empty;
                            }
                            break;
                        }
                    case Q.q4:
                        {
                            word += str[i];
                            state += "q4 ";
                            if (chechWord(str[i]))
                                stat = Q.q5;
                            else
                            {
                                res = "false";
                                log += word + " " + state + res + '\n';
                                stat = Q.q0;
                                word = string.Empty;
                                state = string.Empty;
                            }
                            break;
                        }
                    case Q.q5:
                        {
                            word += str[i];
                            state += "q5 ";

                            if (chechWord(str[i]) || str[i] == '-')
                                stat = Q.q5;
                            else if (str[i] == '.')
                                stat = Q.q6;
                            else
                            {
                                res = "false";
                                log += word + " " + state + res + '\n';
                                stat = Q.q0;
                                word = string.Empty;
                                state = string.Empty;
                            }
                            break;
                        }
                    case Q.q6:
                        {
                            state += "q6 ";

                            if (chechDom(ref i, str, ref word))
                            {
                                --i;
                                stat = Q.q7;
                            }
                            else if (chechWord(str[i]))
                            {
                                word += str[i];
                                stat = Q.q5;
                            }
                            else
                            {
                                word += str[i];
                                res = "false";
                                log += word + " " + state + res + '\n';
                                stat = Q.q0;
                                word = string.Empty;
                                state = string.Empty;
                            }
                            break;
                        }
                    case Q.q7:
                        {
                            state += "q0 ";
                            if (chechEnd(i, str))
                            {
                                stat = Q.q8;
                            }
                            else if (str[i] == '.')
                            {
                                word += str[i];
                                stat = Q.q6;
                            }
                            else
                            {
                                res = "false";
                                log += word + " " + state + res + '\n';
                                stat = Q.q0;
                                word = string.Empty;
                                state = string.Empty;
                            }
                            break;
                        }
                    case Q.q8:
                        {
                            state += "q8 ";
                            res = "true";
                            log += word + " " + state + res+'\n';
                            stat = Q.q0;
                            word = string.Empty;
                            state = string.Empty;
                            break;
                        }
                }
            }
            return log;
        }

    }
}
