using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
    {
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите размерность матриц A,B,C(от 1 до 10):  ");
            int n;
            while (!(Int32.TryParse(Console.ReadLine(), out n)) || (n < 1) || (n > 10))
                Console.WriteLine("Некорректный ввод.Введите размерность матрицы не меньше 1 и не больше 10");
            
            Console.WriteLine("\nВведите матрицу А");
            var matrixA = Matrix.InputMatrix(n);
            Console.WriteLine("\nВведите матрицу B");                                                                 
            var matrixB = Matrix.InputMatrix(n);
            Console.WriteLine("\nВведите матрицу C");                                                                 
            var matrixC = Matrix.InputMatrix(n);
            Console.WriteLine("\nВведите матрицу А");



            
            Console.WriteLine("\nМатрица А");
            matrixA.Print();
            Console.WriteLine("\nМатрица B");
            matrixB.Print();
            Console.WriteLine("\nМатрица C");
            matrixC.Print();
            var F=Logic.ReturnRezult(matrixA,matrixB,matrixC);
            Console.WriteLine("\nМатрица F");
            F.Print();                                                         //вывод результата в консоль
            
            Console.ReadKey();
        }
    }
    public class Logic
    {
        public static Matrix ReturnRezult (Matrix A, Matrix B, Matrix C)
        {
            Matrix F;

            if (((Matrix.CheckMax(B)) - (Matrix.CheckMin(B)) < ((Matrix.CheckMax(A)) - (Matrix.CheckMin(C)))
            {
                F = Matrix.Trans(B - C) + 2 * (2 + A);
            }
            else
            {
                F = A * 3 - Matrix.Trans(C) * 3 + 2 - B;
            }
            return F;
        }
    }
    public class Matrix 
    {
        public int[,] data;                                                     // поле для хранения данных
        private int n;                                                          // поле для хранения размера матрицы
        
        public Matrix(int n)                                                    //конструкторы инициализация массива
        {
            this.data = new int[n, n]; // инициализируем матрицу
            this.n = n;
        }

        public int this[int i, int j]                                           //индексатор для обращения к обьекту класса как  к двумерному массиву 
        {
            get // обращение, например если кто-то пишет var k = matrix[1,1];
            {
                return data[i, j]; // зеркалим данные из поля data
            }
            set // присваивание, вызывается если кто-то пишет matrix[1,1] = 2;
            {
                data[i, j] = value; // зеркалим
                присвоенное значение в data[i,j]
            }
        }

        public Matrix(int[,] inputData)                                         //новый конструктор с параметром двумерным массивом
        {
            // мы надеемся, что передали квадратную матрицу
            // и берем за размер количество строк
            this.n = inputData.GetLength(0);

            // инициализируем внутренний двумерный массив 
            this.data = new int[this.n, this.n];

            // копируем элементы, поэлементно
            for (var i = 0; i < this.n; ++i)
            {
                for (var j = 0; j < this.n; ++j)
                {
                    this.data[i, j] = inputData[i, j];
                }
            }
        }

        public void Print()                                                     //вывод матрицы
        {
            for (var i = 0; i < this.Size; ++i)
            {
                for (var j = 0; j < this.Size; ++j)
                {
                    Console.Write("{0}\t", this[i, j]);
                }
                Console.WriteLine();
            }
        }                                                          

        public static Matrix InputMatrix(int n)                                 //Ввод матрицы
        {
            Matrix A = new Matrix(n);                                                                   // объявил матрицу
            for (var i = 0; i < A.Size; ++i)
            {
                for (var j = 0; j < A.Size; ++j)
                {
                    int t;
                    Console.Write("Элемент[" + i + "," + j + "] :  ");
                    while (!(Int32.TryParse(Console.ReadLine(), out t)))
                        Console.WriteLine("Некорректный ввод.Элемент матрицы может быть только числом ");// заполнили
                    A[i, j] = t;
                    
                }
            }
            return A;
        }

        public static Matrix operator +(Matrix A, Matrix B)                     //Оператор сложения двух матриц
        {
            var resultMatix = new Matrix(A.Size);
            for (var i = 0; i < A.Size; ++i)
            {
                for (var j = 0; j < A.Size; ++j)
                {
                    resultMatix[i, j] = A[i, j] + B[i, j];
                }
            }
            return resultMatix;
        }

        public static Matrix operator +(Matrix A, int c)                        //Оператор сложения матрицы и числа
        {
            var resultMatix = new Matrix(A.Size);
            for (var i = 0; i < A.Size; ++i)
            {
                for (var j = 0; j < A.Size; ++j)
                {
                    if (i == j) // если элемент на диагонали, то прибавляем c
                    {
                        resultMatix[i, j] = A[i, j] + c;
                    }
                    else // а если нет, то просто присваиваем значение исходной матрицы
                    {
                        resultMatix[i, j] = A[i, j];
                    }
                }
            }
            return resultMatix;
        }
        
        public static Matrix operator +(int c, Matrix A)                        // функция сложения матрицы и числа //
        {

            return A + c;
        }

        public static Matrix operator -(Matrix A, Matrix B)                     //Оператор вычитания двух матриц
        {
            var resultMatix = new Matrix(A.Size);
            for (var i = 0; i < A.Size; ++i)
            {
                for (var j = 0; j < A.Size; ++j)
                {
                    resultMatix[i, j] = A[i, j] - B[i, j];
                }
            }
            return resultMatix;
        }
        
        public static Matrix operator *(Matrix A, Matrix B)                     // функция умножения матриц //
        {
            var resultMatix = new Matrix(A.Size);
            for (var i = 0; i < A.Size; ++i)
            {
                for (var j = 0; j < A.Size; ++j)
                {
                    for (var k = 0; k < A.Size; ++k)
                    {
                        resultMatix[i, j] += A[i, k] * B[k, j];
                    }

                }
            }
            return resultMatix;
        }
        
        public static Matrix operator *(Matrix A, int c)                        //Оператор умножения матрицы на число
        {
            var resultMatix = new Matrix(A.Size);
            for (var i = 0; i < A.Size; ++i)
            {
                for (var j = 0; j < A.Size; ++j)
                {
                    resultMatix[i, j] = A[i, j] * c;
                }
            }
            return resultMatix;
        }

        public static Matrix operator *(int c, Matrix A)                        // функция умножения числа на матрицу //
        {
            return A * c;
        }
        
        public override bool Equals(object obj)
        {
            // тут мы пытаемся преобразовать переданный объект в матрицу
            var B = obj as Matrix;

            // если преобразование не удалось, то есть если B не матрица, то в B окажется null
            if (B == null)
                return false; // а если не матрица, то значит точно не совпадает, возвращаем false

            // а если B оказалось матрицей поэлементно сравниваем элементы
            for (var i = 0; i < this.Size; ++i)
            {
                for (var j = 0; j < this.Size; ++j)
                {
                    //  ищем первый несовпавший элемент
                    if (this[i, j] != B[i, j])
                        return false; // если найдем, значит не совпадают
                }
            }
            return true; // ну а если такого не найдем, значит совпадает, возвращает true
        }

        public static int CheckMax (Matrix A)                                   //Нахождение максимального элемента матрицы
        {
            int Max=A[0,0];
            for (var i = 0; i < A.Size; ++i)
            {
                for (var j = 0; j < A.Size; ++j)
                {
                    if (A[i, j] > Max)
                    {
                        Max = A[i, j];
                    }
                }
            }
            return Max;
        }
        
        public static int CheckMin(Matrix A)                                    //Нахождение минимального элемента матрицы
        {
            int Min = A[0, 0];
            for (var i = 0; i < A.Size; ++i)
            {
                for (var j = 0; j < A.Size; ++j)
                {
                    if (A[i, j] < Min)
                    {
                        Min = A[i, j];
                    }
                }
            }
            return Min;
        }
        
        public static Matrix Trans(Matrix A)                              //транспонирование матрицы
        {
            var resultMatix = new Matrix(A.Size);
            for (var i = 0; i < A.Size; ++i)
            {
                for (var j = 0; j < A.Size; ++j)
                {
                    resultMatix [i,j] = A[j,i];
                }
            }
            return resultMatix;
        }

        public int Size                                                         // свойство которое возвращает количество элементов в матрице
        {
            get // тут только метод для обращения
            {
                return n; // возвращаем просто размер матрицы
            }
        }
    }
    
}
