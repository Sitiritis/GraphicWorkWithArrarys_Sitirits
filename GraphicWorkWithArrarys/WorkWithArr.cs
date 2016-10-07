using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WkWArrays
{
    class WorkWithArray // Класс для работы с массивами
    {
        protected int x, y, min_val, max_val, aver_val, maxx, maxy, minx, miny; // x и y - измерения двумерного массива; min_val, max_val, aver - минимальное, максимальное и среднее значение; maxx, maxy, minx, miny - положение максимального и минимального элемента
        protected int[,] main_twodim_arr; // Главный двумерный массив класса
        private Random rnd = new Random();

        // Обёртки для полей
        public int X
        {
            get
            {
                return x;
            }
        }

        public int Y
        {
            get
            {
                return y;
            }
        }

        public int[,] Main_twodim_arr
        {
            get
            {
                return main_twodim_arr;
            }
        }

        public int Min_val
        {
            get
            {
                return min_val;
            }
        }

        public int Max_val
        {
            get
            {
                return max_val;
            }
        }

        public int Aver_val
        {
            get
            {
                return aver_val;
            }
        }

        public int Maxx
        {
            get
            {
                return maxx;
            }
        }

        public int Maxy
        {
            get
            {
                return maxy;
            }
        }

        public int Minx
        {
            get
            {
                return minx;
            }
        }

        public int Miny
        {
            get
            {
                return miny;
            }
        }
        //Конец обёрок

        public int this[int indy, int indx] // Идексация класса, для получения значений из массива
        {
            get { return main_twodim_arr[indy, indx]; }
        }

        public WorkWithArray() // Конструктор без параметра задаст значения x и y = 10
        {
            x = 10; y = 10;
            NewArr(x, y);
        }

        public WorkWithArray(int width, int height) // Конструктор задаёт измерения для двумерного массива
        {
            x = width; y = height;
            NewArr(x, y);
        }

        public void NewArr(int width, int height) // Регенерация массива в данном экземпляре класса
        {
            x = width; y = height;
            main_twodim_arr = this.ArrGen();
            MaxVal(out max_val, out maxx, out maxy);
            MinVal(out min_val, out minx, out miny);
            aver_val = Aver();
        }

        protected int[,] ArrGen() // Генерация случаного двумерного массива для класса
        {
            int[,] randt_arr = new int[y, x];
            Random rnd = new Random();

            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    randt_arr[i, j] = rnd.Next(101);
                }
            }

            return randt_arr;
        }

        protected void MaxVal(out int max, out int xn, out int yn) // Функция возвращает максимальное значение в двумерном массиве; так же возвращает и позицию этого значения в этом массиве
        {
            xn = 0;
            yn = 0;
            max = main_twodim_arr[0, 0];
            for (int i = 0; i < y; i++)
            {
                for (int j = 1; j < x; j++)
                {
                    if (main_twodim_arr[i, j] > max)
                    {
                        max = main_twodim_arr[i, j];
                        xn = j;
                        yn = i;
                    }
                }
            }
        }

        protected void MinVal(out int min, out int xn, out int yn) // Функция возвращает минимальное значение в двумерном массиве; так же возвращает и позицию этого значения в этом массиве
        {
            xn = 0;
            yn = 0;
            min = main_twodim_arr[0, 0];
            for (int i = 0; i < y; i++)
            {
                for (int j = 1; j < x; j++)
                {
                    if (main_twodim_arr[i, j] < min)
                    {
                        min = main_twodim_arr[i, j];
                        xn = j;
                        yn = i;
                    }
                }
            }
        }

        protected int Aver() // Функция возвращет среднее значение всех элементов двумерного массива
        {
            int avr = 0;

            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    avr = avr + main_twodim_arr[i, j];
                }
            }

            return avr / main_twodim_arr.Length;
        }
    }
}