using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicWorkWithArrarys
{
    class ArrToLb // Класс для перевода числового двумерного массива в двумерный массив типа Label
    {
        private int lbcount = -1, x, y, top, left, inc_leng = 21, lb_width = 25, lb_height = 12;
        private int[,] main_arr_toout;
        public Label[,] lb_arr;

        public int LbCount // Возвращает кол-во элементов созданныйх label
        {
            get
            {
                return lbcount;
            }
        }

        public ArrToLb(int[,] arr, int width, int height, int Top, int Left) // Конструтор, выполняет основную работу, arr[,] - массив, который будет преобразовываться, width и height - ширина и высота этого массива, Top и Left - координаты верхнего левого угла двумерного массива из Label
        {
            x = width; y = height; top = Top; left = Left;
            main_arr_toout = arr;
            lb_arr = new Label[height, width];
            ArrayToLabel();
        }
        
        private void ArrayToLabel() // Переводит массив main_arr_toout[,] в lb_arr[,]
        {
            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    lb_arr[i, j] = CreateLb(j, i); // Делаем заготовку label со значением текущего элемента массива и помещаем в lb_arr
                    lb_arr[i, j].Location = new System.Drawing.Point( (left + (inc_leng * j)) , (top + (inc_leng * i)) ); // Задаём координаты для текущего label
                }
            }
        }

        private Label CreateLb(int curx, int cury) // Функция получает текущее значение элемента массива и возвращает заготовку label без координат положения
        {
            lbcount++;
            Label Lb = new Label();
            Lb.Tag = lbcount;
            Lb.Name = "LB_" + curx + "_" + cury;
            Lb.Visible = true;
            Lb.Width = lb_width;
            Lb.Height = lb_height;
            Lb.Text = main_arr_toout[cury, curx].ToString();
            Lb.BackColor = System.Drawing.Color.Transparent;
            Lb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            return Lb;
        }
    }
}