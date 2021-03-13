using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console1303Dz
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = 1;

            string[] name = new string[width];
            string[] job = new string[width];

            bool exit = false;

            while (exit == false)
            {
                Console.WriteLine("1)Добавить досье \n2)Вывести все досье \n3)Удалить досье \n4)Поиск по имени \n5)Выход");
                int answer = int.Parse(Console.ReadLine());
                Console.WriteLine();

                switch (answer)
                {
                    case 1:
                        Console.Write("Имя: ");
                        name[name.Length - 1] = Console.ReadLine();
                        Console.Write("Должность: ");
                        job[job.Length - 1] = Console.ReadLine();

                        Dossier(ref width, ref name, ref job);
                        break;
                    case 2:
                        AllDossier(ref name, ref job);
                        break;
                    case 3:
                        int indexDel = int.Parse(Console.ReadLine());
                        indexDel -= 1;

                        Delete(indexDel, ref width, ref name, ref job);
                        break;
                    case 4:
                        string searchName = Console.ReadLine();

                        Search(searchName, ref name, ref job);
                        break;
                    case 5:
                        Exit(out exit);
                        break;
                }
            }
        }

        public static void Dossier(ref int width, ref string[] name, ref string[] job)
        {
            string[] tempName = new string[width];
            string[] tempJob = new string[width];

            for (int i = 0; i < name.Length; i++)
            {
                tempName[i] = name[i];
                tempJob[i] = job[i];
            }

            width++;
            name = new string[width];
            job = new string[width];

            for (int i = 0; i < tempName.Length; i++)
            {
                name[i] = tempName[i];
                job[i] = tempJob[i];
            }

            Console.WriteLine();
        }

        public static void AllDossier(ref string[] name, ref string[] job)
        {
            for (int i = 0; i < name.Length - 1; i++)
            {
                Console.WriteLine($"{i + 1}){name[i]} - {job[i]}");
            }

            Console.WriteLine();
        }

        public static void Delete(int indexDel, ref int width, ref string[] name, ref string[] job)
        {
            for (int i = 0; i < name.Length - 1; i++)
            {
                if (i == indexDel)
                {
                    name[i] = null;
                    job[i] = null;
                }
                if (i > indexDel)
                {
                    string tempName2 = name[i];
                    string tempJob2 = job[i];

                    name[i - 1] = tempName2;
                    job[i - 1] = tempJob2;
                }
            }

            string[] tempName = new string[width];
            string[] tempJob = new string[width];

            for (int i = 0; i < name.Length; i++)
            {
                tempName[i] = name[i];
                tempJob[i] = job[i];
            }

            width--;
            name = new string[width];
            job = new string[width];

            for (int i = 0; i < name.Length; i++)
            {
                name[i] = tempName[i];
                job[i] = tempJob[i];
            }

            Console.WriteLine();
        }

        public static void Search(string searchName, ref string[] name, ref string[] job)
        {
            for (int i = 0; i < name.Length - 1; i++)
            {
                if (searchName == name[i])
                {
                    Console.WriteLine($"{i + 1}){name[i]} - {job[i]}");
                }
            }

            Console.WriteLine();
        }

        public static void Exit(out bool exit)
        {
            exit = true;
        }
    }
}
