using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task5.TO_INT_OR_NOT_TO_INT
{
    public static class Program
    {
        public static bool IsNum(this string str)
        {
            if (str == null)
            {
                throw new ArgumentException("Null string!!!");
            }

            int indexE = 0;
            int point = 0;
            str = str.ToLower();
            str = str.Trim();
            char[] intPart;
            char[] floatPart;
            char[] mantiss;
            char znak = 'z';
            if (str[0] == '-')
            {
                return false;
            }
            else if (str[0] == '+' && !char.IsDigit(str[1]))
            {
                return false;
            }

            point = str.IndexOf('.');
            if (point != str.LastIndexOf('.'))
            {
                return false;
            }
                    
            if ((point > -1) && (!char.IsDigit(str[point - 1]) || !char.IsDigit(str[point + 1])))
            {
                return false;
            }

            indexE = str.IndexOf('e');
            if (indexE > 0)
            {
                mantiss = str.ToCharArray(indexE + 1, str.Length - indexE - 1);
            }
            else
            {
                mantiss = null;
                indexE = 0;
            }

            if (point < 0)
            {
                intPart = str.ToCharArray(0, str.Length - indexE - 1);
                point = 0;
            }
            else
            {
                intPart = str.ToCharArray(0, point);
            }

            if (point > 0)
            {
                floatPart = str.ToCharArray(point + 1, str.Length - indexE - point - 1);
            }
            else
            {
                floatPart = null;
                point = 0;
            }
            
            if (intPart[0] == '+')
            {
                intPart[0] = '0';
            }
            
            for (int i = 0; i < intPart.Length; i++)
            {
                if (!char.IsDigit(intPart[i]))
                {
                    return false;
                }
            }

            if (floatPart != null)
            {
                for (int i = 0; i < floatPart.Length; i++)
                {
                    if (!char.IsDigit(floatPart[i]))
                    {
                        return false;
                    }
                }
            }

            if (mantiss[0] == '-')
            {
                znak = '-';
            }
            else if (mantiss[0] == '+' || char.IsDigit(mantiss[0]))
            {
                znak = '+';
            }

            if (mantiss != null)
            {
                if (mantiss[0] == '+' || mantiss[0] == '-')
                {
                   mantiss[0] = '0';
                }

                for (int i = 0; i < mantiss.Length; i++)
                {
                    if (!char.IsDigit(mantiss[i]))
                    {
                        return false;
                    }
                }
            }

            int lenInt = 0;
            int lenFl = 0;
            if (floatPart != null)
            {
                lenFl = floatPart.Length;
            }

            if (intPart != null)
            {
                lenInt = intPart.Length;
            }

            if ((znak == '-') && (mantiss[0] < lenFl + lenInt))
            {
                return false;
            }

            return true;
            }

        public static void Main(string[] args)
        {
            string s = "1e-2";
            bool t = s.IsNum();
            Console.WriteLine(t);
        }
    }
}
