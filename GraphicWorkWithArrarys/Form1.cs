using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WkWArrays;

namespace GraphicWorkWithArrarys
{
    public partial class FM_WorkWithArr : Form
    {
        ArrSort AS = new ArrSort(10, 10);

        public FM_WorkWithArr()
        {
            InitializeComponent();
        }

        private void FM_WorkWithArr_Load(object sender, EventArgs e) // На создание формы заполняем панель для вывода оригинального массива оригинальным массивом
        {
            CreateLBArr(AS.Main_twodim_arr, 10, 10, PN_OrigArr);
        }

        private void BTN_SetSize_MouseUp(object sender, MouseEventArgs e) // Когда мы нажимаем на кнопку "Установить размер" создаём новый массив с указанными измерениями и выводим его
        {
            AS.NewArr((int)NUD_X.Value, (int)NUD_Y.Value);
            CreateLBArr(AS.Main_twodim_arr, (int)NUD_X.Value, (int)NUD_Y.Value, PN_OrigArr);
            AS.Sort(); // Сортируем новый массив этот массив
        }        

        private void TSMI_SortBy_Lines_Click(object sender, EventArgs e) // Выводим отсортированный массив по строкам
        {            
            CreateLBArr(AS.Sorted_twodim_arr, AS.X, AS.Y, PN_SortedArr);
        }

        private void TSMI_SortBy_Helix_Click(object sender, EventArgs e) // Выводим отсортированный массив по спирали
        {
            CreateLBArr(AS.Sortedhel_twodim_arr, AS.X, AS.Y, PN_SortedArr);
        }

        private void CreateLBArr(int[,] arr, int x, int y, Panel pn) // Функция создаёт массив из label и помещает их на заданную в параметрах панель
        {
            pn.Controls.Clear();            
            ArrToLb AtL = new ArrToLb(arr, x, y, 5, 5);

            LB_Max.Text = AS.Max_val.ToString();
            LB_MaxX.Text = (AS.Maxx + 1).ToString();
            LB_MaxY.Text = (AS.Maxy + 1).ToString();

            LB_Min.Text = AS.Min_val.ToString();
            LB_MinX.Text = (AS.Minx + 1).ToString();
            LB_MinY.Text = (AS.Miny + 1).ToString();

            LB_Aver.Text = AS.Aver_val.ToString();

            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                        pn.Controls.Add(AtL.lb_arr[i, j]);
                }
            }            
        }

        private void TSMI_Info_Click(object sender, EventArgs e) // Вывод информации
        {
            MessageBox.Show("V. 1.0A", "Информация");
        }
    }
}
