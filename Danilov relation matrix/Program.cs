using System;

namespace Бикташев
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matr = new int[16];
            Console.WriteLine("Данилов Роман Игоревич 2");
            Console.WriteLine("---------------------------------------------");

            Console.WriteLine("Введите: '1' если использовать матрицу 2 Вариант " +
                     "Введите: '2' если хотите ввести собственную матрицу 4х4");
            int kl = Convert.ToInt32(Console.ReadLine());
            int g = 0;
            switch (kl)
            {
                case 1:
                    matr = new int[16] { 0, 1, 1, 0, 1, 0, 1, 0, 1, 1, 1, 0, 0, 0, 0, 1 };
                    break;
                case 2:
                    Console.WriteLine("Введите ваши отношения");
                    for (int gg = 1; gg < 5; gg++)
                    {
                        for (int ggg = 1; ggg < 5; ggg++)
                        {
                            Console.WriteLine($"({gg},{ggg}) = ");
                            matr[g] = Convert.ToInt32(Console.ReadLine());
                            g++;
                        }
                    }
                    break;
                default:
                    matr = new int[16] { 0, 1, 1, 0, 1, 0, 1, 0, 1, 1, 1, 0, 0, 0, 0, 1 };
                    Console.WriteLine("Недопустимое значение, испоользуется матрица Вариант 2");
                    break;
            }

            //рефлексивность
            bool refleksivn = false;
            if (matr[0] == 1 && matr[5] == 1 && matr[10] == 1 && matr[15] == 1)
            {
                refleksivn = true;
                Console.WriteLine("1)  Рефлексивное отношение");
            }
            else Console.WriteLine("1)  Не рефлексивное отношение");

            //антирефлексивность
            bool antirefleksivn = false;
            if (matr[0] == 0 && matr[5] == 0 && matr[10] == 0 && matr[15] == 0)
            {
                antirefleksivn = true;
                Console.WriteLine("2)  Антиефлексивное отношение");
            }
            else Console.WriteLine("2)  Не антирефлексивное отношение");

            //симметричное
            bool simmetrichnost = false;
            if (matr[1] == matr[4] && matr[2] == matr[8] && matr[6] == matr[9] &&
                matr[3] == matr[12] && matr[13] == matr[7] && matr[14] == matr[11])
            {
                simmetrichnost = true;
                Console.WriteLine("3)  Симметричное отношение");
            }
            else Console.WriteLine("3)  Не симметричное отношение");

            //антисимметричность
            bool antisimmetrichnost = false;
            if (matr[1] != matr[4] && matr[2] != matr[8] && matr[6] != matr[9] &&
                matr[3] != matr[12] && matr[13] != matr[7] && matr[14] != matr[11])
            {
                antisimmetrichnost = true;
                Console.WriteLine("4)  Антисимметричное отношение");
            }
            else Console.WriteLine("4)  Не антисимметричное отношение");



            int[,] masmatr = new int[4, 4]
                {
                 {matr[0],matr[2], matr[2], matr[3]},
                 {matr[4],matr[5], matr[6], matr[7]},
                 {matr[8],matr[9], matr[10], matr[11]},
                 {matr[12],matr[13], matr[14], matr[15]}
                };

            //транзитивность
            //антитранзитивность
            int antitranzit = 0;
            bool tranzitivnot = true;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (masmatr[i, j] == 1 && i != j)
                    {
                        for (int k = 0; k < 4; k++)
                        {
                            if (k != i && k != j)
                            {
                                if (masmatr[j, k] == 1)
                                {
                                    if (masmatr[i, k] == 0) { tranzitivnot = false; break; }
                                    else antitranzit++;
                                }
                            }
                        }
                    }
                    if (tranzitivnot == false)
                    {
                        break;
                    }
                }
            }
            if (tranzitivnot == true) Console.WriteLine("5)  Транзитивное отношение ");
            else Console.WriteLine("5)  Не Транзитивное отношение ");

            if (antitranzit == 0) Console.WriteLine("6)  Антитранзитивное отношение");
            else Console.WriteLine("6)  Не антитранзитивное отношение");


            //эквивалентность
            if (refleksivn == true && simmetrichnost == true && tranzitivnot == true)
                Console.WriteLine("7)  Отношение эквивалентности");
            else Console.WriteLine("7)  Отношение не эквивалентно");
            // частичный порядок
            if (refleksivn == true && antisimmetrichnost == true && tranzitivnot == true)
                Console.WriteLine("8)  Отношение частичного порядка");
            else Console.WriteLine("8)  Отношение не является отношением частичного порядка");
            // отношение строго порядка
            if (antirefleksivn == true && antisimmetrichnost == true && tranzitivnot == true)
                Console.WriteLine("9)  Отношение строгого порядка");
            else Console.WriteLine("9)  Отношение не является отношением строгого порядка");
            Console.WriteLine();

            Console.WriteLine("Введите: '1' если использовать ту же матрицу" +
                                 "введите: '2' если хотиет использовать новую матрицу");
            int N = Convert.ToInt32(Console.ReadLine());
            int[,] twomas = new int[4, 4];
            switch (N)
            {
                case 1:
                    twomas = masmatr;
                    break;
                case 2:
                    for (int i = 0; i < 4; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            Console.Write("mas[" + i + "," + j + "]: ");
                            twomas[i, j] = int.Parse(Console.ReadLine());
                        }
                    }

                    break;
                default:
                    Console.WriteLine("Недопустимое значение, используется основная матрица");
                    twomas = masmatr;
                    break;
            }
            Console.WriteLine(new string('-', 50));
            Console.WriteLine();
            int[,] otvet = new int[4, 4];

            //сложение
            for (int r = 0; r < 4; r++)
            {
                for (int rr = 0; rr < 4; rr++)
                {
                    if (Convert.ToInt32(masmatr[r, rr]) + Convert.ToInt32(twomas[r, rr]) > 1) otvet[r, rr] = 1;
                    else otvet[r, rr] = 0;
                }
            }

            Console.WriteLine("Сложение матриц. Ответ:");
            for (int ot = 0; ot < 4; ot++)
            {
                for (int otv = 0; otv < 4; otv++) Console.Write($"{otvet[ot, otv]} ");
                Console.WriteLine();
            }

            //умножение
            int[,] otvetumn = new int[4, 4];

            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    for (int k = 0; k < 4; k++)
                        otvetumn[i, j] += masmatr[i, k] * twomas[k, j];

            Console.WriteLine("\nУмножение матриц. Ответ:");
            for (int ott = 0; ott < 4; ott++)
            {
                for (int ottv = 0; ottv < 4; ottv++)
                {
                    if (otvetumn[ott, ottv] > 1) Console.Write($"1 ");
                    else Console.Write($"{otvetumn[ott, ottv]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Данилов Роман");

        }
    }
}
