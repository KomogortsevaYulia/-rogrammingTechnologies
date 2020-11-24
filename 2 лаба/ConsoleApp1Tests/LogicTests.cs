using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Tests
{
    [TestClass()]
    public class LogicTests
    {
        [TestMethod()]
        public void ReturnRezultTest()
        {
            var matrixA = new Matrix(new int[,] { { 1, 2 }, { 3, 4} });
            var matrixB = new Matrix(new int[,] { { 1, 5 }, { 0, 3 } });
            var matrixC = new Matrix(new int[,] { { -4, 10 }, { 2, 7 } });
            var F = new Matrix(new int[,] { { 7, 2 }, { 1, 4 } });
            var rezult = Logic.ReturnRezult(matrixA, matrixB, matrixC);
            Assert.AreEqual(F, rezult);
        }
        [TestMethod()]
        public void ReturnRezultTest1()
        {
            var matrixA = new Matrix(new int[,] { { 1, 2 }, { 3, 4 } });
            var matrixB = new Matrix(new int[,] { { 10, 5 }, { 1, 0 } });
            var matrixC = new Matrix(new int[,] { { 2, 10 }, { 15, 4 } });
            var rezult = Logic.ReturnRezult(matrixA, matrixB, matrixC);
            var F = new Matrix(new int[,] { { -11, -44 }, { -22, 2 } });
            Assert.AreEqual(F, rezult);
        }
        [TestMethod()]
        public void ReturnRezultTest2()
        {
            var matrixA = new Matrix(new int[,] { { 5, 0 }, { 1, 2 } });
            var matrixB = new Matrix(new int[,] { { 6, 3 }, { 4, 5 } });
            var matrixC = new Matrix(new int[,] { { 2, 3 }, { 4, 6 } });
            var F = new Matrix(new int[,] { { 5, -15 }, {-10, -15 } });
            var rezult = Logic.ReturnRezult(matrixA, matrixB, matrixC);
            Assert.AreEqual(F, rezult);
        }

    }
    
}