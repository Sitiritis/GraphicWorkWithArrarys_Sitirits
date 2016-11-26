using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using WkWArrays;

namespace GraphicWorkWithArrarys
{    
    public partial class FM_WorkWithArr : Form
    {
        private delegate void TimeDeleg(); // Создаём делегат TimeDeleg, который будет получать ничего , и возвращать тоже ничего

        ArrSort AS = new ArrSort(10, 10);
        TimeDeleg Tm_Del; // Создаём экземпляр делегата TimeDeleg, с именем Tm_Del, как поле у нашей формы

        public FM_WorkWithArr()
        {
            InitializeComponent();
        }

        private void FM_WorkWithArr_Load(object sender, EventArgs e) // На создание формы заполняем панель для вывода оригинального массива оригинальным массивом
        {                                                            // и создаём новый поток, который будет выводить текущее время на LB_CurTime
            CreateLBArr(AS.Main_twodim_arr, 10, 10, PN_OrigArr);
            Tm_Del = () => LB_CurTime.Text = DateTime.Now.ToLongTimeString(); // Задаём лямбда выражение, которое присваивает текущее время свойству Text элементу управления LB_CurTime, нашему экземпляру делегата
            Thread TimeThread = new Thread(new ThreadStart(TDExecForever)); // Создаём новый поток, который будет выполнять метод TDExecForever
            TimeThread.IsBackground = true; // Делаем поток фоновым
            TimeThread.Start(); // Запускаем поток
        }

        private void TDExecForever() // Этот метод будет вызываться в потоке TimeThread
        {
            try
            {
                while (true) // Выполняется в бесконечном цикле (чтобы время обновлялось)
                {
                    if (LB_CurTime.InvokeRequired) // Запрашиваем разрешение на доступ к LB_CurTime из другого потока, и в случае успеха
                        LB_CurTime.Invoke(Tm_Del); // Выполняем делегат, который содержит лямбда-выражение, которое меняет у LB_CurTime свойство Text на текущее время системы 
                }
            } catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }
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
            MessageBox.Show("V. 1.0a", "Информация");
        }
    }
}
