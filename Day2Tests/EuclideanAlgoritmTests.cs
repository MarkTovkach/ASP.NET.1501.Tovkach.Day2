using System;
using GreatestCommonDivisor;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Day2Tests
{
    [TestClass]
    class EuclideanAlgoritmTests
    {

        [TestMethod()]
        public void GreatestCommonDivisorTest()
        {
            int a = 16;
            int b = 8;
            int expected = 8;
            double timeSpanded;
            int actual = EuclideanAlgoritm.EuclidGreatestCommonDivisor( out timeSpanded,a, b);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GreatestCommonDivisorTest2()
        {
            int a = -16;
            int b = -8;
            int expected = 8;
            double timeSpanded;
            int actual = EuclideanAlgoritm.EuclidGreatestCommonDivisor(out timeSpanded, a, b);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GreatestCommonDivisorTest3()
        {
            int a = 1071;
            int b = 462;
            int expected = 21;
            double timeSpanded;
            int actual = EuclideanAlgoritm.EuclidGreatestCommonDivisor(out timeSpanded, a, b);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GreatestCommonDivisorTest4()
        {
            int a = 10000000;
            int b = 10;
            int expected = 10;
            double timeSpanded;
            int actual = EuclideanAlgoritm.EuclidGreatestCommonDivisor(out timeSpanded, a, b);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GreatestCommonDivisorTestWithParams()
        {
            int a = 12;
            int b = 8;
            int c = 4;
            int expected = 4;
            double timeSpanded;
            CommonDivisor F = new CommonDivisor(EuclideanAlgoritm.EuclidGreatestCommonDivisor);
            int actual = EuclideanAlgoritm.GCD(out timeSpanded,F, a, b, c);
            Assert.AreEqual(expected, actual);
        }

       
        [TestMethod()]
        public void SteinGreatestCommonDivisorTest()
        {
            int a = 1071;
            int b = 462;
            int expected = 21;
            double timeSpanded;
            int actual = EuclideanAlgoritm.BinaryCD(out timeSpanded, a, b);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SteinGreatestCommonDivisorTestWithParams()
        {
            int a = 12;
            int b = 8;
            int c = 4;
            int expected = 4;
            double timeSpanded;
            CommonDivisor F = new CommonDivisor(EuclideanAlgoritm.BinaryCD);
            int actual = EuclideanAlgoritm.GCD(out timeSpanded,F, a, b, c);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SteinGreatestCommonDivisorTest1()
        {
            int a = 0;
            int b = 462;
            int expected = 462;
            double timeSpanded;
            int actual = EuclideanAlgoritm.BinaryCD(out timeSpanded, a, b);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SteinGreatestCommonDivisorTest2()
        {
            int a = 462;
            int b = 0;
            int expected = 462;
            double timeSpanded;
            int actual = EuclideanAlgoritm.BinaryCD(out timeSpanded, a, b);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SteinGreatestCommonDivisorTest3()
        {
            int a = 12;
            int expected = 12;
            double timeSpanded;
            CommonDivisor F = new CommonDivisor(EuclideanAlgoritm.BinaryCD);
            int actual = EuclideanAlgoritm.GCD(out timeSpanded,F, a);
            Assert.AreEqual(expected, actual);
        }
    }
}
