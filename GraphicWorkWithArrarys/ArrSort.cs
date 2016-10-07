using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WkWArrays
{
    class ArrSort : WorkWithArray // Класс для сортировки двумерного массива
    {
        private int[] main_sdim_arr, sorted_sdim_arr; // main_sdim_arr - сюда будет записываться значения из двумерного массива, sorted_sdim_arr - сортированный одномерный массив
        private int[,] sorted_twodim_arr, sortedhel_twodim_arr; // сюда будет записываться сортированный двумерный массив

        // Обёртки для полей
        public int[,] Sorted_twodim_arr
        {
            get
            {
                return sorted_twodim_arr;
            }
        }

        public int[,] Sortedhel_twodim_arr
        {
            get
            {
                return sortedhel_twodim_arr;
            }
        }

        // Конец обёрток

        public ArrSort() : base () // Конструктор без параметра
        {
            Sort();
        }        

        public ArrSort(int width, int height) : base(width, height) // Конструктор со входящими параметрами - измерениями массива
        {
            Sort();
        }

        private void tdimtosdim() // Процедура переводит массив main_twodim_arr[,] класса предка в поле main_sdim_arr
        {
            main_sdim_arr = new int[main_twodim_arr.Length];

            int k = 0;

            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {                    
                    main_sdim_arr[k] = main_twodim_arr[i, j];
                    k++;
                }
            }
        }
        
        private void SortSDimArr() // Процедура сортирует массив main_sdim_arr и записывает значения в поле sorted_sdim_arr
        {
            int[] arr = main_sdim_arr;

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = arr.Length - 1; j > i; j--)
                {
                    if (arr[j] < arr[i])
                    {
                        Swap(ref arr[j], ref arr[i]);
                    }
                }
            }

            sorted_sdim_arr = arr;
        }

        public void Sort() // Процедура переводит sorted_sdim_arr в sorted_twodim_arr и заполняет поле sortedhel_twodim_arr
        {
            tdimtosdim(); SortSDimArr();
            int k = 0;

            sorted_twodim_arr = new int[y, x];

            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    sorted_twodim_arr[i, j] = sorted_sdim_arr[k];
                    k++;
                }
            }

            sdimtohelix();
        }        
        
        private void sdimtohelix() // Заполняет поле sortedhel_twodim_arr значениями из sorted_sdim_arr по спирали
        {
            bool b_dir = true;
            int[,] helix_arr = new int[y, x];
            int i_curx = 0, i_cury = 0, maxxp = x - 1, maxyp = y - 1, maxxm = 0, maxym = 1, k = 0;

            while (k < sorted_sdim_arr.Length)
            {
                if(b_dir)
                {
                    for (int i = i_curx; i <= maxxp; i++, i_curx++, k++)
                    {
                        helix_arr[i_cury, i] = sorted_sdim_arr[k];
                    }
                    
                    i_curx--; i_cury++;
                    
                    for (int j = i_cury; j <= maxyp; j++, i_cury++, k++)
                    {
                        helix_arr[j, i_curx] = sorted_sdim_arr[k];
                    }

                    i_cury--; i_curx--; maxxp--; maxyp--; b_dir = false;
                }
                else
                {
                    for (int i = i_curx; i >= maxxm; i--, i_curx--, k++)
                    {
                        helix_arr[i_cury, i] = sorted_sdim_arr[k];
                    }

                    i_curx++; i_cury--;

                    for (int j = i_cury; j >= maxym; j--, i_cury--, k++)
                    {
                        helix_arr[j, i_curx] = sorted_sdim_arr[k];
                    }

                    i_cury++; i_curx++; maxxm++; maxym++; b_dir = true;
                }
            }

            sortedhel_twodim_arr = helix_arr;
        }

        static public void Swap (ref int a, ref int b) // Процедура меняет значения входящих в неё параметров
        {
            int buff;

            buff = a;
            a = b;
            b = buff;            
        }
    }
}