using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Day2Tests
{
    [TestClass]
    public class HexadecimalTests
    {
        [TestMethod()]
        public void GetFormatTest()
        {
            //HexadecimalFormatter formatter = new HexadecimalFormatter();
            //object expected = formatter;
            //object actual = formatter.GetFormat(typeof(HexadecimalFormatter));
            //Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void FormatTest()
        {
            string format = "{0}";
            object integer = 15;

            var instanse = new CustomFormatProvider.Hexadecimal();

            string expected = "00 00 00 0f";
            string actual = instanse.Format(format, integer, instanse);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void FormatTestNegativeValue()
        {
            string format = "{0}";
            object integer = -15;

            var instanse = new CustomFormatProvider.Hexadecimal();

            string expected = "ff ff ff f1";
            string actual = instanse.Format(format, integer, instanse);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void FormatTestBigNumber()
        {
            string format = "{0}";
            object integer = 12312412415;

            var instanse = new CustomFormatProvider.Hexadecimal();

            string expected = "00 00 00 02 dd e0 80 ff";
            string actual = instanse.Format(format, integer, instanse);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void FormatTestWrongFormat()
        {
            string format = "";
            object integer = 15;

            var instanse = new CustomFormatProvider.Hexadecimal();

            string expected = "00 00 00 0f";
            string actual = instanse.Format(format, integer, instanse);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void FormatTestOtherFormats()
        {
            string format = "";
            object integer = 255.123;

            var instanse = new CustomFormatProvider.Hexadecimal();

            string expected = "255,123";
            string actual = instanse.Format(format, integer, instanse);
            Assert.AreEqual(expected, actual);
        }
    }
}
