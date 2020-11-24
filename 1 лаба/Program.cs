using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаба1
{
    public class Logic 
    {
        public static string GetVariantWordRuble(int a)
        {
            string s = null;
            if (a < 9)
            {
                switch (a)
                {
                    case 1:
                        s = " рубль ";
                        break;
                    case 2:
                    case 3:
                    case 4:
                        s = " рубля ";
                        break;
                    case 5:
                    case 6:
                    case 7:
                    case 8:
                    case 9:
                    case 0:
                        s = " рублей ";
                        break;
                }
            }
            else if ((14 < a) & (a < 11))
            {
                s = " рублей ";
            }
            else
            { 
                switch (a % 10)
                {
                    case 1:
                        s = " рубль ";
                        break;
                    case 2:
                    case 3:
                    case 4:
                        s = " рубля ";
                        break;
                    case 5:
                    case 6:
                    case 7:
                    case 8:
                    case 9:
                    case 0:
                        s = " рублей ";
                        break;
                }
            }
            return s;
        }
        public static string GetVariantWordKopek(int a)
        {
            string s = null;
            if (a < 9)
            {
                switch (a % 10)
                {
                    case 1:
                        s = " копейка ";
                        break;
                    case 2:
                    case 3:
                    case 4:
                        s = " копейки ";
                        break;
                    case 5:
                    case 6:
                    case 7:
                    case 8:
                    case 9:
                    case 0:
                        s = " копеек ";
                        break;
                }
            }
            else if ((14 < a) & (a < 11))
            {
                s = " копеек ";
            }
            else
            {
                switch (a % 10)
                {
                    case 1:
                        s = " копейка ";
                        break;
                    case 2:
                    case 3:
                    case 4:
                        s = " копейки ";
                        break;
                    case 5:
                    case 6:
                    case 7:
                    case 8:
                    case 9:
                    case 0:
                        s = " копеек ";
                        break;
                }
            }
            return s;
        }
        public static string GetRezult(int n)
        { 
            int ruble = n / 100;
            int kopek = n % 100;
            string result;
            string WorldRuble;
            string WorldKopek;
            if (ruble == 0)
            {
                WorldKopek = GetVariantWordKopek(kopek);
                result = kopek + WorldKopek;
            }
            else if (kopek == 0)
            {
                WorldRuble = GetVariantWordRuble(ruble);
                result = ruble + WorldRuble + "ровно";
            }
            else
            {
                WorldRuble = GetVariantWordRuble(ruble);
                WorldKopek = GetVariantWordKopek(kopek);
                result = ruble + WorldRuble + kopek + WorldKopek;
            }
            return result;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите стоимость товара в копейках:");
            int n;
            while (!(Int32.TryParse(Console.ReadLine(), out n)) || (n < 1) || (n > 9999))  /* цикл на проверку корректности ввода,подходит если число и 1≤n≤9999*/
            {
                Console.WriteLine("Некорректный ввод.Введите стоимость не меньше 1 и не больше 9999");
            }
            string output= Logic.GetRezult(n);
            Console.WriteLine("Стоимость товара в рублях и копейках:"+ output);
            Console.ReadLine();
        }
    }
}

