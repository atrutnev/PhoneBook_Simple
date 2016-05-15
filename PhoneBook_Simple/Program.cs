using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneList
{
    class Program
    {
        private static int n = 4;
        private static int m = 5;
        private static string[,] phoneList = new string[n, m];

        static void Main()
        {
            while (true)
            {
                phoneView();
                Console.WriteLine("Команды меню: ");
                Console.WriteLine("1.Создать запись\n2.Удалить запись\n3.Выход");
                Console.Write("Введите команду: ");

                string com = Console.ReadLine();

                switch (com)
                {
                    case "1":
                        phoneNew();
                        break;
                    case "2":
                        phoneDelete();
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Недопустимая команда.\n");
                        break;
                }
            }
        }

        static void phoneNew()
        {
            Console.Clear();

            Console.Write("Введите имя: ");
            string name = Console.ReadLine();
            Console.Write("Введите номер телефона: ");
            string number = Console.ReadLine();

            try
            {
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < m; j++)
                        if (phoneList[i, j] == null)
                        {
                            phoneList[i, j] = string.Format("{0} {1}", name, number);
                            Console.WriteLine("Записано!");
                            Console.WriteLine();
                            return;
                        }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        static void phoneDelete()
        {
            Console.Clear();
            Console.WriteLine("Список");

            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    if (phoneList[i, j] != null)
                    {
                        int a = 1;
                        switch (i)
                        {
                            case 0:
                                a = j + a;
                                break;
                            case 1:
                                a = a + m + j;
                                break;
                            case 2:
                                a = a + (m * 2) + j;
                                break;
                            case 3:
                                a = a + (m * 3) + j;
                                break;
                        }
                        Console.WriteLine("{0}. {1}", a, phoneList[i, j]);
                    }

            try
            {
                Console.Write("Введите номер удаляемого контакта: ");
                int index = Convert.ToInt32(Console.ReadLine()) - 1;

                int index1 = index / 4;

                switch (index)
                {
                    case 4:
                    case 8:
                    case 9:
                    case 12:
                    case 13:
                    case 14:
                    case 16:
                    case 17:
                    case 18:
                    case 19:
                        index1 = index1 - 1;
                        break;
                }

                int index2 = index;

                while (index2 > 4)
                {
                    index2 = index2 - 5;
                }

                phoneList[index1, index2] = null;
                Console.WriteLine("Удалено!");

                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        static void phoneView()
        {
            int a = 1;
            Console.WriteLine("Список контактов: ");
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    if (phoneList[i, j] != null)
                        Console.WriteLine("{0}. {1}", a++, phoneList[i, j]);

            Console.WriteLine();
        }
    }
}
