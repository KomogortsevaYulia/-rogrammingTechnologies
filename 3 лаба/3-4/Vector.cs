using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_4
{
    //предназначено для записи размера:двумерные и трехмерные векторы
    public enum MeasureVec { size2, size3 };

    //предназначено для записи заданного типа:точками и координатами
    public enum TypeSetVec { point, coordinate };

    public class Vector
    {
        private double[] vec;      //для координат и точек векторов
        private MeasureVec size;    //для размерности вектора
        private TypeSetVec type;    //для заданного типа

        //конструктор,задает начальное значение для вектора
        public Vector(double[] vec, MeasureVec size, TypeSetVec type) 
        {
            this.vec = vec;
            this.type = type;
            this.size = size;
        }

        //  свойство возвращающее размерность вектора,предназначено для удобства использования в циклах
        public int GetSize          
        {
            get {
                int k=0;
                switch (this.size)
                {
                    case MeasureVec.size2:
                        k = 2;
                        break;
                    case MeasureVec.size3:
                        k = 3;
                        break;
                }
                return k;
            }
        }

        //метод для конвертации из заданного типа представления вектора "точки" в "координаты"
        public static Vector To(Vector A)
        { 
            Vector result = new Vector(A.vec, A.size, TypeSetVec.coordinate);
            if (A.type == TypeSetVec.point)
            {
                for (int i = 0; i < A.GetSize; i++)
                {
                    result.vec[i] = A.vec[A.GetSize + i] - A.vec[i];
                } 
            }
            return result;
        }

        //свойство которое возвращает ответ в необходимом виде
        public string Verbose()
        {
            int k=0;
            switch(this.size)
            {
                case MeasureVec.size2:
                    k = 2;
                    break;
                case MeasureVec.size3:
                    k = 3;
                    break;
            }
            string s = " ";
            if (k == 2)
            {
                s = "(" + vec[0] + ";" + vec[1] + ")";
            }
            else
            {
                s = "(" + vec[0] + ";" + vec[1] + ";" + vec[2] + ")";
            }           
            return s;
        }

        //метод позволяющий выводить результат не координатами ,а числом
        public static string Chislo(double rez)
        {
            string P = string.Format("{0}", rez);
            return P;
        }

        //оператор сложения векторов
        public static Vector operator +(Vector A, Vector B)
        {
            //векторы A и B конвертируем в задаваемый тип "координаты"
            A =To(A);
            B =To(B);
            //создаем новый обьект Vector
            Vector result = new Vector(A.vec,A.size, A.type);
            //цикл сложения координат векторов
            for (int i = 0; i < A.GetSize ; i++) {
                result.vec[i]=A.vec[i] + B.vec[i];
            }
            return result;
        }

        //оператор вычитания векторов
        public static Vector operator -(Vector A, Vector B)
        {
            //векторы A и B конвертируем в задаваемый тип "координаты"
            A = To(A);
            B=To(B);
            //создаем новый обьект Vector
            Vector result = new Vector(A.vec, A.size, A.type);
            //цикл вычитания координат векторов
            for (int i = 0; i < A.GetSize; i++)
            {
                result.vec[i] = A.vec[i] - B.vec[i];
            }
            return result;
        }

        //оператор скалярного произведения векторов
        public static double operator *(Vector A, Vector B)    
        {
            double result=0 ;
            //векторы A и B конвертируем в задаваемый тип "координаты"
            A = To(A);
            B = To(B);
            //цикл  нахождения скалярного произведения векторов(на выходе число)
            for (int i = 0; i < A.GetSize; i++)
            {
                result = result+ (A.vec[i] * B.vec[i]);
            }
            return result;
        }

        //оператор векторного произведения векторов
        public static Vector operator &(Vector A, Vector B)   
        {
            //векторы A и B конвертируем в задаваемый тип "координаты"
            A = To(A);
            B = To(B);
            //создаем новый обьект Vector
            Vector result = new Vector(A.vec, A.size, A.type);
            double[] r = new double[A.GetSize];
            r[0] = A.vec[1] * B.vec[2] - A.vec[2] * B.vec[1]; 
            r[1] =  A.vec[2] * B.vec[0]- A.vec[0] * B.vec[2];
            r[2] = A.vec[0] * B.vec[1] - A.vec[1] * B.vec[0];
            for (int i = 0; i < A.GetSize; i++)
            {
                result.vec[i] = r[i];
            }
            return result;
        }
         
        //метод нахождения длнны вектора
        public static double Lenght (Vector A)    
        {
            double result = 0;
            A = To(A);
            for (int i = 0; i < A.GetSize; i++)
            {
                result += Math.Pow(A.vec[i], 2);
            }
            result=Math.Sqrt(result);
            result = Math.Round(result, 2);
            return result;
        }

    }
}
