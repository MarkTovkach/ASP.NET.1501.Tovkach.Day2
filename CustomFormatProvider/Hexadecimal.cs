using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
namespace CustomFormatProvider
{
    public class Hexadecimal : IFormatProvider, ICustomFormatter
    {
        /// <summary>
        /// IFormatProvider.GetFormat implementation.
        /// </summary>
        /// <param name="formatType"></param>
        /// <returns></returns>
        public object GetFormat(Type formatType)
        {
            // Determine whether custom formatting object is requested.
            if (formatType == typeof(ICustomFormatter))
                return this;
            else
                return null;
        }

        /// <summary>
        /// ICustomFormatter.Format implementation.
        /// </summary>
        /// <param name="format"></param>
        /// <param name="arg"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            // Get a byte array representing the numeric value.
            byte[] bytes;
            if (arg is sbyte)
            {
                string byteString = ((sbyte)arg).ToString("X2");
                bytes = new byte[1] 
                { 
                    Byte.Parse(byteString, NumberStyles.HexNumber) 
                };
            }
            else if (arg is byte)
            {
                bytes = new byte[1] { (byte)arg };
            }
            else if (arg is short)
            {
                bytes = BitConverter.GetBytes((short)arg);
            }
            else if (arg is int)
            {
                bytes = BitConverter.GetBytes((int)arg);
            }
            else if (arg is long)
            {
                bytes = BitConverter.GetBytes((long)arg);
            }
            else if (arg is ushort)
            {
                bytes = BitConverter.GetBytes((ushort)arg);
            }
            else if (arg is uint)
            {
                bytes = BitConverter.GetBytes((uint)arg);
            }
            else if (arg is ulong)
            {
                bytes = BitConverter.GetBytes((ulong)arg);
            }
            
            else
            {
                try
                {
                    return HandleOtherFormats(format, arg);
                }
                catch (FormatException e)
                {
                    throw new FormatException(String.Format("The format of '{0}' is invalid.", format), e);
                }
            }

            // Return a formatted string.
            string numericString = String.Empty;
            for (int ctr = bytes.GetUpperBound(0); ctr >= bytes.GetLowerBound(0); ctr--)
            {
                string byteString = String.Empty;

                byteString += ByteToChar((byte)(bytes[ctr] / 16));
                byteString += ByteToChar((byte)(bytes[ctr] % 16));

                byteString = new String('0', 2 - byteString.Length) + byteString;

                numericString += byteString + " ";
            }
            return numericString.Trim();
        }

        /// <summary>
        /// Converts byte from 0 to 15 to char
        /// </summary>
        /// <param name="temp"></param>
        /// <returns></returns>
        private char ByteToChar(byte temp)
        {
            switch (temp)
            {
                case 1:
                    return '1';
                case 2:
                    return '2';
                case 3:
                    return '3';
                case 4:
                    return '4';
                case 5:
                    return '5';
                case 6:
                    return '6';
                case 7:
                    return '7';
                case 8:
                    return '8';
                case 9:
                    return '9';
                case 10:
                    return 'a';
                case 11:
                    return 'b';
                case 12:
                    return 'c';
                case 13:
                    return 'd';
                case 14:
                    return 'e';
                case 15:
                    return 'f';
                default:
                    return '0';
            }
        }

        private string HandleOtherFormats(string format, object arg)
        {
            if (arg is IFormattable)
                return ((IFormattable)arg).ToString(format, CultureInfo.CurrentCulture);
            else if (arg != null)
                return arg.ToString();
            else
                return String.Empty;
        }


    }
}
