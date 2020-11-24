using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3_4
{
    public partial class Form1 : Form
    {
        //что бы хранить какую операцию сейчас делаем
        public int operation=0;

        //что бы хранить размер вектора
        public int size;

        // для хранения типа представления  вектора.false это задано точками, true это координатами 
        public bool typeA;

        // для хранения типа представления  вектора.false это задано точками, true это координатами
        public bool typeB;

        public Form1()
        {
            InitializeComponent();
            Text = "Калькулятор векторов";
        }

        //метод выполняющий создание и заполение векторов,математические подчеты и вывод ответа
        private void Calculate(int operation, int size)
        {
            double[] V = new double[0];
            double[] V1 = new double[0];
            var A = new Vector(V, MeasureVec.size2, TypeSetVec.point);
            var B = new Vector(V1, MeasureVec.size2, TypeSetVec.point);
            try
            {
                //происходит выбор по размерности вектора
                switch (size)
                {
                    case 2:
                        //если векторы двумерные,то выбираем по каким типам представления они заданы
                        switch (typeA)
                        {
                            case false:
                                //если вектор А задан 2мя точками то создаем вектор и записываем координаты
                                double[] Vec = new double[4];
                                Vec[0] = double.Parse(A1X.Text);
                                Vec[1] = double.Parse(A1Y.Text);
                                Vec[2] = double.Parse(A2X.Text);
                                Vec[3] = double.Parse(A2Y.Text);
                                A = new Vector(Vec, MeasureVec.size2, TypeSetVec.point);
                                break;
                            case true:
                                //если вектор А задан координатами вектора то создаем вектор и записываем координаты
                                Vec = new double[2];
                                Vec[0] = double.Parse(AX.Text);
                                Vec[1] = double.Parse(AY.Text);
                                A = new Vector(Vec, MeasureVec.size2, TypeSetVec.coordinate);
                                break;
                        }
                        switch (typeB)
                        {
                            case false:
                                //если вектор В задан 2мя точками то создаем вектор и записываем координаты
                                double[] Vec1 = new double[4];
                                Vec1[0] = double.Parse(B1X.Text);
                                Vec1[1] = double.Parse(B1Y.Text);
                                Vec1[2] = double.Parse(B2X.Text);
                                Vec1[3] = double.Parse(B2Y.Text);
                                B = new Vector(Vec1, MeasureVec.size2, TypeSetVec.point);
                                break;
                            case true:
                                //если вектор В задан координатами вектора то создаем вектор и записываем координаты
                                Vec1 = new double[2];
                                Vec1[0] = double.Parse(BX.Text);
                                Vec1[1] = double.Parse(BY.Text);
                                B = new Vector(Vec1, MeasureVec.size2, TypeSetVec.coordinate);
                                break;
                        }
                        break;
                    case 3:
                        //если векторы трехмерные,то выбираем по каким типам представления они заданы
                        switch (typeA)
                        {
                            case false:
                                //если вектор А задан 2мя точками то создаем вектор и записываем координаты
                                double[] Vec_0 = new double[6];
                                Vec_0[0] = double.Parse(A1_X.Text);
                                Vec_0[1] = double.Parse(A1_Y.Text);
                                Vec_0[2] = double.Parse(A1_Z.Text);
                                Vec_0[3] = double.Parse(A2_X.Text);
                                Vec_0[4] = double.Parse(A2_Y.Text);
                                Vec_0[5] = double.Parse(A2_Z.Text);
                                A = new Vector(Vec_0, MeasureVec.size3, TypeSetVec.point);
                                break;
                            case true:
                                //если вектор А задан координатами вектора то создаем вектор и записываем координаты
                                Vec_0 = new double[3];
                                Vec_0[0] = double.Parse(A_X.Text);
                                Vec_0[1] = double.Parse(A_Y.Text);
                                Vec_0[1] = double.Parse(A_Z.Text);
                                A = new Vector(Vec_0, MeasureVec.size3, TypeSetVec.coordinate);
                                break;
                        }
                        switch (typeB)
                        {
                            case false:
                                //если вектор В задан 2мя точками то создаем вектор и записываем координаты
                                double[] Vec_1 = new double[6];
                                Vec_1[0] = double.Parse(B1_X.Text);
                                Vec_1[1] = double.Parse(B1_Y.Text);
                                Vec_1[2] = double.Parse(B1_Z.Text);
                                Vec_1[3] = double.Parse(B2_X.Text);
                                Vec_1[4] = double.Parse(B2_Y.Text);
                                Vec_1[5] = double.Parse(B2_Z.Text);
                                B = new Vector(Vec_1, MeasureVec.size3, TypeSetVec.point);
                                break;
                            case true:
                                //если вектор В задан координатами вектора то создаем вектор и записываем координаты
                                Vec_1 = new double[3];
                                Vec_1[0] = double.Parse(B_X.Text);
                                Vec_1[1] = double.Parse(B_Y.Text);
                                Vec_1[1] = double.Parse(B_Z.Text);
                                B= new Vector(Vec_1, MeasureVec.size3, TypeSetVec.coordinate);
                                break;
                        }
                        break;
                    default:
                        break;
                }
            }
            catch (FormatException)
            {

            }
            string rez = "";
            //далее будет происходить решение математической части,исходя из значения переменной operation
            switch (operation)
            {
                case 1:
                    rez ="A + B="+(A + B).Verbose();
                    break;
                case 2:
                    rez = "A - B=" + (A - B).Verbose();
                    break;
                case 3:
                    rez = "A * B=" + Vector.Chislo(A * B);
                    break;
                case 4:
                    rez = "A x B=" + (A & B).Verbose();
                    break;
                case 5:
                    rez = "|A|=" + Vector.Chislo(Vector.Lenght(A));
                    break;
                case 6:
                    rez = "|B|=" + Vector.Chislo(Vector.Lenght(B));
                    break;
                default:

                    break;
            }
            switch (size)
            {
                case 2:
                    txtResult.Text =rez;
                    break;
                case 3:
                    txtResult2.Text = rez;
                    break;
            }
        }

        //при нажатии на кнопку произойдет присваивание размера и номера операции
        private void сумма_Click(object sender, EventArgs e)
        {
            operation = 1;
            size = 2;
            Calculate(operation, size);
        }

        //при нажатии на кнопку произойдет присваивание размера и номера операции
        private void разность_Click(object sender, EventArgs e)
        {
           
            operation = 2;
            size = 2;
            Calculate(operation, size);
        }

        //при нажатии на кнопку произойдет присваивание размера и номера операции
        private void Скаляр_Click(object sender, EventArgs e)
        {
            
            operation = 3;
            size = 2;
            Calculate(operation, size);
        }


        //при нажатии на кнопку произойдет присваивание размера и номера операции
        private void длиннаА_Click(object sender, EventArgs e)
        {
            
            operation = 5;
            size = 2;
            Calculate(operation, size);
        }

        //при нажатии на кнопку произойдет присваивание размера и номера операции
        private void длиннаB_Click(object sender, EventArgs e)
        {
            
            operation = 6;
            size = 2;
            Calculate(operation, size);
        }

        //при нажатии на кнопку произойдет присваивание размера и номера операции
        private void Сумма2_Click(object sender, EventArgs e)
        {
            operation = 1;
            size = 3;
            Calculate(operation, size);
        }

        //при нажатии на кнопку произойдет присваивание размера и номера операции
        private void Скаляр2_Click(object sender, EventArgs e)
        {
            operation = 3;
            size = 3;
            Calculate(operation, size);
        }

        //при нажатии на кнопку произойдет присваивание размера и номера операции
        private void Длинна_а_Click(object sender, EventArgs e)
        {
            operation = 5;
            size = 3;
            Calculate(operation, size);
        }

        //при нажатии на кнопку произойдет присваивание размера и номера операции
        private void Длинна_в_Click(object sender, EventArgs e)
        {
            operation = 6;
            size = 3;
            Calculate(operation, size);
        }

        //при нажатии на кнопку произойдет присваивание размера и номера операции
        private void Разн_Click(object sender, EventArgs e)
        {
            operation = 2;
            size = 3;
            Calculate(operation, size);
        }

        //при нажатии на кнопку произойдет присваивание размера и номера операции
        private void Векторн_Click(object sender, EventArgs e)
        {
            operation = 4;
            size = 3;
            Calculate(operation, size);
        }

        //при нажатии на кнопку произойдет очищение всех ячеек
        private void ОЧИСТИТЬ_Click(object sender, EventArgs e)
        {
            operation = 0;
            switch (typeA)
            {
                case false:
                    A1X.Text = "";
                    A2X.Text = "";
                    A1Y.Text = "";
                    A2Y.Text = "";
                    break;
                case true:
                    AX.Text = "";
                    AY.Text = "";
                    break;
            }
            switch (typeB)
            {
                case false:
                    B1X.Text = "";
                    B2X.Text = "";
                    B1Y.Text = "";
                    B2Y.Text = "";
                    break;
                case true:
                    BX.Text = "";
                    BY.Text = "";
                    break;
            }
            txtResult.Text = "";
        }

        //при нажатии на кнопку произойдет очищение всех ячеек
        private void Очистить_Click_1(object sender, EventArgs e)
        {
            operation = 0;
            switch (typeA)
            {
                case false:
                    A1_X.Text = "";
                    A2_X.Text = "";
                    A1_Z.Text = "";
                    A1_Y.Text = "";
                    A2_Y.Text = "";
                    A2_Z.Text = "";
                    break;
                case true:
                    A_X.Text = "";
                    A_Y.Text = "";
                    A_Z.Text = "";
                    break;
            }
            switch (typeB)
            {
                case false:
                    B1_X.Text = "";
                    B2_X.Text = "";
                    B1_Z.Text = "";
                    B1_Y.Text = "";
                    B2_Y.Text = "";
                    B2_Z.Text = "";
                    break;
                case true:
                    B_X.Text = "";
                    B_Y.Text = "";
                    B_Z.Text = "";
                    break;
            }
            txtResult2.Text = "";
        }

        //кнопка вызывающая форму "справка"
        private void справкаToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
        }

        //кнопка заполняющая ячейки векторов рандомными числами
        private void auto1_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            switch (typeA) {

                case false:
                    //если вектор А задан 2мя точками то создаем вектор и записываем координаты рандомно
                    A1X.Text = "" + rand.Next(-10, 10);
                    A2X.Text = "" + rand.Next(-10, 10);
                    A1Y.Text = "" + rand.Next(-10, 10);
                    A2Y.Text = "" + rand.Next(-10, 10);
                    break;
                case true:
                    //если вектор А задан координатами то создаем вектор и записываем координаты рандомно
                    AX.Text = "" + rand.Next(-10, 10);
                    AY.Text = "" + rand.Next(-10, 10);
                    break;
            }
            switch (typeB)
            {
                case false:
                    //если вектор В задан 2мя точками то создаем вектор и записываем координаты рандомно
                    B1X.Text = "" + rand.Next(-10, 10);
                    B2X.Text = "" + rand.Next(-10, 10);
                    B1Y.Text = "" + rand.Next(-10, 10);
                    B2Y.Text = "" + rand.Next(-10, 10);
                    break;
                case true:
                    //если вектор В задан координатами то создаем вектор и записываем координаты рандомно
                    BX.Text = "" + rand.Next(-10, 10);
                    BY.Text = "" + rand.Next(-10, 10);
                    break;
            }
            
        }

        //кнопка заполняющая ячейки векторов рандомными числами
        private void auto3_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            switch (typeA)
            {
                case false:
                    //если вектор А задан 2мя точками то создаем вектор и записываем координаты рандомно
                    A1_X.Text = "" + rand.Next(-10, 10);
                    A2_X.Text = "" + rand.Next(-10, 10);
                    A1_Y.Text = "" + rand.Next(-10, 10);
                    A2_Y.Text = "" + rand.Next(-10, 10);
                    A1_Z.Text = "" + rand.Next(-10, 10);
                    A2_Z.Text = "" + rand.Next(-10, 10);
                    break;
                case true:
                    //если векторА задан координатами то создаем вектор и записываем координаты рандомно
                    A_X.Text = "" + rand.Next(-10, 10);
                    A_Y.Text = "" + rand.Next(-10, 10);
                    A_Z.Text = "" + rand.Next(-10, 10);
                    break;
            }
            switch (typeB)
            {
                case false:
                    //если вектор В задан 2мя точками то создаем вектор и записываем координаты рандомно
                    B1_X.Text = "" + rand.Next(-10, 10);
                    B2_X.Text = "" + rand.Next(-10, 10);
                    B1_Y.Text = "" + rand.Next(-10, 10);
                    B2_Y.Text = "" + rand.Next(-10, 10);
                    B1_Z.Text = "" + rand.Next(-10, 10);
                    B2_Z.Text = "" + rand.Next(-10, 10);
                    break;
                case true:
                    //если вектор В задан  то создаем вектор и записываем координаты рандомно
                    B_X.Text = "" + rand.Next(-10, 10);
                    B_Y.Text = "" + rand.Next(-10, 10);
                    B_Z.Text = "" + rand.Next(-10, 10);
                    break;
            }
            
        }

        //что бы сделать темную тему по щелчку,я меняю свойства background
        private void темныйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(77, 100, 141);
            tabPage3.BackColor = Color.RoyalBlue;
            tabPage4.BackColor = Color.RoyalBlue;
            menuStrip1.BackColor = Color.FromArgb(77, 100, 141);
            Acoord3.BackColor = Color.LightBlue;
            Acoord.BackColor = Color.LightBlue;
            Bcoord3.BackColor = Color.LightBlue;
            Bcoord.BackColor = Color.LightBlue;
            Apoint.BackColor = Color.LightBlue;
            Apoint3.BackColor = Color.LightBlue;
            Bpoint.BackColor = Color.LightBlue;
            Bpoint3.BackColor = Color.LightBlue;
            Скаляр2.BackColor = Color.LightBlue;
            Сумма2.BackColor = Color.LightBlue;
            сумма.BackColor = Color.LightBlue;
            Разн.BackColor = Color.LightBlue;
            разность.BackColor = Color.LightBlue;
            Длинна_а.BackColor = Color.LightBlue;
            Длинна_в.BackColor = Color.LightBlue;
            длиннаB.BackColor = Color.LightBlue;
            длиннаА.BackColor = Color.LightBlue;
            Очистить.BackColor = Color.LightBlue;
            Векторн.BackColor = Color.LightBlue;
            auto1.BackColor = Color.LightBlue;
            auto3.BackColor = Color.LightBlue;
            Скаляр.BackColor = Color.LightBlue;
            button1.BackColor = Color.LightBlue;
            txtResult.BackColor = Color.LightBlue;
            txtResult2.BackColor = Color.LightBlue;
        }

        //что бы сделать светлую тему по щелчку,я меняю свойства background
        private void светлая_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(153, 103, 103);
            tabPage3.BackColor = Color.FromArgb(215, 183, 163);
            tabPage4.BackColor = Color.FromArgb(215, 183, 163);
            menuStrip1.BackColor = Color.FromArgb(153, 103, 103);
            Acoord3.BackColor = Color.FromArgb(234, 231, 234);
            Acoord.BackColor = Color.FromArgb(234, 231, 234);
            Bcoord3.BackColor = Color.FromArgb(234, 231, 234);
            Bcoord.BackColor = Color.FromArgb(234, 231, 234);
            Apoint.BackColor = Color.FromArgb(234, 231, 234);
            Apoint3.BackColor = Color.FromArgb(234, 231, 234);
            Bpoint.BackColor = Color.FromArgb(234, 231, 234);
            Bpoint3.BackColor = Color.FromArgb(234, 231, 234);
            Скаляр2.BackColor = Color.FromArgb(234, 231, 234);
            Сумма2.BackColor = Color.FromArgb(234, 231, 234);
            сумма.BackColor = Color.FromArgb(234, 231, 234);
            Разн.BackColor = Color.FromArgb(234, 231, 234);
            разность.BackColor = Color.FromArgb(234, 231, 234);
            Длинна_а.BackColor = Color.FromArgb(234, 231, 234);
            Длинна_в.BackColor = Color.FromArgb(234, 231, 234);
            длиннаB.BackColor = Color.FromArgb(234, 231, 234);
            длиннаА.BackColor = Color.FromArgb(234, 231, 234);
            Очистить.BackColor = Color.FromArgb(234, 231, 234);
            Векторн.BackColor = Color.FromArgb(234, 231, 234);
            auto1.BackColor = Color.FromArgb(234, 231, 234);
            auto3.BackColor = Color.FromArgb(234, 231, 234);
            Скаляр.BackColor = Color.FromArgb(234, 231, 234);
            button1.BackColor = Color.FromArgb(234, 231, 234);
            txtResult.BackColor = Color.FromArgb(234, 231, 234);
            txtResult2.BackColor = Color.FromArgb(234, 231, 234);
        }

        //комбобокс для выбора представления типа
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.Text)
            {
                case "точкам":
                    Apoint.Visible = true;
                    Acoord.Visible = false;
                    typeA = false;
                    txtResult.Text = "";
                    break;
                case "координатам":
                    Apoint.Visible = false;
                    Acoord.Visible = true;
                    typeA = true;
                    txtResult.Text = "";
                    break;
            }
        }

        //комбобокс для выбора представления типа
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox2.Text)
            {
                case "точкам":
                    Bcoord.Visible = false;
                    Bpoint.Visible = true;
                    typeB = false;
                    txtResult.Text = "";
                    break;
                case "координатам":
                    Bpoint.Visible = false;// не видна
                    Bcoord.Visible = true;
                    typeB = true;
                    txtResult.Text = "";
                    break;
            }
        }

        //комбобокс для выбора представления типа
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox3.Text)
            {
                case "точкам":
                    Acoord3.Visible = false;
                    Apoint3.Visible = true;
                    typeA = false;
                    txtResult2.Text = "";
                    break;
                case "координатам":
                    Apoint3.Visible = false;// не видна
                    Acoord3.Visible = true;
                    typeA = true;
                    txtResult2.Text = "";
                    break;
            }
        }

        //комбобокс для выбора представления типа
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox4.Text)
            {
                case "точкам":
                    Bcoord3.Visible = false;
                    Bpoint3.Visible = true;
                    typeB = false;
                    txtResult2.Text = "";
                    break;
                case "координатам":
                    Bpoint3.Visible = false;// не видна
                    Bcoord3.Visible = true;
                    typeB = true;
                    txtResult2.Text = "";
                    break;
            }
        }

        public void proverka(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && number != 44 && number != 45)
            {
                e.Handled = true;
            }
        }

        private void onValueChanged(object sender, EventArgs e)
        {
            if(operation != 0) {
                Calculate(operation,size); 
            }
            
        }
    }
}
