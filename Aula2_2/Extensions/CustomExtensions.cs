using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aula2_2.Extensions
{
    public static class CustomExtensions
    {
        public static bool MetodoString(this string value)
        {
            int min = 0;
            int max = value.Length - 1;
            while (true)
            {
                if (min > max)
                {
                    return true;
                }
                char a = value[min];
                char b = value[max];
                if (char.ToLower(a) != char.ToLower(b))
                {
                    return false;
                }
                min++;
                max--;
            }
        }

    }
}