using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFLK_lab_1_
{
    public enum Lexemes { NUM , ID, PARENT, SIGN , ERROR};

    public struct InfoLExems
    {
        public int posStart;
        public Lexemes lexemes;
        public string name;

        public InfoLExems(int pos , Lexemes lexemes, string name)
        {
            this.lexemes = lexemes;
            this.name = name;
            this.posStart = pos;
        }
    }
    
    public class Scaner
    {
        static List<InfoLExems> listINfo;

        private static List<InfoLExems> ListINfo { get => listINfo; set => listINfo = value; }


        static private bool chechWord(char sim)
        {
            if ((sim >= 'a' && sim <= 'z') || (sim >= 'A' && sim <= 'Z'))
                return true;
            return false;

        }
        static private bool chechNum(char sim)
        {
            if (sim >= '0' && sim <= '9')
                return true;
            return false;

        }

        public static List<InfoLExems> findLexems(string str)
        {
            listINfo = new List<InfoLExems>();
            for (int i = 0; i < str.Length; ++i)
            {
                if (chechWord(str[i]))
                {
                    int pos = i;
                    string st = "";
                    while (chechWord(str[i]) || chechNum(str[i]))
                    {
                        st += str[i];
                        if (i + 1>= str.Length)
                            break;
                        i++;
                    }
                    if (!(i + 1 >= str.Length))
                        i--;
                    listINfo.Add(new InfoLExems(pos, Lexemes.ID, st));
                    continue;

                } else
                if (str[i] == '-' || str[i] == '*' || str[i] == '+' || str[i] == '/')
                {
                    string st = "" + str[i];
                    listINfo.Add(new InfoLExems(i, Lexemes.SIGN, st));

                } else
                if (str[i] == ')' || str[i] == '(')
                {
                    string st = "" + str[i];
                    listINfo.Add(new InfoLExems(i, Lexemes.PARENT, st));
                } else
                if (chechNum(str[i])) 
                {
                    int pos = i;
                    string st = "";
                    bool flag = false;

                    while (chechNum(str[i]))
                    {
                        st += str[i];
                        if (i + 1 >= str.Length)
                        {
                            listINfo.Add(new InfoLExems(pos, Lexemes.NUM, st));
                            return listINfo;
                        }
                        i++;
                    }

                    while ((chechWord(str[i]) || chechNum(str[i])))
                    {
                        flag = true;
                        st += str[i];
                        if (i + 1 >= str.Length)
                        {
                            listINfo.Add(new InfoLExems(pos, Lexemes.ERROR, st));
                            return listINfo;
                        }
                        i++;
                    }

                    if (!(i + 1 >= str.Length))
                        i--;

                    if (flag)
                        listINfo.Add(new InfoLExems(pos, Lexemes.ERROR, st));
                    else
                        listINfo.Add(new InfoLExems(pos, Lexemes.NUM, st));


                    continue;
                } else if (str[i] == ' ')
                {
                    continue;
                }
                else
                {
                    string st = "" + str[i];
                    listINfo.Add(new InfoLExems(i, Lexemes.ERROR, st));
                }
            }

            return listINfo;
        }

    }

}
