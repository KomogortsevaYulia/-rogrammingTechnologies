using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4_1
{
    public partial class Form1 : Form
    {
        //создание листа SweetssList,который может хранить обьекты типа Sweets
        List<Sweets> SweetssList = new List<Sweets>();
        public Form1()
        {
            InitializeComponent();
            ShowInfo();
        }
        //метод для кнопки "перезаполнить"
        private void Refill_Click(object sender, EventArgs e)
        {
            //очищаем все элементы листа SweetssList
            this.SweetssList.Clear();

            //очищаем все поля
            richTextBox1.Text = "";
            txtOut.Text = "";
            pictureBox1.Image = null;
            var rnd = new Random();
            //заполнение листа SweetssList происходит рандомно, всего 10 обьектов
            for (var i = 0; i < 10; ++i)
            {
                // генерируются случайные числа от 0 до 2 
                switch (rnd.Next() % 3) 
                {
                    case 0:
                        //вызов метода генерирования обьекта класса Chocolate для записи в SweetssList
                        this.SweetssList.Add(Chocolate.Generate());
                        richTextBox1.Text += "Шоколад" + "\n";
                        break;
                    case 1:
                        //вызов метода генерирования обьекта класса Baking для записи в SweetssList
                        this.SweetssList.Add(Baking.Generate());
                        richTextBox1.Text += "Выпечка" + "\n";
                        break;
                    case 2:
                        //вызов метода генерирования обьекта класса Fruits для записи в SweetssList
                        this.SweetssList.Add(Fruits.Generate());
                        richTextBox1.Text += "Фрукт" + "\n";
                        break;
                }
            }
            //вызов метода, который показывает информацию о наличие сладостей в автомате
            ShowInfo();
        }
        
        // функция выводит информацию о количестве сладостей на форму
        private void ShowInfo()
        {
            // счетчики под каждый тип
            int ChocolateCount = 0;
            int BakingCount = 0;
            int FruitsCount = 0;
            // проходим через весь список,если находим нужные предметы,увеличиваем счетчики
            foreach (var fruit in this.SweetssList)
            {
                if (fruit is Chocolate) 
                {
                    ChocolateCount += 1;
                }
                else if (fruit is Baking)
                {
                    BakingCount += 1;
                }
                else if (fruit is Fruits)
                {
                    FruitsCount += 1;
                }
            }
            // выводим информацию на форму
            txtInfo.Text = "Шоколад\tВыпечка\tФрукты";       
            txtInfo.Text += "\n";
            txtInfo.Text += String.Format("{0}\t{1}\t{2}", ChocolateCount, BakingCount, FruitsCount);
        }

        //метод ,выполняющийся при нажатии на кнопку "взять"
        private void btnGet_Click(object sender, EventArgs e)
        {
            // если список пуст, то напишем что пусто и выйдем из функции
            if (this.SweetssList.Count == 0)
            {
                txtOut.Text = "Пусто";
                richTextBox1.Text = "Пусто";
                pictureBox1.Image= null;
                textBox1.Text = "";
                ShowInfo();
                return;
            }
            //дословно-берем из списка первый предмет
            var sweets = this.SweetssList[0];
            //вызов метода который возвращает характеристики предмета
            txtOut.Text = sweets.GetInfo();
            //выводим картинку этого предмета
            picture(sweets.GetNumPic());
            // очищаем "очередь"
            richTextBox1.Text = "";
            foreach (var sweet in this.SweetssList)
            {
                if (sweet is Chocolate)
                {
                    richTextBox1.Text += "Шоколад" + "\n";
                }
                else if (sweet is Baking)
                {
                    richTextBox1.Text +=  "Выпечка" + "\n";
                }
                else if (sweet is Fruits)
                {
                    richTextBox1.Text += "Фрукт" + "\n";
                }
            }
            String s = null;
            //находим 0 элемент в листе и исходя из его значений присваиваем строке слово
            var fruit = SweetssList[0];
            if (fruit is Chocolate)
            {s = "Шоколад";}
            else if (fruit is Baking)
            {s = "Выпечка";}
            else if (fruit is Fruits)
            {s = "Фрукт";}
            //проверяем наличие строки(нашли ее выше) которую нужно окрасить
            int pos = richTextBox1.Find(s);
            //если искомая строка найдена
            if (pos != -1) {
                //то окрашиваем эту строку в красный цвет
                richTextBox1.Select(0, s.Length);
                richTextBox1.SelectionColor= Color.Red;
            }
            //удаляем нулевой элемент списка
            this.SweetssList.RemoveAt(0);
            // обновим информацию о количестве товара на форме
            ShowInfo();
        }
        //метод для вывода картинок
        public void picture(int a)
        {
            try
            {
                //на входе двухначное число,первая цифра это шоколад/выпечка/фрукты, 
                //вторая цифра это тип каждой из сладостей,находим каждую цифру
                int type1 = a / 10;
                int type2 = a % 10;
                textBox1.Visible = false;
                //находим что у нас за предмет,находим картинку этого предмета по указанному адресу и выводим ее
                switch (type1)
                {
                    //шоколад
                    case 1:
                        switch (type2)
                        {
                            case 1:
                                pictureBox1.Image = Image.FromFile("C:\\Юлия\\Институт\\2 курс\\Технология програмирования\\Лабы\\4 лаба\\Картинки\\темный шоколад.jpg");
                                break;
                            case 2:
                                pictureBox1.Image = Image.FromFile("C:\\Юлия\\Институт\\2 курс\\Технология програмирования\\Лабы\\4 лаба\\Картинки\\белый шоколад.jpg");
                                break;
                        }
                        break;
                    //выпечка
                    case 2:
                        switch (type2)
                        {
                            case 1:
                                pictureBox1.Image = Image.FromFile("C:\\Юлия\\Институт\\2 курс\\Технология програмирования\\Лабы\\4 лаба\\Картинки\\булочка.jpg");
                                break;
                            case 2:
                                pictureBox1.Image = Image.FromFile("C:\\Юлия\\Институт\\2 курс\\Технология програмирования\\Лабы\\4 лаба\\Картинки\\пирожок.jpg");
                                break;
                            case 3:
                                pictureBox1.Image = Image.FromFile("C:\\Юлия\\Институт\\2 курс\\Технология програмирования\\Лабы\\4 лаба\\Картинки\\чизкейк.jpg");
                                break;
                            case 4:
                                pictureBox1.Image = Image.FromFile("C:\\Юлия\\Институт\\2 курс\\Технология програмирования\\Лабы\\4 лаба\\Картинки\\пончик.jpg");
                                break;
                        }
                        break;
                    //фрукты
                    case 3:
                        switch (type2)
                        {
                            case 1:
                                pictureBox1.Image = Image.FromFile("C:\\Юлия\\Институт\\2 курс\\Технология програмирования\\Лабы\\4 лаба\\Картинки\\яблоко.jpg");
                                break;
                            case 2:
                                pictureBox1.Image = Image.FromFile("C:\\Юлия\\Институт\\2 курс\\Технология програмирования\\Лабы\\4 лаба\\Картинки\\банан.png");
                                break;
                            case 3:
                                pictureBox1.Image = Image.FromFile("C:\\Юлия\\Институт\\2 курс\\Технология програмирования\\Лабы\\4 лаба\\Картинки\\апельсин.jpg");
                                break;
                        }
                        break;
                }
            }
            catch(System.IO.FileNotFoundException ex) {
                //на входе двухначное число,первая цифра это шоколад/выпечка/фрукты, 
                //вторая цифра это тип каждой из сладостей,находим каждую цифру
                int type1 = a / 10;
                int type2 = a % 10;
                textBox1.Visible = true;
                //находим что у нас за предмет,находим картинку этого предмета по указанному адресу и выводим ее
                switch (type1)
                {
                    //шоколад
                    case 1:
                        switch (type2)
                        {
                            case 1:
                                textBox1.Text = "Тут должно было быть изображение темного шоколада,но его не удалось загрузить.";
                                break;
                            case 2:
                                textBox1.Text = "Тут должно было быть изображение белого шоколада,но его не удалось загрузить.";
                                break;
                        }
                        break;
                    //выпечка
                    case 2:
                        switch (type2)
                        {
                            case 1:
                                textBox1.Text = "Тут должно было быть изображение булочки,но его не удалось загрузить.";
                                break;
                            case 2:
                                textBox1.Text = "Тут должно было быть изображение пирожка,но его не удалось загрузить.";
                                break;
                            case 3:
                                textBox1.Text = "Тут должно было быть изображение чизкейка,но его не удалось загрузить.";
                                break;
                            case 4:
                                textBox1.Text = "Тут должно было быть изображение пончика,но его не удалось загрузить.";
                                break;
                        }
                        break;
                    //фрукты
                    case 3:
                        switch (type2)
                        {
                            case 1:
                                textBox1.Text = "Тут должно было быть изображение яблока,но его не удалось загрузить.";
                                break;
                            case 2:
                                textBox1.Text = "Тут должно было быть изображение банана,но его не удалось загрузить.";
                                break;
                            case 3:
                                textBox1.Text = "Тут должно было быть изображение апельсина,но его не удалось загрузить.";
                                break;
                        }
                        break;
                }
            }
        }
    }
}
