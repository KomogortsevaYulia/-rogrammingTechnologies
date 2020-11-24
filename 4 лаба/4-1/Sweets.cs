using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_1
{
    //родительский класс,все что в нем написано наследуют его "дети"
    public class Sweets {
        public static Random rnd = new Random();
        // вес-это общая характеристика
        public int weight = 0;  
        //родительская функция,которую можно переопределять(выдает информацию)
        public virtual String GetInfo()
        {
            var str = String.Format("\nВес:"+ this.weight+ " грамм");
            return str;
        }
        //родительская функция,которую можно переопределять(выдает код для выбора картинки)
        public virtual int GetNumPic()
        {
            var index=0 ;
            return index;
        }

    }
    //тип шоколада(темный ,молочный)
    public enum ChocolateType { темный, белый }; 
    //наличие начинки(Орехи,изюм)         
    public enum Stuffing {Орехи, Изюм };
    //класс chocolate ,наследует всё от родительского класса Sweets
    public class Chocolate : Sweets
    {
        //наличие начинки
        public Stuffing Stuf = Stuffing.Орехи;            
        // количество плиток
        public int BarCount = 0;
        // тип шоколада                        
        public ChocolateType Type = ChocolateType.темный; 
        //переопределили метод что бы каждый предмет выдавал информацию конкретно о себе
        public override String GetInfo()
        {
            var str = "Шоколад";
            str += String.Format("\nТип: {0}", this.Type);
            str += base.GetInfo();
            str += String.Format("\nНачинка: {0}", this.Stuf);
            str += String.Format("\nКоличество плиток: {0}", this.BarCount);
           return str;
        }
        //переопределили метод что бы выбор картинки осуществлялся по цифре
        public override int GetNumPic()
        {
            //индекс равен 10,потому что первая цифра 1-это шоколад,вторая цифра означает тип шоколада
            var index = 10;
            switch (this.Type) {
                case ChocolateType.темный:
                    index+=1;
                    break;
                case ChocolateType.белый:
                    index += 2;
                    break;
            }
            return index;
        }
        //метод рандомно генерирующий характеристики шоколада
        public static Chocolate Generate()
        {
            return new Chocolate
            {
                weight = rnd.Next(10, 200),
                Stuf = (Stuffing)rnd.Next(2),
                BarCount = rnd.Next() % 10,
                Type = (ChocolateType)rnd.Next(2)
            };
        }
    }
    //тип выпечки(булочка, пирожок,чизкейк, пончик )
    public enum BakingType {булочка, пирожок,чизкейк, пончик };
    //класс Baking ,наследует всё от родительского класса Sweets
    public class Baking : Sweets
    {   
        //тип выпечки
        public BakingType type = BakingType.булочка;   
        // энергетическая ценность
        public int EnergyValue = 0;
        //переопределили метод что бы каждый предмет выдавал информацию конкретно о себе
        public override String GetInfo()
        {
            var str = "Выпечка"; 
            str += String.Format("\nТип: {0}", this.type);
            str += base.GetInfo();
           str += String.Format("\nЭнергетическая ценность(ККал): {0}", this.EnergyValue);
           return str;
        }
        //переопределили метод что бы выбор картинки осуществлялся по цифре
        public override int GetNumPic()
        {   //индекс равен 20,потому что первая цифра 2-это выпечка,вторая цифра означает тип выпечки
            var index = 20;
            switch (this.type)
            {
                case BakingType.булочка:
                    index += 1;
                    break;
                case BakingType.пирожок:
                    index += 2;
                    break;
                case BakingType.чизкейк:
                    index += 3;
                    break;
                case BakingType.пончик:
                    index += 4;
                    break;
            }
            return index;
        }
        //метод рандомно генерирующий характеристики выпечки
        public static Baking Generate()
        {
            return new Baking
            {
                weight = rnd.Next(100,300) ,
                type = (BakingType)rnd.Next(4),
                EnergyValue = rnd.Next() % 600
            };
        }
    }
    //тип фрукта(яблоко, банан,апельсин)
    public enum FruitsType {яблоко, банан,апельсин };
    //класс Fruits ,наследует всё от родительского класса Sweets
    public class Fruits : Sweets
    {   
        // тип 
        public FruitsType type = FruitsType.яблоко;  
        //спелость
        public int Ripeness = 0;
        //переопределили метод что бы каждый предмет выдавал информацию конкретно о себе
        public override String GetInfo()
        {
            var str = "Фрукт"; 
            str += String.Format("\nТип: {0}", this.type);
            str += base.GetInfo();
            str += String.Format("\nСпелость: {0}", this.Ripeness);
            return str;
        }
        //переопределили метод что бы выбор картинки осуществлялся по цифре
        public override int GetNumPic()
        {
            //индекс равен 30,потому что первая цифра 3-это фрукты,вторая цифра означает тип фруктов
            var index = 30;
            switch (this.type)
            {
                case FruitsType.яблоко:
                    index += 1;
                    break;
                case FruitsType.банан:
                    index += 2;
                    break;
                case FruitsType.апельсин:
                    index += 3;
                    break;
            }
            return index;
        }
        //метод рандомно генерирующий характеристики фруктов
        public static Fruits Generate()
        {
            return new Fruits
            {
                weight = rnd.Next(50,200) ,
                type = (FruitsType)rnd.Next(3),
                Ripeness = rnd.Next(10,100) ,
            };
        }
    }
}